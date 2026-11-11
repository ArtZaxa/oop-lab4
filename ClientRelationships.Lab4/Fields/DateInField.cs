using ClientRelationships.Filtering;

namespace ClientRelationships.Fields;
public sealed class DateInField : Field
{
    public DateInField() : base("DateIn", "Дата ввода фирмы", FieldDataType.Date) { }
    public override object GetRawValue(Firm firm) => firm?.DateIn;
    public override FilterRule CreateRule(FilterCondition condition)
    {
        condition = ValidateCondition(condition);
        return new DateInRule(this, condition.Operation, condition.Value);
    }

    public override Field Clone() => new DateInField();
}
