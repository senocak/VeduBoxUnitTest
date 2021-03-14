using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class WebinarPage : Page{

        private string USER;
        private readonly By INPUT_FIRST_NAME = By.Id("question_first_name");
        private readonly By INPUT_LAST_NAME = By.Id("question_last_name");
        private readonly By INPUT_CONFIRM_EMAIL = By.Id("question_confirm_email");
        private readonly By INPUT_EMAIL = By.Id("question_email");
        private readonly By CHECK_GPDR = By.CssSelector("input[ng-model='isGdprRead']");
        private readonly By CHECK_IS_TERM = By.CssSelector("input[ng-model='isTermRead']");
        private readonly By BUTTON_CREATE_ACCOUNT = By.Id("btnSubmit");
        
        public WebinarPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public WebinarPage EnterFirstName(String username){
            Type(INPUT_FIRST_NAME, username);
            return this;
        }
        public WebinarPage EnterLastName(String name){
            Type(INPUT_LAST_NAME, name);
            return this;
        }
        public WebinarPage EnterConfirmEmail(String confirmMail){
            Type(INPUT_CONFIRM_EMAIL, confirmMail);
            return this;
        }
        public WebinarPage EnterEmail(String mail){
            Type(INPUT_EMAIL, mail);
            return this;
        }
        public WebinarPage SetGpdrPolicy(){
            if (!IsSelected(CHECK_GPDR))
                Click(CHECK_GPDR);
            else
                Console.WriteLine("Already GDPR_POLICY is selected");
            return this;
        }
        public WebinarPage SetAgreePolicy(){
            if (!IsSelected(CHECK_IS_TERM))
                Click(CHECK_IS_TERM);
            else
                Console.WriteLine("Already IS_TERM is selected");
            return this;
        }
        public WebinarPage ClickCreateAccount(){
            Click(BUTTON_CREATE_ACCOUNT);
            return this;
        }
        public WebinarPage AssertEmailSentText(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, By.XPath("//*[contains(text(), 'Webinar Registration Approved')]"));
            return this;
        }
    }
}