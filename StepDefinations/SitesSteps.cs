using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TestFrameworkAPI.ActionMethods.POST;
using TestFrameworkAPI.Repo;
using TestFrameworkAPI.SetupMethods;

namespace TestFrameworkAPI.StepDefinations
{
    [Binding]
    public sealed class SitesSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public SitesSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [When(@"I add a new Site with details '(.*)', '(.*)' and '(.*)'")]
        public void WhenIAddANewSiteWithDetailsAnd(string SiteArea, string Name, string OppId)
        {
            CommonMethods.CreateRequest("POST", StaticObjectRepo.Endpoint);
            CommonMethods.AddHeaders();
            CommonMethods.AddParameters("Sites");
            PostRequest.CreateSite(SiteArea, Name, OppId);
        }

        [When(@"I update an existing Site with details '(.*)', '(.*)' and '(.*)'")]
        public void WhenIUpdateAnExistingSiteWithDetailsAnd(string SiteArea, string Name, string OppId)
        {
            CommonMethods.CreateRequest("POST", StaticObjectRepo.Endpoint);
            CommonMethods.AddHeaders();
            CommonMethods.AddParameters("Sites");
            PostRequest.CreateSite(SiteArea, Name, OppId);
        }


        [When(@"I add a new Site with invalid token with details '(.*)', '(.*)' and '(.*)'")]
        public void WhenIAddANewSiteWithInvalidTokenWithDetailsAnd(string SiteArea, string Name, string OppId)
        {
            CommonMethods.CreateRequest("POST", StaticObjectRepo.Endpoint);
            CommonMethods.AddHeaders();
            CommonMethods.AddParameters("InvalidToken");
            PostRequest.CreateSite(SiteArea, Name, OppId);
        }

        [When(@"I create a bad request for Site with details '(.*)', '(.*)' and '(.*)'")]
        public void WhenICreateABadRequestForSiteWithDetailsAnd(string SiteArea, string Name, string OppId)
        {
            CommonMethods.CreateRequest("POST", StaticObjectRepo.Endpoint);
            CommonMethods.AddHeaders();
            CommonMethods.AddParameters("Sites", "api-version");
            PostRequest.CreateSite(SiteArea, Name, OppId);
        }


        [Then(@"the data entered in the application for Site should be correct")]
        public void ThenTheDataEnteredInTheApplicationForSiteShouldBeCorrect()
        {
            //ScenarioContext.Current.Pending();
        }

    }
}
