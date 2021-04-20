using Microsoft.Extensions.Logging;

namespace Fra.Logging
{
    public interface IHasLogLevel
    {
        LogLevel LogLevel { get; set; }
    }
}
