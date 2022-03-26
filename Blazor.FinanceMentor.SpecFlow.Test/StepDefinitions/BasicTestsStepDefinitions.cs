using System.Runtime.InteropServices.ComTypes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Blazor.FinanceMentor.SpecFlow.Test.StepDefinitions
{
    [Binding]
    public sealed class BasicTestsStepDefinitions
    {
        private IWebDriver _driver { get; set; }

        private const string url = "https://localhost:7275/";

        [BeforeScenario]
        public void BeforeScenario()
        {
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

        [Then(@"the navigation contains (.*) items")]
        public void ThenTheNavigationContainsItems(int itemCount)
        {
            var navMenu = _driver.FindElement(By.Id("navmenufm"));

            var navMenuItems = navMenu.FindElements(By.XPath("//div[contains(@class, 'nav-item')]"));

            Assert.AreEqual(itemCount, navMenuItems.Count);
        }

        [Given(@"The user is on the (.*) overview")]
        public void GivenTheUserIsOnTheOverview(string route)
        {
            _driver.Navigate().GoToUrl($"{url}/{route}s");
            Thread.Sleep(500);
        }

        [Then(@"the page title is (.*)")]
        public void ThenThePageTitleIsEarnings(string pageTitle)
        {
            var cardHeader = _driver.FindElement(By.XPath("//div[@class='card-header']"));
            Assert.AreEqual(pageTitle, cardHeader.Text.Trim());
        }


    }
}