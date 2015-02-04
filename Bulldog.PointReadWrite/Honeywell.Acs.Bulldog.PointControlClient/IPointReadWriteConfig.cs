using Cloud.Platform.Authentication;

namespace Honeywell.Acs.Bulldog.PointControlClient
{
    public interface IPointReadWriteConfig : IActiveDirectoryConfig
    {
        string PointControlServiceWebApiUrl { get; }
        string ReadPointQueryStringFormat { get; }
        string PointControlServiceResourceId { get; }
        string WritePointQueryStringFormat { get; }
    }
}