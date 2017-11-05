using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using QAMagnet.Tests.Pages.HomePage;
using QAMagnet.Tests.Pages.SinglePostPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}