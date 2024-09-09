using BoDi;
using FluentAssertions.Execution;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Diagnostics.Metrics;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowBDDAutomationFramework.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }
        //This hook will run before any scenario that 
        // has the tag @tag1.It’s useful for setting up any
        //specific conditions or state needed for scenarios with that tag.
        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
        }


        //This hook will run before every scenario, and the Order = 1 specifies 
        //  its execution order relative to other[BeforeScenario] hooks.Hooks with a lower order number
        // run before those with a higher number. This is useful for global
        // setup tasks that need to happen before any scenario runs.
       [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(driver);
        }
        //This hook runs after every scenario.
        //It’s used for cleanup tasks or to perform any actions needed after a scenario has executed.

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();
            if (driver != null) 
            {
                driver.Quit();
            }
        }
    }
}