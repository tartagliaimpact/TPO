using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;

namespace lab1112
{
    public class BrowserManager
    {
        public BrowserManager() { }
        public IWebDriver GetDriver(string browserName)
        {

            IWebDriver driver;
            string driverPath = "D:\\институт\\6-й семестр\\Тестирование программного обеспечения\\lab1112\\packages\\Selenium.WebDriver.ChromeDriver.129.0.6668.5800\\driver\\win32";
            var service = ChromeDriverService.CreateDefaultService(driverPath);

            switch (browserName.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver(service);
                    break;
                default:
                    throw new NotSupportedException($"Unsupported browser: {browserName}");
            }

            return driver;
        }
        public void CloseDriver(IWebDriver driver)
        {
            if (driver != null)
            {
                driver.Close();
            }
        }
        public void QuitDriver(IWebDriver driver)
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
