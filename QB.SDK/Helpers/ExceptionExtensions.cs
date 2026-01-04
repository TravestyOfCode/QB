namespace QB.SDK;

public static class ExceptionExtensions
{
    public static void ExclusiveThrow<T>(this T? value, string property, [CallerArgumentExpression(nameof(value))] string source = "")
    {
        if (value != null)
        {
            throw new InvalidOperationException($"Unable to set value to {property} while {source} has a non-null value.");
        }
    }
}
