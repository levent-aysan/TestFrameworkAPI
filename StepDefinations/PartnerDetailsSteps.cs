using System;
using TechTalk.SpecFlow;
using TestFrameworkAPI.ActionMethods.POST;
using TestFrameworkAPI.Repo;
using TestFrameworkAPI.SetupMethods;

namespace TestFrameworkAPI
{
    [Binding]
    public class PartnerDetailsSteps
    {

        [When(@"I add new Partner Details with details '(.*)', '(.*)', '(.*)' and '(.*)'")]
        public void WhenIAddNewWithDetailsAnd(string name, string accType, string accNo, string orgName)
        {
            CommonMethods.CreateRequest("POST", StaticObjectRepo.Endpoint);
            CommonMethods.AddHeaders();
            CommonMethods.AddParameters("PartnerDetails");
            PostRequest.CreatePartner(name, accType, accNo, orgName);
        }


        [When(@"I update existing Partner Details with details '(.*)', '(.*)', '(.*)' and '(.*)'")]
        public void WhenIUpdateExistingWithDetailsAnd(string name, string accType, string accNo, string orgName)
        {
            CommonMethods.CreateRequest("POST", StaticObjectRepo.Endpoint);
            CommonMethods.AddHeaders();
            CommonMethods.AddParameters("PartnerDetails");
            PostRequest.CreatePartner(name, accType, accNo, orgName);
        }


        [When(@"I add new Partner Details with invalid token with details '(.*)', '(.*)', '(.*)' and '(.*)'")]
        public void WhenIAddNewPartnerDetailsWithInvalidTokenWithDetailsAnd(string name, string accType, string accNo, string orgName)
        {
            CommonMethods.CreateRequest("POST", StaticObjectRepo.Endpoint);
            CommonMethods.AddHeaders();
            CommonMethods.AddParameters("InvalidToken");
            PostRequest.CreatePartner(name, accType, accNo, orgName);
        }

        [When(@"I create a bad request for Partner Details with details '(.*)', '(.*)', '(.*)' and '(.*)'")]
        public void WhenICreateABadRequestForPartnerDetailsWithDetailsAnd(string name, string accType, string accNo, string orgName)
        {
            CommonMethods.CreateRequest("POST", StaticObjectRepo.Endpoint);
            CommonMethods.AddHeaders();
            CommonMethods.AddParameters("PartnerDetails", "api-version");
            PostRequest.CreatePartner(name, accType, accNo, orgName);
        }


        [Then(@"the data entered in the application for Partner Details should be correct")]
        public void ThenTheDataEnteredInTheApplicationForPartnerDetailsShouldBeCorrect()
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
