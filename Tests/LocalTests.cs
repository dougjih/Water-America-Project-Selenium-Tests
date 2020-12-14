using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace LocalTests
{
    class LocalTests
    {
        IWebDriver webDriver;

        [SetUp]
        public void start_Browser()
        {
            webDriver = new FirefoxDriver();
        }

        [TearDown]
        public void close_Browser()
        {
            webDriver.Close();
        }

        [Test]
        public void LoadLoginPageAndLogin()
        {
            webDriver.Url = "http://localhost/Water-America-Project/login.php";

            {
                var webElement = webDriver.FindElement(By.XPath("//input[@name='username']"));
                webElement.SendKeys("customerlogin");
            }
            {
                var webElement = webDriver.FindElement(By.XPath("//input[@name='password']"));
                webElement.SendKeys("customerpassword");
            }
            {
                var webElement = webDriver.FindElement(By.XPath("//input[@value='Login']"));
                webElement.Click();
            }

            Assert.AreEqual(webDriver.Url, "http://localhost/Water-America-Project/welcome.php");
        }
    }
}