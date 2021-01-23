using OpenQA.Selenium;
using System;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class OpenUrl : Page{
        private readonly String DOMAIN = "https://selenium.vedubox.net";
        private readonly String LOGIN = "/pages/login";

        public OpenUrl(IWebDriver wd) : base(wd){}

        public OpenUrl OpenPage(){
            Driver.Url = DOMAIN + LOGIN;
            return this;
        }
        public OpenUrl OpenPage(string url){
            Driver.Url = DOMAIN + url;
            return this;
        }
        public OpenUrl Cikis(){
            Click(By.XPath("//*[@id='top - navbar']/ul[3]/li[5]/a"));
            Click(By.XPath("//*[@id='top - navbar']/ul[3]/li[5]/ul/li[2]/a"));
            return this;
        }
    }
}