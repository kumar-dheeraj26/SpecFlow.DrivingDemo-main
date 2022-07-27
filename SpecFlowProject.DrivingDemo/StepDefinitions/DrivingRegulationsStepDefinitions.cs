using SpecFlow.DrivingDemo;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.DrivingDemo.StepDefinitions
{
    [Binding]
    public class DrivingRegulationsStepDefinitions
    {
        private readonly ScenarioContext _scenerioContext;
        private readonly IDrivingRegulations _drivingRegulations;

        public DrivingRegulationsStepDefinitions(ScenarioContext scenerioContext)
        {
            _scenerioContext = scenerioContext;
            _drivingRegulations = new DrivingRegulations(); 
        }
        [Given(@"The driver is (\d+) years old")]
        public void GivenTheDriverIsYearsOld(int age)
        {
            _scenerioContext["Person"] = new Person { Age = age };
        }

        [When(@"they live in (.*)")]
        public void WhenTheyLiveInSwiterzland(string country)
        {
            var countryName = Enum.Parse<Country>(country);
            var person = (Person)_scenerioContext["Person"];
            _scenerioContext["Result"] = _drivingRegulations.IsAllowedToDrive(person, countryName);
        }

        [Then(@"They are permitted to drive")]
        public void ThenTheyArePermittedToDrive()
        {
            var result = (bool)_scenerioContext["Result"];
            Assert.True(result);
        }

        [Then(@"They are not permitted to drive")]
        public void ThenTheyAreNotPermittedToDrive()
        {
            var result = (bool)_scenerioContext["Result"];
            Assert.False(result);
        }

    }
}
