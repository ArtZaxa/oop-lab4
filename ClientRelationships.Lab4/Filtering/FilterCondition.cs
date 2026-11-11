using ClientRelationships.Expressions;

namespace ClientRelationships.Filtering;

/// <summary>Условие, передаваемое формой фильтра контроллеру.</summary>
public sealed class FilterCondition
{
    public string FieldId { get; }
    public LogExpEnum Operation { get; }
    public string Value { get; }

    public FilterCondition(string fieldId, LogExpEnum operation, string value)
    {
        if (string.IsNullOrWhiteSpace(fieldId))
            throw new ArgumentException("Не задан идентификатор поля фильтрации.", nameof(fieldId));
        if (!Enum.IsDefined(typeof(LogExpEnum), operation))
            throw new ArgumentOutOfRangeException(nameof(operation), operation, "Неизвестная операция фильтрации.");

        FieldId = fieldId;
        Operation = operation;
        Value = value ?? string.Empty;
    }
}
