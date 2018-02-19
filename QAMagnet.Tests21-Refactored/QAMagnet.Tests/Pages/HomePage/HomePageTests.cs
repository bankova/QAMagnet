////Copyright 2017 QA Magnet https://qamag.net author Kristina Bankova

////   Licensed under the Apache License, Version 2.0 (the "License");
////   you may not use this file except in compliance with the License.
////   You may obtain a copy of the License at

////       http://www.apache.org/licenses/LICENSE-2.0

////   Unless required by applicable law or agreed to in writing, software
////   distributed under the License is distributed on an "AS IS" BASIS,
////   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
////   See the License for the specific language governing permissions and
////   limitations under the License.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using QAMagnet.Tests.Common;
using QAMagnet.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMagnet.Tests.Pages.HomePage
{
    [TestClass]
    public class HomePageTests: BaseQAMagnetTests
    {
        [TestMethod]
        public void VerifyHomePageElements()
        {
            this.HomePage.Navigate(CommonTestData.BaseUrlHttps);

            this.HomePage.AssertBrowserTitleText("QA Magnet - Software Quality Assurance Tips and Tricks");

            this.HomePage.AssertTextInHeaderDiv();
            this.HomePage.AssertNavigationMenu();
            this.HomePage.AssertPostsDiv();
            this.HomePage.AssertFooter();
            this.HomePage.AssertRightSidebar();
        }

        [TestMethod]
        public void VerifyAuthorSlugRedirectsToHomePage()
        {
            this.HomePage.Navigate(CommonTestData.BaseUrlHttps);

            this.HomePage.AuthorSlug.Click();
            this.HomePage.AssertCurrentUrlIsExpected();
        }

        [TestMethod]
        public void VerifyHttpToHttpsRedirect()
        {
            this.HomePage.Navigate(CommonTestData.BaseUrlHttp);

            this.HomePage.AssertCurrentUrlIsExpected();
        }

        [TestMethod]
        public void VerifyWWWToNoWWWRedirect()
        {
            this.HomePage.Navigate(CommonTestData.BaseUrlHttpsWWW);

            this.HomePage.AssertCurrentUrlIsExpected();
        }


        [TestMethod]
        public void Verify404ErrorPage()
        {
            this.HomePage.Navigate(CommonTestData.NotExistingPageUrl);
        }
    }
}
