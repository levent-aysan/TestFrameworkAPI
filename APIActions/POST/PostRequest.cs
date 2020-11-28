using TestFrameworkAPI.Schemas.RequestSchemas;
using TestFrameworkAPI.TestBase;
using TestFrameworkAPI.Repo;
using RestSharp;
using TestFrameworkAPI.SetupMethods;
using System;
using TechTalk.SpecFlow;
using System.Security.Policy;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections;
using AventStack.ExtentReports.Utils;

namespace TestFrameworkAPI.ActionMethods.POST
{
    class PostRequest
    {
        //public static IRestResponse APIResponse;

        //example
        public static string queryBody;


        internal static void CreatePartner(string name, string accType, string accNo, string orgName)
        {
            if (name.Equals("AutoGen"))
                name =  "Automation" + DateTime.Now.ToString("yyMMddmm");

            if (accNo.Equals("AutoGen"))
                accNo = DateTime.Now.ToString("yyMMddmm");

            PartnerDetails partner = new PartnerDetails(name, accType, accNo, orgName);
            queryBody = "[" + SimpleJson.SerializeObject(partner) + "]";

            StaticObjectRepo.restResponse = ExecuteAPI.CallAPI(queryBody);
        }


        internal static void CreateSite(string siteArea, string name, string oppId)
        {
            if (name.Equals("AutoGen"))
                name = "Automation" + DateTime.Now.ToString("MMddhhmm");

            Sites site = new Sites(Convert.ToDecimal(siteArea), name, Convert.ToInt32(oppId));
            queryBody = "[" + SimpleJson.SerializeObject(site) + "]";

            StaticObjectRepo.restResponse = ExecuteAPI.CallAPI(queryBody);
        }

        public static void CreateContact(string fname, string lname, string email)
        {
            if (fname.Equals("AutoGen"))
                fname = "FName" + DateTime.Now.ToString("yyMMddmm");

            if (lname.Equals("AutoGen"))
                lname = "LName" + DateTime.Now.ToString("yyMMddmm");

            if (email.Equals("AutoGen"))
                email = "Email" + DateTime.Now.ToString("yyMMddmm") + "@automation.co.uk";

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
