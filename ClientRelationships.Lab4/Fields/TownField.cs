using ClientRelationships.Filtering;

namespace ClientRelationships.Fields;
public sealed class TownField : Field
{
    public TownField() : base("Town", "Город", FieldDataType.String) { }
    public override object GetRawValue(Firm firm) => firm?.Town;
    public override FilterRule CreateRule(FilterCondition condition)
    {
        condition = ValidateCondition(condition);
        return new TownRule(this, condition.Operation, condition.Value);
    }

    public override Field Clone() => new TownField();
}
