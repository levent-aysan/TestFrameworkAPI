using AventStack.ExtentReports;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TechTalk.SpecFlow;

namespace TestFrameworkAPI.Repo
{
    //-------------------------------------------------------------------------------------//
    //           Object repository with defined class instances used globally              // 
    //-------------------------------------------------------------------------------------//
    public static class StaticObjectRepo
    {
        public static string ScenarioName { get; set; }
        public static string FeatureName { get; set; }

        public static AventStack.ExtentReports.ExtentReports Reporter = new AventStack.ExtentReports.ExtentReports();

        public static ExtentTest Feature { get; set; }
        public static ExtentTest Scenario { get; set; }
        public static String Environment { get; set; }
        public static String Error { get; set; }
        public static string TokenURL { get; internal set; }

        public static String BaseURL = "";

        public static String Endpoint = "";

        public static IRestRequest restRequest;

        public static IRestResponse restResponse;

        public static IRestClient restClient;

    }
}
