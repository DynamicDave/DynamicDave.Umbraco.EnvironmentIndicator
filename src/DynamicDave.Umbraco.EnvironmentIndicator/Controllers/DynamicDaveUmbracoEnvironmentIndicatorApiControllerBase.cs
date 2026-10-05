using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Api.Common.Attributes;
using Umbraco.Cms.Web.Common.Authorization;
using Umbraco.Cms.Web.Common.Routing;

namespace DynamicDave.Umbraco.EnvironmentIndicator.Controllers
{
    [ApiController]
    [BackOfficeRoute("dynamicdave-environment/api/v{version:apiVersion}")]
    [Authorize(Policy = AuthorizationPolicies.BackOfficeAccess)]
    [MapToApi(Constants.ApiName)]
    public class DynamicDaveUmbracoEnvironmentIndicatorApiControllerBase : ControllerBase
    {
    }
}
