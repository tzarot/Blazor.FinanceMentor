using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Blazor.FinanceMentor.SpecFlow.Test.StepDefinitions
{
    [Binding]
    public sealed class BasicTestsStepDefinitions
    {
        private IWebDriver _driver { get; set; }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var url = "https://localhost:7275/";

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless"); // No Chrome Visible

            _driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions);
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }


        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }

        [Then(@"the home page is loaded")]
        public void ThenTheHomePageIsLoaded()
        {
            var navMenu = _driver.FindElement(By.Id("navmenufm"));
            Assert.IsNotNull(navMenu);
        }


    }
}