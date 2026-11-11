using System.Globalization;
using ClientRelationships.Expressions;
using ClientRelationships.Fields;

namespace ClientRelationships.Filtering;

public class IntFieldRule : FilterRule
{
    private readonly IntFieldExpr _expression;

    public IntFieldRule(Field field, LogExpEnum operation, string value)
        : base(field, operation, value)
    {
        if (field.DataType != FieldDataType.Integer)
            throw new ArgumentException($"Поле «{field.Name}» не является целочисленным.", nameof(field));

        if (!field.SupportedOperations.Contains(operation))
            throw new ArgumentException($"Операция «{operation}» недоступна для поля «{field.Name}».", nameof(operation));

        if (!int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var expected))
        {
            throw new FormatException($"Для поля «{field.Name}» необходимо ввести целое число.");
        }

        _expression = new IntFieldExpr(LogExpFactory.Create<int>(operation), expected);
    }

    public override bool IsMatch(Firm firm)
    {
        var raw = Field.GetRawValue(firm);
        if (raw == null) return false;

        var actual = Convert.ToInt32(raw, CultureInfo.InvariantCulture);
        return _expression.Compare(actual);
    }
}
