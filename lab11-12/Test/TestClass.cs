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
using lab1112.Src;
using System.Threading;
using System.Web.UI.WebControls;
using System.Web.Profile;

namespace lab1112.Test
{
    class TestClass
    {

        BrowserManager browserManager = new BrowserManager();
        IWebDriver driver;
        HomePage HomePage;
        [OneTimeSetUp]
        public async Task startBrowser()
        {
            driver = browserManager.GetDriver("chrome");
            driver.Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage(driver);
            Thread.Sleep(40000);
            await loginPage.WriteLoginInput();
            await loginPage.WritePasswordInput();
            HomePage = new HomePage(await loginPage.SignIn());
            //await HomePage.Open("https://shikimori.one/animes");
        }


        [Test]
        public async Task SearchMangaByName()
        {
            await HomePage.Open("https://shikimori.one/");
            HomePage homePage = new HomePage(HomePage.GetDriver());
            await homePage.clickHeader();
            await homePage.clickCategory();
            IWebDriver searchPage = await homePage.searchInHomePage("Стальной алхимик");
            ClassicAssert.AreEqual("https://shikimori.one/mangas?search=%D0%A1%D1%82%D0%B0%D0%BB%D1%8C%D0%BD%D0%BE%D0%B9%20%D0%B0%D0%BB%D1%85%D0%B8%D0%BC%D0%B8%D0%BA",
                searchPage.Url, "URL страницы не совпадает с ожидаемым.");
        }

        [Test]
        public async Task GetOngoingList()
        {
            await HomePage.Open("https://shikimori.one/");
            HomePage homePage = new HomePage(HomePage.GetDriver());
            await homePage.changeHeaderClass();
            await homePage.changeMenuClass();
            IWebDriver ongoingPage = await homePage.ClickMenuCategory();
            ClassicAssert.AreEqual("https://shikimori.one/ongoings", ongoingPage.Url, "URL страницы не совпадает с ожидаемым.");
        }

        [Test]
        public async Task GradeCollection()
        {
            CollectionPage collectionPage = new CollectionPage(HomePage.GetDriver());
            IWebElement elementGrade = await collectionPage.clickGrade();
            string elementGradeClass = elementGrade.GetAttribute("className");
            ClassicAssert.AreEqual("vote yes selected", elementGradeClass, "Неудача");
        }


        [Test]
        public async Task AddAnimeInFavorites()
        {
            AnimePage animePage = new AnimePage(HomePage.GetDriver(), false);
            await animePage.clickFavorite();
        }

        [Test]
        public async Task AddAnimeinList()
        {
            AnimePage animePage = new AnimePage(HomePage.GetDriver(), false);
            await animePage.clickToDropDownMenu();
            await animePage.clickAddAnime();
        }

        [Test]  
        public async Task GetYourAnimeList()
        {
            await HomePage.Open("https://shikimori.one/");
            ProfilePage profilePage = new ProfilePage(await HomePage.OpenUserProfile(), true);
            IWebDriver listPage = await profilePage.clickToAnimeList();
            ClassicAssert.AreEqual("https://shikimori.one/K+Chara/list/anime", listPage.Url, "URL страницы не совпадает с ожидаемым.");
        }

        [Test]
        public async Task GetAnimeCharecter()
        {
            AnimePage animePage = new AnimePage(HomePage.GetDriver(), true);
            CharactersPage charactersPage = new CharactersPage(await animePage.clickCharacters());
            IWebDriver characterPage = await charactersPage.clickCharacter();
            ClassicAssert.AreEqual("https://shikimori.one/characters/68-roy-mustang", characterPage.Url, "URL страницы не совпадает с ожидаемым.");
        }

        [Test] 
        public async Task GetYourFavorites()
        {
            await HomePage.Open("https://shikimori.one/");
            ProfilePage profilePage = new ProfilePage(await HomePage.OpenUserProfile(), true);
            IWebDriver listPage = await profilePage.clickToFavorites();
            ClassicAssert.AreEqual("https://shikimori.one/You/favorites", listPage.Url, "URL страницы не совпадает с ожидаемым.");

        }

        [Test]
        public async Task SendMessageToUser()
        {
            ProfilePage profilePage = new ProfilePage(HomePage.GetDriver(), false);
            DialogPage mailPage = new DialogPage(await profilePage.clickToTextMail());
            string FinalMessage = await mailPage.typeMessage("Привет!");
            Thread.Sleep(5000);
            ClassicAssert.AreEqual("Привет!", FinalMessage, "Сообщение не отправлено");
        }

        [Test]
        public async Task OpenMail()
        {
            await HomePage.Open("https://shikimori.one/");
            ProfilePage profilePage = new ProfilePage(await HomePage.OpenUserProfile(), true);
            IWebDriver mailPage = await profilePage.clickToMail();
            ClassicAssert.AreEqual("https://shikimori.one/You/dialogs", mailPage.Url, "URL страницы не совпадает с ожидаемым.");
        }

        [OneTimeTearDown]
        public void closeBrowser()
        {
            browserManager.CloseDriver(driver);
            browserManager.QuitDriver(driver);
        }

    }
}
