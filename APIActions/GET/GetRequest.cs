using TestFrameworkAPI.Schemas.RequestSchemas;
using TestFrameworkAPI.TestBase;
using TestFrameworkAPI.Repo;
using RestSharp;
using TestFrameworkAPI.SetupMethods;

namespace TestFrameworkAPI.ActionMethods.POST
{
    class GetRequest
    {
        //public static IRestResponse APIResponse;

        //example
        public static void GetContactData()
        {

            Contact contact = new Contact();

            StaticObjectRepo.restResponse = ExecuteAPI.CallAPI();
        }




        public static void CreateThematicArea(string he_name)
        {
        }

        public static void CreateLocalAuthority(string he_name)
        {

        }
    }
}
