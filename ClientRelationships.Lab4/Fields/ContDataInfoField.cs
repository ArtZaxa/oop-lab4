using ClientRelationships.Filtering;

namespace ClientRelationships.Fields;
public sealed class ContDataInfoField : Field
{
    public ContDataInfoField() : base("ContDataInfo", "Информация о последнем контакте", FieldDataType.String) { }
    public override object GetRawValue(Firm firm) => ContactFieldHelper.LastMainContact(firm)?.DataInfo;
    public override FilterRule CreateRule(FilterCondition condition)
    {
        condition = ValidateCondition(condition);
        return new ContDataInfoRule(this, condition.Operation, condition.Value);
    }

    public override Field Clone() => new ContDataInfoField();
}
