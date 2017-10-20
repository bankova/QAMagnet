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

namespace QAMagnet.Tests
{
    [TestClass]
    public class UnitTest1
    {
        string baseUrlHttps = "https://qamag.net/";
        string baseUrlHttp = "http://qamag.net/";
        string baseUrlHttpsWWW = "https://www.qamag.net/";

        [TestMethod]
        public void VerifyHttpToHttpsRedirect()
        {
            IWebDriver ffDriver = new FirefoxDriver();
            ffDriver.Navigate().GoToUrl(baseUrlHttp);

            string expectedUrl = baseUrlHttps;
            string actualUrl = ffDriver.Url.ToString();
            Assert.AreEqual(expectedUrl, actualUrl);

            ffDriver.Quit();
        }

        [TestMethod]
        public void VerifyHttpToHttpsRedirectStatusCode()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(baseUrlHttp);
            webRequest.AllowAutoRedirect = false;
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            //Returns "MovedPermanently", not 301 which is what I want.
            string expectedStatus = "Redirect";
            string actualStatus = response.StatusCode.ToString();
            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [TestMethod]
        public void VerifyWWWToNoWWWRedirect()
        {
            IWebDriver ffDriver = new FirefoxDriver();
            ffDriver.Navigate().GoToUrl(baseUrlHttpsWWW);

            string expectedUrl = baseUrlHttps;
            string actualUrl = ffDriver.Url.ToString();
            Assert.AreEqual(expectedUrl, actualUrl);

            ffDriver.Quit();
        }

        [TestMethod]
        public void VerifyWWWToNoWWWRedirectStatusCode()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(baseUrlHttpsWWW);
            webRequest.AllowAutoRedirect = false;
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            //Returns "MovedPermanently", not 301 which is what I want.
            string expectedStatus = "MovedPermanently";
            string actualStatus = response.StatusCode.ToString();
            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [TestMethod]
        public void VerifyHomePageElements()
        {
            IWebDriver ffDriver = new FirefoxDriver();
            ffDriver.Navigate().GoToUrl(baseUrlHttps);

            string expectedUrl = baseUrlHttps;
            string actualUrl = ffDriver.Url.ToString();
            Assert.AreEqual(expectedUrl, actualUrl);

            IWebElement headerText = ffDriver.FindElement(By.ClassName("site-branding"));

            Assert.AreEqual("QA MAGNET Software Quality Assurance Tips And Tricks", headerText.Text);

            IWebElement navigationMenuDiv = ffDriver.FindElement(By.Id("navigation_menu"));
            Assert.IsTrue(navigationMenuDiv.Displayed);
            Assert.AreEqual("QA MAGNET Home About", navigationMenuDiv.Text.Replace(Environment.NewLine.ToString(), " "));

            IWebElement allPostsSummaryDiv = ffDriver.FindElement(By.Id("primary"));
            Assert.IsTrue(allPostsSummaryDiv.Displayed);
            IWebElement firstArticleDiv = allPostsSummaryDiv.FindElement(By.XPath("//article"));
            Assert.IsTrue(firstArticleDiv.Text.Contains("Kristina Bankova"));
            Assert.IsTrue(firstArticleDiv.Text.Contains("Comment"));
            Assert.IsTrue(firstArticleDiv.Text.Contains("Read More"));
            IWebElement authorSlug = firstArticleDiv.FindElement(By.CssSelector("a[href='https://qamag.net/author/kristina-bankova/']"));
            Assert.IsTrue(authorSlug.Displayed);

            IWebElement siteFooter = ffDriver.FindElement(By.ClassName("site-footer"));
            string expectedFooterText = string.Format("Copyright © {0} QA Magnet. All Rights Reserved.", DateTime.Now.Year);
            string actualFooterText = siteFooter.Text;
            Assert.AreEqual(expectedFooterText, actualFooterText);

            IWebElement siteSearch = ffDriver.FindElement(By.ClassName("widget_search"));
            string expectedsiteSearchText = "SEARCH… Search for: Search";
            string actualsiteSearchText = siteSearch.Text.Replace(Environment.NewLine.ToString(), " ");
            Assert.AreEqual(expectedsiteSearchText, actualsiteSearchText);

            IWebElement getUpdatesForm = ffDriver.FindElement(By.ClassName("widget_mc4wp_form_widget"));        
            Assert.IsTrue(getUpdatesForm.Text.Contains("GET THE LATEST UPDATES"));

            IWebElement recentPosts = ffDriver.FindElement(By.ClassName("widget_recent_entries"));
            Assert.IsTrue(recentPosts.Text.Contains("RECENT POSTS"));

            IWebElement categoriesofPosts = ffDriver.FindElement(By.ClassName("widget_categories"));
            Assert.IsTrue(categoriesofPosts.Text.Contains("CATEGORIES"));

            ffDriver.Quit();
        }

