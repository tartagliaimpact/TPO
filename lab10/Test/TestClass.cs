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
using lab10.Src;

namespace lab10.Test
{
    class TestClass
    {


        IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("D:\\институт\\6-й семестр\\Тестирование программного обеспечения\\lab10\\packages\\Selenium.WebDriver.ChromeDriver.129.0.6668.5800\\driver\\win32");
            driver.Manage().Window.Maximize();
        }


        [Test]
        public void SearchMangaByName()
        {
            HomePage homePage = new HomePage(driver);
            homePage.clickHeader();
            homePage.clickCategory();
            IWebDriver searchPage = homePage.searchInHomePage("Стальной алхимик");
            ClassicAssert.AreEqual("https://shikimori.one/mangas?search=%D0%A1%D1%82%D0%B0%D0%BB%D1%8C%D0%BD%D0%BE%D0%B9%20%D0%B0%D0%BB%D1%85%D0%B8%D0%BC%D0%B8%D0%BA",
                searchPage.Url, "URL страницы не совпадает с ожидаемым.");
        }

        [Test]
        public void GetOngoingList()
        {
            HomePage homePage = new HomePage(driver);
            homePage.changeHeaderClass();
            homePage.changeMenuClass();
            IWebDriver ongoingPage = homePage.ClickMenuCategory();
            ClassicAssert.AreEqual("https://shikimori.one/ongoings", ongoingPage.Url, "URL страницы не совпадает с ожидаемым.");
        }


        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
