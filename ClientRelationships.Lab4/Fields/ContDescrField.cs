using ClientRelationships.Filtering;

namespace ClientRelationships.Fields;
public sealed class ContDescrField : Field
{
    public ContDescrField() : base("ContDescr", "Описание последнего контакта", FieldDataType.String) { }
    public override object GetRawValue(Firm firm) => ContactFieldHelper.LastMainContact(firm)?.Descr;
    public override FilterRule CreateRule(FilterCondition condition)
    {
        condition = ValidateCondition(condition);
        return new ContDescrRule(this, condition.Operation, condition.Value);
    }

    public override Field Clone() => new ContDescrField();
}
