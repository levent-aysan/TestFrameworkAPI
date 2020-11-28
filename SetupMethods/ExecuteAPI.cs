using AventStack.ExtentReports.Utils;
using RestSharp;
using TestFrameworkAPI.Repo;

namespace TestFrameworkAPI.SetupMethods
{
    class ExecuteAPI
    {
        public static IRestRequest request = StaticObjectRepo.restRequest;

        public static IRestResponse CallAPI(string ReqBody = "")
        {
            StaticObjectRepo.restClient = new RestClient();

           if(!string.IsNullOrEmpty(ReqBody))
                CommonMethods.request.AddJsonBody(ReqBody);

            IRestResponse response = StaticObjectRepo.restClient.Execute(CommonMethods.request);
            return response;
        }

        public static IRestResponse CallAPI(IRestRequest req, string ReqBody = "")
        {
            IRestClient RClient = new RestClient();

            // request.RequestFormat = DataFormat.Json;
            if (!string.IsNullOrEmpty(ReqBody))
                req.AddJsonBody(ReqBody);

            IRestResponse response = RClient.Execute(req);
            return response;
        }

    }
}
