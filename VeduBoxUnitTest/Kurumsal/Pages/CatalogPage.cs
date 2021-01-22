using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class CatalogPage : Page{
        private readonly By BUTTON_ADD_NEW = By.CssSelector("button[ui-sref='veduBox.admin.packages.detail({id: 0})']");
        private readonly By INPUT_NAME = By.CssSelector("input[ng-model='package.name']");
        private readonly By INPUT_TAGS = By.XPath("//*[@id='packageForm']/div[1]/div[2]/div/div/input");
        private readonly By TEXTAREA_DESCRIPTION = By.CssSelector("textarea[ng-model='package.description']");
        private readonly By BUTTON_SUBMIT = By.CssSelector("button[type='submit']:nth-child(1)");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By INPUT_SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private readonly By BUTTON_THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private readonly By BUTTON_DELETE_CATALOG = By.CssSelector("button[ng-click='delete(package.id)']");
        private readonly By BUTTON_UPDATE_CATALOG = By.CssSelector("button[ui-sref='veduBox.admin.packages.detail({id: package.id})']");
        private readonly By BUTTON_CATALOG_SUBSCRIPTION_ADD = By.CssSelector("button[ng-click='createPackageDetail(package.id,0)']");
        private readonly By INPUT_CATALOG_SUBSCRIPTION_TITLE = By.CssSelector("input[ng-model='packageDetail.title']");
        private readonly By DIV_CATALOG_SUBSCRIPTION_DESCRIPTION = By.XPath("/html/body/div[6]/div/div/div/div[2]/div[1]/form/div/div[2]/div/text-angular/div[2]/div[3]");
        private readonly By SELECT_CATALOG_SUBSCRIPTION_CURRENCY = By.CssSelector("select[ng-model='packageDetail.currencyTypeId']");
        private readonly By SELECT_CATALOG_SUBSCRIPTION_TYPE = By.CssSelector("select[ng-model='packageDetail.packageDetailTypeId']");
        private readonly By INPUT_CATALOG_AMOUNT = By.CssSelector("input[ng-model='packageDetail.salePrice']");
        private readonly By INPUT_CATALOG_SELL_PRICE = By.CssSelector("input[ng-model='packageDetail.amount']");
        private readonly By ICON_JSTREE_CATALOG_SUBSCRIPTION_BRANCH = By.XPath("/html/body/div[6]/div/div/div/div[2]/div[1]/form/div/div[8]/div[5]/div/div/div[2]/div/ul/li/i");
        private readonly By ICON_JSTREE_CATALOG_SUBSCRIPTION_STUDENT = By.XPath("/html/body/div[6]/div/div/div/div[2]/div[1]/form/div/div[8]/div[5]/div/div/div[2]/div/ul/li/ul/li/a");
        private readonly By INPUT_CATALOG_SUBSCRIPTION_PACKAGE_DURATION_TIME = By.CssSelector("input[ng-model='packageDetail.duration']");
        private readonly By SELECT_CATALOG_SUBSCRIPTION_PACKAGE_DURATION_TYPE = By.CssSelector("select[ng-model='packageDetail.durationTypeId']");
        private readonly By BUTTON_CATALOG_SUBSCRIPTION_PACKAGE_SAVE = By.XPath("/html/body/div[6]/div/div/div/div[2]/div[2]/button[1]");
        private readonly By CHECKBOX_CATALOG_IS_SHOWN_AT_HOMEPAGE = By.CssSelector("input[ng-model='package.isShownAtHomepage']");
        private readonly By TEMPORARY_START_DATE_SELECT_DATA = By.CssSelector("input[ng-model='packageDetail.startDate']");
        private readonly By INPUT_TEMPORARY_END_DATE_SELECT_DATA = By.CssSelector("input[ng-model='packageDetail.endDate']");
        private readonly By BUTTON_TEMPORARY_START_DATE_OPEN_DATEPICKER = By.CssSelector("button[ng-click*='start']");
        private readonly By BUTTON_TEMPORARY_END_DATE_OPEN_DATEPICKER = By.CssSelector("button[ng-click*='end']");
        private readonly By BUTTON_TEMPORARY_START_DATE_CHOOSE_YEAR = By.XPath("(//button[@ng-click='toggleMode()'])[1]");
        private readonly By BUTTON_TEMPORARY_END_DATE_CHOOSE_YEAR = By.XPath("(//button[@ng-click='toggleMode()'])[2]");
        private readonly By BUTTON_TEMPORARY_START_DATE_GO_PREVIOUS_YEAR = By.XPath("(//button[@ng-click='move(-1)'])[1]");
        private readonly By BUTTON_TEMPORARY_END_DATE_GO_PREVIOUS_YEAR = By.XPath("(//button[@ng-click='move(-1)'])[2]");
        private readonly By BUTTON_TEMPORARY_START_DATE_GO_NEXT_YEAR = By.XPath("(//button[@ng-click='move(1)'])[1]");
        private readonly By BUTTON_TEMPORARY_END_DATE_GO_NEXT_YEAR = By.XPath("(//button[@ng-click='move(1)'])[2]");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");

        private string USER;
        public CatalogPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public CatalogPage SearchNewlyAddedCatalog(string email){
            Type(INPUT_SEARCH_BOX, email);
            Sleepms(1000);
            return this;
        }
        public CatalogPage ClickAddNew(){
            Click(BUTTON_ADD_NEW);
            return this;
        }
        public CatalogPage EnterName(string name){
            Type(INPUT_NAME, name);
            return this;
        }
        public CatalogPage EnterTags(string tags){
            string[] names = tags.Split(',');
            foreach (var name in names){
                Type(INPUT_TAGS, name + ",");
            }
            return this;
        }
        public CatalogPage EnterDescription(string description){
            Type(TEXTAREA_DESCRIPTION, description);
            return this;
        }
        public CatalogPage Submit(){
            Click(BUTTON_SUBMIT);
            return this;
        }
        public CatalogPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
        public CatalogPage SearchNewlyAddedCatalogAndDeleteIt(string email){
            SearchNewlyAddedCatalog(email);
            try{
                Click3Points();
            }catch (Exception e){
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
            ClickDeleteUserButton();
            ClickAreUSure();
            Assert();
            return this;
        }
        public CatalogPage Click3Points(){
            Click(BUTTON_THREE_POINTS);
            return this;
        }
        public CatalogPage ClickDeleteUserButton(){
            Click(BUTTON_DELETE_CATALOG);
            return this;
        }
        public CatalogPage ClickAreUSure(){
            Click(ALERT_ARE_U_SURE_OK);
            return this;
        }
        public CatalogPage ClickUpdateButton(){
            Click(BUTTON_UPDATE_CATALOG);
            return this;
        }
        public CatalogPage clickCatalogSubscriptionAdd_button(){
            Click(BUTTON_CATALOG_SUBSCRIPTION_ADD);
            return this;
        }
        public CatalogPage EnterCatalogSubscriptionTitle(string title){
            Type(INPUT_CATALOG_SUBSCRIPTION_TITLE, title);
            return this;
        }
        public CatalogPage EnterCatalogSubscriptionDescription(string description) {
            Type(DIV_CATALOG_SUBSCRIPTION_DESCRIPTION, description);
            return this;
        }
        public CatalogPage SelectCatalogSubscriptionCurrency(string currency){
            SelectDropDown(SELECT_CATALOG_SUBSCRIPTION_CURRENCY, currency);
            return this;
        }
        public CatalogPage EnterCatalogSubscriptionPackageAmount(int amount){
            Type(INPUT_CATALOG_AMOUNT, amount);
            return this;
        }
        public CatalogPage EnterCatalogSubscriptionPackageSalePrice(int salePrice){
            Type(INPUT_CATALOG_SELL_PRICE, salePrice);
            return this;
        }
        public CatalogPage SelectCatalogSubscriptionType(string type){
            SelectDropDown(SELECT_CATALOG_SUBSCRIPTION_TYPE, type);
            return this;
        }
        public CatalogPage EnterCatalogSubscriptionPackageDurationTime(string time){
            Type(INPUT_CATALOG_SUBSCRIPTION_PACKAGE_DURATION_TIME, time);
            return this;
        }
        public CatalogPage EnterCatalogSubscriptionPackageDurationType(string durationType){
            SelectDropDown(SELECT_CATALOG_SUBSCRIPTION_PACKAGE_DURATION_TYPE, durationType);
            return this;
        }
        public CatalogPage ClickCatalogSubscriptionBranch() {
            Click(ICON_JSTREE_CATALOG_SUBSCRIPTION_BRANCH);
            Sleepms(15000);
            return this;
        }
        public CatalogPage ClickCatalogSubscriptionStudent() {
            Click(ICON_JSTREE_CATALOG_SUBSCRIPTION_STUDENT);
            return this;
        }
        public CatalogPage ClickCatalogSubscriptionSaveButton(){
            Click(BUTTON_CATALOG_SUBSCRIPTION_PACKAGE_SAVE);
            return this;
        }
        public CatalogPage ClickIsShowAtHomePage(){
            if (IsSelected(CHECKBOX_CATALOG_IS_SHOWN_AT_HOMEPAGE) == false)
                Click(CHECKBOX_CATALOG_IS_SHOWN_AT_HOMEPAGE);
            return this;
        }
        public CatalogPage SetTemporaryStartDate(int yearParam = 0, string monthParam = null, string dayParam = null){
            int year = yearParam == 0 ? Utils.Dates.GetCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.GetCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.GetCurrentDay() : dayParam;

            string getCurrentValueOfInput = GetAttribute(TEMPORARY_START_DATE_SELECT_DATA, "value");
            string[] words = getCurrentValueOfInput.Split('/');
            int getCurrentValueOfInputYear = Int32.Parse(words[2]);
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            string getCurrentValueOfInputDay = words[0];

            try{
                Click(BUTTON_TEMPORARY_START_DATE_OPEN_DATEPICKER);
                Click(BUTTON_TEMPORARY_START_DATE_CHOOSE_YEAR);
                if (year != getCurrentValueOfInputYear){
                    if (year < getCurrentValueOfInputYear){
                        for (int i = getCurrentValueOfInputYear; i > year; i--){
                            Click(BUTTON_TEMPORARY_START_DATE_GO_PREVIOUS_YEAR);
                        }
                    }else{
                        for (int i = getCurrentValueOfInputYear; i < year; i++){
                            Click(BUTTON_TEMPORARY_START_DATE_GO_NEXT_YEAR);
                        }
                    }
                }
                Click(By.XPath("//span[contains(text(),'" + month + "')]"));
                Click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[2]"));
            }catch (Exception e){
                Console.WriteLine("Element not found:" + e.Message);
            }
            Sleepms(500);
            return this;
        }

        public CatalogPage SetTemporaryEndDate(int yearParam = 0, string monthParam = null, string dayParam = null){
            int year = yearParam == 0 ? Utils.Dates.GetCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.GetCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.GetCurrentDay() : dayParam;

            string getCurrentValueOfInput = GetAttribute(INPUT_TEMPORARY_END_DATE_SELECT_DATA, "value");
            string[] words = getCurrentValueOfInput.Split('/');
            int getCurrentValueOfInputYear = Int32.Parse(words[2]);
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            string getCurrentValueOfInputDay = words[0];

            try {
                Click(BUTTON_TEMPORARY_END_DATE_OPEN_DATEPICKER);
                Console.WriteLine("clicked end date picker");
                Click(BUTTON_TEMPORARY_END_DATE_CHOOSE_YEAR);
                Console.WriteLine("clicked start date choose year");
                if (year != getCurrentValueOfInputYear){
                    if (year < getCurrentValueOfInputYear){
                        for (int i = getCurrentValueOfInputYear; i > year; i--){
                            Click(BUTTON_TEMPORARY_END_DATE_GO_PREVIOUS_YEAR);
                        }
                    }else{
                        for (int i = getCurrentValueOfInputYear; i < year; i++) {
                            Click(BUTTON_TEMPORARY_END_DATE_GO_NEXT_YEAR);
                            Console.WriteLine("clicked end date go to next year " + i + " times");
                        }
                    }
                }
                Click(By.XPath("//span[contains(text(),'" + month + "')]"));
                Console.WriteLine("clicked end date month " + month + " successfully");
                Click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[2]"));

                Console.WriteLine("clicked start date day " + day + " successfully");
            }catch (Exception e){
                Console.WriteLine("Element not found:" + e.Message);
            }
            Sleepms(500);
            return this;
        }
    }
}