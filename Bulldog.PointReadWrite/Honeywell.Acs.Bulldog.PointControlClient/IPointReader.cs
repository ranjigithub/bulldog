using System;

namespace Honeywell.Acs.Bulldog.PointControlClient
{
    public interface IPointReader
    {
        PointReadResponse ReadPoint(Guid systemGuid, string pointId);
    }
}