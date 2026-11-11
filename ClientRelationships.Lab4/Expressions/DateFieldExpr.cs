namespace ClientRelationships.Expressions;

public sealed class DateFieldExpr
{
    private readonly ILogExp<DateTime> _expression;
    private readonly DateTime _expected;

    public DateFieldExpr(ILogExp<DateTime> expression, DateTime expected)
    {
        _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        _expected = expected;
    }

    public bool Compare(DateTime actual) => _expression.Compare(actual, _expected);
}
