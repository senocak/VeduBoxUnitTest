using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages
{
    class AdminsPage : Page
    {

        private static By SEARCH_BOX = By.CssSelector("input[ng-model='filter.$']");
        private static By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private static By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private static By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static By DELETE_ADMIN = By.CssSelector("a[ng-click='delete(admin)']");
        private static By ADD_BUTTON = By.XPath("//*[@id='mainSection']/div/div[1]/div[2]/div[1]/div[1]/div[2]/div[2]/button");
        private static By INPUT_FIRST_NAME = By.CssSelector("input[ng-model='admin.firstName']");
        private static By INPUT_LAST_NAME = By.CssSelector("input[ng-model='admin.lastName']");
        private static By INPUT_EMAIL = By.CssSelector("input[ng-model='admin.email']");
        private static By INPUT_USER_NAME = By.CssSelector("input[ng-model='admin.userName']");
        private static By INPUT_PASSWORD = By.XPath("(//input[@ng-model='admin.password'])[2]");
        private static By GENERATE = By.CssSelector("button[ng-click='generateRandomPassword()']");
        private static By CHECK_GDPR = By.CssSelector("input[ng-model='admin.gdprAccepted']");
        private static By SAVE_BUTTON = By.CssSelector("button[type='submit'][form='adminForm']");


        private static string _user;

        public AdminsPage(IWebDriver wd, string user) : base(wd)
        {
            _user = user;
        }

        public AdminsPage searchNewlyAddedAdminByName(string name)
        {
            type(SEARCH_BOX, name);
            sleepms(1000);
            return this;
        }
        public AdminsPage searchNewlyAddedAdminByNameAndDeleteIt(string name)
        {
            searchNewlyAddedAdminByName(name);
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
        public AdminsPage click3Points()
        {
            click(THREE_POINTS);
            return this;
        }
        public AdminsPage clickDeleteButton()
        {
            click(DELETE_ADMIN);
            return this;
        }
        public AdminsPage clickAreUSure()
        {
            click(ARE_U_SURE_OK);
            return this;
        }
        public AdminsPage assert()
        {
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }
        public AdminsPage selectGPDR()
        {
            if (isSelected(CHECK_GDPR) == false)
                click(CHECK_GDPR);
            return this;
        }

        public AdminsPage clickAddButton()
        {
            click(ADD_BUTTON);
            return this;
        }
        public AdminsPage enterFirstName(string first_name)
        {
            type(INPUT_FIRST_NAME, first_name);
            return this;
        }
        public AdminsPage enterLastName(string last_name)
        {
            type(INPUT_LAST_NAME, last_name);
            return this;
        }
        public AdminsPage enterEmail(string email)
        {
            type(INPUT_EMAIL, email);
            return this;
        }
        public AdminsPage enterUserName(string user_name)
        {
            type(INPUT_USER_NAME, user_name);
            return this;
        }
        public AdminsPage enterPassword(string password)
        {
            type(INPUT_PASSWORD, password);
            return this;
        }

        public AdminsPage clickGenerate()
        {
            click(GENERATE);
            return this;
        }
        public AdminsPage clickSaveButton()
        {
            click(SAVE_BUTTON);
            return this;
        }


    }
}
