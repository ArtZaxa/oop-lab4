using ClientRelationships.Expressions;
using ClientRelationships.Fields;

namespace ClientRelationships.Filtering;

/// <summary>Базовый класс правила фильтрации одной фирмы.</summary>
public abstract class FilterRule
{
    protected FilterRule(Field field, LogExpEnum operation, string value)
    {
        Field = field ?? throw new ArgumentNullException(nameof(field));
        if (!Enum.IsDefined(typeof(LogExpEnum), operation))
            throw new ArgumentOutOfRangeException(nameof(operation), operation, "Неизвестная операция фильтрации.");

        Operation = operation;
        Value = value ?? string.Empty;
    }

    public Field Field { get; }
    public LogExpEnum Operation { get; }
    public string Value { get; }

    public abstract bool IsMatch(Firm firm);
}
