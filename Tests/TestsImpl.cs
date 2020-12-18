using NUnit.Framework;
using OpenQA.Selenium;

namespace Common
{
    class TestsImpl
    {
        public TestsImpl(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void LoginPageLogin(string username, string password, bool expectedSuccess)
        {
            webDriver.Url = "http://localhost/Water-America-Project/login.php";

            {
                var webElement = webDriver.FindElement(By.XPath("//input[@name='username']"));
                webElement.SendKeys(username);
            }
            {
                var webElement = webDriver.FindElement(By.XPath("//input[@name='password']"));
                webElement.SendKeys(password);
            }
            {
                var webElement = webDriver.FindElement(By.XPath("//input[@value='Login']"));
                webElement.Click();
            }

            const string successfulUrl = "http://localhost/Water-America-Project/welcome.php";

            if (expectedSuccess)
            {
                Assert.AreEqual(webDriver.Url, successfulUrl);
            }
            else
            {
                Assert.AreNotEqual(webDriver.Url, successfulUrl);
            }
        }

        private readonly IWebDriver webDriver;
    }
}
