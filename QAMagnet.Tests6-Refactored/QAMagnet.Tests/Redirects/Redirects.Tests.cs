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
using QAMagnet.Tests.Common;

namespace QAMagnet.Redirects.Tests
{
    [TestClass]
    public class RedirectsTests : BaseQAMagnetTests
    {
        [TestMethod]
        public void VerifyHttpToHttpsRedirect()
        {
            this.HomePage.Navigate(CommonTestData.BaseUrlHttp);

            string expectedUrl = CommonTestData.BaseUrlHttps;
            string actualUrl = this.Driver.Url.ToString();
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void VerifyWWWToNoWWWRedirect()
        {
            this.HomePage.Navigate(CommonTestData.BaseUrlHttpsWWW);

            string expectedUrl = CommonTestData.BaseUrlHttps;
            string actualUrl = this.Driver.Url.ToString();
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void VerifyHttpToHttpsRedirectStatusCode()
        {
            this.AssertWebResponseStatusCode(CommonTestData.BaseUrlHttp, "Redirect");
        }

        [TestMethod]
        public void VerifyWWWToNoWWWRedirectStatusCode()
        {
            this.AssertWebResponseStatusCode(CommonTestData.BaseUrlHttpsWWW, "MovedPermanently");
        }

        private void AssertWebResponseStatusCode(string Url, string expectedStatusCode)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Url);
            webRequest.AllowAutoRedirect = false;
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            string actualStatusCode = response.StatusCode.ToString();
            Assert.AreEqual(expectedStatusCode, actualStatusCode);
        }
    }
}
