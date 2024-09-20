using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace webdriver
{
    class TestClass
    {


        IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("D:\\институт\\6-й семестр\\Тестирование программного обеспечения\\lab9\\packages\\Selenium.WebDriver.ChromeDriver.129.0.6668.5800\\driver\\win32");
            driver.Manage().Window.Maximize();
        }


        [Test]
        public void SearchMangaByName()
        {
            driver.Url = "https://shikimori.one/";
            var searchbutton = driver.FindElement(By.XPath("//*[@id=\"dashboards_show\"]/header"));
            searchbutton.Click();
            var searchCategory = driver.FindElement(By.XPath("//*[@id=\"dashboards_show\"]/header/div[3]/div/div/div/div[2]"));
            searchCategory.Click();

            var searchinput = driver.FindElement(By.XPath("//*[@id=\"dashboards_show\"]/header/div[3]/label/input"));
            searchinput.Click();
            searchinput.SendKeys("Стальной алхимик");
            searchinput.SendKeys(Keys.Enter);
            ClassicAssert.AreEqual("https://shikimori.one/mangas?search=%D0%A1%D1%82%D0%B0%D0%BB%D1%8C%D0%BD%D0%BE%D0%B9%20%D0%B0%D0%BB%D1%85%D0%B8%D0%BC%D0%B8%D0%BA", driver.Url, "URL страницы не совпадает с ожидаемым.");
        }

        [Test]
        public void GetOngoingList()
        {
            driver.Url = "https://shikimori.one/";

            var mainHeader = driver.FindElement(By.XPath("//*[@id=\"dashboards_show\"]/header"));
            IJavaScriptExecutor mainHeaderJs = (IJavaScriptExecutor)driver;
            mainHeaderJs.ExecuteScript("arguments[0].className = 'l-top_menu-v2 is-submenu';", mainHeader);

            var mainPagebutton = driver.FindElement(By.XPath("//*[@id=\"dashboards_show\"]/header/div[1]/div/div"));
            IJavaScriptExecutor mainPagebuttonJs = (IJavaScriptExecutor)driver;
            mainPagebuttonJs.ExecuteScript("arguments[0].className = 'menu-dropdown main active';", mainPagebutton);

            var getCalendar = driver.FindElement(By.XPath("//*[@id=\"dashboards_show\"]/header/div[1]/div/div/a[11]"));
            new Actions(driver).MoveToElement(getCalendar).Perform();

            getCalendar.Click();
            ClassicAssert.AreEqual("https://shikimori.one/ongoings", driver.Url, "URL страницы не совпадает с ожидаемым.");
        }


        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
