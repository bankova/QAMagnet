using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMagnet.Tests
{
    public class CommonTestData
    {
        public const string BaseUrlHttps = "https://qamag.net/";
        public const string BaseUrlHttp = "http://qamag.net/";
        public const string BaseUrlHttpsWWW = "https://www.qamag.net/";

        public const string AuthorUrl= BaseUrlHttps + "author/kristina-bankova/";
        public const string AutomationCategoryUrl = BaseUrlHttps + "category/area/automation/";
        public const string ConferencesTagUrl = BaseUrlHttps + "tag/conferences/";
        public const string SinglePostUrl = BaseUrlHttps + "become-quality-assurance-expert/";
        public const string AboutPageUrl = BaseUrlHttps + "about-blog-author-info/";

        public const string BadRequestPageUrl = BaseUrlHttps + "wp-config.php";
        public const string NotExistingPageUrl = BaseUrlHttps + "non-existing-page";
        public const string ForbiddenAccessDirectoryUrl = BaseUrlHttps + "wp-content/";
        public const string ForbiddenAccessHtAccessUrl = BaseUrlHttps + ".htaccess";

        ////public const string ServerErrorPageUrl = NotExistingPageUrl + NotExistingPageUrl;
    }
}
