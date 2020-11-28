using AventStack.ExtentReports.Utils;
using RestSharp;
using System;
using TestFrameworkAPI.Repo;
using TestFrameworkAPI.TestBase;

namespace TestFrameworkAPI.SetupMethods
{
    static class CommonMethods
    {
        public static IRestRequest request = StaticObjectRepo.restRequest;

        public static void SetBaseURL(string aPIname)
        {
            string BaseURL = "";
            switch (aPIname.ToLower().Trim())
            {
                case "thematicarea":
                    BaseURL = "TABase";
                    break;

                case "localauthority":
                    BaseURL = "LABase";
                    break;

                case "partnerdetails":
                    BaseURL = "PartnerBase";
                    break;

                case "contact":
                    BaseURL = "ContactBase";
                    break;

                case "partneropportunity":
                    BaseURL = "PartnerOppBase";
                    break;

                case "sites":
                    BaseURL = "SiteBase";
                    break;

                case "placeopportunity":
                    BaseURL = "PlaceOppBase";
                    break;

                case "associateopportunities":
                    BaseURL = "APPOBase";
                    break;

                case "associatepartners":
                    BaseURL = "APPBase";
                    break;

                default:
                    Console.WriteLine("\n Token not found for {0}", aPIname);
                    break;
            }

            if (!String.IsNullOrEmpty(BaseURL))
                if (StaticObjectRepo.Environment.ToLower().Equals("tst"))
                    StaticObjectRepo.BaseURL = AppReader.GetConfigValue(BaseURL + "Tst");
                else
                    StaticObjectRepo.BaseURL = AppReader.GetConfigValue(BaseURL + "Dev");
            else
                StaticObjectRepo.BaseURL = "";
        }

        internal static void RemoveAllParameters()
        {
            for (int i=request.Parameters.Count; i >= 1; i--)
            {
                request.Parameters.RemoveAt(0);
            }
        }

        public static void SetEndPoint(string APIType)
        {
            switch (APIType.ToLower())
            {
                case "thematicarea":
                    StaticObjectRepo.Endpoint = "";
                    break;
                case "localauthority":
                    StaticObjectRepo.Endpoint = "";
                    break;
                case "partnerdetails":
                    StaticObjectRepo.Endpoint = "";
                    break;
                case "contacts":
                    StaticObjectRepo.Endpoint = "";
                    //StaticObjectRepo.Endpoint = "?sig=fjRDaP2fNZLqM2NVVkVI06B_RpkXTYtAA8oENA6qmFg"; //"?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0";// &sig=kkwoVS9rCVTRa-5vDYoaojYEYhOTBfnYlgZDODf2M_s";
                    break;
                case "partneropportunity":
                    StaticObjectRepo.Endpoint = "";
                    break;
                case "sites":
                    StaticObjectRepo.Endpoint = "";
                    break;
                case "placeopportunity":
                    StaticObjectRepo.Endpoint = "";
                    break;
                case "associateopportunities":
                    StaticObjectRepo.Endpoint = "";
                    break;
                case "associatepartners":
                    StaticObjectRepo.Endpoint = "";
                    break;
            }
        }

        public static void CreateRequest(string RequestType, string EndPoint, string _BaseURL = "")
        {
            request = StaticObjectRepo.restRequest;
            if (String.IsNullOrEmpty(_BaseURL))
                _BaseURL = StaticObjectRepo.BaseURL;
            //StaticObjectRepo.Endpoint += "?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=fjRDaP2fNZLqM2NVVkVI06B_RpkXTYtAA8oENA6qmFg";
            switch (RequestType.ToUpper())
            {
                case "GET":
                    request = new RestRequest(_BaseURL + EndPoint, Method.GET);
                    break;

                case "PUT":
                    request = new RestRequest(_BaseURL + EndPoint, Method.PUT);
                    break;

                case "POST":
                    request = new RestRequest(_BaseURL + EndPoint, Method.POST);
                    break;

                case "DELETE":
                    request = new RestRequest(_BaseURL + EndPoint, Method.DELETE);
                    break;
            }
        }

        //public static void CreateDynamicsRequest(string RequestType, string BaseURL, string EndPoint)
        //{
        //    request = new RestRequest(BaseURL + EndPoint, Method.GET);
        //}

        public static void AddHeaders(string BaseURL = "", string RemoveHeader = "")
        {
            string Burl = BaseURL;
            if (!RemoveHeader.ToLower().Equals("content-type"))
                request.AddHeader("Content-Type", "application/json");

            if (String.IsNullOrEmpty(BaseURL))
            {
                Burl = StaticObjectRepo.BaseURL;
            }
            Uri myuri = new Uri(Burl);

            if (!RemoveHeader.ToLower().Equals("host"))
                request.AddHeader("Host", myuri.Host);
        }

        public static void AddParameters(string APIname, string RemoveParameter = "")
        {
            if(!RemoveParameter.ToLower().Equals("api-version"))
                request.AddQueryParameter("api-version", "2016-10-01", false);
            if(!RemoveParameter.ToLower().Equals("sp"))
                request.AddQueryParameter("sp", "%2Ftriggers%2Fmanual%2Frun", false);
            if(!RemoveParameter.ToLower().Equals("sv"))
                request.AddQueryParameter("sv", "1.0", false);
            if(!RemoveParameter.ToLower().Equals("sig"))
                request.AddQueryParameter("sig", GetTokenParameter(APIname).ToString(), false);
        }

        private static string GetTokenParameter(string aPIname)
        {
            string TokenValue = "";
            aPIname.Replace(" ", "");
            switch (aPIname.ToLower().Trim())
            {
                case "thematicarea":
                    TokenValue = "TAToken";
                    break;

                case "localauthority":
                    TokenValue = "LAToken";
                    break;

                case "partnerdetails":
                    TokenValue = "PartnerToken";
                    break;

                case "contact":
                    TokenValue = "ContactToken";
                    break;

                case "partneropportunity":
                    TokenValue = "PartnerOppToken";
                    break;

                case "sites":
                    TokenValue = "SiteToken";
                    break;

                case "placeopportunity":
                    TokenValue = "PlaceOppToken";
                    break;

                case "associateopportunities":
                    TokenValue = "APPOToken";
                    break;

                case "associatepartners":
                    TokenValue = "APPToken";
                    break;

                default:
                    TokenValue = "InvalidToken";
                    break;
            }

                if(StaticObjectRepo.Environment.ToLower().Equals("tst"))
                    return AppReader.GetConfigValue(TokenValue + "Tst");
                else
                    return AppReader.GetConfigValue(TokenValue + "Dev");
        }


        internal static bool ValidateStatus(string statusCode)
        {
            bool StatusMatch = false; 
            switch (statusCode.ToLower())
            {
                case "accepted":
                    if (StaticObjectRepo.restResponse.StatusCode.ToString().Equals(StatusCodes.Accepted.ToString()))
                        StatusMatch = true;
                        break;

                case "unauthorised":
                    if (StaticObjectRepo.restResponse.StatusCode.ToString().Equals(StatusCodes.Unauthorized.ToString()))
                        StatusMatch = true;
                    break;

                case "bad request":
                    if (StaticObjectRepo.restResponse.StatusCode.ToString().Equals(StatusCodes.BadRequest.ToString()))
                        StatusMatch = true;
                    break;
            }
            return StatusMatch;

        }
 
    }
}
