using Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace LocalTests
{
    class LocalTests
    {
        IWebDriver webDriver;
        TestsImpl testsImpl;

        [SetUp]
        public void start_Browser()
        {
            webDriver = new FirefoxDriver();
            testsImpl = new TestsImpl(webDriver);
        }

        [TearDown]
        public void close_Browser()
        {
            webDriver.Close();
        }

        [Test]
        [TestCase("customerlogin", "customerpassword", true)]
        [TestCase("qwerty", "qwerty", false)]
        public void LoadLoginPageAndLogin(string username, string password, bool expectedSuccess)
        {
            testsImpl.LoginPageLogin(username, password, expectedSuccess);
        }
    }
}