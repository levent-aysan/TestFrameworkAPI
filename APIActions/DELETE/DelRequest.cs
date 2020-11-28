using TestFrameworkAPI.Schemas.RequestSchemas;
using TestFrameworkAPI.TestBase;
using TestFrameworkAPI.Repo;
using RestSharp;
using TestFrameworkAPI.SetupMethods;

namespace TestFrameworkAPI.ActionMethods.POST
{
    public class DeleteRequest
    {
        //public static IRestResponse APIResponse;

        //example
        public static void DeleteContact(string fname, string lname, string email)
        {
            string queryBody;

            Contact contact = new Contact(fname, lname, email);

            queryBody = "[" + SimpleJson.SerializeObject(contact) + "]";

            StaticObjectRepo.restResponse = ExecuteAPI.CallAPI(queryBody);
        }

    }
}
