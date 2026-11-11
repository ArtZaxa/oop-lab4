using ClientRelationships.Filtering;

namespace ClientRelationships.Fields;
public sealed class PostInxField : Field
{
    public PostInxField() : base("PostInx", "Индекс", FieldDataType.String) { }
    public override object GetRawValue(Firm firm) => firm?.PostInx;
    public override FilterRule CreateRule(FilterCondition condition)
    {
        condition = ValidateCondition(condition);
        return new PostInxRule(this, condition.Operation, condition.Value);
    }

    public override Field Clone() => new PostInxField();
}
