using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.Configuration;
using System.IO;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;
using Feature = AventStack.ExtentReports.Gherkin.Model.Feature;
using Scenario = AventStack.ExtentReports.Gherkin.Model.Scenario;
using TestFrameworkAPI.Repo;
using TestFrameworkAPI.TestBase;

namespace TestFrameworkCore.TestBase
{
    //-------------------------------------------------------------------------------------//
    //                     Class to initalise the test framework before run                // 
    //-------------------------------------------------------------------------------------//

    [Binding]
    public class TestInitialise
    {
        //public readonly ScenarioContext scenarioContext;
        //public readonly FeatureContext featureContext;

        public static string ProjectBinLocation = (Directory.GetParent(Directory.GetCurrentDirectory())).Parent.ToString();
        public static string ProjectLocation = Directory.GetCurrentDirectory().ToString();
        public static string reportsDirectory = ProjectBinLocation + "\\Reports";
        public static string errorDirectory = reportsDirectory + "\\Errors";
        //public static string BaseURL = "";


        public TestInitialise()
        {
            StaticObjectRepo.ScenarioName = ScenarioContext.Current.ScenarioInfo.Title;
        }

        public void InitialiseTest()
        {
            SetEnvironment();
        }

        private void SetEnvironment()
        {
            StaticObjectRepo.Environment = ConfigurationManager.AppSettings["Env"].ToLower(); 
        }

        public void SetURLs(string env = "")
        {
            string envionment = env;
            if (string.IsNullOrEmpty(env))
            {
                envionment = StaticObjectRepo.Environment.ToLower();
            }

            switch (envionment)
            {
                case "dev":
                    StaticObjectRepo.BaseURL = ConfigurationManager.AppSettings["DevBaseUrl"];
                    StaticObjectRepo.TokenURL = ConfigurationManager.AppSettings["DevTokenUrl"];
                    break;

                case "tst":
                    StaticObjectRepo.BaseURL = ConfigurationManager.AppSettings["TstBaseUrl"];
                    StaticObjectRepo.TokenURL = ConfigurationManager.AppSettings["TstTokenUrl"];
                    break;

                case "usr":
                    StaticObjectRepo.BaseURL = ConfigurationManager.AppSettings["UsrBaseUrl"];
                    StaticObjectRepo.TokenURL = ConfigurationManager.AppSettings["UsrTokenUrl"];
                    break;

                case "train":
                    StaticObjectRepo.BaseURL = ConfigurationManager.AppSettings["TrainBaseUrl"];
                    StaticObjectRepo.TokenURL = ConfigurationManager.AppSettings["TrainTokenUrl"];
                    break;

                case "pro":
                    StaticObjectRepo.BaseURL = ConfigurationManager.AppSettings["ProBaseUrl"];
                    StaticObjectRepo.TokenURL = ConfigurationManager.AppSettings["ProTokenUrl"];
                    break;

                default:
                    Console.WriteLine("Valid URL not found in Config file!!");
                    break;
            }
            //return StaticObjectRepo.BaseURL;
        }

        public static void InitialiseReport()
        {
            var htmlReporter = new ExtentV3HtmlReporter($@"{reportsDirectory}\APITestReport {DateTime.Now.ToString("dd-MMM-yy hh-mm")}.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.Config.ReportName = AppReader.GetConfigValue("Project");
            htmlReporter.Config.DocumentTitle = "Automation Testing Report";

            //StaticObjectRepo.Reporter = null; //$@"{reportsDirectory}\\{DateTime.Now.ToString("dd-MMM-yy")}.html", false);

            StaticObjectRepo.Reporter.AttachReporter(htmlReporter);

            StaticObjectRepo.Reporter.AddSystemInfo("Tester", Environment.UserName);
            StaticObjectRepo.Reporter.AddSystemInfo("Environment", AppReader.GetConfigValue("Env").ToUpper());
            //StaticObjectRepo.Reporter.AddSystemInfo("Browser", AppReader.GetConfigValue("Browser").ToUpper());
            StaticObjectRepo.Reporter.AddSystemInfo("Machine", Environment.MachineName);
            StaticObjectRepo.Reporter.AddSystemInfo("OS", Environment.OSVersion.VersionString);
            StaticObjectRepo.Reporter.AddSystemInfo("Execution Date", DateTime.Now.ToString("D"));
            StaticObjectRepo.Reporter.AddSystemInfo("Execution Time", DateTime.Now.ToString("T"));
        }


        public static void ExtractFeatureName()
        {
            StaticObjectRepo.Feature = StaticObjectRepo.Reporter.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);

        }

