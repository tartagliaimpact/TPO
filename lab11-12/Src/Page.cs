using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1112.Src
{
    public class Page
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private Logger logger;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            logger = new Logger("LoggerFile.txt");
            logger.Log("Constructor :" + this.driver.Url);
        }

        public async Task Open(string url)
        {
            driver.Navigate().GoToUrl(url);
            logger.Log("Open :" + url);
            await Task.CompletedTask; // Для соответствия асинхронному методу
        }

        public async Task<IWebElement> FindElement(string Xpath)
        {
            logger.Log("FindElement :" + Xpath);
            return await Task.Run(() =>
            {
                return driver.FindElement(By.XPath(Xpath));
            });
        }

        public async Task<IWebElement> FindClickableElement(string Xpath)
        {
            logger.Log("FindClickableElement :" + Xpath);
            return await Task.Run(() =>
            {
                return wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            });
        }

        public async Task<IWebElement> FindVisibleElement(string Xpath)
        {
            logger.Log("FindVisibleElement :" + Xpath);
            return await Task.Run(() =>
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            });
        }

        public async Task Click(IWebElement webElement)
        {
            logger.Log("Click :" + webElement.ToString());
            webElement.Click();
           await Task.CompletedTask;
        }

        public async Task SendKeys(IWebElement webElement, string keys)
        {
            logger.Log("SendKeys :" + keys);
            webElement.SendKeys(keys);
            await Task.CompletedTask;
        }

        public async Task ChangeClassName(IWebElement webElement, string newCssClassName)
        {
            logger.Log("NewClassName :" + newCssClassName);
            IJavaScriptExecutor mainPagebuttonJs = (IJavaScriptExecutor)driver;
            mainPagebuttonJs.ExecuteScript($"arguments[0].className = '{newCssClassName}';", webElement);
            await Task.CompletedTask;
        }
        public async Task MoveToElement(IWebElement webElement)
        {
            logger.Log("MoveTo :" + webElement.ToString());
            new Actions(driver).MoveToElement(webElement).Perform();
            await Task.CompletedTask;
        }



        public IWebDriver GetDriver()
        {
            logger.Log("GetDriver :" + driver.Url);
            return driver;
        }




    }
}
