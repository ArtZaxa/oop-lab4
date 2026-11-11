namespace ClientRelationships.Expressions;

public sealed class StrFieldExpr
{
    private readonly ILogExp<string> _expression;
    private readonly string _expected;

    public StrFieldExpr(ILogExp<string> expression, string expected)
    {
        _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        _expected = expected ?? string.Empty;
    }

    public bool Compare(string actual) => _expression.Compare(actual ?? string.Empty, _expected);
}
