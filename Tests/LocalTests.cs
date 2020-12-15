using Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace LocalTests
{
    class LocalTests
    {
        IWebDriver webDriver;
        TestsImpl testsImple;

        [SetUp]
        public void start_Browser()
        {
            webDriver = new FirefoxDriver();
            testsImple = new TestsImpl(webDriver);
        }

        [TearDown]
        public void close_Browser()
        {
            webDriver.Close();
        }

        [Test]
        public void LoadLoginPageAndLogin()
        {
            testsImple.LoadLoginPageAndLogin();
        }
    }
}