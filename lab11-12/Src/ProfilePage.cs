using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1112.Src
{
    public class ProfilePage : Page
    {
        String profilePageUrl = "https://shikimori.one/You";
        String profileAnotherPageUrl = "https://shikimori.one/User";
        public IWebElement elementAnime { get; set; }
        public IWebElement elementFavorite { get; set; }
        public IWebElement elementMail { get; set; }
        public IWebElement elementTextMail { get; set; }

        String XpathElementAnime = "//a[text()=\"Список аниме\"]";

        String XpathElementFavorite = "//a[@title=\"Избранное\"]";

        String XpathElementMail = "//a[@original-title=\"Почта\"]";


        String XpathElementTextMail = "//a[@original-title=\"Написать\"]";
        public ProfilePage(IWebDriver driver , bool myuser) : base(driver)
        {
            if (myuser)
            {
                driver.Url = profilePageUrl;
            }
            else
            {
                driver.Url = profileAnotherPageUrl;
            }
        }


        public async Task<IWebDriver> clickToAnimeList()
        {
            elementAnime = await base.FindClickableElement(XpathElementAnime);
            await base.Click(elementAnime);
            return await Task.FromResult(base.GetDriver());
        }

        public async Task<IWebDriver> clickToFavorites()
        {
            elementFavorite = await base
                .FindClickableElement(XpathElementFavorite);
            await base.Click(elementFavorite);
            return await Task.FromResult(base.GetDriver());
        }

        public async Task<IWebDriver> clickToMail()
        {
            elementMail = await base
                .FindClickableElement(XpathElementMail);
            await base.Click(elementMail);
            return await Task.FromResult(base.GetDriver());
        }

        public async Task<IWebDriver> clickToTextMail()
        {
            elementTextMail = await base
                .FindClickableElement(XpathElementTextMail);
            await base.Click(elementTextMail);
            return await Task.FromResult(base.GetDriver());
        }
    }
}
