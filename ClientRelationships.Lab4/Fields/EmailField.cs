using ClientRelationships.Filtering;

namespace ClientRelationships.Fields;
public sealed class EmailField : Field
{
    public EmailField() : base("Email", "Электронная почта", FieldDataType.String) { }
    public override object GetRawValue(Firm firm) => firm?.Email;
    public override FilterRule CreateRule(FilterCondition condition)
    {
        condition = ValidateCondition(condition);
        return new EmailRule(this, condition.Operation, condition.Value);
    }

    public override Field Clone() => new EmailField();
}
