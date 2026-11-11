namespace ClientRelationships;

public class Firm
{
    private string _country;
    private DateTime _dateIn;
    private string _email;
    private string _name;
    private string _postInx;
    private string _region;
    private string _town;
    private string _street;
    private string _web;
    private readonly List<SubFirm> _sbFirms = new();
    private readonly Dictionary<string, string> _usrFields = new();

    public string Name { get => _name; set => _name = value; }
    public string Country { get => _country; set => _country = value; }
    public string Region { get => _region; set => _region = value; }
    public string Town { get => _town; set => _town = value; }
    public string Street { get => _street; set => _street = value; }
    public string PostInx { get => _postInx; set => _postInx = value; }
    public DateTime DateIn { get => _dateIn; set => _dateIn = value; }
    public string Email { get => _email; set => _email = value; }
    public string Web { get => _web; set => _web = value; }
    public int SbFirmsCount => _sbFirms.Count;
    public int ContactsCount => _sbFirms.Sum(sf => sf.CountCont);
    public IReadOnlyList<SubFirm> SubFirms => _sbFirms.AsReadOnly();
    public IReadOnlyDictionary<string, string> UserFields => _usrFields;
    public IReadOnlyList<Contact> MainContacts => GetMain().Contacts;

    public Firm(SbFirmType mainType)
    {
        if (mainType == null || !mainType.IsMain)
            throw new ArgumentException("Необходимо передать тип основного подразделения.", nameof(mainType));
        _sbFirms.Add(new SubFirm("Основное подразделение", mainType));
    }

    public void AddSbFirm(SubFirm sf)
    {
        if (sf == null || string.IsNullOrWhiteSpace(sf.Name) || sf.SbFirmTyp == null)
            throw new ArgumentException("Неверные данные подразделения.", nameof(sf));
        if (_sbFirms.Any(s => s.Name == sf.Name || s.IsYourType(sf.SbFirmTyp)))
            throw new InvalidOperationException("Подразделение с таким типом или именем уже существует.");
        _sbFirms.Add(sf);
    }

    public SubFirm GetMain() => _sbFirms.First(s => s.IsMain);
    public SubFirm GetSubFirmByName(string name) => _sbFirms.FirstOrDefault(sf => sf.Name == name);
    public SubFirm GetSubFirmByType(SbFirmType type) => _sbFirms.FirstOrDefault(sf => sf.IsYourType(type));

    public void AddContact(Contact contact) => GetMain().AddCont(contact);
    public void ReplaceMainContacts(IEnumerable<Contact> contacts) => GetMain().ReplaceContacts(contacts);
    public void UpdateMainContact(int index, Contact contact) => GetMain().UpdateContact(index, contact);
    public void RemoveMainContactAt(int index) => GetMain().RemoveContactAt(index);

    public void AddContactToSbFirm(Contact contact, string sbFirmName)
    {
        var sf = GetSubFirmByName(sbFirmName);
        if (sf == null) throw new InvalidOperationException("Подразделение не найдено: " + sbFirmName);
        sf.AddCont(contact);
    }

    public List<Contact> GetContact(Contact contact) =>
        _sbFirms.Select(sf => sf.GetContact(contact)).Where(c => c != null).ToList();

    public List<Contact> GetContactByType(ContType type) =>
        _sbFirms.SelectMany(sf => sf.GetContactByType(type)).ToList();

    public bool ExistContact(Contact contact) => _sbFirms.Any(sf => sf.ExistContact(contact));

    public void AddField(string fieldName)
    {
        if (string.IsNullOrWhiteSpace(fieldName)) throw new ArgumentException("Название поля не задано.");
        if (_usrFields.ContainsKey(fieldName)) return;
        if (_usrFields.Count >= 5) throw new InvalidOperationException("Нельзя добавить больше пяти пользовательских полей.");
        _usrFields[fieldName] = string.Empty;
    }

    public string GetField(string fieldName) =>
        _usrFields.TryGetValue(fieldName, out var value) ? value : throw new KeyNotFoundException("Нет пользовательского поля: " + fieldName);

    public void SetField(string fieldName, string value)
    {
        if (!_usrFields.ContainsKey(fieldName) && _usrFields.Count >= 5)
            throw new InvalidOperationException("Такого пользовательского поля нет.");
        _usrFields[fieldName] = value ?? string.Empty;
    }

    public void RenameField(string oldName, string newName)
    {
        if (!_usrFields.ContainsKey(oldName)) throw new KeyNotFoundException("Старое поле не найдено.");
        if (string.IsNullOrWhiteSpace(newName) || (_usrFields.ContainsKey(newName) && newName != oldName))
            throw new InvalidOperationException("Новое название поля недопустимо или уже занято.");
        var value = _usrFields[oldName];
        _usrFields.Remove(oldName);
        _usrFields[newName] = value;
    }

    public override string ToString() => $"{_name} ({_town})";
}
