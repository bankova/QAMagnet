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

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Net;
using QAMagnet.Tests;
using QAMagnet.Tests.Common.Pages;
using QAMagnet.Tests.Utilities;

namespace QAMagnet.ResponseStatusCode
{
    ////Contains tests that do not need browser and Driver instance.
    [TestClass]
    public class ResponseStatusCodeTests
    {
        [TestMethod]
        public void VerifyHttpToHttpsRedirectStatusCode()
        {
            WebRequestUtils.AssertWebResponseStatusCode(CommonTestData.BaseUrlHttp, HttpStatusCode.Redirect.ToString());
        }

        [TestMethod]
        public void VerifyWWWToNoWWWRedirectStatusCode()
        {
            WebRequestUtils.AssertWebResponseStatusCode(CommonTestData.BaseUrlHttpsWWW, HttpStatusCode.MovedPermanently.ToString());
        }

        [TestMethod]
        public void VerifyAuthorSlugRedirectStatusCode()
        {
            WebRequestUtils.AssertWebResponseStatusCode(CommonTestData.AuthorUrl, HttpStatusCode.MovedPermanently.ToString());
        }

        [TestMethod]
        public void VerifyHomePageStatusCode()
        {
            WebRequestUtils.AssertWebResponseStatusCode(CommonTestData.BaseUrlHttps, HttpStatusCode.OK.ToString());
        }

        [TestMethod]
        public void VerifyAboutPageStatusCode()
        {
            WebRequestUtils.AssertWebResponseStatusCode(CommonTestData.AboutPageUrl, HttpStatusCode.OK.ToString());
        }

        [TestMethod]
        public void VerifySinglePostStatusCode()
        {
            WebRequestUtils.AssertWebResponseStatusCode(CommonTestData.SinglePostUrl, HttpStatusCode.OK.ToString());
        }

        [TestMethod]
        public void VerifyCategoryPageStatusCode()
        {
            WebRequestUtils.AssertWebResponseStatusCode(CommonTestData.AutomationCategoryUrl, HttpStatusCode.OK.ToString());
        }

        [TestMethod]
        public void VerifyTagPageStatusCode()
        {
            WebRequestUtils.AssertWebResponseStatusCode(CommonTestData.ConferencesTagUrl, HttpStatusCode.OK.ToString());
        }

        [TestMethod]
        public void Verify404PageStatusCode()
        {
            WebRequestUtils.AssertWebResponseStatusCodeErrorPages(CommonTestData.NotExistingPageUrl, HttpStatusCode.NotFound.ToString());
        }

        [TestMethod]
        public void Verify400PageStatusCode()
        {
            WebRequestUtils.AssertWebResponseStatusCodeErrorPages(CommonTestData.BadRequestPageUrl, HttpStatusCode.BadRequest.ToString());
        }

        [TestMethod]
        public void Verify403PageStatusCode_DirectoryBrowsingDisabled()
        {
            WebRequestUtils.AssertWebResponseStatusCodeErrorPages(CommonTestData.ForbiddenAccessDirectoryUrl, HttpStatusCode.Forbidden.ToString());
        }

        [TestMethod]
        public void Verify403PageStatusCode_HtAccess()
        {
            WebRequestUtils.AssertWebResponseStatusCodeErrorPages(CommonTestData.ForbiddenAccessHtAccessUrl, HttpStatusCode.Forbidden.ToString());
        }

        // not found way to simulate error 500
        ////[TestMethod]
        ////public void Verify500PageStatusCode()
        ////{
        ////    WebRequestUtils.AssertWebResponseStatusCodeErrorPages(CommonTestData.ServerErrorPageUrl, HttpStatusCode.InternalServerError.ToString());
        ////}
    }
}
