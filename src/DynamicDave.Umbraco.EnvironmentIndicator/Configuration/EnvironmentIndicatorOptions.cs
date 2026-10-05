namespace DynamicDave.Umbraco.EnvironmentIndicator.Configuration;

public sealed class EnvironmentIndicatorOptions
{
    public const string SectionName = "DynamicDave:EnvironmentIndicator";

    public bool ShowHost { get; set; } = true;

    public Dictionary<string, EnvironmentStyle> Environments { get; set; } = new(StringComparer.OrdinalIgnoreCase);
}

public sealed class EnvironmentStyle
{
    public string Label { get; set; } = string.Empty;
    public string Color { get; set; } = "#607d8b";
}
