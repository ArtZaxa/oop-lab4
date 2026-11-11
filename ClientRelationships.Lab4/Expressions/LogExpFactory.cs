namespace ClientRelationships.Expressions;

/// <summary>
/// Фабрика логических выражений. Тип T задаётся вызывающим типизированным
/// выражением: string, DateTime или int.
/// </summary>
public static class LogExpFactory
{
    public static ILogExp<T> Create<T>(LogExpEnum type) => type switch
    {
        LogExpEnum.EQ => new EqualExpression<T>(),
        LogExpEnum.NoEQ => new NotEqualExpression<T>(),
        LogExpEnum.LT => new LessThanExpression<T>(),
        LogExpEnum.LE => new LessThanOrEqualExpression<T>(),
        LogExpEnum.GT => new GreaterThanExpression<T>(),
        LogExpEnum.GE => new GreaterThanOrEqualExpression<T>(),
        LogExpEnum.Contains => CreateContains<T>(negate: false),
        LogExpEnum.NoContains => CreateContains<T>(negate: true),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Неизвестная операция сравнения.")
    };

    private static ILogExp<T> CreateContains<T>(bool negate)
    {
        if (typeof(T) != typeof(string))
        {
            throw new NotSupportedException("Операции «Содержит» и «Не содержит» доступны только для строк.");
        }

        return (ILogExp<T>)(object)new ContainsExpression(negate);
    }

    private static bool AreEqual<T>(T left, T right)
    {
        if (left is string leftText && right is string rightText)
        {
            return StringComparer.CurrentCultureIgnoreCase.Equals(leftText, rightText);
        }

        return EqualityComparer<T>.Default.Equals(left, right);
    }

    private static int CompareValues<T>(T left, T right)
    {
        if (left is null || right is null)
        {
            throw new ArgumentNullException("Операция сравнения получила пустое значение.");
        }

        if (left is string leftText && right is string rightText)
        {
            return StringComparer.CurrentCultureIgnoreCase.Compare(leftText, rightText);
        }

        return Comparer<T>.Default.Compare(left, right);
    }

    private sealed class EqualExpression<T> : ILogExp<T>
    {
        public bool Compare(T left, T right) => AreEqual(left, right);
    }

    private sealed class NotEqualExpression<T> : ILogExp<T>
    {
        public bool Compare(T left, T right) => !AreEqual(left, right);
    }

    private sealed class LessThanExpression<T> : ILogExp<T>
    {
        public bool Compare(T left, T right) => CompareValues(left, right) < 0;
    }

    private sealed class LessThanOrEqualExpression<T> : ILogExp<T>
    {
        public bool Compare(T left, T right) => CompareValues(left, right) <= 0;
    }

    private sealed class GreaterThanExpression<T> : ILogExp<T>
    {
        public bool Compare(T left, T right) => CompareValues(left, right) > 0;
    }

    private sealed class GreaterThanOrEqualExpression<T> : ILogExp<T>
    {
        public bool Compare(T left, T right) => CompareValues(left, right) >= 0;
    }

    private sealed class ContainsExpression : ILogExp<string>
    {
        private readonly bool _negate;

        public ContainsExpression(bool negate) => _negate = negate;

        public bool Compare(string left, string right)
        {
            var contains = (left ?? string.Empty).IndexOf(
                right ?? string.Empty,
                StringComparison.CurrentCultureIgnoreCase) >= 0;

            return _negate ? !contains : contains;
        }
    }
}
