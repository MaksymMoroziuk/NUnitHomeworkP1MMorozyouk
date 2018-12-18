using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitHomeworkP1MMorozyouk
{
    [TestFixture]
    public class NUnitHomework
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

        [SetUp]
        public void Login()
        {
            driver.Url = "https://atata-framework.github.io/atata-sample-app/#!/signin";
            driver.FindElement(By.Id("email")).SendKeys("admin@mail.com");
            driver.FindElement(By.Id("password")).SendKeys("abc123");
            driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();
        }

        [TearDown]
        public void Logout()
        {
            driver.FindElement(By.ClassName("navbar-right")).Click();
            driver.FindElement(By.LinkText("Sign Out")).Click();
        }

        [Test]
        public void VerifyPlansHeader()
        {
            driver.FindElement(By.LinkText("Plans")).Click();
            var pageHeader = driver.FindElement(By.TagName("h1")); 

            Assert.AreEqual("Plans", pageHeader.Text);
        }

        [Test]
        public void VerifuThatCalculationsAreCurrect()
        {
            driver.FindElement(By.LinkText("Calculations")).Click();
            driver.FindElement(By.Id("addition-value-1")).SendKeys("2");
            driver.FindElement(By.Id("addition-value-2")).SendKeys("2");
            var additionResult = driver.FindElement(By.Id("addition-result"));

            Assert.AreEqual("4", additionResult.GetAttribute("value"));
        }

        [Test]
        public void VerifyPricesContainDollarSign()
        {
            driver.FindElement(By.LinkText("Products")).Click();
            var prices = driver.FindElements(By.XPath("//tr/td[2]"));

            foreach(var price in prices)
            {
                Assert.That(price.Text, Does.Contain("$"));
            }
        }
    }
}
