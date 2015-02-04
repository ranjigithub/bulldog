using System;
using System.Configuration;
using Cloud.Platform.Authentication;
using Honeywell.Acs.Bulldog.PointControlClient;

namespace Bulldog.PointReadWrite
{
    internal class PointReadWriteConfig : IPointReadWriteConfig
    {
        public string AzureActiveDirectoryTenant
        {
            get { return ConfigurationManager.AppSettings["AzureActiveDirectoryTenant"]; }
        }

        string IActiveDirectoryConfig.ApplicationActiveDirectoryId
        {
            get { return ConfigurationManager.AppSettings["ApplicationActiveDirectoryId"]; }
        }

        string IActiveDirectoryConfig.ApplicationActiveDirectoryKey
        {
            get { return ConfigurationManager.AppSettings["ApplicationActiveDirectoryKey"]; }
        }

        string IActiveDirectoryConfig.TenantIdClaimType
        {
            get { throw new NotImplementedException(); }
        }

        string IActiveDirectoryConfig.ActiveDirectoryGraphResourceId
        {
            get { throw new NotImplementedException(); }
        }

        string IActiveDirectoryConfig.ActiveDirectoryGraphApiVersion
        {
            get { throw new NotImplementedException(); }
        }

        string IActiveDirectoryConfig.PostLogoutRedirectUrl
        {
            get { throw new NotImplementedException(); }
        }

        string IActiveDirectoryConfig.ActiveDirectoryApplicationAudience
        {
            get { throw new NotImplementedException(); }
        }

        public string AzureActiveDirectoryInstance
        {
            get { return ConfigurationManager.AppSettings["AzureActiveDirectoryInstance"]; }
        }

        public string PointControlServiceWebApiUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["PointControlServiceWebApiUrl"];
            }
        }

        public string ReadPointQueryStringFormat
        {
            get
            {
                return ConfigurationManager.AppSettings["ReadPointQueryStringFormat"];
            }
        }

        public string PointControlServiceResourceId
        {
            get
            {
                return ConfigurationManager.AppSettings["PointControlServiceResourceId"];
            }
        }

        public string WritePointQueryStringFormat
        {
            get
            {
                return ConfigurationManager.AppSettings["WritePointQueryStringFormat"];
            }
        }
    }
}