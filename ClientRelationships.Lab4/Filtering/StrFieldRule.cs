using System.Globalization;
using ClientRelationships.Expressions;
using ClientRelationships.Fields;

namespace ClientRelationships.Filtering;

public class StrFieldRule : FilterRule
{
    private readonly StrFieldExpr _expression;

    public StrFieldRule(Field field, LogExpEnum operation, string value)
        : base(field, operation, value)
    {
        if (field.DataType != FieldDataType.String)
            throw new ArgumentException($"Поле «{field.Name}» не является строковым.", nameof(field));

        if (!field.SupportedOperations.Contains(operation))
            throw new ArgumentException($"Операция «{operation}» недоступна для поля «{field.Name}».", nameof(operation));

        _expression = new StrFieldExpr(LogExpFactory.Create<string>(operation), value);
    }

    public override bool IsMatch(Firm firm)
    {
        var raw = Field.GetRawValue(firm);
        if (raw == null) return false;

        var actual = Convert.ToString(raw, CultureInfo.CurrentCulture) ?? string.Empty;
        return _expression.Compare(actual);
    }
}
