using ClientRelationships.Filtering;

namespace ClientRelationships.Fields;
public sealed class UsrField : Field
{
    public string FieldName { get; }
    public UsrField(string fieldName) : base("Usr:" + fieldName, fieldName, FieldDataType.String)
    {
        FieldName = fieldName;
    }
    public override object GetRawValue(Firm firm)
    {
        if (firm == null || !firm.UserFields.ContainsKey(FieldName)) return null;
        return firm.UserFields[FieldName];
    }
    public override FilterRule CreateRule(FilterCondition condition)
    {
        condition = ValidateCondition(condition);
        return new UsrFieldRule(this, condition.Operation, condition.Value);
    }

    public override Field Clone() => new UsrField(FieldName);
}
