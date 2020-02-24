using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace WebPageAutomator
{
    /// <summary>
    /// Webpage handler
    /// </summary>
    public class WebPageHandler : IDisposable
    {
        /// <summary>
        /// Variable for holding url address
        /// </summary>
        private string PageUrlAddress;

        /// <summary>
        /// Selenium webdriver handle
        /// </summary>
        private IWebDriver driver;

        public WebPageHandler(string urlAddress)
        {
            if (String.IsNullOrEmpty(urlAddress))
                throw new ArgumentException("Invalid URL address!", urlAddress);

            PageUrlAddress = urlAddress;
        }

        public void OpenWebBrowser()
        {
            driver = new ChromeDriver();
            driver.Url = PageUrlAddress;
            Thread.Sleep(3000);
        }

        public void EnterTextToControl(string elementName, string textToEnter)
        {
            IWebElement elem1 = driver.FindElement(By.XPath(elementName));
            elem1.SendKeys(textToEnter);
        }

        public void ClickItem(string elementName)
        {
            IWebElement elem1 = driver.FindElement(By.XPath(elementName));
            elem1.Click();
        }

        public string GetText(string elementName)
        {
            IWebElement elem1 = driver.FindElement(By.XPath(elementName));
            return elem1.Text;
        }

        public void CloseWebBrowser()
        {
            driver.Quit();
            driver = null;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    if (driver != null)
                    {
                        driver.Quit();
                        driver = null;
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~WebPageHandler() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);

            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
