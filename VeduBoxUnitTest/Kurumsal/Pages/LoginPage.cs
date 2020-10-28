using OpenQA.Selenium;
using System;

namespace VeduBoxUnitTest.Kurumsal.Pages {
    class LoginPage : Page {

        public static By USERNAME = By.Id("userName");
        public static By PASSWORD = By.Id("password");
        public static By SUBMIT = By.Id("loginLeftLogin");

        public LoginPage(IWebDriver wd) : base(wd){}

        public LoginPage enterUsername(String username){
            type(USERNAME, username);
            return this;
        }
        public LoginPage enterPassword(String pass){
            type(PASSWORD, pass);
            return this;
        }

        public HomePage submit(){
            click(SUBMIT);
            return new HomePage(driver);
        }
    }
}
