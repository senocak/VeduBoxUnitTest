using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class WebinarPage : Page{

        private static string _user;
        public static By FIRST_NAME = By.CssSelector("input[ng-model='account.fname']");
        public static By LAST_NAME = By.CssSelector("input[ng-model='account.lname']");
        public static By PHONE_NUMBER = By.CssSelector("input[ng-model='account.phoneNumber']");
        public static By EMAIL = By.CssSelector("input[ng-model='account.email']");
        public static By GPDR = By.CssSelector("input[ng-model='isGdprRead']");
        public static By IS_TERM = By.CssSelector("input[ng-model='isTermRead']");
        public static By CREATE_ACCOUNT = By.CssSelector("button[ng-click='submit()']");
        
        public WebinarPage(IWebDriver wd, string user) : base(wd){
            _user = user;
        }
        public WebinarPage enterFirstName(String username){
            type(FIRST_NAME, username);
            return this;
        }
        public WebinarPage enterLastName(String name){
            type(LAST_NAME, name);
            return this;
        }
        public WebinarPage enterPhoneNumber(String number){
            type(PHONE_NUMBER, number);
            return this;
        }
        public WebinarPage enterEmail(String mail){
            type(EMAIL, mail);
            return this;
        }
        public WebinarPage setGPDRPolicy(){
            if (!isSelected(GPDR))
                click(GPDR);
            else
                Console.WriteLine("Already GDPR_POLICY is selected");
            return this;
        }
        public WebinarPage setAGREEPolicy(){
            if (!isSelected(IS_TERM))
                click(IS_TERM);
            else
                Console.WriteLine("Already IS_TERM is selected");
            return this;
        }
        public WebinarPage clickCreateAccount(){
            click(CREATE_ACCOUNT);
            return this;
        }

        public WebinarPage assertEmailSentText(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, By.XPath("//*[contains(text(), 'The email sent')]"));
            return this;
        }
    }
}
