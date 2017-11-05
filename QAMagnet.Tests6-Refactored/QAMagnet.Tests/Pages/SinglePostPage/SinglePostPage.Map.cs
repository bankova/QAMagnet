using OpenQA.Selenium;
using QAMagnet.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMagnet.Tests.Pages.SinglePostPage
{
    public partial class SinglePostPage : BasePage
    {
        public SinglePostPage(IWebDriver driver): base(driver)
        {

        }

        public IWebElement SinglePostDiv
        {
            get
            {
                return this.Driver.FindElement(By.Id("main"));
            }
        }

        public IWebElement PostNavigationDiv
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("post-navigation"));
            }
        }

        public IWebElement AddToAnySharePanelTop
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("addtoany_content_top"));
            }
        }

        public IWebElement AddToAnySharePanelBottom
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("addtoany_content_bottom"));
            }
        }

        public IWebElement AuthorSlug
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//header//a[@href='https://qamag.net/author/kristina-bankova/']"));
            }
        }
            
        public IWebElement CategoryLinksSpan
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("cat-links"));
            }
        }

        public IWebElement CommentsDiv
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("post-comments"));
            }
        }


        public IWebElement DisqusIFrame
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//iframe[starts-with(@name,'dsq-app')]"));
            }
        }

        public IWebElement CommentsDivInFrame
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("community-name"));
            }
        }
    }
}
