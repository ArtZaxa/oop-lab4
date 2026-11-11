using ClientRelationships.Filtering;

namespace ClientRelationships.Fields;
public sealed class NameField : Field
{
    public NameField() : base("Name", "Название фирмы", FieldDataType.String) { }
    public override object GetRawValue(Firm firm) => firm?.Name;
    public override FilterRule CreateRule(FilterCondition condition)
    {
        condition = ValidateCondition(condition);
        return new NameRule(this, condition.Operation, condition.Value);
    }

    public override Field Clone() => new NameField();
}
