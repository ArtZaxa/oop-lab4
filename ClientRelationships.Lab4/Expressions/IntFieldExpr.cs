namespace ClientRelationships.Expressions;

public sealed class IntFieldExpr
{
    private readonly ILogExp<int> _expression;
    private readonly int _expected;

    public IntFieldExpr(ILogExp<int> expression, int expected)
    {
        _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        _expected = expected;
    }

    public bool Compare(int actual) => _expression.Compare(actual, _expected);
}
