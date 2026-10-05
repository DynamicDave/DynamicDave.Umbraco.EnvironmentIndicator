namespace DynamicDave.Umbraco.EnvironmentIndicator.Models;

public sealed class EnvironmentInfoModel
{
    public required string EnvironmentName { get; init; }
    public required string Label { get; init; }
    public required string Color { get; init; }
    public string? Host { get; init; }
    public required string UmbracoVersion { get; init; }
}
