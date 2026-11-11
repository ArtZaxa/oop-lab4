using ClientRelationships.Filtering;

namespace ClientRelationships.Fields;
public sealed class StreetField : Field
{
    public StreetField() : base("Street", "Улица", FieldDataType.String) { }
    public override object GetRawValue(Firm firm) => firm?.Street;
    public override FilterRule CreateRule(FilterCondition condition)
    {
        condition = ValidateCondition(condition);
        return new StreetRule(this, condition.Operation, condition.Value);
    }

    public override Field Clone() => new StreetField();
}
