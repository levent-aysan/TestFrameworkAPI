using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TestFrameworkAPI.ActionMethods.POST;
using TestFrameworkAPI.SetupMethods;
using TestFrameworkAPI.Repo;

namespace TestFrameworkAPI.StepDefinations
{
    [Binding]
    public sealed class ContactSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public ContactSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [When(@"I add a new Contact with details  '(.*)', '(.*)' and '(.*)'")]
        public void WhenIAddANewWithDetailsAnd(string Firstname, string Lastname, string Email)
        {
            CommonMethods.CreateRequest("POST", StaticObjectRepo.Endpoint);
            CommonMethods.AddHeaders();
            CommonMethods.AddParameters("Contact");
            PostRequest.CreateContact(Firstname, Lastname, Email);
        }

        [When(@"I update an existing Contact with details  '(.*)', '(.*)' and '(.*)'")]
        public void WhenIUpdateAnExistingWithDetailsAnd(string Firstname, string Lastname, string Email)
        {
            CommonMethods.CreateRequest("POST", StaticObjectRepo.Endpoint);
            CommonMethods.AddHeaders();
            CommonMethods.AddParameters("Contact");
            PostRequest.CreateContact(Firstname, Lastname, Email);
        }

        [When(@"I add a new Contact with invalid token with details '(.*)', '(.*)' and '(.*)'")]
        public void WhenIAddANewContactWithInvalidTokenWithDetailsAnd(string Firstname, string Lastname, string Email)
        {
            CommonMethods.CreateRequest("POST", StaticObjectRepo.Endpoint);
            CommonMethods.AddHeaders();
            CommonMethods.AddParameters("InvalidToken");
            PostRequest.CreateContact(Firstname, Lastname, Email);
        }

        [When(@"I create a bad request for Contact with details '(.*)', '(.*)' and '(.*)'")]
        public void WhenICreateABadRequestForContactWithDetailsAnd(string Firstname, string Lastname, string Email)
        {
            CommonMethods.CreateRequest("POST", StaticObjectRepo.Endpoint);
            CommonMethods.AddHeaders();
            CommonMethods.AddParameters("Contact", "api-version");
            PostRequest.CreateContact(Firstname, Lastname, Email);
        }


        [Then(@"the data entered in the application for Contacts should be correct")]
        public void ThenTheDataEnteredInTheApplicationForContactsShouldBeCorrect()
        {
            //CommonMethods.RemoveAllParameters();
            //CommonMethods.CreateRequest("GET", @"/Contacts", AppReader.GetConfigValue("DynamicsBaseURL"));
            //CommonMethods.AddHeaders(AppReader.GetConfigValue("DynamicsBaseURL"));
            ////CommonMethods.AddParameters("Dynamics");
            //GetRequest.GetContactData();
        }
    }
}
