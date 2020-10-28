using OpenQA.Selenium;
using System;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages
{
    class UserPage:Page
    {
        private static By ADD_NEW = By.CssSelector("button[ui-sref='veduBox.admin.students.new']");
        private static By FIRSTNAME = By.CssSelector("input[ng-model='student.firstName']");
        private static By LASTNAME = By.CssSelector("input[ng-model='student.lastName']");
        private static By BRANCH = By.CssSelector("select[ng-model='student.branchId']");
        private static By EMAIL = By.CssSelector("input[ng-model='student.email']");
        private static By USER_NAME = By.CssSelector("input[ng-model='student.userName']");
        private static By PASSWORD = By.CssSelector("input[ng-model='student.password']");
        private static By DESCRIPTION = By.CssSelector("textarea[ng-model='student.description']");
        private static By EMAIL_CONFIRMED = By.CssSelector("input[ng-model='student.emailConfirmed']");
        private static By GDPR_POLICY = By.CssSelector("input[ng-model='student.gdprAccepted']");
        private static By SUBMIT = By.CssSelector("button[type='submit']:nth-child(1)");
        private static By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static By SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private static By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private static By DELETE_USER = By.CssSelector("a[ng-click='delete(user)']");
        private static By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        
        private static string _user;
        public UserPage(IWebDriver wd, string user) : base(wd) {
            _user = user;
        }
        public UserPage addNew(){
            click(ADD_NEW);
            return this;
        }
        public UserPage setFirstName(string firstName){
            type(FIRSTNAME, firstName);
            return this;
        }
        public UserPage setLastName(string lastName){
            type(LASTNAME, lastName);
            return this;
        }
        public UserPage selectBranch(string branchName){
            selectDropDown(BRANCH, branchName);
            return this;
        }
        public UserPage setEmail(string email){
            type(EMAIL, email);
            return this;
        }
        public UserPage setUserName(string userName){
            type(USER_NAME, userName);
            return this;
        }
        public UserPage setPassword(string pass){
            type(PASSWORD, pass);
            return this;
        }
        public UserPage setCatalog(string catalogNames){
            string[] names = catalogNames.Split(',');
            foreach (var name in names){
                click(By.XPath("//a[contains(text(), '" + name + "')]"));
            }
            return this;
        }
        public UserPage setDescription(string description){
            type(DESCRIPTION, description);
            return this;
        }
        public UserPage setEmailConfirmed(){
            if (!isSelected(EMAIL_CONFIRMED))
                click(EMAIL_CONFIRMED);
            else
                Console.WriteLine("Already EMAIL_CONFIRMED is selected");
            return this;
        }
        public UserPage setGPDRPolicy(){
            if (!isSelected(GDPR_POLICY))
                click(GDPR_POLICY);
            else
                Console.WriteLine("Already GDPR_POLICY is selected");
            return this;
        }
        public UserPage submit(){
            click(SUBMIT);
            return this;
        }
        public UserPage assert(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }
        public UserPage searchNewlyAddedUserByEmailAndDeleteIt(string email){
            searchNewlyAddedUserByEmail(email);
            try{
                click3Points();
            }catch (Exception e){
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
            clickDeleteUserButton();
            clickAreUSure();
            assert();
            return this;
        }
        public UserPage searchNewlyAddedUserByEmail(string email){
            type(SEARCH_BOX, email);
            sleepms(1000);
            return this;
        }
        public UserPage click3Points(){
            click(THREE_POINTS);
            return this;
        }
        public UserPage clickDeleteUserButton(){
            click(DELETE_USER);
            return this;
        }
        public UserPage clickAreUSure(){
            click(ARE_U_SURE_OK);
            return this;
        }
    }
}
