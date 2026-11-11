using System.Globalization;
using ClientRelationships.Expressions;
using ClientRelationships.Filtering;

namespace ClientRelationships.Fields;

public enum FieldDataType
{
    String,
    Date,
    Integer
}

/// <summary>
/// Абстрактное поле представления фирмы.
/// Конкретное поле само определяет тип создаваемого правила фильтрации.
/// </summary>
public abstract class Field
{
    private static readonly IReadOnlyList<LogExpEnum> StringOperations = Array.AsReadOnly(
        new[] { LogExpEnum.EQ, LogExpEnum.NoEQ, LogExpEnum.Contains, LogExpEnum.NoContains });

    private static readonly IReadOnlyList<LogExpEnum> ScalarOperations = Array.AsReadOnly(
        new[] { LogExpEnum.EQ, LogExpEnum.NoEQ, LogExpEnum.LT, LogExpEnum.LE, LogExpEnum.GT, LogExpEnum.GE });

    protected Field(string id, string name, FieldDataType dataType)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Идентификатор поля не задан.", nameof(id));
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название поля не задано.", nameof(name));

        Id = id;
        Name = name;
        DataType = dataType;
    }

    public string Id { get; }
    public string Name { get; }
    public FieldDataType DataType { get; }

    /// <summary>Операции, допустимые для данного типа поля.</summary>
    public IReadOnlyList<LogExpEnum> SupportedOperations =>
        DataType == FieldDataType.String ? StringOperations : ScalarOperations;

    public abstract object GetRawValue(Firm firm);

    public virtual string GetValue(Firm firm)
    {
        var value = GetRawValue(firm);
        return value switch
        {
            null => string.Empty,
            DateTime date => date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
            _ => Convert.ToString(value, CultureInfo.CurrentCulture) ?? string.Empty
        };
    }

    /// <summary>
    /// Создаёт типизированное правило. Реализация находится в конкретном поле,
    /// поэтому базовый класс не зависит от списка идентификаторов полей.
    /// </summary>
    public abstract FilterRule CreateRule(FilterCondition condition);

    protected FilterCondition ValidateCondition(FilterCondition condition)
    {
        ArgumentNullException.ThrowIfNull(condition);

        if (!string.Equals(condition.FieldId, Id, StringComparison.Ordinal))
        {
            throw new ArgumentException(
                $"Условие фильтрации относится к полю '{condition.FieldId}', а не к '{Id}'.",
                nameof(condition));
        }

        return condition;
    }

    public abstract Field Clone();

    public override string ToString() => Name;
}
