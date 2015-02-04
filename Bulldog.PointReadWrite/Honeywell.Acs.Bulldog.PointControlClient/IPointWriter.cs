using System;

namespace Honeywell.Acs.Bulldog.PointControlClient
{
    public interface IPointWriter
    {
        PointWriteResponse WritePoint(Guid systemGuid, string pointId, object value);
    }
}