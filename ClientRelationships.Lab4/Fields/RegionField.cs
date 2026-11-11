using ClientRelationships.Filtering;

namespace ClientRelationships.Fields;
public sealed class RegionField : Field
{
    public RegionField() : base("Region", "Регион", FieldDataType.String) { }
    public override object GetRawValue(Firm firm) => firm?.Region;
    public override FilterRule CreateRule(FilterCondition condition)
    {
        condition = ValidateCondition(condition);
        return new RegionRule(this, condition.Operation, condition.Value);
    }

    public override Field Clone() => new RegionField();
}
