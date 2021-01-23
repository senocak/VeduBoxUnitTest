using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages {
    class AdminsPage : Page {

        private readonly By INPUT_SEARCH_BOX = By.CssSelector("input[ng-model='filter.$']");
        private readonly By BUTTON_THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By A_DELETE_ADMIN = By.CssSelector("a[ng-click='delete(admin)']");
        private readonly By BUTTON_ADD = By.XPath("//*[@id='mainSection']/div/div[1]/div[2]/div[1]/div[1]/div[2]/div[2]/button");
        private readonly By INPUT_FIRST_NAME = By.CssSelector("input[ng-model='admin.firstName']");
        private readonly By INPUT_LAST_NAME = By.CssSelector("input[ng-model='admin.lastName']");
        private readonly By INPUT_EMAIL = By.CssSelector("input[ng-model='admin.email']");
        private readonly By INPUT_USER_NAME = By.CssSelector("input[ng-model='admin.userName']");
        private readonly By INPUT_PASSWORD = By.XPath("(//input[@ng-model='admin.password'])[2]");
        private readonly By BUTTON_GENERATE = By.CssSelector("button[ng-click='generateRandomPassword()']");
        private readonly By CHECKBOX_GDPR = By.CssSelector("input[ng-model='admin.gdprAccepted']");
        private readonly By BUTTON_SAVE = By.CssSelector("button[type='submit'][form='adminForm']");

        private string USER;

        public AdminsPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public AdminsPage SearchNewlyAddedAdminByName(string name) {
            Type(INPUT_SEARCH_BOX, name);
            Sleepms(1000);
            return this;
        }
        public AdminsPage SearchNewlyAddedAdminByNameAndDeleteIt(string name){
            SearchNewlyAddedAdminByName(name);
            try {
                Click3Points();
            }catch (Exception e){
                Console.WriteLine("Error while clicking 3dots. Looks like there is no record. Returning null." + e.Message);
                return null;
            }
            ClickDeleteButton();
            ClickAreUSure();
            Assert();
            return this;
        }
        public AdminsPage Click3Points(){
            Click(BUTTON_THREE_POINTS);
            return this;
        }
        public AdminsPage ClickDeleteButton() {
            Click(A_DELETE_ADMIN);
            return this;
        }
        public AdminsPage ClickAreUSure(){
            Click(ALERT_ARE_U_SURE_OK);
            return this;
        }
        public AdminsPage Assert() {
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
        public AdminsPage SelectGpdr() {
            if (IsSelected(CHECKBOX_GDPR) == false)
                Click(CHECKBOX_GDPR);
            return this;
        }
        public AdminsPage ClickAddButton(){
            Click(BUTTON_ADD);
            return this;
        }
        public AdminsPage EnterFirstName(string firstName) {
            Type(INPUT_FIRST_NAME, firstName);
            return this;
        }
        public AdminsPage EnterLastName(string lastName) {
            Type(INPUT_LAST_NAME, lastName);
            return this;
        }
        public AdminsPage EnterEmail(string email) {
            Type(INPUT_EMAIL, email);
            return this;
        }
        public AdminsPage EnterUserName(string userName) {
            Type(INPUT_USER_NAME, userName);
            return this;
        }
        public AdminsPage EnterPassword(string password) {
            Type(INPUT_PASSWORD, password);
            return this;
        }

        public AdminsPage ClickGenerate() {
            Click(BUTTON_GENERATE);
            return this;
        }
        public AdminsPage ClickSaveButton() {
            Click(BUTTON_SAVE);
            return this;
        }
    }
}
