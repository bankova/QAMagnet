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
using QAMagnet.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMagnet.Tests.Pages.SinglePostPage
{
    [TestClass]
    public class SinglePostPageTests : BaseQAMagnetTests
    {
        [TestMethod]
        public void VerifySinglePostPageElements()
        {
            this.HomePage.Navigate(CommonTestData.BaseUrlHttps);

            string expectedUrl = CommonTestData.BaseUrlHttps;
            string actualUrl = this.Driver.Url.ToString();
            Assert.AreEqual(expectedUrl, actualUrl);

            this.HomePage.AssertAllPostsSummaryDivIsVisible();
            this.HomePage.FirstArticleTitle.Click();

            this.SinglePostPage.AssertSinglePostDivIsVisible();
            this.SinglePostPage.AssertAddToAnySharePanels();
            this.SinglePostPage.AssertAuthorSlugIsVisible();

            this.SinglePostPage.AssertDisqusComments();
            this.SinglePostPage.AssertSinglePostFooterNav();
            this.SinglePostPage.AssertCategoryLinkIsVisible();

            this.HomePage.AssertTextInHeaderDiv();
            this.HomePage.AssertNavigationMenu();
            this.HomePage.AssertFooter();
            this.HomePage.AssertRightSidebar();
        }
    }
}
