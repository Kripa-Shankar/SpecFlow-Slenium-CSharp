using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowBDDAutomationFramework.StepDefinitions
{
    [Binding]
    public sealed class FeatureStepDefinitions
    {
        private IWebDriver driver;

        [Given(@"Open the browser")]
        public void GivenOpenTheBrowser()
        {
            driver= new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [When(@"Enter the url")]
        public void WhenEnterTheURL() 
        {
            //driver.Navigate().GoToUrl("https://www.youtube.com");
            driver.Url = "https://www.youtube.com";
            Thread.Sleep(1000);
        }

        [Then(@"Search for the Testers Talk")]
        public void ThenSearchForTheTesterTalk()
        {
            driver.FindElement(By.XPath("//input[@id='search']")).SendKeys("Tester Talk");
            driver.FindElement(By.XPath("//input[@id='search']")).SendKeys(Keys.Enter);

            Thread.Sleep(5000);

            driver.Quit();

        }
    }
}
