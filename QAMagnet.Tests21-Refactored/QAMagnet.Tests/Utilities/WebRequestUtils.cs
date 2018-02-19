using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QAMagnet.Tests.Utilities
{
    public static class WebRequestUtils
    {
        public static void AssertWebResponseStatusCode(string Url, string expectedStatusCode)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Url);
            webRequest.AllowAutoRedirect = false;
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            string actualStatusCode = response.StatusCode.ToString();
            Assert.AreEqual(expectedStatusCode, actualStatusCode);
        }

        public static void AssertWebResponseStatusCodeErrorPages(string Url, string expectedStatusCode)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Url);
            webRequest.AllowAutoRedirect = false;
            string actualStatusCode = null;

            try
            {
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            }
            catch(WebException ex)
            {
               actualStatusCode = ((HttpWebResponse)ex.Response).StatusCode.ToString();
            }

            Assert.AreEqual(expectedStatusCode, actualStatusCode);
        }
    }
}
