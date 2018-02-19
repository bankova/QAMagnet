using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMagnet.Tests.Pages.HomePage
{
    public partial class HomePage
    {
        public void AssertTextInHeaderDiv()
        {
            Assert.AreEqual("QA MAGNET Software Quality Assurance Tips And Tricks", this.HeaderTextDiv.Text);
            Assert.IsTrue(this.HeaderTextDiv.Displayed);
        }

        public void AssertAllPostsSummaryDivIsVisible()
        {
            Assert.IsTrue(this.AllPostsSummaryDiv.Displayed);
        }

        public void AssertNavigationMenu()
        {
            Assert.IsTrue(this.NavigationMenuDiv.Displayed);

            string expected = "QA MAGNET Home About";
            string actual = this.NavigationMenuDiv.Text.Replace(Environment.NewLine.ToString(), " ");

            Assert.AreEqual(expected, actual);
        }

        public void AssertPostCountIs(int expectedCount)
        {
            int actualCount = this.ArticleCount;
            Assert.AreEqual(expectedCount, actualCount);
        }

        public void AssertPostsDiv()
        {
            Assert.IsTrue(this.AllPostsSummaryDiv.Displayed);

            Assert.IsTrue(this.FirstArticleDiv.Text.Contains("Kristina Bankova"));
            Assert.IsTrue(this.FirstArticleDiv.Text.Contains("Comment"));
            Assert.IsTrue(this.FirstArticleDiv.Text.Contains("Read More"));
            
            Assert.IsTrue(this.AuthorSlug.Displayed);
        }

        public void AssertFooter()
        {
            string expectedFooterText = string.Format("Copyright © {0} QA Magnet. All Rights Reserved.", DateTime.Now.Year);
            string actualFooterText = this.SiteFooter.Text;
            Assert.AreEqual(expectedFooterText, actualFooterText);
        }

        public void AssertRightSidebar()
        {
            this.AssertSearchWidget();
            Assert.IsTrue(this.GetUpdatesForm.Text.Contains("GET THE LATEST UPDATES"));
            Assert.IsTrue(this.RecentPosts.Text.Contains("RECENT POSTS"));
            Assert.IsTrue(this.CategoriesofPosts.Text.Contains("CATEGORIES"));
        }

        public void AssertCurrentUrlIsExpected(string expectedUrl = CommonTestData.BaseUrlHttps)
        {
            string actualUrl = this.Driver.Url.ToString();
            Assert.AreEqual(expectedUrl, actualUrl);
        } 

        private void AssertSearchWidget()
        {
            string expectedsiteSearchText = "SEARCH… Search for: Search";
            string actualsiteSearchText = this.SiteSearch.Text.Replace(Environment.NewLine.ToString(), " ");
            Assert.AreEqual(expectedsiteSearchText, actualsiteSearchText);
        }
    }
}
