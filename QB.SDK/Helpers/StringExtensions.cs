using System.Diagnostics.CodeAnalysis;

namespace QB.SDK;

public static class StringExtensions
{
    public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value) => string.IsNullOrWhiteSpace(value);
    public static bool IsNotNullOrWhiteSpace([NotNullWhen(true)] this string? value) => !string.IsNullOrWhiteSpace(value);
    public static void ThrowIfNullOrWhiteSpace([NotNull] this string? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{name} can not be null or empty.");
        }
    }
}
