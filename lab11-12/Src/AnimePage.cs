using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using com.sun.tools.@internal.ws.wsdl.framework;

namespace lab1112.Src
{
    class AnimePage : Page
    {
        String animeGatariPageUrl = "https://shikimori.one/animes/y5081-bakemonogatari";
        String animeAlchemistPageUrl = "https://shikimori.one/animes/z5114-fullmetal-alchemist-brotherhood";

        public IWebElement elementDropDownMenu { get; set; }
        public IWebElement elementAdd { get; set; }
        public IWebElement elementFavorite { get; set; }
        public IWebElement elementCharacters { get; set; }

        String XpathElementDropDownMenu = "//*[@id=\"animes_show\"]/section/div/div[2]/div/div/div[1]/div[1]/div[1]/div[2]/div/div/form/div[1]/div[1]";
        String XpathElementAdd = "//*[@id=\"animes_show\"]/section/div/div[2]/div/div/div[1]/div[1]/div[1]/div[2]/div/div/form/div[2]/div[6]/div/span";

        String XpathElementFavorite = "//*[@id=\"animes_show\"]/section/div/div[2]/div/div/div[1]/div[1]/div[1]/div[1]/div[2]/div/a[4]";

        String XpathElementCharacters = "//a[@href=\"https://shikimori.one/animes/z5114-fullmetal-alchemist-brotherhood/characters\"]";


        public AnimePage(IWebDriver driver, bool alchmisturl) : base(driver)
        {
            if(alchmisturl)
            {
                driver.Url = animeAlchemistPageUrl;
            }
            else
            {
                driver.Url = animeGatariPageUrl;
            }
        }

        public async Task clickToDropDownMenu()
        {
            elementDropDownMenu = await base.FindClickableElement(XpathElementDropDownMenu);
            await base.Click(elementDropDownMenu);
        }

        public async Task clickAddAnime()
        {
            elementAdd = await base
                .FindClickableElement(XpathElementAdd);
            await base.Click(elementAdd);
        }


        public async Task clickFavorite()
        {
            elementFavorite = await base
                .FindClickableElement(XpathElementFavorite);
            await base.Click(elementFavorite);
        }

        public async Task<IWebDriver> clickCharacters()
        {
            elementCharacters = await base.FindClickableElement(XpathElementCharacters);
            await base.Click(elementCharacters);
            return await Task.FromResult(base.GetDriver());
        }

        //public async Task changeHeaderClass()
        //{
        //    elementHeader = await base.FindElement(XpathHeader);
        //    await base.ChangeClassName(elementHeader, "l-top_menu-v2 is-submenu");
        //}

        //public async Task changeMenuClass()
        //{
        //    elementDropDownMenu = await base.FindElement(XpathHeaderDropDownMenu);
        //    await base.ChangeClassName(elementDropDownMenu, "menu-dropdown main active");
        //}

        //public async Task<IWebDriver> ClickMenuCategory()
        //{
        //    elementCalendarCategory = await base.FindClickableElement(XpathHeaderCalendarCategory);
        //    await base.MoveToElement(elementCalendarCategory);
        //    await base.Click(elementCalendarCategory);
        //    return await Task.FromResult(base.GetDriver());
        //}
    }
}
