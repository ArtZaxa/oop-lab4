namespace ClientRelationships;

public class SubFirm
{
    private string _name;
    private string _bossName;
    private string _ofcBossName;
    private string _tel;
    private string _email;
    private SbFirmType _tpy;
    private readonly List<Contact> _conts = new();

    public string Name { get => _name; set => _name = value; }
    public string BossName { get => _bossName; set => _bossName = value; }
    public string OfcBossName { get => _ofcBossName; set => _ofcBossName = value; }
    public string Tel { get => _tel; set => _tel = value; }
    public string Email { get => _email; set => _email = value; }
    public SbFirmType SbFirmTyp { get => _tpy; set => _tpy = value; }
    public int CountCont => _conts.Count;
    public bool IsMain => _tpy != null && _tpy.IsMain;
    public IReadOnlyList<Contact> Contacts => _conts.AsReadOnly();

    public SubFirm() { }
    public SubFirm(string name, SbFirmType type) { _name = name; _tpy = type; }

    public void AddCont(Contact contact)
    {
        if (contact == null) throw new ArgumentNullException(nameof(contact));
        _conts.Add(contact.Clone());
    }

    public void ReplaceContacts(IEnumerable<Contact> contacts)
    {
        _conts.Clear();
        if (contacts == null) return;
        _conts.AddRange(contacts.Where(c => c != null).Select(c => c.Clone()));
    }

    public void UpdateContact(int index, Contact contact)
    {
        if (contact == null) throw new ArgumentNullException(nameof(contact));
        _conts[index] = contact.Clone();
    }

    public void RemoveContactAt(int index) => _conts.RemoveAt(index);
    public bool ExistContact(Contact contact) => _conts.Any(x => x.Equals(contact));
    public Contact GetContact(Contact contact) => _conts.FirstOrDefault(x => x.Equals(contact));
    public List<Contact> GetContactByType(ContType type) => _conts.Where(x => x.CntType == type).ToList();
    public bool IsYourType(SbFirmType type) => _tpy != null && type != null && _tpy == type;
}
