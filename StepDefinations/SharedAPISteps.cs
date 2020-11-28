using System;
using TechTalk.SpecFlow;
using TestFrameworkAPI.Repo;
using TestFrameworkAPI.SetupMethods;
using TestFrameworkAPI.TestBase;
using NUnit.Framework;

namespace TestFrameworkAPI.StepDefinations
{ [Binding]
    public class SharedAPISteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public SharedAPISteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"the '(.*)' api endpoint")]
        public void GivenTheApiEndpoint(string APIName)
        {
            CommonMethods.SetBaseURL(APIName);
            CommonMethods.SetEndPoint(APIName);
        }


        [Then(@"status code of response should be '(.*)'")]
        public void ThenStatusCodeOfResponseShouldBe(string StatusCode)
        {
            Assert.IsTrue(CommonMethods.ValidateStatus(StatusCode), "\nExpected Status is " + StatusCode + "\n Actual status is " + StaticObjectRepo.restResponse.StatusCode.ToString());
        }

    }
}
