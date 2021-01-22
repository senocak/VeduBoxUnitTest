using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class PollQuestionsPage : Page{

        private string USER;
        private readonly By INPUT_SEARCH = By.CssSelector("input.form-control.vedu-search");
        private readonly By BUTTON_ADD = By.CssSelector("button[ui-sref='veduBox.poll.questions.new']");
        private readonly By BUTTON_THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private readonly By BUTTON_DELETE_POLL_QUESTION = By.CssSelector("button[ng-click='delete(question.id)']");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private readonly By INPUT_TEXT = By.CssSelector("div[ng-model='html']");
        private readonly By SELECT_TYPE = By.CssSelector("select[ng-model='question.questionTypeId']");
        private readonly By INPUT_IS_PUBLIC = By.CssSelector("input[ng-model='question.isPublic']");
        private readonly By INPUT_IS_EDITABLE = By.CssSelector("input[ng-model='question.isEditable']");
        private readonly By BUTTON_SAVE = By.XPath("//*[@id='questionForm']/div[2]/button[1]");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By BUTTON_ADD_NEW_ANSWER = By.CssSelector("button[ng-click='addChoice()']");
        private readonly By INPUT_ANSWER1 = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/form/div[1]/div[9]/div[3]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By INPUT_ANSWER2 = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/form/div[1]/div[9]/div[4]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By INPUT_ANSWER3 = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/form/div[1]/div[9]/div[5]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By INPUT_ANSWER4 = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/form/div[1]/div[9]/div[6]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        public PollQuestionsPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public PollQuestionsPage SearchNewlyAddedQuestionByName(string name){
            Type(INPUT_SEARCH, name);
            Sleepms(1000);
            return this;
        }
        public PollQuestionsPage SearchNewlyAddedQuestionByNameAndDeleteIt(string name){
            Sleepms(3000);
            SearchNewlyAddedQuestionByName(name);
            try{
                Click3Points();
            }catch (Exception e){
                Console.WriteLine("Error while clicking 3dots. Looks like there is no record. Returning null." + e.Message);
                return null;
            }
            ClickDeleteButton();
            ClickAreUSure();
            Assert();
            return this;
        }
        public PollQuestionsPage Click3Points(){
            Click(BUTTON_THREE_POINTS);
            return this;
        }
        public PollQuestionsPage ClickDeleteButton(){
            Click(BUTTON_DELETE_POLL_QUESTION);
            return this;
        }
        public PollQuestionsPage ClickAreUSure(){
            Click(ALERT_ARE_U_SURE_OK);
            return this;
        }
        public PollQuestionsPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
        public PollQuestionsPage ClickAddButton(){
            Click(BUTTON_ADD);
            return this;
        }
        public PollQuestionsPage EnterText(string title){
            Type(INPUT_TEXT, title);
            return this;
        }
        public PollQuestionsPage SelectType(string type){
            SelectDropDown(SELECT_TYPE, type);
            return this;
        }
        public PollQuestionsPage ClickIsPublic(){
            if (IsSelected(INPUT_IS_PUBLIC) == false)
                Click(INPUT_IS_PUBLIC);
            return this;
        }
        public PollQuestionsPage ClickIsEditable(){
            if (IsSelected(INPUT_IS_EDITABLE) == false)
                Click(INPUT_IS_EDITABLE);
            return this;
        }
        public PollQuestionsPage ClickSaveButton(){
            Click(BUTTON_SAVE);
            return this;
        }
        public PollQuestionsPage ClickAddNewAnswerButton(){
            Click(BUTTON_ADD_NEW_ANSWER);
            return this;
        }
        public PollQuestionsPage EnterAnswer1(string answer){
            Type(INPUT_ANSWER1, answer);
            return this;
        }
        public PollQuestionsPage EnterAnswer2(string answer){
            Type(INPUT_ANSWER2, answer);
            return this;
        }
        public PollQuestionsPage EnterAnswer3(string answer){
            Type(INPUT_ANSWER3, answer);
            return this;
        }
        public PollQuestionsPage EnterAnswer4(string answer){
            Type(INPUT_ANSWER4, answer);
            return this;
        }
    }
}