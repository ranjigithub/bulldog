using System;
using System.Net;
using Cloud.Platform.Authentication;
using RestSharp;

namespace Honeywell.Acs.Bulldog.PointControlClient.Impl
{
    public class PointWriter : IPointWriter
    {
        private readonly IPointReadWriteConfig _config;
        private readonly IActiveDirectoryHelper _activeDirectoryHelper;

        public PointWriter(IPointReadWriteConfig config, IActiveDirectoryHelper activeDirectoryHelper)
        {
            _config = config;
            _activeDirectoryHelper = activeDirectoryHelper;
        }

        public PointWriteResponse WritePoint(Guid systemGuid, string pointId, object value)
        {
            var restRequest = CreateWritePointRestRequest(systemGuid, pointId);
            restRequest.AddBody(new PointWriteRequest {Value = value});

            var response = ExecuteWriteRequest(restRequest);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }

            return PointWriteResponse.Failure(response.StatusCode.ToString());

        }

        private IRestResponse<PointWriteResponse> ExecuteWriteRequest(RestRequest restRequest)
        {
            var restClient = new RestClient(_config.PointControlServiceWebApiUrl);
            var response = restClient.Execute<PointWriteResponse>(restRequest);
            return response;
        }

        private RestRequest CreateWritePointRestRequest(Guid systemGuid, string pointId)
        {
            var readPointQueryStringFormat = _config.WritePointQueryStringFormat;
            var restRequest =
                new RestRequest(string.Format(readPointQueryStringFormat, systemGuid, Uri.EscapeDataString(pointId)),
                    Method.PUT) { RequestFormat = DataFormat.Json };

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