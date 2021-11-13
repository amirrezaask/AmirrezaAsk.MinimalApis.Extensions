using Microsoft.AspNetCore.Http;

namespace AmirrezaAsk.MinimalApis.Extensions.Results;

public class Json : BaseResult, IResult
{
    public object? Object { get; set; }
    public Json(int statusCode, object? obj) : base(statusCode)
    {
        Object = obj;
    }
    public Json(int statusCode) : base(statusCode)
    {
    }
    public Task ExecuteAsync(HttpContext httpContext)
    {
        httpContext.Response.StatusCode = this.StatusCode;
        return httpContext.Response.WriteAsJsonAsync(this.Object);
    }
    
}
