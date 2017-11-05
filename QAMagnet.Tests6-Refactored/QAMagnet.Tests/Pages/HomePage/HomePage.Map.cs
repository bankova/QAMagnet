using OpenQA.Selenium;
using QAMagnet.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMagnet.Tests.Pages.HomePage
{
    public partial class HomePage : BasePage
    {
        public HomePage(IWebDriver driver): base(driver)
        {

        }

        public IWebElement HeaderTextDiv
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("site-branding"));
            }
        }

        public IWebElement NavigationMenuDiv
        {
            get
            {
                return this.Driver.FindElement(By.Id("navigation_menu"));
            }
        }

        public IWebElement AllPostsSummaryDiv
        {
            get
            {
                return this.Driver.FindElement(By.Id("primary"));
            }
        }


        public IWebElement FirstArticleDiv
        {
            get
            {
                return this.AllPostsSummaryDiv.FindElement(By.XPath("//article"));
            }
        }

        public IWebElement FirstArticleTitle
        {
            get
            {
                return this.AllPostsSummaryDiv.FindElement(By.XPath("//article//h2/a"));
            }
        }

        public IWebElement AuthorSlug
        {
            get
            {
                return this.FirstArticleDiv.FindElement(By.CssSelector("a[href='https://qamag.net/author/kristina-bankova/']"));
            }
        }

        public IWebElement SiteFooter
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("site-footer"));
            }
        }

        public IWebElement SiteSearch
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("widget_search"));
            }
        }

        public IWebElement GetUpdatesForm
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("widget_mc4wp_form_widget"));
            }
        }

        public IWebElement RecentPosts
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("widget_recent_entries"));
            }
        }

        public IWebElement CategoriesofPosts
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("widget_categories"));
            }
        }
    }
}
