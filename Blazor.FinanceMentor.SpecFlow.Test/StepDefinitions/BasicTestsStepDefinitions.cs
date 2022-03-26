using System.Runtime.InteropServices.ComTypes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

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

        [When(@"The user adds a new earning")]
        public void WhenTheUserAddsANewEarning()
        {
            var earningsFormContainer = _driver.FindElement(By.Id("earnings-form-container"));
            var earningsForm = earningsFormContainer.FindElement(By.TagName("form"));
            var subjectInput = earningsForm.FindElement(By.Id("subjectInput"));
            var categoryInput = earningsForm.FindElement(By.Id("categoryInput"));
            var amountInput = earningsForm.FindElement(By.Id("amountInput"));
            var submitEarning = earningsForm.FindElement(By.Id("submitEarning"));

            
            subjectInput.SendKeys("Painting Work: 2 Rooms");
            categoryInput.SendKeys("Freelancing");
            amountInput.SendKeys("480");
            
            Actions actions = new Actions(_driver);
            actions.Click(submitEarning);
            

        }

        [Then(@"the new earning should be in the table")]
        public void ThenTheNewEarningShouldBeInTheTable()
        {
            var earningsTable = _driver.FindElement(By.Id("earnings-table"));
            var tableRows = earningsTable.FindElements(By.TagName("tr"));
            var containsPaintingWork = tableRows.Any(row => row.Text.Contains("Painting Work: 2 Rooms"));
        }







    }
}