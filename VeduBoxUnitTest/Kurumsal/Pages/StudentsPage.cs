using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class StudentsPage : Page{
        private static string _user;

        private static readonly By ADMIN_ADD_NEW = By.CssSelector("button[ui-sref='veduBox.admin.students.new']");
        private static readonly By INSTRUCTOR_ADD_NEW = By.CssSelector("button[ui-sref='veduBox.teacher.students.new']");
        private static readonly By FIRSTNAME = By.CssSelector("input[ng-model='student.firstName']");
        private static readonly By LASTNAME = By.CssSelector("input[ng-model='student.lastName']");
        private static readonly By BRANCH = By.CssSelector("select[ng-model='student.branchId']");
        private static readonly By EMAIL = By.CssSelector("input[ng-model='student.email']");
        private static readonly By USER_NAME = By.CssSelector("input[ng-model='student.userName']");
        private static readonly By PASSWORD = By.CssSelector("input[ng-model='student.password']");
        private static readonly By DESCRIPTION = By.CssSelector("textarea[ng-model='student.description']");
        private static readonly By EMAIL_CONFIRMED = By.CssSelector("input[ng-model='student.emailConfirmed']");
        private static readonly By GDPR_POLICY = By.CssSelector("input[ng-model='student.gdprAccepted']");
        private static readonly By SUBMIT = By.CssSelector("button[type='submit']:nth-child(1)");
        private static readonly By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static readonly By SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private static readonly By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private static readonly By DELETE_USER = By.CssSelector("a[ng-click='delete(user)']");
        private static readonly By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");

        public StudentsPage(IWebDriver wd, string user) : base(wd){
            _user = user;
        }
        public StudentsPage addNew(){
            if(_user == "admin"){
                click(ADMIN_ADD_NEW);
            }else if(_user == "instructor"){
                click(INSTRUCTOR_ADD_NEW);
            }
            return this;
        }
        public StudentsPage setFirstName(string firstName){
            type(FIRSTNAME, firstName);
            return this;
        }
        public StudentsPage setLastName(string lastName){
            type(LASTNAME, lastName);
            return this;
        }
        public StudentsPage selectBranch(string branchName){
            selectDropDown(BRANCH, branchName);
            return this;
        }
        public StudentsPage setEmail(string email){
            type(EMAIL, email);
            return this;
        }
        public StudentsPage setUserName(string userName){
            type(USER_NAME, userName);
            return this;
        }
        public StudentsPage setPassword(string password){
            type(PASSWORD, password);
            return this;
        }
        public StudentsPage setCatalog(params string[] catalogNames){
            foreach (string catalogName in catalogNames){
                click(By.XPath("//a[contains(text(), '" + catalogName + "')]"));
            }
            return this;
        }
        public StudentsPage setDescription(string description){
            type(DESCRIPTION, description);
            return this;
        }
        public StudentsPage setEmailConfirmed(){
            if (!isSelected(EMAIL_CONFIRMED))
                click(EMAIL_CONFIRMED);
            else
                Console.WriteLine("Already EMAIL_CONFIRMED is selected");
            return this;
        }
        public StudentsPage setGPDRPolicy(){
            if (!isSelected(GDPR_POLICY))
                click(GDPR_POLICY);
            else
                Console.WriteLine("Already GDPR_POLICY is selected");
            return this;
        }
        public StudentsPage submit(){
            click(SUBMIT);
            return this;
        }
        public StudentsPage assert(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }
        public StudentsPage searchNewlyAddedUserByEmail(string email){
            type(SEARCH_BOX, email);
            sleepms(1000);
            return this;
        }
        public StudentsPage searchNewlyAddedUserByEmailAndDeleteIt(string email){
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
        public StudentsPage click3Points(){
            click(THREE_POINTS);
            return this;
        }
        public StudentsPage clickDeleteUserButton(){
            click(DELETE_USER);
            return this;
        }
        public StudentsPage clickAreUSure(){
            click(ARE_U_SURE_OK);
            return this;
        }

    }
}
