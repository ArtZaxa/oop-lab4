using ClientRelationships.Filtering;

namespace ClientRelationships.Fields;
public sealed class DateBegField : Field
{
    public DateBegField() : base("DateBeg", "Дата начала контакта", FieldDataType.Date) { }
    public override object GetRawValue(Firm firm) => ContactFieldHelper.LastMainContact(firm)?.BeginDt;
    public override FilterRule CreateRule(FilterCondition condition)
    {
        condition = ValidateCondition(condition);
        return new DateBegRule(this, condition.Operation, condition.Value);
    }

    public override Field Clone() => new DateBegField();
}
