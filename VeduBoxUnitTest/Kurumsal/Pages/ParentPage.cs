using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages
{
    class ParentPage : Page{
        private static By SEARCH_BOX = By.CssSelector("input[ng-model='filter.$']");
        private static By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private static By DELETE_USER = By.CssSelector("a[ng-click='delete(parent)']");
        private static By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private static By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static By ADD_BUTTON = By.CssSelector("button[ng-click='select(states.new, null)']");
        private static By INPUT_FIRST_NAME = By.CssSelector("input[ng-model='parent.firstName']");
        private static By INPUT_LAST_NAME = By.CssSelector("input[ng-model='parent.lastName']");
        private static By INPUT_EMAIL = By.CssSelector("input[ng-model='parent.email']");
        private static By INPUT_USER_NAME = By.CssSelector("input[ng-model='parent.userName']");
        private static By INPUT_PASSWORD = By.CssSelector("input[ng-model='parent.password']");
        private static By CHECK_GDPR = By.CssSelector("input[ng-model='parent.gdprAccepted']");
        private static By SAVE_BUTTON = By.CssSelector("button[type='submit'][form='parentForm']");
        private static By ROLES_BUTTON = By.CssSelector("a[ng-click='editRolesForUser(parent)']");
        private static By ROLES_SAVE_BUTTON = By.XPath("/html/body/div[6]/div/div/div/div[2]/form/div/div/div[2]/button[1]");
        private static By ADD_ANOTHER_CHILD = By.CssSelector("span[ng-click='children.push(children.length)']");
        private static By FIRST_BRANCH = By.CssSelector("select[ng-model='childrenBranchIds[child]']");
        private static By FIRST_STUDENTS = By.CssSelector("select[ng-model='childrenIds[child]']");
        private static By SECOND_BRANCH = By.XPath("(//select[@ng-model='childrenBranchIds[child]'])[2]");
        private static By SECOND_STUDENTS = By.XPath("(//select[@ng-model='childrenIds[child]'])[2]");
        private static By GENERATE = By.CssSelector("button[ng-click='generateRandomPassword()']");


        private static string _user;
        public ParentPage(IWebDriver wd, string user) : base(wd){
            _user = user;
        }
        public ParentPage searchNewlyAddedParent(string name){
            type(SEARCH_BOX, name);
            sleepms(1000);
            return this;
        }
        public ParentPage searchNewlyAddedParentAndDeleteIt(string name){
            searchNewlyAddedParent(name);
            try{
                click3Points();
            }catch (Exception e){
                Console.WriteLine("Error while clicking 3dots. Looks like there is no record. Returning null." + e.Message);
                return null;
            }
            clickDeleteButton();
            clickAreUSure();
            assert();
            return this;
        }
        public ParentPage click3Points(){
            click(THREE_POINTS);
            return this;
        }
        public ParentPage clickDeleteButton(){
            click(DELETE_USER);
            return this;
        }
        public ParentPage clickAreUSure(){
            click(ARE_U_SURE_OK);
            return this;
        }
        public ParentPage assert(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }
        public ParentPage clickAddButton(){
            click(ADD_BUTTON);
            return this;
        }
        public ParentPage enterFirstName(string first_name){
            type(INPUT_FIRST_NAME, first_name);
            return this;
        }
        public ParentPage enterLastName(string last_name){
            type(INPUT_LAST_NAME, last_name);
            return this;
        }
        public ParentPage clickAnotherChildButton()
        {
            click(ADD_ANOTHER_CHILD);
            return this;
        }

        public ParentPage selectFirstBranchName(string firstBranchName)
        {
            selectDropDown(FIRST_BRANCH, firstBranchName);
            return this;
        }

        public ParentPage selectFirstStudents(string firstStudents)
        {
            selectDropDown(FIRST_STUDENTS, firstStudents);
            return this;
        }

        public ParentPage selectSecondBranchName(string secondBranchName)
        {
            selectDropDown(SECOND_BRANCH, secondBranchName);
            return this;
        }

        public ParentPage selectSecondStudents(string secondStudents)
        {
            selectDropDown(SECOND_STUDENTS, secondStudents);
            return this;
        }
        public ParentPage enterEmail(string email){
            type(INPUT_EMAIL, email);
            return this;
        }
        public ParentPage enterUserName(string user_name){
            type(INPUT_USER_NAME, user_name);
            return this;
        }
        public ParentPage enterPassword(string password){
            type(INPUT_PASSWORD, password);
            return this;
        }
        public ParentPage clickGenerate()
        {
            click(GENERATE);
            return this;
        }
        public ParentPage selectGPDR(){
            if (isSelected(CHECK_GDPR) == false)
                click(CHECK_GDPR);
            return this;
        }
        public ParentPage clickSaveButton(){
            click(SAVE_BUTTON);
            return this;
        }

        public ParentPage clickRolesInThreePoints(){
            click(ROLES_BUTTON);
            return this;
        }
        public ParentPage selectRole(string role){
            int id = 1;
            if (role == "Admin") id = 1;
            if (role == "Manager") id = 2;
            if (role == "Parent") id = 3;
            if (role == "User") id = 4;
            if (role == "Instructor") id = 5;
            click(By.XPath("/html/body/div[6]/div/div/div/div[2]/form/div/div/div[1]/div[1]/div[" + id + "]/label/input"));
            return this;
        }
        public ParentPage clickRoleSaveButton(){
            click(ROLES_SAVE_BUTTON);
            return this;
        }
    }
}