        public void ExtractScenarioName()
        {
            StaticObjectRepo.Scenario =  StaticObjectRepo.Feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        public static void WriteToReport()
        {
            StaticObjectRepo.Reporter.Flush();
        }

        public static void GetStepDetials()
        {
            string StepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            var Error = ScenarioContext.Current.TestError;
            string StepPass = "True";
            string StepText = StepType + " " + ScenarioStepContext.Current.StepInfo.Text;
            MediaEntityModelProvider mediaModel;
            //string StepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            //************ Temp set cookies workaround for 2FA for Dynamics application *********//
            //-----------------------------------------------------------------------------------//
            if (ScenarioStepContext.Current.StepInfo.Text.Equals("I navigate to the url"))
            {
                //if (AppReader.GetConfigValue("Browser").ToLower().Equals("chrome"))
                //{
                //    Helper.SetCookies();
                //}
            }
            //-----------------------------------------------------------------------------------//

            if (!(Error is null))
            {
                StepPass = "False";
            }

            switch (StepType + StepPass)
            {

                case "GivenTrue":
                StaticObjectRepo.Scenario.CreateNode<Given>(StepText);
                    break;

                case "WhenTrue":
                    StaticObjectRepo.Scenario.CreateNode<When>(StepText);
                    break;

                case "ThenTrue":
                    StaticObjectRepo.Scenario.CreateNode<Then>(StepText);
                    break;

                case "AndTrue":
                    StaticObjectRepo.Scenario.CreateNode<And>(StepText);
                    break;

                case "GivenFalse":
                    //getScreenshot(StaticObjectRepo.ScenarioName);
                    mediaModel = MediaEntityBuilder.CreateScreenCaptureFromPath(reportsDirectory + "\\" + StaticObjectRepo.ScenarioName + ".png").Build();
                    StaticObjectRepo.Scenario.CreateNode<Given>(StepText).Fail(Error.ToString(), mediaModel);
                    break;

                case "WhenFalse":
                    //getScreenshot(StaticObjectRepo.ScenarioName); // (StepText);
                    mediaModel = MediaEntityBuilder.CreateScreenCaptureFromPath(reportsDirectory + "\\" + StaticObjectRepo.ScenarioName  + ".png").Build();
                    StaticObjectRepo.Scenario.CreateNode<When>(StepText).Fail(Error.ToString(), mediaModel);
                    break;

                case "ThenFalse":
                    //getScreenshot(StaticObjectRepo.ScenarioName);
                    mediaModel = MediaEntityBuilder.CreateScreenCaptureFromPath(reportsDirectory + "\\" + StaticObjectRepo.ScenarioName + ".png").Build();
                    StaticObjectRepo.Scenario.CreateNode<Then>(StepText).Fail(Error.ToString(), mediaModel);
                    break;

                case "AndFalse":
                    //getScreenshot(StaticObjectRepo.ScenarioName);
                    mediaModel = MediaEntityBuilder.CreateScreenCaptureFromPath(reportsDirectory + "\\" + StaticObjectRepo.ScenarioName + ".png").Build();
                    StaticObjectRepo.Scenario.CreateNode<And>(StepText).Fail(Error.ToString(), mediaModel);
                    break;
            }
        }

    }

}