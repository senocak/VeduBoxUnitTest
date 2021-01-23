using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class ManagersPage : Page{

        private readonly By INPUT_SEARCH = By.CssSelector("input[ng-model='filter.$']");
        private readonly By BUTTON_THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By A_DELETE_ADMIN = By.CssSelector("a[ng-click='delete(manager)']");
        private readonly By BUTTON_ADD = By.XPath("(//button[@ui-sref='veduBox.admin.managers.new'])[1]");
        private readonly By INPUT_FIRST_NAME = By.CssSelector("input[ng-model='manager.firstName']");
        private readonly By INPUT_LAST_NAME = By.CssSelector("input[ng-model='manager.lastName']");
        private readonly By INPUT_EMAIL = By.CssSelector("input[ng-model='manager.email']");
        private readonly By INPUT_USER_NAME = By.CssSelector("input[ng-model='manager.userName']");
        private readonly By INPUT_PASSWORD = By.XPath("(//input[@ng-model='manager.password'])[2]");
        private readonly By BUTTON_GENERATE = By.CssSelector("button[ng-click='generateRandomPassword()']");
        private readonly By CHECK_GDPR = By.CssSelector("input[ng-model='manager.gdprAccepted']");
        private readonly By BUTTON_SAVE = By.CssSelector("button[type='submit'][form='managerForm']");
        private readonly By SELECT_BRANCH = By.CssSelector("select[ng-model='manager.branch']");

        private string USER;
        public ManagersPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public ManagersPage SearchNewlyAddedManagerByName(string name){
            Type(INPUT_SEARCH, name);
            Sleepms(1000);
            return this;
        }
        public ManagersPage SearchNewlyAddedManagerByNameAndDeleteIt(string name){
            SearchNewlyAddedManagerByName(name);
            try{
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
        public ManagersPage Click3Points(){
            Click(BUTTON_THREE_POINTS);
            return this;
        }
        public ManagersPage ClickDeleteButton(){
            Click(A_DELETE_ADMIN);
            return this;
        }
        public ManagersPage ClickAreUSure(){
            Click(ALERT_ARE_U_SURE_OK);
            return this;
        }
        public ManagersPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
        public ManagersPage SelectGpdr(){
            if (IsSelected(CHECK_GDPR) == false)
                Click(CHECK_GDPR);
            return this;
        }
        public ManagersPage ClickAddButton(){
            Click(BUTTON_ADD);
            return this;
        }
        public ManagersPage EnterFirstName(string firstName){
            Type(INPUT_FIRST_NAME, firstName);
            return this;
        }
        public ManagersPage EnterLastName(string lastName){
            Type(INPUT_LAST_NAME, lastName);
            return this;
        }
        public ManagersPage SelectBranchName(string branchName){
            SelectDropDown(SELECT_BRANCH, branchName);
            return this;
        }
        public ManagersPage EnterEmail(string email){
            Type(INPUT_EMAIL, email);
            return this;
        }
        public ManagersPage EnterUserName(string userName){
            Type(INPUT_USER_NAME, userName);
            return this;
        }
        public ManagersPage EnterPassword(string password){
            Type(INPUT_PASSWORD, password);
            return this;
        }
        public ManagersPage ClickGenerate(){
            Click(BUTTON_GENERATE);
            return this;
        }
        public ManagersPage ClickSaveButton(){
            Click(BUTTON_SAVE);
            return this;
        }
    }
}