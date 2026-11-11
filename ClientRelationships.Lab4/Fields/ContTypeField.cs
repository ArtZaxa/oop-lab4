using ClientRelationships.Filtering;

namespace ClientRelationships.Fields;
public sealed class ContTypeField : Field
{
    public ContTypeField() : base("ContType", "Тип последнего контакта", FieldDataType.String) { }
    public override object GetRawValue(Firm firm) => ContactFieldHelper.LastMainContact(firm)?.CntType?.Name;
    public override FilterRule CreateRule(FilterCondition condition)
    {
        condition = ValidateCondition(condition);
        return new ContTypeRule(this, condition.Operation, condition.Value);
    }

    public override Field Clone() => new ContTypeField();
}
