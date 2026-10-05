using DynamicDave.Umbraco.EnvironmentIndicator.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace DynamicDave.Umbraco.EnvironmentIndicator.Composers;

public class EnvironmentIndicatorComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
        => builder.Services.Configure<EnvironmentIndicatorOptions>(
            builder.Config.GetSection(EnvironmentIndicatorOptions.SectionName));
}
