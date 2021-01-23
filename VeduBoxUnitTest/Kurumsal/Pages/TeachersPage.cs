using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;
using VeduBoxUnitTest.Utils;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class TeachersPage : Page {

        private readonly By BUTTON_ADD = By.CssSelector("button[ng-click='select(states.new, null)']");
        private readonly By INPUT_FIRST_NAME = By.CssSelector("input[ng-model='teacher.firstName']");
        private readonly By INPUT_LAST_NAME = By.CssSelector("input[ng-model='teacher.lastName']");
        private readonly By SELECT_BRANCH = By.CssSelector("select[ng-model='teacher.branchId']");
        private readonly By INPUT_EMAIL = By.CssSelector("input[ng-model='teacher.email']");
        private readonly By INPUT_USER_NAME = By.CssSelector("input[ng-model='teacher.userName']");
        private readonly By INPUT_PASSWORD = By.CssSelector("input[ng-model='teacher.password']");
        private readonly By CHECK_GDPR_POLICY = By.CssSelector("input[ng-model='teacher.gdprAccepted']");
        private readonly By BUTTON_SAVE = By.XPath("//*[@id='teacherForm']/div[2]/div/div/button[1]");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private readonly By INPUT_SEARCH_BOX = By.CssSelector("input[ng-model='filter.$']");
        private readonly By BUTTON_THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private readonly By A_ROLES = By.CssSelector("a[ng-click='editRolesForUser(teacher)']");
        private readonly By BUTTON_ROLES_SAVE = By.XPath("/html/body/div[6]/div/div/div/div[2]/form/div/div/div[2]/button[1]");
        private readonly By BUTTON_DELETE_MODERATOR = By.CssSelector("a[ng-click='delete(teacher)']");
        private readonly By CHECK_IS_GUIDANCE_TEACHER = By.CssSelector("input[ng-model='teacher.isGuidanceTeacher']");

        private string USER;
        public TeachersPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public TeachersPage ClickAddButton(){
            Click(BUTTON_ADD);
            return this;
        }
        public TeachersPage EnterFirstName(string firstName){
            Type(INPUT_FIRST_NAME, firstName);
            return this;
        }
        public TeachersPage EnterLastName(string lastName){
            Type(INPUT_LAST_NAME, lastName);
            return this;
        }
        public TeachersPage SelectBranchName(string lastName){
            SelectDropDown(SELECT_BRANCH, lastName);
            return this;
        }
        public TeachersPage EnterEmailName(string email){
            Type(INPUT_EMAIL, email);
            return this;
        }
        public TeachersPage EnterUserNameName(string username){
            Type(INPUT_USER_NAME, username);
            return this;
        }
        public TeachersPage EnterPasswordName(string password){
            Type(INPUT_PASSWORD, password);
            return this;
        }
        public TeachersPage SelectGpdrPolicy(){
            if (IsSelected(CHECK_GDPR_POLICY) == false)
                Click(CHECK_GDPR_POLICY);
            return this;
        }
        public TeachersPage SelectIsGuidanceTeacher() {
            if (IsSelected(CHECK_IS_GUIDANCE_TEACHER) == false)
                Click(CHECK_IS_GUIDANCE_TEACHER);
            return this;
        }
        public TeachersPage ClickSaveButton(){
            Click(BUTTON_SAVE);
            return this;
        }
        public TeachersPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
        public TeachersPage ClickAreYouSure(){
            Click(ALERT_ARE_U_SURE_OK);
            return this;
        }
        public TeachersPage SearchNewlyAddedModeratorByNameAndDeleteIt(string tag){
            SearchNewlyAddedModeratorByName(tag);
            try{
                ClickThreePoints();
            }catch (Exception e){
                Console.WriteLine("Error while clicking 3dots. Looks like there is no record. Returning null." + e.Message);
                return null;
            }
            ClickDeleteInThreePoints();
            ClickAreYouSure();
            Assert();
            return this;
        }
        public TeachersPage SearchNewlyAddedModeratorByName(string tag){
            Type(INPUT_SEARCH_BOX, tag);
            Sleepms(1000);
            return this;
        }
        public TeachersPage ClickThreePoints(){
            Click(BUTTON_THREE_POINTS);
            return this;
        }
        public TeachersPage ClickRolesInThreePoints(){
            Click(A_ROLES);
            return this;
        }
        public TeachersPage SelectRole(string role){
            int id = 1;
            if (role == Constants.Roles.Admin.ToString()) id = 1;
            if (role == Constants.Roles.Manager.ToString()) id = 2;
            if (role == Constants.Roles.Parent.ToString()) id = 3;
            if (role == Constants.Roles.Student.ToString()) id = 4;
            if (role == Constants.Roles.Instructor.ToString()) id = 5;
            Click(By.XPath("/html/body/div[6]/div/div/div/div[2]/form/div/div/div[1]/div[1]/div["+ id + "]/label/input"));
            return this;
        }
        public TeachersPage ClickRoleSaveButton(){
            Click(BUTTON_ROLES_SAVE);
            return this;
        }
        public TeachersPage ClickDeleteInThreePoints(){
            Click(BUTTON_DELETE_MODERATOR);
            return this;
        }
    }
}
