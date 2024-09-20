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

namespace lab10.Src
{
    class HomePage
    {
        String homePageUrl = "https://shikimori.one/";
        private IWebDriver driver;
        private WebDriverWait wait;


        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = homePageUrl;
            PageFactory.InitElements(driver, this);
        }


        public IWebElement elementHeader { get; set; }
        public IWebElement elementHeaderSearchDropDownMenuCategoryManga { get; set; }
        public IWebElement elementHeaderSearchInput { get; set; }

        public IWebElement elementDropDownMenu { get; set; }
        public IWebElement elementCalendarCategory {  get; set; }

        String XpathHeader = "//*[@id=\"dashboards_show\"]/header";
        String XpathHeaderSearchDropDownMenuCategoryManga = "//*[@id=\"dashboards_show\"]/header/div[3]/div/div/div/div[2]";
        String XpathHeaderSearchInput = "//*[@id=\"dashboards_show\"]/header/div[3]/label/input";


        String XpathHeaderDropDownMenu = "//*[@id=\"dashboards_show\"]/header/div[1]/div/div";
        String XpathHeaderCalendarCategory = "//*[@id=\"dashboards_show\"]/header/div[1]/div/div/a[11]";



        public void clickHeader()
        {
            elementHeader = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath(XpathHeader)));
            elementHeader.Click();
        }

        public void clickCategory()
        {
            elementHeaderSearchDropDownMenuCategoryManga = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath(XpathHeaderSearchDropDownMenuCategoryManga)));
            elementHeaderSearchDropDownMenuCategoryManga.Click();
        }

        public IWebDriver searchInHomePage(string inputSearch)
        {
            elementHeaderSearchInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(XpathHeaderSearchInput)));
            elementHeaderSearchInput.SendKeys(inputSearch);
            elementHeaderSearchInput.SendKeys(Keys.Enter);
            return driver;
        }

        public void changeHeaderClass()
        {
            elementHeader = driver.FindElement(By.XPath(XpathHeader));
            IJavaScriptExecutor mainHeaderJs = (IJavaScriptExecutor)driver;
            mainHeaderJs.ExecuteScript("arguments[0].className = 'l-top_menu-v2 is-submenu';", elementHeader);
        }

        public void changeMenuClass()
        {
            elementDropDownMenu = driver.FindElement(By.XPath(XpathHeaderDropDownMenu));
            IJavaScriptExecutor mainPagebuttonJs = (IJavaScriptExecutor)driver;
            mainPagebuttonJs.ExecuteScript("arguments[0].className = 'menu-dropdown main active';", elementDropDownMenu);
        }

        public IWebDriver ClickMenuCategory()
        {
            elementCalendarCategory = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(XpathHeaderCalendarCategory)));
            new Actions(driver).MoveToElement(elementCalendarCategory).Perform();
            elementCalendarCategory.Click();
            return driver;
        }


    }
}


