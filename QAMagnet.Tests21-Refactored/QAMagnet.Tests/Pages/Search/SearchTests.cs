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
    public class SearchTests : BaseQAMagnetTests
    {
        [TestMethod]
        public void VerifySearchIsWorking()
        {
            this.HomePage.Navigate(CommonTestData.BaseUrlHttps);

            string searchedText = "ISTA";
            string expectedUrl = CommonTestData.BaseUrlHttps + "?s=" + searchedText;

            this.HomePage.SearchInput.SendKeys(searchedText);
            this.HomePage.SearchSubmit.Click();

            this.HomePage.AssertCurrentUrlIsExpected(expectedUrl);
            this.HomePage.AssertPostCountIs(2);
        }
    }
}
