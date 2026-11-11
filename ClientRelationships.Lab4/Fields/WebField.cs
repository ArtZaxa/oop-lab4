using ClientRelationships.Filtering;

namespace ClientRelationships.Fields;
public sealed class WebField : Field
{
    public WebField() : base("Web", "Сайт", FieldDataType.String) { }
    public override object GetRawValue(Firm firm) => firm?.Web;
    public override FilterRule CreateRule(FilterCondition condition)
    {
        condition = ValidateCondition(condition);
        return new WebRule(this, condition.Operation, condition.Value);
    }

    public override Field Clone() => new WebField();
}
