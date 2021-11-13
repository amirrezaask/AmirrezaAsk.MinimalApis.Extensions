[![AmirrezaAsk.MinimalApis.Extensions](https://img.shields.io/nuget/v/AmirrezaAsk.MinimalApis.Extensions)](https://www.nuget.org/packages/AmirrezaAsk.MinimalApis.Extensions/)
# AmirrezaAsk.MinimalApis.Extensions
Set of extension method and helper types to help you with new MinimalApis in aspnetcore6.

## Configurations
You have a class like this to store part of your app configuration in it. If you add `Configuration` attribute to your class called with 
the key of the section in appsettings file, extension method `WantConfigurations` will register all of these configuration classes
in DI as singletong and `GetConfigurationOf<T>` of will create a new instance of configuration class for you.
```csharp
[Configuration("Jwt")]
public class JwtConfigurations
{
    public string Secret { get; set; }
    public TimeSpan ExpiresIn { get; set;  }
}

// Registering it inside DI
WebApplication
    .CreateBuilder(args)
    .WantConfigurations();


// Getting a fresh instance from IConfiguration (for times that the DI is not built yet.)
builder.Configuration.GetConfigurationOf<JwtConfigurations>().Secret
```
## Endpoints
Minimal Apis introduce a new simpler way of defining endpoints instead of controller classes, using `map` methods on `WebApplication` class. But in 
larger applications you probably need a standard way of defining them so here comes the `IEndpointDefinition`. It's a C# interface and it's fairly
simple
```csharp
public interface IEndpointDefinition
{
    WebApplication Map(string prefix, WebApplication app);
}
```
It only has one method, and it's for registering endpoints and their respective delegate. forexample
```csharp
public class HelloHandler : IEndpointDefinition
{
    public static IResult HelloWorld() => Results.Ok("hello world");
    public WebApplication Map(string prefix, WebApplication app)
    {
        app.MapGet($"{prefix}/hello/world", HelloWorld);
        return app;
    }
}
```
## Results