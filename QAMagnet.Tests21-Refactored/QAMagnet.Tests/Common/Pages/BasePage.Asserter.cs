using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMagnet.Tests.Common.Pages
{
    public partial class BasePage
    {
        public void AssertHeading1Text(string expectedText)
        {
            string actualText = this.H1.Text;
            Assert.AreEqual(expectedText, actualText);
        }

        public void AssertBrowserTitleText(string expectedText)
        {
            string actualText = this.Driver.Title;
            Assert.AreEqual(expectedText, actualText);
        }
    }
}
