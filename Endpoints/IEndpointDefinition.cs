using Microsoft.AspNetCore.Builder;

namespace AmirrezaAsk.MinimalApis.Extensions.Endpoints;

public interface IEndpointDefinition
{
    WebApplication Map(string prefix, WebApplication app);
}
