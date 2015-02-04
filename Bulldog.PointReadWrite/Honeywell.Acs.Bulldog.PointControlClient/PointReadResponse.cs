namespace Honeywell.Acs.Bulldog.PointControlClient
{
    public class PointReadResponse
    {
        public object Value { get; set; }
        public string Status { get; set; }

        public static PointReadResponse Failure(string status)
        {
            return new PointReadResponse
            {
                Status = status,
                Value = null
            };
        }
    }
}