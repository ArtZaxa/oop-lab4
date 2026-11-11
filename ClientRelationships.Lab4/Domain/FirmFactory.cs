namespace ClientRelationships;

// Singleton-фабрика из лабораторной №3. Она знает имена пяти пользовательских полей.
public class FirmFactory
{
    private static FirmFactory _instance;
    public List<string> flds = new() { "Поле1", "Поле2", "Поле3", "Поле4", "Поле5" };
    public SbFirmType NameMain { get; }

    public static FirmFactory Instance(SbFirmType mainType)
    {
        if (mainType == null || !mainType.IsMain)
            throw new ArgumentException("FirmFactory требует тип основного подразделения.", nameof(mainType));
        return _instance ??= new FirmFactory(mainType);
    }

    private FirmFactory(SbFirmType mainType) { NameMain = mainType; }

    public Firm Create(string name)
    {
        var firm = new Firm(NameMain)
        {
            Name = name ?? string.Empty,
            DateIn = DateTime.Now
        };
        foreach (var fieldName in flds.Take(5))
            firm.SetField(fieldName, string.Empty);
        return firm;
    }

    public List<string> fldNames() => flds;
}
