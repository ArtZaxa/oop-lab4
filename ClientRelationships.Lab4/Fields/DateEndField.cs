using ClientRelationships.Filtering;

namespace ClientRelationships.Fields;
public sealed class DateEndField : Field
{
    public DateEndField() : base("DateEnd", "Дата завершения контакта", FieldDataType.Date) { }
    public override object GetRawValue(Firm firm) => ContactFieldHelper.LastMainContact(firm)?.EndDt;
    public override FilterRule CreateRule(FilterCondition condition)
    {
        condition = ValidateCondition(condition);
        return new DateEndRule(this, condition.Operation, condition.Value);
    }

    public override Field Clone() => new DateEndField();
}
