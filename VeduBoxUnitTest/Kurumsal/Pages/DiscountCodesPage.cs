using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class DiscountCodesPage : Page{
        private string USER;
        private readonly By BUTTON_ADD_NEW = By.CssSelector("button[ui-sref='veduBox.admin.discountCodes.new']");
        private readonly By SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private readonly By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private readonly By DELETE_CODE= By.CssSelector("button[ng-click='delete(discountCode)']");
        private readonly By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private readonly By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By INPUT_CODE = By.CssSelector("input[ng-model='discountCode.code']");
        private readonly By INPUT_DESCRIPTION = By.CssSelector("textarea[ng-model='discountCode.description']");
        private readonly By INPUT_PERCENTAGE = By.CssSelector("input[ng-model='discountCode.discountPercentage']");
        private readonly By CHECKBOX_IS_LIMITED = By.XPath("//*[@id='discountCodeForm']/div[1]/div[6]/div/label/span");
        private readonly By INPUT_LIMIT = By.CssSelector("input[ng-model='discountCode.limit']");

        private readonly By INPUT_START_DATE_TEXTBOX = By.CssSelector("input[ng-model='startDate']");
        private readonly By BUTTON_START_DATE_PICKER = By.CssSelector("button[ng-click='startDatePicker($event)']");
        private readonly By BUTTON_START_DATE_CHOOSE_YEAR = By.XPath("/html/body/div[3]/div/section/div/div[1]/div[3]/div/div/div[2]/form/div[1]/div[8]/div/p/ul/li[1]/div/table/thead/tr[1]/th[2]/button");
        private readonly By BUTTON_START_DATE_PREVIOUS_YEAR = By.XPath("//*[@id='discountCodeForm']/div[1]/div[8]/div/p/ul/li[1]/div/table/thead/tr[1]/th[1]/button");
        private readonly By BUTTON_START_DATE_NEXT_YEAR = By.XPath("//*[@id='discountCodeForm']/div[1]/div[8]/div/p/ul/li[1]/div/table/thead/tr[1]/th[3]/button");

        private readonly By INPUT_END_DATE_TEXTBOX = By.CssSelector("input[ng-model='endDate']");
        private readonly By BUTTON_END_DATE_PICKER = By.CssSelector("button[ng-click='endDatePicker($event)']");
        private readonly By BUTTON_END_DATE_CHOOSE_YEAR = By.XPath("/html/body/div[3]/div/section/div/div[1]/div[3]/div/div/div[2]/form/div[1]/div[9]/div/p/ul/li[1]/div/table/thead/tr[1]/th[2]/button");
        private readonly By BUTTON_END_DATE_PREVIOUS_YEAR = By.XPath("//*[@id='discountCodeForm']/div[1]/div[9]/div/p/ul/li[1]/div/table/thead/tr[1]/th[1]/button");
        private readonly By BUTTON_END_DATE_NEXT_YEAR = By.XPath("//*[@id='discountCodeForm']/div[1]/div[9]/div/p/ul/li[1]/div/table/thead/tr[1]/th[3]/button");
        private readonly By BUTTON_SAVE = By.XPath("//*[@id='discountCodeForm']/div[2]/button[1]");

        public DiscountCodesPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public DiscountCodesPage SearchNewlyAddedDiscountCodeByNameAndDeleteIt(string name){
            SearchNewlyAddedDiscountCodeByName(name);
            try{
                Click3Points();
            }catch (Exception e){
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
            ClickDeleteCodeButton();
            ClickAreUSure();
            Assert();
            return this;
        }
        public DiscountCodesPage SearchNewlyAddedDiscountCodeByName(string tag){
            Type(SEARCH_BOX, tag);
            Sleepms(1000);
            return this;
        }
        public DiscountCodesPage Click3Points(){
            Click(THREE_POINTS);
            return this;
        }
        public DiscountCodesPage ClickDeleteCodeButton(){
            Click(DELETE_CODE);
            return this;
        }
        public DiscountCodesPage ClickAreUSure(){
            Click(ARE_U_SURE_OK);
            return this;
        }
        public DiscountCodesPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, SUCCESS);
            return this;
        }
        public DiscountCodesPage ClickAddNew(){
            Click(BUTTON_ADD_NEW);
            return this;
        }
        public DiscountCodesPage EnterCode(string code){
            Type(INPUT_CODE, code);
            return this;
        }
        public DiscountCodesPage EnterDescription(string desc){
            Type(INPUT_DESCRIPTION, desc);
            return this;
        }
        public DiscountCodesPage EnterPercentage(string desc){
            Type(INPUT_PERCENTAGE, desc);
            return this;
        }
        public DiscountCodesPage SelectIsLimited(bool limit){
            if (limit == true) {
                if (IsSelected(CHECKBOX_IS_LIMITED) == false) {
                    Click(CHECKBOX_IS_LIMITED);
                }
            }else{ 
                Console.WriteLine("limit is not selected.");   
            }
            return this;
        }
        public DiscountCodesPage EnterLimit(string limit = null){
            if (limit != null) {
                Type(INPUT_LIMIT, limit);   
            }
            return this;
        }
        public DiscountCodesPage SetStartDate(int yearParam = 0, string monthParam = null, string dayParam = null){
            int year = yearParam == 0 ? Utils.Dates.GetCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.GetCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.GetCurrentDay() : dayParam;

            string getCurrentValueOfInput = GetAttribute(INPUT_START_DATE_TEXTBOX, "value");
            
            string[] words = getCurrentValueOfInput.Split('/');
            string getCurrentValueOfInputDay = words[0];
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            int getCurrentValueOfInputYear = Int32.Parse(words[2]);

            try{
                Click(BUTTON_START_DATE_PICKER);
                Click(BUTTON_START_DATE_CHOOSE_YEAR);
                if (year != getCurrentValueOfInputYear){
                    if (year < getCurrentValueOfInputYear){
                        for (int i = getCurrentValueOfInputYear; i > year; i--){
                            Click(BUTTON_START_DATE_PREVIOUS_YEAR);
                        }
                    }else{
                        for (int i = getCurrentValueOfInputYear; i < year; i++){
                            Click(BUTTON_START_DATE_NEXT_YEAR);
                        }
                    }
                }
                Click(By.XPath("//span[contains(text(),'" + month + "')]"));
                Click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[1]"));
            }catch(Exception e){
                Console.WriteLine("Element not found:" + e);
            }
            Sleepms(500);
            return this;
        }
        public DiscountCodesPage SetEndDate(int yearParam = 0, string monthParam = null, string dayParam = null){
            int year = yearParam == 0 ? Utils.Dates.GetCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.GetCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.GetCurrentDay() : dayParam;

            string getCurrentValueOfInput = GetAttribute(INPUT_END_DATE_TEXTBOX, "value");
            string[] words = getCurrentValueOfInput.Split('/');
            string getCurrentValueOfInputDay = words[0];
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            int getCurrentValueOfInputYear = Int32.Parse(words[2]);

            try{
                Click(BUTTON_END_DATE_PICKER);
                Click(BUTTON_END_DATE_CHOOSE_YEAR);
                if (year != getCurrentValueOfInputYear){
                    if (year < getCurrentValueOfInputYear){
                        for (int i = getCurrentValueOfInputYear; i > year; i--){
                            Click(BUTTON_END_DATE_PREVIOUS_YEAR);
                        }
                    }else{
                        for (int i = getCurrentValueOfInputYear; i < year; i++){
                            Click(BUTTON_END_DATE_NEXT_YEAR);
                        }
                    }
                }
                Click(By.XPath("//span[contains(text(),'" + month + "')]"));
                Click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[1]"));
            }catch (Exception e){
                Console.WriteLine("Element not found:" + e);
            }
            Sleepms(500);
            return this;
        }
        public DiscountCodesPage ClickSave(){
            Click(BUTTON_SAVE);
            return this;
        }
        
    }
}
