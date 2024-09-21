using OpenQA.Selenium;
using sun.security.krb5.@internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
namespace lab1112.Src
{
    public class LoginPage : Page
    {
        String loginPageUrl = "https://shikimori.one/users/sign_in";
        Model.User user = new Model.User("loginname", "password");
        public IWebElement LoginInput { get; set; }
        public IWebElement PasswordInput { get; set; }
        public IWebElement LoginButton { get; set; }
        public IWebElement CapchaCheckBox { get; set; }

        String XpathLoginInput = "//*[@id=\"user_nickname\"]";
        String XpathPasswordInput = "//*[@id=\"user_password\"]";
        String XpathLoginButton = "//input[@type=\"submit\"]";
        


        public LoginPage(IWebDriver driver) : base(driver)
        {
            driver.Url = loginPageUrl;
        }


        public async Task WriteLoginInput()
        {
            LoginInput = await base.FindClickableElement(XpathLoginInput);
            await base.Click(LoginInput);
            await base.SendKeys(LoginInput, this.user.userlogin);
        }

        public async Task WritePasswordInput()
        {
            PasswordInput = await base.FindClickableElement(XpathPasswordInput);
            await base.Click(PasswordInput);
            await base.SendKeys(PasswordInput, this.user.password);
        }

        public async Task<IWebDriver> SignIn()
        {
            LoginButton = await base.FindClickableElement(XpathLoginButton);
            await base.MoveToElement(LoginButton);
            await base.Click(LoginButton);
            return await Task.FromResult(base.GetDriver());
        }

        

         public static string GetCapcha()
         {
            var client = new RestClient("https://api.zenrows.com/v1/?apikey=dd9c0f9ce712c8957e3d72a18d528753c8029c40&url=https%3A%2F%2Fshikimori.one%2Fusers%2Fsign_in&premium_proxy=true&proxy_country=de");
            var request = new RestRequest();

            var response = client.Get(request);
            return response.Content;
         }
    }
}


