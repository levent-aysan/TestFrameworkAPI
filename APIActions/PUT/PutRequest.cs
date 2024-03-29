﻿using TestFrameworkAPI.Schemas.RequestSchemas;
using TestFrameworkAPI.TestBase;
using TestFrameworkAPI.Repo;
using RestSharp;
using TestFrameworkAPI.SetupMethods;

namespace TestFrameworkAPI.ActionMethods.POST
{
    class PutRequest
    {
        //public static IRestResponse APIResponse;

        //example
        public static void PutContact(string fname, string lname, string email)
        {
            string queryBody;

            Contact contact = new Contact(fname, lname, email);

            queryBody = "[" + SimpleJson.SerializeObject(contact) + "]";

            StaticObjectRepo.restResponse = ExecuteAPI.CallAPI(queryBody);
        }




        public static void CreateThematicArea(string he_name)
        {
        }

        public static void CreateLocalAuthority(string he_name)
        {

        }
    }
}
