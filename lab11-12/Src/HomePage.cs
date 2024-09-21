using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using NUnit.Framework.Legacy;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

namespace lab1112.Src
{
    class HomePage : Page
    {
        String homePageUrl = "https://shikimori.one/";

        public IWebElement elementHeader { get; set; }
        public IWebElement elementHeaderSearchDropDownMenuCategoryManga { get; set; }
        public IWebElement elementHeaderSearchInput { get; set; }

        public IWebElement elementDropDownMenu { get; set; }
        public IWebElement elementCalendarCategory { get; set; }


        public IWebElement elementUser { get; set; }


        String XpathHeader = "//*[@id=\"dashboards_show\"]/header";
        String XpathHeaderSearchDropDownMenuCategoryManga = "//*[@id=\"dashboards_show\"]/header/div[3]/div/div/div/div[2]";
        String XpathHeaderSearchInput = "//*[@id=\"dashboards_show\"]/header/div[3]/label/input";


        String XpathHeaderDropDownMenu = "//*[@id=\"dashboards_show\"]/header/div[1]/div/div";
        String XpathHeaderCalendarCategory = "//*[@id=\"dashboards_show\"]/header/div[1]/div/div/a[11]";
        String XpathUser = "//*[@id=\"dashboards_show\"]/header/div[4]/span/a";





        public HomePage(IWebDriver driver) : base(driver) {
            driver.Url = homePageUrl;
        }

        public async Task Open(string url)
        {
            base.Open(url);
            await Task.CompletedTask; // Для соответствия асинхронному методу
        }
        public async Task clickHeader()
        {
            elementHeader = await base.FindClickableElement(XpathHeader);
            await base.Click(elementHeader);
        }

        public async Task clickCategory()
        {
            elementHeaderSearchDropDownMenuCategoryManga = await base
                .FindClickableElement(XpathHeaderSearchDropDownMenuCategoryManga);
            await base.Click(elementHeaderSearchDropDownMenuCategoryManga);
        }

        public async Task<IWebDriver> searchInHomePage(string inputSearch)
        {
            elementHeaderSearchInput = await base.FindVisibleElement(XpathHeaderSearchInput);
            await base.SendKeys(elementHeaderSearchInput, inputSearch);
            await base.SendKeys(elementHeaderSearchInput, Keys.Enter);
            return await Task.FromResult(base.GetDriver());
        }

        public async Task changeHeaderClass()
        {
            elementHeader = await base.FindElement(XpathHeader);
            await base.ChangeClassName(elementHeader, "l-top_menu-v2 is-submenu");
        }

        public async Task changeMenuClass()
        {
            elementDropDownMenu = await base.FindElement(XpathHeaderDropDownMenu);
            await base.ChangeClassName(elementDropDownMenu, "menu-dropdown main active");
        }

        public async Task<IWebDriver> ClickMenuCategory()
        {
            elementCalendarCategory = await base.FindClickableElement(XpathHeaderCalendarCategory);
            await base.MoveToElement(elementCalendarCategory);
            await base.Click(elementCalendarCategory);
            return await Task.FromResult(base.GetDriver());
        }

        public async Task<IWebDriver> OpenUserProfile()
        {
            elementUser = await base.FindClickableElement(XpathUser);
            await base.MoveToElement(elementUser);
            await base.Click(elementUser);
            return await Task.FromResult(base.GetDriver());
        }

    }
}


