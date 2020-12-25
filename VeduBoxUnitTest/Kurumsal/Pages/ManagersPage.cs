using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages
{
    class ManagersPage : Page
    {

        private static readonly By SEARCH_BOX = By.CssSelector("input[ng-model='filter.$']");
        private static readonly By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private static readonly By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private static readonly By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static readonly By DELETE_ADMIN = By.CssSelector("a[ng-click='delete(manager)']");
        private static readonly By ADD_BUTTON = By.XPath("(//button[@ui-sref='veduBox.admin.managers.new'])[1]");
        private static readonly By INPUT_FIRST_NAME = By.CssSelector("input[ng-model='manager.firstName']");
        private static readonly By INPUT_LAST_NAME = By.CssSelector("input[ng-model='manager.lastName']");
        private static readonly By INPUT_EMAIL = By.CssSelector("input[ng-model='manager.email']");
        private static readonly By INPUT_USER_NAME = By.CssSelector("input[ng-model='manager.userName']");
        private static readonly By INPUT_PASSWORD = By.XPath("(//input[@ng-model='manager.password'])[2]");
        private static readonly By GENERATE = By.CssSelector("button[ng-click='generateRandomPassword()']");
        private static readonly By CHECK_GDPR = By.CssSelector("input[ng-model='manager.gdprAccepted']");
        private static readonly By SAVE_BUTTON = By.CssSelector("button[type='submit'][form='managerForm']");
        private static readonly By BRANCH = By.CssSelector("select[ng-model='manager.branch']");


        private static string _user;
        public ManagersPage(IWebDriver wd, string user) : base(wd)
        {
            _user = user;

        }
        public ManagersPage searchNewlyAddedManagerByName(string name)
        {
            type(SEARCH_BOX, name);
            sleepms(1000);
            return this;
        }
        public ManagersPage searchNewlyAddedManagerByNameAndDeleteIt(string name)
        {
            searchNewlyAddedManagerByName(name);
            try
            {
                click3Points();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while clicking 3dots. Looks like there is no record. Returning null." + e.Message);
                return null;
            }
            clickDeleteButton();
            clickAreUSure();
            assert();
            return this;
        }
        public ManagersPage click3Points()
        {
            click(THREE_POINTS);
            return this;
        }
        public ManagersPage clickDeleteButton()
        {
            click(DELETE_ADMIN);
            return this;
        }
        public ManagersPage clickAreUSure()
        {
            click(ARE_U_SURE_OK);
            return this;
        }
        public ManagersPage assert()
        {
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }
        public ManagersPage selectGPDR()
        {
            if (isSelected(CHECK_GDPR) == false)
                click(CHECK_GDPR);
            return this;
        }

        public ManagersPage clickAddButton()
        {
            click(ADD_BUTTON);
            return this;
        }
        public ManagersPage enterFirstName(string first_name)
        {
            type(INPUT_FIRST_NAME, first_name);
            return this;
        }
        public ManagersPage enterLastName(string last_name)
        {
            type(INPUT_LAST_NAME, last_name);
            return this;
        }
        public ManagersPage selectBranchName(string branchName)
        {
            selectDropDown(BRANCH, branchName);
            return this;
        }
        public ManagersPage enterEmail(string email)
        {
            type(INPUT_EMAIL, email);
            return this;
        }
        public ManagersPage enterUserName(string user_name)
        {
            type(INPUT_USER_NAME, user_name);
            return this;
        }
        public ManagersPage enterPassword(string password)
        {
            type(INPUT_PASSWORD, password);
            return this;
        }

        public ManagersPage clickGenerate()
        {
            click(GENERATE);
            return this;
        }
        public ManagersPage clickSaveButton()
        {
            click(SAVE_BUTTON);
            return this;
        }


    
}
}
