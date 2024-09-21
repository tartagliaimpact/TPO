using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1112.Src
{
    class CharactersPage : Page
    {
        String animeAlchemistPageUrl = "https://shikimori.one/animes/z5114-fullmetal-alchemist-brotherhood/characters";

        public IWebElement elementCharacter { get; set; }

        String XpathElementCharacter = "//img[@alt=\"Рой Мустанг\"]";

        public CharactersPage(IWebDriver driver) : base(driver)
        {

                driver.Url = animeAlchemistPageUrl;
        }

        public async Task<IWebDriver> clickCharacter()
        {
            elementCharacter = await base.FindClickableElement(XpathElementCharacter);
            await base.Click(elementCharacter);
            return await Task.FromResult(base.GetDriver());
        }
    }
}
