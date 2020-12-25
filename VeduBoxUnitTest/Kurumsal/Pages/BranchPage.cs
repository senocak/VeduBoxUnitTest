using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class BranchPage : Page{
        private static string _user;
        private static readonly By ADD_BUTTON = By.CssSelector("button[ng-click='branch={ id: 0 }']");
        private static readonly By NAME = By.CssSelector("input[ng-model='branch.name']");
        private static readonly By LIMIT = By.CssSelector("input[ng-model='branch.userLimitCount']");
        private static readonly By SAVE_BUTTON = By.CssSelector("button[class='btn btn-default btn-oval mb5'][type='submit']");
        private static readonly By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static readonly By DELETE_BUTTON = By.CssSelector("button[ng-click='delete()']");
        private static readonly By SEARCH_BOX = By.Id("search");
        private static readonly By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");

        public BranchPage(IWebDriver wd, string user) : base(wd){
            _user = user;
        }
        public BranchPage clickAddButton(){
            click(ADD_BUTTON);
            return this;
        }
        public BranchPage enterName(string name){
            type(NAME, name);
            return this;
        }
        public BranchPage enterLimit(int limit){
            type(LIMIT, limit);
            return this;
        }
        public BranchPage clickSaveButton(){
            click(SAVE_BUTTON);
            return this;
        }
        public BranchPage assert(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }
        public BranchPage searchNewlyAddedBranchByNameAndDeleteItAndAssertIt(string name){
            searchNewlyAddedBranchByName(name);
            try{
                selectBranch(name);
            }catch (Exception e){
                Console.WriteLine("Error while selecting branch. Looks like there is no record. Returning null." + e.Message);
                return null;
            }
            deleteNewlyAddedBranch();
            clickAreYouSure();
            assert();
            return this;
        }
        public BranchPage searchNewlyAddedBranchByName(string name){
            type(SEARCH_BOX, name);
            sleepms(1000);
            return this;
        }
        public BranchPage selectBranch(string name){
            click(By.XPath("//a[contains(text(), '" + name + "')]"));
            return this;
        }
        public BranchPage deleteNewlyAddedBranch(){
            click(DELETE_BUTTON);
            return this;
        }
        public BranchPage clickAreYouSure(){
            click(ARE_U_SURE_OK);
            return this;
        }
    }
}
