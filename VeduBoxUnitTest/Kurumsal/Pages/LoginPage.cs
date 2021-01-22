using OpenQA.Selenium;
using System;

namespace VeduBoxUnitTest.Kurumsal.Pages {
    class LoginPage : Page {

        public readonly By InputUsername = By.Id("userName");
        public readonly By InputPassword = By.Id("password");
        public readonly By ButtonSubmit = By.Id("loginLeftLogin");

        public LoginPage(IWebDriver wd) : base(wd){}

        public LoginPage EnterUsername(String username){
            Type(InputUsername, username);
            return this;
        }
        public LoginPage EnterPassword(String pass){
            Type(InputPassword, pass);
            return this;
        }
        public HomePage Submit(){
            Click(ButtonSubmit);
            return new HomePage(Driver);
        }
    }
}