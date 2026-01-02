namespace QB.SDK;

internal static class XElementExtensions
{
    public static XElement Append(this XElement element, string? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XElement(name, value));
        }
        return element;
    }
    public static XElement Append(this XElement element, int? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XElement(name, value));
        }
        return element;
    }
    public static XElement Append(this XElement element, DateTime? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XElement(name, value.Value.ToString("yyyy-MM-ddTHH:mm:ss")));
        }
        return element;
    }
    public static XElement Append(this XElement element, DateOnly? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XElement(name, value.Value.ToString("yyyy-MM-dd")));
        }
        return element;
    }
    public static XElement Append(this XElement element, bool? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XElement(name, value.Value ? "true" : "false"));
        }
        return element;
    }
    public static XElement Append(this XElement element, float? value, int decimalPlaces = 5, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XElement(name, value.Value.ToString($"F{decimalPlaces}")));
        }
        return element;
    }
    public static XElement Append(this XElement element, decimal? value, int decimalPlaces = 2, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XElement(name, value.Value.ToString($"F{decimalPlaces}")));
        }
        return element;
    }
    public static XElement Append<T>(this XElement element, T value, [CallerArgumentExpression(nameof(value))] string name = "") where T : struct, Enum
    {
        element.Add(new XElement(name, value.ToString()));
        return element;
    }
    public static XElement Append<T>(this XElement element, T? value, [CallerArgumentExpression(nameof(value))] string name = "") where T : struct, Enum
    {
        if (value != null)
        {
            element.Add(new XElement(name, value.ToString()));
        }
        return element;
    }
    public static XElement Append(this XElement element, List<string>? values, [CallerArgumentExpression(nameof(values))] string name = "")
    {
        if (values != null)
        {
            foreach (var value in values)
            {
                element.Add(new XElement(name, value));
            }
        }
        return element;
    }
    public static XElement Append(this XElement element, XElement? value)
    {
        if (value != null)
        {
            element.Add(value);
        }
        return element;
    }
    public static XElement Append(this XElement element, IQBXML? value)
    {
        if (value != null)
        {
            element.Add(value.ToQBXML());
        }
        return element;
    }

    public static XElement AppendAttribute(this XElement element, string? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XAttribute(name, value));
        }
        return element;
    }
    public static XElement AppendAttribute<T>(this XElement element, T? value, [CallerArgumentExpression(nameof(value))] string name = "") where T : struct, Enum
    {
        if (value != null)
        {
            element.Add(new XAttribute(name, value));
        }
        return element;
    }
}
