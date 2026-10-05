using DynamicDave.Umbraco.EnvironmentIndicator.Configuration;
using DynamicDave.Umbraco.EnvironmentIndicator.Models;

namespace DynamicDave.Umbraco.EnvironmentIndicator.Services;

internal static class EnvironmentResolver
{
    private const string Neutral = "#607d8b";

    private static readonly Dictionary<string, EnvironmentStyle> Defaults = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Development"] = new() { Label = "LOCAL", Color = "#2e9e4f" },
        ["Local"] = new() { Label = "LOCAL", Color = "#2e9e4f" },
        ["Staging"] = new() { Label = "ACCEPTANCE/STAGING", Color = "#e0a800" },
        ["Acceptance"] = new() { Label = "ACCEPTANCE/STAGING", Color = "#e0a800" },
        ["Production"] = new() { Label = "PRODUCTION", Color = "#c62828" },
    };

    public static EnvironmentInfoModel Resolve(string? environmentName, string? host, EnvironmentIndicatorOptions options, string umbracoVersion)
    {
        var name = string.IsNullOrWhiteSpace(environmentName) ? "UNKNOWN" : environmentName.Trim();

        EnvironmentStyle style;
        if (options.Environments.TryGetValue(name, out var configured))
        {
            style = configured;
        }
        else if (Defaults.TryGetValue(name, out var builtIn))
        {
            style = builtIn;
        }
        else
        {
            style = new EnvironmentStyle { Label = name.ToUpperInvariant(), Color = Neutral };
        }

        return new EnvironmentInfoModel
        {
            EnvironmentName = name,
            Label = string.IsNullOrWhiteSpace(style.Label) ? name.ToUpperInvariant() : style.Label,
            Color = style.Color,
            Host = options.ShowHost ? host : null,
            UmbracoVersion = umbracoVersion,
        };
    }
}
