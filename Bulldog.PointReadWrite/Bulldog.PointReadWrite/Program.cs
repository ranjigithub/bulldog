using System;
using System.Configuration;
using Cloud.Platform.Authentication;
using Honeywell.Acs.Bulldog.PointControlClient.Impl;

namespace Bulldog.PointReadWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new PointReadWriteConfig();
            var activeDirectoryHelper = new ActiveDirectoryHelper(config, new TokenCacheFactory());

            var pointReader = new PointReader(config, activeDirectoryHelper);
            var systemGuid = Guid.Parse(ConfigurationManager.AppSettings["SystemGuid"]);

            //Point id format is <pointname.property> ex: blr_sp.pv
            var readResponse = pointReader.ReadPoint(systemGuid, "CBC_VAV2RoomTemp.presentvalue"); 

            var pointWriter = new PointWriter(config, activeDirectoryHelper);
            object pointValueToWrite = 0; //put what ever value you want to write

            //Point id format is <pointname.property> ex: blr_sp.sp
            var writeResponse = pointWriter.WritePoint(systemGuid, "PUT YOUR POINT ID HERE", pointValueToWrite);

            Console.ReadLine();
        }
    }
}
