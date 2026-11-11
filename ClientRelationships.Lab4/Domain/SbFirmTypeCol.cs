using System.Collections;

namespace ClientRelationships;

// Коллекция типов подразделений. Каждый GetEnumerator возвращает независимый перечислитель.
public class SbFirmTypeCol : IEnumerable<SbFirmType>
{
    private readonly List<SbFirmType> _list = new();
    public int Count => _list.Count;
    public SbFirmType this[int index] { get => _list[index]; set => _list[index] = value; }
    public void Add(SbFirmType type) => _list.Add(type ?? throw new ArgumentNullException(nameof(type)));
    public IEnumerator<SbFirmType> GetEnumerator() => _list.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
