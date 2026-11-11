namespace ClientRelationships;

public class Contact : IEquatable<Contact>
{
    private DateTime _beginDt;
    private DateTime _endDt;
    private string _descr;
    private string _dataInfo;
    private ContType _tpy;

    public DateTime BeginDt { get => _beginDt; set => _beginDt = value; }
    public DateTime EndDt { get => _endDt; set => _endDt = value; }
    public string Descr { get => _descr; set => _descr = value; }
    public string DataInfo { get => _dataInfo; set => _dataInfo = value; }
    public ContType CntType { get => _tpy; set => _tpy = value; }

    public Contact() : this(DateTime.Now, DateTime.Now, string.Empty, string.Empty, null) { }

    public Contact(DateTime beginDt, DateTime endDt, string descr, string dataInfo, ContType type)
    {
        _beginDt = beginDt;
        _endDt = endDt;
        _descr = descr ?? string.Empty;
        _dataInfo = dataInfo ?? string.Empty;
        _tpy = type;
    }

    public Contact Clone() => new(_beginDt, _endDt, _descr, _dataInfo, _tpy);

    public bool Equals(Contact other) => other != null &&
        _beginDt == other._beginDt && _endDt == other._endDt &&
        _descr == other._descr && _dataInfo == other._dataInfo &&
        ((_tpy == null && other._tpy == null) ||
         (_tpy != null && other._tpy != null && _tpy.Name == other._tpy.Name));

    public override bool Equals(object obj) => Equals(obj as Contact);

    public override int GetHashCode() => HashCode.Combine(_beginDt, _endDt, _descr, _dataInfo, _tpy?.Name);

    public static bool operator ==(Contact a, Contact b) =>
        ReferenceEquals(a, b) || ((object)a != null && (object)b != null && a.Equals(b));
    public static bool operator !=(Contact a, Contact b) => !(a == b);
}
