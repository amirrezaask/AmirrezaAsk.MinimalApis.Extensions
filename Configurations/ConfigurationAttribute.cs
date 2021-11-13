namespace AmirrezaAsk.MinimalApis.Extensions;

public class ConfigurationAttribute : Attribute
{
    public string ConfigurationKey { get; set; }
    public ConfigurationAttribute()
    {

    }
    public ConfigurationAttribute(string key)
    {
        ConfigurationKey = key;
    }
}
