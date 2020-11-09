using OpenQA.Selenium;
using System;

namespace VeduBoxUnitTest.Kurumsal.Pages
{
    class OpenURL : Page
    {
        private static String DOMAIN = "https://selenium.vedubox.net";
        private static String LOGIN = "/pages/login";

        public OpenURL(IWebDriver wd) : base(wd){}

        public OpenURL openPage(){
            driver.Url = DOMAIN + LOGIN;
            return this;
        }
        public OpenURL openPage(string url){
            driver.Url = DOMAIN + url;
            return this;
        }

        public OpenURL cikis(){
            click(By.XPath("//*[@id='top - navbar']/ul[3]/li[5]/a"));
            click(By.XPath("//*[@id='top - navbar']/ul[3]/li[5]/ul/li[2]/a"));
            return this;
        }
    }
}