        [TestMethod]
        public void VerifySinglePostPageElements()
        {
            IWebDriver ffDriver = new FirefoxDriver();
            ffDriver.Navigate().GoToUrl(baseUrlHttps);

            string expectedUrl = baseUrlHttps;
            string actualUrl = ffDriver.Url.ToString();
            Assert.AreEqual(expectedUrl, actualUrl);

            IWebElement headerText = ffDriver.FindElement(By.ClassName("site-branding"));

            Assert.AreEqual("QA MAGNET Software Quality Assurance Tips And Tricks", headerText.Text);

            IWebElement navigationMenuDiv = ffDriver.FindElement(By.Id("navigation_menu"));
            Assert.IsTrue(navigationMenuDiv.Displayed);
            Assert.AreEqual("QA MAGNET Home About", navigationMenuDiv.Text.Replace(Environment.NewLine.ToString(), " "));

            IWebElement allPostsSummaryDiv = ffDriver.FindElement(By.Id("primary"));
            Assert.IsTrue(allPostsSummaryDiv.Displayed);
            IWebElement firstArticleLink = allPostsSummaryDiv.FindElement(By.XPath("//article//h2/a"));
            firstArticleLink.Click();

            IWebElement singlePostDiv = ffDriver.FindElement(By.Id("main"));
            Assert.IsTrue(singlePostDiv.Displayed);

            IWebElement addToAnySharePanelTop = ffDriver.FindElement(By.ClassName("addtoany_content_top"));
            Assert.IsTrue(addToAnySharePanelTop.Displayed);

            IWebElement addToAnySharePanelBottom = ffDriver.FindElement(By.ClassName("addtoany_content_bottom"));
            Assert.IsTrue(addToAnySharePanelBottom.Displayed);

            IWebElement authorSlug = ffDriver.FindElement(By.XPath("//header//a[@href='https://qamag.net/author/kristina-bankova/']"));
            Assert.IsTrue(authorSlug.Displayed);

            IWebElement categoryLinksSpan = ffDriver.FindElement(By.ClassName("cat-links"));
            Assert.IsTrue(categoryLinksSpan.Displayed);

            IWebElement commentsDiv = ffDriver.FindElement(By.ClassName("post-comments"));
            Assert.IsTrue(commentsDiv.Displayed);

            ((IJavaScriptExecutor)ffDriver).ExecuteScript("arguments[0].scrollIntoView(true);", commentsDiv);
            System.Threading.Thread.Sleep(5000);
            ffDriver.SwitchTo().Frame(ffDriver.FindElement(By.XPath("//iframe[starts-with(@name,'dsq-app')]")));
            IWebElement commentsDivInFrame = ffDriver.FindElement(By.ClassName("community-name"));
            Assert.AreEqual("qamag.net", commentsDivInFrame.Text);
            Assert.IsTrue(commentsDivInFrame.Displayed);
            ffDriver.SwitchTo().DefaultContent();

            IWebElement postNavigationDiv = ffDriver.FindElement(By.ClassName("post-navigation"));
            Assert.IsTrue(postNavigationDiv.Text.Contains("PREVIOUS"));
            Assert.IsTrue(postNavigationDiv.Displayed);

            IWebElement siteFooter = ffDriver.FindElement(By.ClassName("site-footer"));
            string expectedFooterText = string.Format("Copyright © {0} QA Magnet. All Rights Reserved.", DateTime.Now.Year);
            string actualFooterText = siteFooter.Text;
            Assert.AreEqual(expectedFooterText, actualFooterText);

            IWebElement siteSearch = ffDriver.FindElement(By.ClassName("widget_search"));
            string expectedsiteSearchText = "SEARCH… Search for: Search";
            string actualsiteSearchText = siteSearch.Text.Replace(Environment.NewLine.ToString(), " ");
            Assert.AreEqual(expectedsiteSearchText, actualsiteSearchText);

            IWebElement getUpdatesForm = ffDriver.FindElement(By.ClassName("widget_mc4wp_form_widget"));
            Assert.IsTrue(getUpdatesForm.Text.Contains("GET THE LATEST UPDATES"));

            IWebElement recentPosts = ffDriver.FindElement(By.ClassName("widget_recent_entries"));
            Assert.IsTrue(recentPosts.Text.Contains("RECENT POSTS"));

            IWebElement categoriesofPosts = ffDriver.FindElement(By.ClassName("widget_categories"));
            Assert.IsTrue(categoriesofPosts.Text.Contains("CATEGORIES"));

            ffDriver.Quit();
        }
    }

    ////[SetUp]
    ////public void SetupTest()
    ////{
    ////    Driver = WebDriverFactory.GetDriver();
    ////}

    ////[TearDown]
    ////public void TearDown()
    ////{
    ////    if (Driver != null)
    ////        Driver.Quit();
    ////}
}
