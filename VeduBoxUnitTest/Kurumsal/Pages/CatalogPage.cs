using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class CatalogPage : Page{
        private static By ADD_NEW = By.CssSelector("button[ui-sref='veduBox.admin.packages.detail({id: 0})']");
        private static By NAME = By.CssSelector("input[ng-model='package.name']");
        private static By TAGS = By.XPath("//*[@id='packageForm']/div[1]/div[2]/div/div/input");
        private static By DESCRIPTION = By.CssSelector("textarea[ng-model='package.description']");
        private static By SUBMIT = By.CssSelector("button[type='submit']:nth-child(1)");
        private static By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static By SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private static By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private static By DELETE_CATALOG = By.CssSelector("button[ng-click='delete(package.id)']");
        private static By UPDATE_CATALOG = By.CssSelector("button[ui-sref='veduBox.admin.packages.detail({id: package.id})']");
        private static By CATALOG_SUBSCRIPTION_ADD = By.CssSelector("button[ng-click='createPackageDetail(package.id,0)']");
        private static By CATALOG_SUBSCRIPTION_TITLE= By.CssSelector("input[ng-model='packageDetail.title']");
        private static By CATALOG_SUBSCRIPTION_CURRENCY = By.CssSelector("select[ng-model='packageDetail.currencyTypeId']");
        private static By CATALOG_SUBSCRIPTION_TYPE = By.CssSelector("select[ng-model='packageDetail.packageDetailTypeId']");
        private static By CATALOG_SUBSCRIPTION_PACKAGE_DURATION_TIME = By.CssSelector("input[ng-model='packageDetail.duration']");
        private static By CATALOG_SUBSCRIPTION_PACKAGE_DURATION_TYPE = By.CssSelector("select[ng-model='packageDetail.durationTypeId']");
        private static By CATALOG_SUBSCRIPTION_PACKAGE_SAVE= By.XPath("/html/body/div[6]/div/div/div/div[2]/div[2]/button[1]");


        private static By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");

        private static string _user;
        public CatalogPage(IWebDriver wd, string user) : base(wd){
            _user = user;
        }
        public CatalogPage searchNewlyAddedCatalog(string email){
            type(SEARCH_BOX, email);
            sleepms(1000);
            return this;
        }
        public CatalogPage clickAddNew(){
            click(ADD_NEW);
            return this;
        }
        public CatalogPage enterName(string name){
            type(NAME, name);
            return this;
        }
        public CatalogPage enterTags(string tags){
            string[] names = tags.Split(',');
            foreach (var name in names){
                type(TAGS, name + ",");
            }
            return this;
        }
        public CatalogPage enterDescription(string description){
            type(DESCRIPTION, description);
            return this;
        }
        public CatalogPage submit(){
            click(SUBMIT);
            return this;
        }
        public CatalogPage assert(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }
        public CatalogPage searchNewlyAddedCatalogAndDeleteIt(string email){
            searchNewlyAddedCatalog(email);
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
        public CatalogPage click3Points(){
            click(THREE_POINTS);
            return this;
        }
        public CatalogPage clickDeleteUserButton(){
            click(DELETE_CATALOG);
            return this;
        }
        public CatalogPage clickAreUSure(){
            click(ARE_U_SURE_OK);
            return this;
        }
        public CatalogPage clickUpdateButton(){
            click(UPDATE_CATALOG);
            return this;
        }
        public CatalogPage clickCatalogSubscriptionAdd_button(){
            click(CATALOG_SUBSCRIPTION_ADD);
            return this;
        }
        public CatalogPage enterCatalogSubscriptionTitle(string title){
            type(CATALOG_SUBSCRIPTION_TITLE, title);
            return this;
        }
        public CatalogPage selectCatalogSubscriptionCurrency(string currency){
            selectDropDown(CATALOG_SUBSCRIPTION_CURRENCY, currency);
            return this;
        }
        public CatalogPage selectCatalogSubscriptionType(string type){
            selectDropDown(CATALOG_SUBSCRIPTION_TYPE, type);
            return this;
        }
        public CatalogPage enterCatalogSubscriptionPackageDurationTime(string time){
            type(CATALOG_SUBSCRIPTION_PACKAGE_DURATION_TIME, time);
            return this;
        }
        public CatalogPage enterCatalogSubscriptionPackageDurationType(string duration_type){
            selectDropDown(CATALOG_SUBSCRIPTION_PACKAGE_DURATION_TYPE, duration_type);
            return this;
        }
        public CatalogPage clickCatalogSubscriptionSaveButton(){
            click(CATALOG_SUBSCRIPTION_PACKAGE_SAVE);
            return this;
        }
    }
}
