using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace lab1112.Src
{
    public class CollectionPage : Page
    {
        String collectionPageUrl = "https://shikimori.one/collections/17903-monogatari";

        public IWebElement elementGrade { get; set; }

        String XpathGrade = "//*[@id=\"562802\"]/div[1]/footer/div/div[3]/div[1]";
        
        public CollectionPage(IWebDriver driver) : base(driver)
        {
            driver.Url = collectionPageUrl;
        }

        public async Task<IWebElement> clickGrade()
        {
            elementGrade = await base.FindClickableElement(XpathGrade);
            await base.Click(elementGrade);
            await base.ChangeClassName(elementGrade, "vote yes selected");
            return await Task.FromResult(elementGrade);
        }




    }
}
