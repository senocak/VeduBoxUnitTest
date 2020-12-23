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
        private static readonly By CATALOG_SUBSCRIPTION_DESCRIPTION = By.XPath("/html/body/div[6]/div/div/div/div[2]/div[1]/form/div/div[2]/div/text-angular/div[2]/div[3]");
        private static readonly By CATALOG_SUBSCRIPTION_CURRENCY = By.CssSelector("select[ng-model='packageDetail.currencyTypeId']");
        private static readonly By CATALOG_SUBSCRIPTION_TYPE = By.CssSelector("select[ng-model='packageDetail.packageDetailTypeId']");
        private static readonly By CATALOG_AMOUNT = By.CssSelector("input[ng-model='packageDetail.salePrice']");
        private static readonly By CATALOG_SELL_PRICE = By.CssSelector("input[ng-model='packageDetail.amount']");
        private static readonly By CATALOG_SUBSCRIPTION_BRANCH = By.XPath("/html/body/div[6]/div/div/div/div[2]/div[1]/form/div/div[8]/div[5]/div/div/div[2]/div/ul/li/i");
        private static readonly By CATALOG_SUBSCRIPTION_STUDENT = By.XPath("/html/body/div[6]/div/div/div/div[2]/div[1]/form/div/div[8]/div[5]/div/div/div[2]/div/ul/li/ul/li/a");
        private static readonly By CATALOG_SUBSCRIPTION_PACKAGE_DURATION_TIME = By.CssSelector("input[ng-model='packageDetail.duration']");
        private static readonly By CATALOG_SUBSCRIPTION_PACKAGE_DURATION_TYPE = By.CssSelector("select[ng-model='packageDetail.durationTypeId']");
        private static readonly By CATALOG_SUBSCRIPTION_PACKAGE_SAVE = By.XPath("/html/body/div[6]/div/div/div/div[2]/div[2]/button[1]");
        private static readonly By CATALOG_IS_SHOWN_AT_HOMEPAGE = By.CssSelector("[ng-model='package.isShownAtHomepage']");
        private static readonly By TEMPORARY_START_DATE_SELECT_DATA = By.CssSelector("input[ng-model='packageDetail.startDate']");
        private static readonly By TEMPORARY_END_DATE_SELECT_DATA = By.CssSelector("input[ng-model='packageDetail.endDate']");

        private static readonly By TEMPORARY_START_DATE_OPEN_DATEPICKER = By.CssSelector("button[ng-click*='start']");
        private static readonly By TEMPORARY_END_DATE_OPEN_DATEPICKER = By.CssSelector("button[ng-click*='end']");
        private static readonly By TEMPORARY_START_DATE_CHOOSE_YEAR = By.XPath("(//button[@ng-click='toggleMode()'])[1]");
        private static readonly By TEMPORARY_END_DATE_CHOOSE_YEAR = By.XPath("(//button[@ng-click='toggleMode()'])[2]");
        private static readonly By TEMPORARY_START_DATE_GO_PREVIOUS_YEAR = By.XPath("(//button[@ng-click='move(-1)'])[1]");
        private static readonly By TEMPORARY_END_DATE_GO_PREVIOUS_YEAR = By.XPath("(//button[@ng-click='move(-1)'])[2]");
        private static readonly By TEMPORARY_START_DATE_GO_NEXT_YEAR = By.XPath("(//button[@ng-click='move(1)'])[1]");
        private static readonly By TEMPORARY_END_DATE_GO_NEXT_YEAR = By.XPath("(//button[@ng-click='move(1)'])[2]");
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
        public CatalogPage enterCatalogSubscriptionDescription(string description)
        {
            type(CATALOG_SUBSCRIPTION_DESCRIPTION, description);
            return this;
        }
        public CatalogPage selectCatalogSubscriptionCurrency(string currency){
            selectDropDown(CATALOG_SUBSCRIPTION_CURRENCY, currency);
            return this;
        }
        public CatalogPage enterCatalogSubscriptionPackageAmount(int amount)
        {
            type(CATALOG_AMOUNT, amount);
            return this;
        }
        public CatalogPage enterCatalogSubscriptionPackageSalePrice(int salePrice)
        {
            type(CATALOG_SELL_PRICE, salePrice);
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
        public CatalogPage clickCatalogSubscriptionBranch()
        {
            click(CATALOG_SUBSCRIPTION_BRANCH);
            return this;
        }
        public CatalogPage clickCatalogSubscriptionStudent()
        {
            click(CATALOG_SUBSCRIPTION_STUDENT);
            return this;
        }
        public CatalogPage clickCatalogSubscriptionSaveButton(){
            click(CATALOG_SUBSCRIPTION_PACKAGE_SAVE);
            return this;
        }
        public CatalogPage clickIsShowAtHomePage()
        {
            if (isSelected(CATALOG_IS_SHOWN_AT_HOMEPAGE) == false)
                click(CATALOG_IS_SHOWN_AT_HOMEPAGE);
            return this;
        }
        public CatalogPage setTemporaryStartDate(int yearParam = 0, string monthParam = null, string dayParam = null)
        {
            int year = yearParam == 0 ? Utils.Dates.getCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.getCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.getCurrentDay() : dayParam;

            string getCurrentValueOfInput = getAttribute(TEMPORARY_START_DATE_SELECT_DATA, "value");
            string[] words = getCurrentValueOfInput.Split('/');
            int getCurrentValueOfInputYear = Int32.Parse(words[2]);
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            string getCurrentValueOfInputDay = words[0];

            try
            {
                click(TEMPORARY_START_DATE_OPEN_DATEPICKER);
                Console.WriteLine("clicked start date picker");
                click(TEMPORARY_START_DATE_CHOOSE_YEAR);
                Console.WriteLine("clicked start date choose year");
                if (year != getCurrentValueOfInputYear)
                {
                    if (year < getCurrentValueOfInputYear)
                    {
                        for (int i = getCurrentValueOfInputYear; i > year; i--)
                        {
                            click(TEMPORARY_START_DATE_GO_PREVIOUS_YEAR);

                        }
                    }
                    else
                    {
                        for (int i = getCurrentValueOfInputYear; i < year; i++)
                        {
                            click(TEMPORARY_START_DATE_GO_NEXT_YEAR);

                        }
                    }
                }
                click(By.XPath("//span[contains(text(),'" + month + "')]"));
                Console.WriteLine("clicked start date month " + month + " successfully");
                click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[2]"));
                Console.WriteLine("clicked start date day " + day + " successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Element not found:" + e);
            }
            sleepms(500);
            return this;
        }

        public CatalogPage setTemporaryEndDate(int yearParam = 0, string monthParam = null, string dayParam = null)
        {
            int year = yearParam == 0 ? Utils.Dates.getCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.getCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.getCurrentDay() : dayParam;

            string getCurrentValueOfInput = getAttribute(TEMPORARY_END_DATE_SELECT_DATA, "value");
            string[] words = getCurrentValueOfInput.Split('/');
            int getCurrentValueOfInputYear = Int32.Parse(words[2]);
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            string getCurrentValueOfInputDay = words[0];


            try
            {
                click(TEMPORARY_END_DATE_OPEN_DATEPICKER);
                Console.WriteLine("clicked end date picker");
                click(TEMPORARY_END_DATE_CHOOSE_YEAR);
                Console.WriteLine("clicked start date choose year");
                if (year != getCurrentValueOfInputYear)
                {
                    if (year < getCurrentValueOfInputYear)
                    {
                        for (int i = getCurrentValueOfInputYear; i > year; i--)
                        {
                            click(TEMPORARY_END_DATE_GO_PREVIOUS_YEAR);
                        }
                    }
                    else
                    {
                        for (int i = getCurrentValueOfInputYear; i < year; i++)
                        {
                            click(TEMPORARY_END_DATE_GO_NEXT_YEAR);
                            Console.WriteLine("clicked end date go to next year " + i + " times");
                        }
                    }
                }
                click(By.XPath("//span[contains(text(),'" + month + "')]"));
                Console.WriteLine("clicked end date month " + month + " successfully");
                click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[2]"));

                Console.WriteLine("clicked start date day " + day + " successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Element not found:" + e);
            }
            sleepms(500);
            return this;
        }


    }
}
