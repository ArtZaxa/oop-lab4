using System.Globalization;
using ClientRelationships.Expressions;
using ClientRelationships.Fields;

namespace ClientRelationships.Filtering;

public class DateFieldRule : FilterRule
{
    private readonly DateFieldExpr _expression;

    public DateFieldRule(Field field, LogExpEnum operation, string value)
        : base(field, operation, value)
    {
        if (field.DataType != FieldDataType.Date)
            throw new ArgumentException($"Поле «{field.Name}» не является полем даты.", nameof(field));

        if (!field.SupportedOperations.Contains(operation))
            throw new ArgumentException($"Операция «{operation}» недоступна для поля «{field.Name}».", nameof(operation));

        if (!DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out var expected))
        {
            throw new FormatException($"Для поля «{field.Name}» введите дату в формате ГГГГ-ММ-ДД; время необязательно.");
        }

        _expression = new DateFieldExpr(LogExpFactory.Create<DateTime>(operation), expected);
    }

    public override bool IsMatch(Firm firm)
    {
        var raw = Field.GetRawValue(firm);
        if (raw == null) return false;

        var actual = raw is DateTime date
            ? date
            : Convert.ToDateTime(raw, CultureInfo.InvariantCulture);

        return _expression.Compare(actual);
    }
}
