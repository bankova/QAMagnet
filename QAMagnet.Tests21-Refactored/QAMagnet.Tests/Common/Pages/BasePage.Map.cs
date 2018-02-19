using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMagnet.Tests.Common.Pages
{
    public partial class BasePage
    {
        public IWebElement H1
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//h1"));
            }
        }
    }
}
