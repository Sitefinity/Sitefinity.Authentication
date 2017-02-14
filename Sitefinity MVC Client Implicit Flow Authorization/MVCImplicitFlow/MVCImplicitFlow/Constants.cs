using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCImplicitFlow
{
    public class Constants
    {
        public const string SitefinityBaseUrl = "http://localhost:1010";
        public const string SitefinitySTSUrl = SitefinityBaseUrl + "/Sitefinity/Authenticate/OpenID";
        public const string SiteUrl = "http://localhost:64761/";
        public const string SitefinityNewsItemsApiUrl = SitefinityBaseUrl + "api/default/newsitems";
        public const string ClientId = "testApp";
    }
}