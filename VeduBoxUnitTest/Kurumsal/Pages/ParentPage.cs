using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;
using VeduBoxUnitTest.Utils;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class ParentPage : Page{

        private readonly By INPUT_SEARCH = By.CssSelector("input[ng-model='filter.$']");
        private readonly By BUTTON_THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private readonly By A_DELETE_USER = By.CssSelector("a[ng-click='delete(parent)']");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By BUTTON_ADD = By.CssSelector("button[ng-click='select(states.new, null)']");
        private readonly By INPUT_FIRST_NAME = By.CssSelector("input[ng-model='parent.firstName']");
        private readonly By INPUT_LAST_NAME = By.CssSelector("input[ng-model='parent.lastName']");
        private readonly By INPUT_EMAIL = By.CssSelector("input[ng-model='parent.email']");
        private readonly By INPUT_USER_NAME = By.CssSelector("input[ng-model='parent.userName']");
        private readonly By INPUT_PASSWORD = By.CssSelector("input[ng-model='parent.password']");
        private readonly By CHECK_GDPR = By.CssSelector("input[ng-model='parent.gdprAccepted']");
        private readonly By BUTTON_SAVE = By.CssSelector("button[type='submit'][form='parentForm']");
        private readonly By BUTTON_ROLES = By.CssSelector("a[ng-click='editRolesForUser(parent)']");
        private readonly By BUTTON_ROLES_SAVE = By.XPath("/html/body/div[6]/div/div/div/div[2]/form/div/div/div[2]/button[1]");
        private readonly By SPAN_ADD_ANOTHER_CHILD = By.CssSelector("span[ng-click='children.push(children.length)']");
        private readonly By SELECT_FIRST_BRANCH = By.CssSelector("select[ng-model='childrenBranchIds[child]']");
        private readonly By SELECT_FIRST_STUDENTS = By.CssSelector("select[ng-model='childrenIds[child]']");
        private readonly By SELECT_SECOND_BRANCH = By.XPath("(//select[@ng-model='childrenBranchIds[child]'])[2]");
        private readonly By SELECT_SECOND_STUDENTS = By.XPath("(//select[@ng-model='childrenIds[child]'])[2]");
        private readonly By BUTTON_GENERATE = By.CssSelector("button[ng-click='generateRandomPassword()']");

        private string USER;
        public ParentPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public ParentPage SearchNewlyAddedParent(string name){
            Type(INPUT_SEARCH, name);
            Sleepms(1000);
            return this;
        }
        public ParentPage SearchNewlyAddedParentAndDeleteIt(string name){
            SearchNewlyAddedParent(name);
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
        public ParentPage Click3Points(){
            Click(BUTTON_THREE_POINTS);
            return this;
        }
        public ParentPage ClickDeleteButton(){
            Click(A_DELETE_USER);
            return this;
        }
        public ParentPage ClickAreUSure(){
            Click(ALERT_ARE_U_SURE_OK);
            return this;
        }
        public ParentPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
        public ParentPage ClickAddButton(){
            Click(BUTTON_ADD);
            return this;
        }
        public ParentPage EnterFirstName(string firstName){
            Type(INPUT_FIRST_NAME, firstName);
            return this;
        }
        public ParentPage EnterLastName(string lastName){
            Type(INPUT_LAST_NAME, lastName);
            return this;
        }
        public ParentPage ClickAnotherChildButton() {
            Click(SPAN_ADD_ANOTHER_CHILD);
            return this;
        }
        public ParentPage SelectFirstBranchName(string firstBranchName) {
            SelectDropDown(SELECT_FIRST_BRANCH, firstBranchName);
            return this;
        }
        public ParentPage SelectFirstStudents(string firstStudents) {
            SelectDropDown(SELECT_FIRST_STUDENTS, firstStudents);
            return this;
        }
        public ParentPage SelectSecondBranchName(string secondBranchName) {
            SelectDropDown(SELECT_SECOND_BRANCH, secondBranchName);
            return this;
        }
        public ParentPage SelectSecondStudents(string secondStudents) {
            SelectDropDown(SELECT_SECOND_STUDENTS, secondStudents);
            return this;
        }
        public ParentPage EnterEmail(string email){
            Type(INPUT_EMAIL, email);
            return this;
        }
        public ParentPage EnterUserName(string userName){
            Type(INPUT_USER_NAME, userName);
            return this;
        }
        public ParentPage EnterPassword(string password){
            Type(INPUT_PASSWORD, password);
            return this;
        }
        public ParentPage ClickGenerate() {
            Click(BUTTON_GENERATE);
            return this;
        }
        public ParentPage SelectGpdr(){
            if (IsSelected(CHECK_GDPR) == false)
                Click(CHECK_GDPR);
            return this;
        }
        public ParentPage ClickSaveButton(){
            Click(BUTTON_SAVE);
            return this;
        }

        public ParentPage ClickRolesInThreePoints(){
            Click(BUTTON_ROLES);
            return this;
        }
        public ParentPage SelectRole(string role){
            int id = 1;
            if (role == Constants.Roles.Admin.ToString()) id = 1;
            if (role == Constants.Roles.Manager.ToString()) id = 2;
            if (role == Constants.Roles.Parent.ToString()) id = 3;
            if (role == Constants.Roles.Student.ToString()) id = 4;
            if (role == Constants.Roles.Instructor.ToString()) id = 5;
            Click(By.XPath("/html/body/div[6]/div/div/div/div[2]/form/div/div/div[1]/div[1]/div[" + id + "]/label/input"));
            return this;
        }
        public ParentPage ClickRoleSaveButton(){
            Click(BUTTON_ROLES_SAVE);
            return this;
        }
    }
}
