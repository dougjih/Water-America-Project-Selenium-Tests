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

        private readonly IWebDriver webDriver;
    }
}
