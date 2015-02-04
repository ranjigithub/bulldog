using System;
using System.Diagnostics;
using System.Net;
using Cloud.Platform.Authentication;
using RestSharp;

namespace Honeywell.Acs.Bulldog.PointControlClient.Impl
{
    public class PointReader : IPointReader
    {
        private readonly IPointReadWriteConfig _config;
        private readonly IActiveDirectoryHelper _activeDirectoryHelper;

        public PointReader(IPointReadWriteConfig config, IActiveDirectoryHelper activeDirectoryHelper)
        {
            _config = config;
            _activeDirectoryHelper = activeDirectoryHelper;
        }

        public PointReadResponse ReadPoint(Guid systemGuid, string pointId)
        {
            var restRequest = CreateReadPointRestRequest(systemGuid, pointId);

            var response = ExecuteReadRequest(restRequest);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }

            return PointReadResponse.Failure(response.StatusCode.ToString());
        }

        private IRestResponse<PointReadResponse> ExecuteReadRequest(RestRequest restRequest)
        {
            var restClient = new RestClient(_config.PointControlServiceWebApiUrl);
            var stopwatch = Stopwatch.StartNew();
            var response = restClient.Execute<PointReadResponse>(restRequest);
            stopwatch.Stop();

            var elapsed = stopwatch.ElapsedMilliseconds;
            return response;
        }

        private RestRequest CreateReadPointRestRequest(Guid systemGuid, string pointId)
        {
            var readPointQueryStringFormat = _config.ReadPointQueryStringFormat;
            var restRequest =
                new RestRequest(string.Format(readPointQueryStringFormat, systemGuid, Uri.EscapeDataString(pointId)),
                    Method.GET);

            var header = GetAuthHeader();
            restRequest.AddParameter("Authorization", header, ParameterType.HttpHeader);

            return restRequest;
        }
       
        private string GetAuthHeader()
        {
            var registrationServiceResourceId = _config.PointControlServiceResourceId;
            var header = _activeDirectoryHelper.GetAuthorizationHeader(registrationServiceResourceId);
            return header;
        }

    }
}
