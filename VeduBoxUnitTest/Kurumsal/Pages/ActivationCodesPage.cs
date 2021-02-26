using System;
using OpenQA.Selenium;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages {
    class ActivationCodesPage : Page {
        private string USER;
        private IJavaScriptExecutor JS;
        private readonly By BUTTON_ADD = By.CssSelector("button[ui-sref='veduBox.admin.activationCodes.new']");
        private readonly By SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private readonly By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private readonly By DELETE = By.CssSelector("span[translate='common.delete']");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By INPUT_CODE = By.CssSelector("input[ng-model='activationCode.code']");
        private readonly By TEXTAREA_DESC = By.CssSelector("textarea[ng-model='activationCode.description']");
        private readonly By INPUT_LIMIT = By.CssSelector("input[ng-model='activationCode.limit']");
        private readonly By BUTTON_SAVE = By.XPath("//*[@id='activationCodeForm']/div[2]/button[1]"); 
            
        private readonly By START_DATE_SELECT_DATA = By.CssSelector("input[ng-model='activationCode.startDate']");
        private readonly By BUTTON_START_DATE_OPEN_DATEPICKER = By.XPath("//*[@id='activationCodeForm']/div[1]/div[4]/div/p/span/button");
        private readonly By BUTTON_START_DATE_CHOOSE_YEAR = By.XPath("/html/body/div[3]/div/section/div/div[1]/div[3]/div/div/div[2]/form/div[1]/div[4]/div/p/ul/li[1]/div/table/thead/tr[1]/th[2]/button");
        private readonly By BUTTON_START_DATE_GO_PREVIOUS_YEAR = By.XPath("/html/body/div[3]/div/section/div/div[1]/div[3]/div/div/div[2]/form/div[1]/div[4]/div/p/ul/li[1]/div/table/thead/tr[1]/th[1]/button");
        private readonly By BUTTON_START_DATE_GO_NEXT_YEAR = By.XPath("/html/body/div[3]/div/section/div/div[1]/div[3]/div/div/div[2]/form/div[1]/div[4]/div/p/ul/li[1]/div/table/thead/tr[1]/th[3]/button");
        
        private readonly By END_DATE_SELECT_DATA = By.CssSelector("input[ng-model='activationCode.endDate']");
        private readonly By BUTTON_END_DATE_OPEN_DATEPICKER = By.XPath("//*[@id='activationCodeForm']/div[1]/div[5]/div/p/span/button");
        private readonly By BUTTON_END_DATE_CHOOSE_YEAR = By.XPath("/html/body/div[3]/div/section/div/div[1]/div[3]/div/div/div[2]/form/div[1]/div[5]/div/p/ul/li[1]/div/table/thead/tr[1]/th[2]/button");
        private readonly By BUTTON_END_DATE_GO_PREVIOUS_YEAR = By.XPath("/html/body/div[3]/div/section/div/div[1]/div[3]/div/div/div[2]/form/div[1]/div[5]/div/p/ul/li[1]/div/table/thead/tr[1]/th[1]/button");
        private readonly By BUTTON_END_DATE_GO_NEXT_YEAR = By.XPath("/html/body/div[3]/div/section/div/div[1]/div[3]/div/div/div[2]/form/div[1]/div[5]/div/p/ul/li[1]/div/table/thead/tr[1]/th[3]/button");
        
        public ActivationCodesPage(IWebDriver wd, string user) : base(wd) {
            USER = user;
            JS = (IJavaScriptExecutor)wd;
        }
        public ActivationCodesPage ClickAddButton(){
            Click(BUTTON_ADD);
            return this;
        }
        public ActivationCodesPage EnterCode(string code){
            Type(INPUT_CODE, code);
            return this;
        }
        public ActivationCodesPage EnterDesc(string desc){
            Type(TEXTAREA_DESC, desc);
            return this;
        }
        public ActivationCodesPage EnterLimit(int limit){
            Type(INPUT_LIMIT, limit.ToString());
            return this;
        }
        public ActivationCodesPage ClickSaveButton(){
            Click(BUTTON_SAVE);
            return this;
        }
        public ActivationCodesPage ClickThreePoints(){
            Click(THREE_POINTS);
            return this;
        }
        public ActivationCodesPage ClickDelete(){
            Click(DELETE);
            return this;
        }
        public ActivationCodesPage SearchNewlyAddedActivationCodesByName(string name){
            Type(SEARCH_BOX, name);
            Sleepms(1000);
            return this;
        }
        public ActivationCodesPage ClickAreUSure(){
            Click(ALERT_ARE_U_SURE_OK);
            return this;
        }
        public ActivationCodesPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
        public ActivationCodesPage SearchNewlyAddedActivationCodesByNameAndDeleteIt(string name){
            SearchNewlyAddedActivationCodesByName(name);
            try{
                ClickThreePoints();
            }catch (Exception e){
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
            ClickDelete();
            ClickAreUSure();
            Assert();
            return this;
        }
        public ActivationCodesPage SetStartDate(int yearParam = 0, string monthParam = null, string dayParam = null){
            int year = yearParam == 0 ? Utils.Dates.GetCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.GetCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.GetCurrentDay() : dayParam;

            string getCurrentValueOfInput = GetAttribute(START_DATE_SELECT_DATA, "value");
            string[] words = getCurrentValueOfInput.Split('-');
            
            int getCurrentValueOfInputYear = Int32.Parse(words[0]);
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            string getCurrentValueOfInputDay = words[2];

            try{
                Click(BUTTON_START_DATE_OPEN_DATEPICKER);
                Click(BUTTON_START_DATE_CHOOSE_YEAR);
                if (year != getCurrentValueOfInputYear){
                    if (year < getCurrentValueOfInputYear){
                        for (int i = getCurrentValueOfInputYear; i > year; i--){
                            Click(BUTTON_START_DATE_GO_PREVIOUS_YEAR);
                        }
                    }else{
                        for (int i = getCurrentValueOfInputYear; i < year; i++){
                            Click(BUTTON_START_DATE_GO_NEXT_YEAR);
                        }
                    }
                }
                Click(By.XPath("//span[contains(text(),'" + month + "')]"));
                Click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[1]"));
            }catch (Exception e){
                Console.WriteLine("Element not found:" + e.Message);
            }
            Sleepms(500);
            return this;
        }
        public ActivationCodesPage SetEndDate(int yearParam = 0, string monthParam = null, string dayParam = null){
            int year = yearParam == 0 ? Utils.Dates.GetCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.GetCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.GetCurrentDay() : dayParam;

            string getCurrentValueOfInput = GetAttribute(END_DATE_SELECT_DATA, "value");
            string[] words = getCurrentValueOfInput.Split('-');

            int getCurrentValueOfInputYear = Int32.Parse(words[0]);
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            string getCurrentValueOfInputDay = words[2];

            try {
                Click(BUTTON_END_DATE_OPEN_DATEPICKER);
                Click(BUTTON_END_DATE_CHOOSE_YEAR);
                if (year != getCurrentValueOfInputYear){
                    if (year < getCurrentValueOfInputYear){
                        for (int i = getCurrentValueOfInputYear; i > year; i--){
                            Click(BUTTON_END_DATE_GO_PREVIOUS_YEAR);
                        }
                    }else{
                        for (int i = getCurrentValueOfInputYear; i < year; i++) {
                            Click(BUTTON_END_DATE_GO_NEXT_YEAR);
                            Console.WriteLine("clicked end date go to next year " + i + " times");
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
    }
}