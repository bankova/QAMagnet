using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using QAMagnet.Tests.Common.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMagnet.Tests.Pages.SinglePostPage
{
    public partial class SinglePostPage : BasePage
    {
        public void AssertSinglePostDivIsVisible()
        {
            Assert.IsTrue(this.SinglePostDiv.Displayed);
        }

        public void AssertSinglePostFooterNav()
        {
            Assert.IsTrue(this.PostNavigationDiv.Text.Contains("PREVIOUS"));
            Assert.IsTrue(this.PostNavigationDiv.Displayed);
        }

        public void AssertAddToAnySharePanels()
        {
            Assert.IsTrue(this.AddToAnySharePanelTop.Displayed);
            Assert.IsTrue(this.AddToAnySharePanelBottom.Displayed);
        }

        public void AssertAuthorSlugIsVisible()
        {
            Assert.IsTrue(this.AuthorSlug.Displayed);
        }

        public void AssertCategoryLinkIsVisible()
        {
            Assert.IsTrue(this.CategoryLinksSpan.Displayed);
        }

        public void AssertDisqusComments()
        {
            Assert.IsTrue(this.CommentsDiv.Displayed);

            ((IJavaScriptExecutor)this.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", this.CommentsDiv);
            System.Threading.Thread.Sleep(5000);
            this.Driver.SwitchTo().Frame(this.DisqusIFrame);
            Assert.AreEqual("qamag.net", this.CommentsDivInFrame.Text);
            Assert.IsTrue(this.CommentsDivInFrame.Displayed);
            this.Driver.SwitchTo().DefaultContent();
        }
    }
}
