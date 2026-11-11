namespace ClientRelationships.Expressions;

/// <summary>
/// Строго типизированное логическое выражение сравнения.
/// </summary>
public interface ILogExp<T>
{
    bool Compare(T left, T right);
}
