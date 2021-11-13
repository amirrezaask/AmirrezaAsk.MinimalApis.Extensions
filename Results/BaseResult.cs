namespace AmirrezaAsk.MinimalApis.Extensions.Results;

public class BaseResult
{
    public int StatusCode { get; set; }
    public BaseResult(int StatusCode)
    {
        this.StatusCode = StatusCode;
    }
}
