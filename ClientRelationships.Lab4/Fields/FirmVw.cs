namespace ClientRelationships.Fields;

public sealed class FirmVw
{
    private readonly List<Field> _fields;
    public IReadOnlyList<Field> Fields => _fields.AsReadOnly();

    public FirmVw(IEnumerable<Field> fields)
    {
        _fields = (fields ?? Enumerable.Empty<Field>()).Select(f => f.Clone()).ToList();
    }

    public Field FindField(string id) => _fields.FirstOrDefault(f => f.Id == id)
        ?? throw new KeyNotFoundException("Поле представления не найдено: " + id);

    public string[] GetValues(Firm firm) => _fields.Select(f => f.GetValue(firm)).ToArray();
    public FirmVw Clone() => new(_fields);

    public void SetFields(IEnumerable<Field> fields)
    {
        _fields.Clear();
        _fields.AddRange((fields ?? Enumerable.Empty<Field>()).Select(f => f.Clone()));
    }
}
