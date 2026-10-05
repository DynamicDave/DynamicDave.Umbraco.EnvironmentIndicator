using DynamicDave.Umbraco.EnvironmentIndicator.Configuration;
using DynamicDave.Umbraco.EnvironmentIndicator.Services;
using Xunit;

namespace DynamicDave.Umbraco.Tests;

public class EnvironmentResolverTests
{
    private static readonly EnvironmentIndicatorOptions Defaults = new();

    [Theory]
    [InlineData("Development", "LOCAL")]
    [InlineData("Local", "LOCAL")]
    [InlineData("Staging", "ACCEPTANCE/STAGING")]
    [InlineData("Acceptance", "ACCEPTANCE/STAGING")]
    [InlineData("Production", "PRODUCTION")]
    public void Known_environments_get_default_labels(string env, string label)
        => Assert.Equal(label, EnvironmentResolver.Resolve(env, "x.nl", Defaults, "17.0.0").Label);

    [Fact]
    public void Environment_name_is_case_insensitive()
        => Assert.Equal("PRODUCTION", EnvironmentResolver.Resolve("production", null, Defaults, "17.0.0").Label);

    [Fact]
    public void Production_is_red_and_development_is_green()
    {
        Assert.Equal("#c62828", EnvironmentResolver.Resolve("Production", null, Defaults, "1").Color);
        Assert.Equal("#2e9e4f", EnvironmentResolver.Resolve("Development", null, Defaults, "1").Color);
    }

    [Fact]
    public void Unknown_environment_uses_uppercased_name_and_neutral_color()
    {
        var info = EnvironmentResolver.Resolve("qa", null, Defaults, "1");
        Assert.Equal("QA", info.Label);
        Assert.Equal("#607d8b", info.Color);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Empty_environment_name_falls_back_to_unknown(string? env)
        => Assert.Equal("UNKNOWN", EnvironmentResolver.Resolve(env, null, Defaults, "1").Label);

    [Fact]
    public void Configuration_overrides_defaults()
    {
        var options = new EnvironmentIndicatorOptions();
        options.Environments["Production"] = new EnvironmentStyle { Label = "LIVE", Color = "#000000" };
        var info = EnvironmentResolver.Resolve("Production", null, options, "1");
        Assert.Equal("LIVE", info.Label);
        Assert.Equal("#000000", info.Color);
    }

    [Fact]
    public void Host_is_hidden_when_ShowHost_is_false()
    {
        var options = new EnvironmentIndicatorOptions { ShowHost = false };
        Assert.Null(EnvironmentResolver.Resolve("Production", "www.klant.nl", options, "1").Host);
        Assert.Equal("www.klant.nl", EnvironmentResolver.Resolve("Production", "www.klant.nl", Defaults, "1").Host);
    }
}
