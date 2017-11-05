using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMagnet.Tests.Common
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public string CurrentUrl
        {
            get
            {
                return this.Driver.Url;
            }
        }

        public void Navigate(string Url)
        {
            this.Driver.Navigate().GoToUrl(Url);
        }
    }
}
