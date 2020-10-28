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

        private static By ADD_NEW = By.CssSelector("button[ui-sref='veduBox.teacher.students.new']");
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

        public StudentsPage(IWebDriver wd, string user) : base(wd){
            _user = user;
        }
        public StudentsPage addNew(){
            click(ADD_NEW);
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
        public StudentsPage deleteNewlyAddedUser(){
            click(THREE_POINTS);
            click(DELETE_USER);
            click(ARE_U_SURE_OK);
            return this;
        }

       

    }
}
