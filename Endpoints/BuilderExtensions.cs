using Microsoft.AspNetCore.Builder;
using System.Reflection;

namespace AmirrezaAsk.MinimalApis.Extensions.Endpoints;

public static class BuilderExtensions
{
    public static WebApplication MapAPIs(this WebApplication app, string prefix)
    {
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetInterfaces().Contains(typeof(IEndpointDefinition)))
                {
                    var h = (IEndpointDefinition)Activator.CreateInstance(type);
                    h.Map(prefix, app);
                }
            }
        }
        return app;
    }
}
