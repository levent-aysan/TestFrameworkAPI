using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
//using static TestFrameworkCore.TestBase.TestInitialise;

namespace TestFrameworkCore.TestBase
{
    //-------------------------------------------------------------------------------------//
    //                  Hooks class specify the methods to run after milestones            //
    //-------------------------------------------------------------------------------------//
    [Binding]
    public sealed class TestHooks : TestInitialise
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        //public static ScenarioContext SContext;


        [BeforeTestRun]
        public static void InitaliseReport()
        {
            InitialiseReport();
        }


        [BeforeFeature]
        public static void BeforeFeature()
        {
            ExtractFeatureName();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            try
            {
                InitialiseTest();
                ExtractScenarioName();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured!! \n\n {0}", e);
            }

        }


        [AfterStep]
        public static void AfterStep()
        {
            GetStepDetials();
        }


        [AfterTestRun]
        public static void CompleteReport()
        {
            WriteToReport();
        }

    }
}
