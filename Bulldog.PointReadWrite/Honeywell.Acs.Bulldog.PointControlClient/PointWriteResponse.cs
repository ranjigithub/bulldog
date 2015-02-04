namespace Honeywell.Acs.Bulldog.PointControlClient
{
    public class PointWriteResponse
    {
        public string Status { get; set; }

        public static PointWriteResponse Failure(string status)
        {
            return new PointWriteResponse
            {
                Status = status
            };
        }
    }
}