using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1112.Src
{
    public class DialogPage : Page
    {
        String dialogPageUrl = "https://shikimori.one/You/dialogs/User";
        public IWebElement elementTextArea { get; set; }
        public IWebElement elementSendButton { get; set; }

        String XpathElementTextArea = "//textarea[@name=\"message[body]\"]";

        String XpathElementSendButton = "//input[@value=\"Написать\"]";

        string XpathElementMessage;
        public DialogPage(IWebDriver driver) : base(driver)
        {
                driver.Url = dialogPageUrl;
        }

        public async Task<string> typeMessage(string inputText)
        {
            elementTextArea = await base.FindVisibleElement(XpathElementTextArea);
            XpathElementMessage = $"//*[text()=\"{inputText}\"]";
            await base.SendKeys(elementTextArea, inputText);
            elementSendButton = await base.FindClickableElement(XpathElementSendButton);
            await base.Click(elementSendButton);
            return await Task.FromResult(XpathElementMessage);
        }


    }
}
