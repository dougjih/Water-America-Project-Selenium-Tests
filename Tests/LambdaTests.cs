using Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace LambdaTests
{
    [TestFixture("Chrome", "87.0", "Windows 10")]
    [TestFixture("Firefox", "82.0", "Windows 10")]
    [TestFixture("Safari", "12.0", "macOS Mojave")]
    [Parallelizable]
    class LambdaTests
    {
        IWebDriver webDriver;
        private string browser;
        private string version;
        private string os;
        TestsImpl testsImpl;

        public LambdaTests(string browser, string version, string os)
        {
            this.browser = browser;
            this.version = version;
            this.os = os;
        }

        [SetUp]
        public void start_Browser()
        {
            webDriver = new RemoteWebDriver(new Uri("https://doug.jih:JNzJjzlmzsAtVVlOpM7vGEOYZmMOBqE7ZyWULXwFtl3rrnHRC0@hub.lambdatest.com/wd/hub"), GetDesiredCapabilities());

            ICapabilities GetDesiredCapabilities()
            {
#pragma warning disable CS0618 // TODO: Unclear how to use the newer DriverOptions class with RemoteWebDriver; use the old DesiredCapabilities for now
                var capabilities = new DesiredCapabilities();
                capabilities.SetCapability("tunnel", true);
                capabilities.SetCapability("browserName", browser);
                capabilities.SetCapability("version", version);
                capabilities.SetCapability("platform", os);
#pragma warning restore CS0618e
                return capabilities;
            }

            testsImpl = new TestsImpl(webDriver);
        }

        [TearDown]
        public void close_Browser()
        {
            webDriver.Quit();
        }

        [Test]
        public void LoadLoginPageAndLogin()
        {
            testsImpl.LoadLoginPageAndLogin();
        }
    }
}