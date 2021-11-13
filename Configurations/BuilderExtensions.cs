using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AmirrezaAsk.MinimalApis.Extensions.Configurations;

public static class BuilderExtensions
{
    public static WebApplicationBuilder WantConfigurations(this WebApplicationBuilder builder)
    {
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (Type type in assembly.GetTypes())
            {
                var attribs = type.GetCustomAttributes(typeof(ConfigurationAttribute), false);
                if (attribs != null && attribs.Length > 0)
                {
                    var attr = (ConfigurationAttribute)attribs[0];
                    Console.WriteLine(attr.ConfigurationKey);
                    var obj = builder.Configuration.GetSection($"{attr.ConfigurationKey}").Get(type);
                    builder.Services.AddSingleton(type, obj);
                }
            }
        }
        return builder;
    }
    public static T GetConfigurationOf<T>(this IConfiguration configuration)
    {
        var attr = typeof(T).GetCustomAttribute<ConfigurationAttribute>();
        if (attr == null)
        {
            return default;
        }
        return (T)configuration.GetSection(attr.ConfigurationKey).Get(typeof(T));
    }
}
