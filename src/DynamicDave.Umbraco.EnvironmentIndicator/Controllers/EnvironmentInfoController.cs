using Asp.Versioning;
using DynamicDave.Umbraco.EnvironmentIndicator.Configuration;
using DynamicDave.Umbraco.EnvironmentIndicator.Models;
using DynamicDave.Umbraco.EnvironmentIndicator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Configuration;
using Umbraco.Extensions;

namespace DynamicDave.Umbraco.EnvironmentIndicator.Controllers;

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "EnvironmentInfo")]
public class EnvironmentInfoController(
    IHostEnvironment hostEnvironment,
    IOptionsSnapshot<EnvironmentIndicatorOptions> options,
    IUmbracoVersion umbracoVersion) : DynamicDaveUmbracoEnvironmentIndicatorApiControllerBase
{
    [HttpGet("info", Name = "GetEnvironmentInfo")]
    [ProducesResponseType<EnvironmentInfoModel>(StatusCodes.Status200OK)]
    public IActionResult GetEnvironmentInfo()
        => Ok(EnvironmentResolver.Resolve(
            hostEnvironment.EnvironmentName,
            Request.Host.Host,
            options.Value,
            umbracoVersion.SemanticVersion.ToSemanticStringWithoutBuild()));
}
