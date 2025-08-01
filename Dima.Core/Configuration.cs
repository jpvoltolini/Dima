namespace Dima.Core;

public class Configuration
{
    public const int DefaultPageNumber = 1;
    public const int DefaultPageSize = 25;
    public const int DefaultStatusCode = 200;

// Wrapper for configuration settings
    public static string ConnectionString { get; set; } = string.Empty;
    public static string FrontendUrl { get; set; } = string.Empty;
    public static string BackendUrl { get; set; } = string.Empty;

}