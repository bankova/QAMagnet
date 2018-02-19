using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using QAMagnet.Tests.ErrorPages;
using QAMagnet.Tests.Pages.HomePage;
using QAMagnet.Tests.Pages.SinglePostPage;
using QAMagnet.Tests.Common.Pages;

namespace QAMagnet.Tests.Common
{
    public class BaseQAMagnetTests
    {
        public IWebDriver Driver = new FirefoxDriver();

        [TestInitialize()]
        public void Initialize()
        {
            ////this.Driver = new FirefoxDriver();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            this.Driver.Quit();
        }

        public BasePage BasePage
        {
            get
            {
                return new BasePage(this.Driver);
            }
        }

        public HomePage HomePage
        {
            get
            {
                return new HomePage(this.Driver);
            }
        }

        public SinglePostPage SinglePostPage
        {
            get
            {
                return new SinglePostPage(this.Driver);
            }
        }

        public ErrorPage ErrorPage
        {
            get
            {
                return new ErrorPage(this.Driver);
            }
        }
    }
}