using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class PollsPage : Page{

        private string USER;
        private readonly By BUTTON_ADD = By.XPath("(//*[@translate='common.add'])[1]");
        private readonly By INPUT_NAME = By.CssSelector("input[ng-model='poll.name']");
        private readonly By INPUT_DESCRIPTION = By.CssSelector("textarea[ng-model='poll.description']");
        private readonly By INPUT_REPEAT_NUMBER = By.CssSelector("input[ng-model='poll.repeatNumber']");
        private readonly By CHECK_IS_MANDATORY = By.CssSelector("input[ng-model='poll.isMandatory']");
        private readonly By BUTTON_SET_DATE_OPEN_DATE_PICKER = By.XPath("//*[@id='step1']/div[12]/div/p/span/button/i");
        private readonly By BUTTON_SET_DATE_CHOOSE_YEAR = By.XPath("(//button[@ng-click='toggleMode()'])[2]");
        private readonly By BUTTON_SET_DATE_GO_NEXT_YEAR = By.XPath("(//button[@ng-click='move(1)'])[2]");
        private readonly By BUTTON_SET_DATE_GO_PREVIOUS_YEAR = By.XPath("(//button[@ng-click='move(-1)'])[2]");
        private readonly By BUTTON_NEXT = By.CssSelector("button[ng-click='goToStep(2)']");
        private readonly By BUTTON_SET_QUESTION = By.XPath("//button[@ng-click='setSelectedQuestions(question)']");
        private readonly By BUTTON_SAVE = By.CssSelector("span[translate='common.save']");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By INPUT_SEARCH = By.CssSelector("input.form-control.vedu-search");
        private readonly By BUTTON_THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private readonly By BUTTON_DELETE_POLL = By.CssSelector("button[ng-click='delete(poll)']");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private readonly By INPUT_QUESTION_LIST_SEARCH = By.XPath("//*[@id='step2']/div[1]/div/div[1]/div[2]/div[4]/input");

        public PollsPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public PollsPage ClickAddButton(){
            Click(BUTTON_ADD);
            return this;
        }
        public PollsPage EnterName(string name){
            Type(INPUT_NAME, name);
            return this;
        }
        public PollsPage EnterDescription(string description){
            Type(INPUT_DESCRIPTION, description);
            return this;
        }
        public PollsPage EnterRepeatNumber(int repeatNumber){
            Type(INPUT_REPEAT_NUMBER, repeatNumber);
            return this;
        }
        public PollsPage SelectIsMandatory(){
            if (IsSelected(CHECK_IS_MANDATORY) == false)
                Click(CHECK_IS_MANDATORY);
            return this;
        }
        public PollsPage SetDate(int yearParam = 0, string monthParam = null, string dayParam = null){
            int year = yearParam == 0 ? Utils.Dates.GetCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.GetCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.GetCurrentDay() : dayParam;
        
            Click(BUTTON_SET_DATE_OPEN_DATE_PICKER);
            Click(BUTTON_SET_DATE_CHOOSE_YEAR);

            if (year < 2020){
                for (int i = 2020; i > year; i--){
                    Console.WriteLine("year is older than 2020 so is going to " + year);
                    Click(BUTTON_SET_DATE_GO_PREVIOUS_YEAR);
                }
            }
            if (year > 2020){
                for (int i = 2020; i < year; i++){
                    Console.WriteLine("year is newer than 2020 so is going to " + year);
                    Click(BUTTON_SET_DATE_GO_NEXT_YEAR);
                }
            }
            Click(By.XPath("//span[contains(text(),'" + month + "')]"));
            Click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[2]"));
            Sleepms(500);
            return this;
        }
        public PollsPage ClickNextButton(){
            Click(BUTTON_NEXT);
            return this;
        }
        public PollsPage SearchQuestion(string question){
            Type(INPUT_QUESTION_LIST_SEARCH, question);
            return this;
        }
        public PollsPage SetSetQuestion(){
            Click(BUTTON_SET_QUESTION);
            return this;
        }
        public PollsPage ClickSaveButton(){
            Click(BUTTON_SAVE);
            return this;
        }
        public PollsPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
        public PollsPage SearchNewlyAddedPollByName(string Name){
            Type(INPUT_SEARCH, Name);
            Sleepms(1000);
            return this;
        }
        public PollsPage ClickThreePoints(){
            Click(BUTTON_THREE_POINTS);
            return this;
        }
        public PollsPage ClickDelete(){
                Click(BUTTON_DELETE_POLL);
                return this;
        }
        public PollsPage ClickAreYouSureOk(){
            Click(ALERT_ARE_U_SURE_OK);
            return this;
        }
        public PollsPage ClearSearchBox(){
            Clear(INPUT_SEARCH);
            return this;
        }
        public PollsPage CheckPollIsExist(string name){
            SearchNewlyAddedPollByName(name);
            try{
                ClickThreePoints();
            }catch (Exception e){
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
            ClickDelete();
            ClickAreYouSureOk();
            Assert();
            return this;
        }
    }
}