using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class TeachersPage : Page
    {
        private static By ADD_BUTTON = By.CssSelector("button[ng-click='select(states.new, null)']");
        private static By FIRST_NAME = By.CssSelector("input[ng-model='teacher.firstName']");
        private static By LAST_NAME = By.CssSelector("input[ng-model='teacher.lastName']");
        private static By BRANCH = By.CssSelector("select[ng-model='teacher.branchId']");
        private static By EMAIL = By.CssSelector("input[ng-model='teacher.email']");
        private static By USER_NAME = By.CssSelector("input[ng-model='teacher.userName']");
        private static By PASSWORD = By.CssSelector("input[ng-model='teacher.password']");
        private static By GDPR_POLICY = By.CssSelector("input[ng-model='teacher.gdprAccepted']");
        private static By SAVE_BUTTON = By.XPath("//*[@id='teacherForm']/div[2]/div/div/button[1]");
        private static By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private static By SEARCH_BOX = By.CssSelector("input[ng-model='filter.$']");
        private static By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private static By ROLES = By.CssSelector("a[ng-click='editRolesForUser(teacher)']");
        private static By ROLES_SAVE_BUTTON = By.XPath("/html/body/div[6]/div/div/div/div[2]/form/div/div/div[2]/button[1]");
        private static By DELETE_MODERATOR = By.CssSelector("a[ng-click='delete(teacher)']");
        private static By IS_GUIDANCE_TEACHER = By.CssSelector("input[ng-model='teacher.isGuidanceTeacher']");

        private static string _user;
        public TeachersPage(IWebDriver wd, string user) : base(wd){
            _user = user;
        }
        public TeachersPage clickAddButton(){
            click(ADD_BUTTON);
            return this;
        }
        public TeachersPage enterFirstName(string first_name){
            type(FIRST_NAME, first_name);
            return this;
        }
        public TeachersPage enterLastName(string last_name){
            type(LAST_NAME, last_name);
            return this;
        }
        public TeachersPage selectBranchName(string last_name){
            selectDropDown(BRANCH, last_name);
            return this;
        }
        public TeachersPage enterEmailName(string email){
            type(EMAIL, email);
            return this;
        }
        public TeachersPage enterUserNameName(string username){
            type(USER_NAME, username);
            return this;
        }
        public TeachersPage enterPasswordName(string password){
            type(PASSWORD, password);
            return this;
        }
        public TeachersPage selectGPDRPolicy(){
            if (isSelected(GDPR_POLICY) == false)
                click(GDPR_POLICY);
            return this;
        }
        public TeachersPage selectIsGuidanceTeacher()
        {
            if (isSelected(IS_GUIDANCE_TEACHER) == false)
                click(IS_GUIDANCE_TEACHER);
            return this;
        }
        public TeachersPage clickSaveButton(){
            click(SAVE_BUTTON);
            return this;
        }
        public TeachersPage assert(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }
        public TeachersPage clickAreYouSure(){
            click(ARE_U_SURE_OK);
            return this;
        }
        public TeachersPage searchNewlyAddedModeratorByNameAndDeleteIt(string tag){
            searchNewlyAddedModeratorByName(tag);
            try{
                clickThreePoints();
            }catch (Exception e){
                Console.WriteLine("Error while clicking 3dots. Looks like there is no record. Returning null." + e.Message);
                return null;
            }
            clickDeleteInThreePoints();
            clickAreYouSure();
            assert();
            return this;
        }
        public TeachersPage searchNewlyAddedModeratorByName(string tag){
            type(SEARCH_BOX, tag);
            sleepms(1000);
            return this;
        }
        public TeachersPage clickThreePoints(){
            click(THREE_POINTS);
            return this;
        }
        public TeachersPage clickRolesInThreePoints(){
            click(ROLES);
            return this;
        }
        public TeachersPage selectRole(string role){
            int id = 1;
            if (role == "Admin") id = 1;
            if (role == "Manager") id = 2;
            if (role == "Parent") id = 3;
            if (role == "User") id = 4;
            if (role == "Instructor") id = 5;
            click(By.XPath("/html/body/div[6]/div/div/div/div[2]/form/div/div/div[1]/div[1]/div["+ id + "]/label/input"));
            return this;
        }
        public TeachersPage clickRoleSaveButton(){
            click(ROLES_SAVE_BUTTON);
            return this;
        }
        public TeachersPage clickDeleteInThreePoints(){
            click(DELETE_MODERATOR);
            return this;
        }
    }
}
