using ClientRelationships.Filtering;

namespace ClientRelationships.Fields;
public sealed class CountContField : Field
{
    public CountContField() : base("CountCont", "Количество контактов", FieldDataType.Integer) { }
    public override object GetRawValue(Firm firm) => firm?.ContactsCount;
    public override FilterRule CreateRule(FilterCondition condition)
    {
        condition = ValidateCondition(condition);
        return new ContCountRule(this, condition.Operation, condition.Value);
    }

    public override Field Clone() => new CountContField();
}
