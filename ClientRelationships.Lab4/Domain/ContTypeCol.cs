using System.Collections;

namespace ClientRelationships;

public class ContTypeCol : IEnumerable<ContType>
{
    private readonly List<ContType> _list = new();
    public int Count => _list.Count;
    public ContType this[int index] { get => _list[index]; set => _list[index] = value; }
    public IReadOnlyList<ContType> Items => _list.AsReadOnly();
    public void Add(ContType type) => _list.Add(type ?? throw new ArgumentNullException(nameof(type)));
    public void Clear() => _list.Clear();
    public IEnumerator<ContType> GetEnumerator() => _list.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
