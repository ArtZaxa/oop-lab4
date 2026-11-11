using ClientRelationships.Filtering;

namespace ClientRelationships.Fields;
public sealed class CountryField : Field
{
    public CountryField() : base("Country", "Страна", FieldDataType.String) { }
    public override object GetRawValue(Firm firm) => firm?.Country;
    public override FilterRule CreateRule(FilterCondition condition)
    {
        condition = ValidateCondition(condition);
        return new CountryRule(this, condition.Operation, condition.Value);
    }

    public override Field Clone() => new CountryField();
}
