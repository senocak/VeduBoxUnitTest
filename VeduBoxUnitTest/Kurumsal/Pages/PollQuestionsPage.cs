using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages
{
    class PollQuestionsPage : Page{
        private static string _user;
        private static By SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private static By ADD_BUTTON = By.CssSelector("button[ui-sref='veduBox.poll.questions.new']");
        private static By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private static By DELETE_POLL_QUESTION = By.CssSelector("button[ng-click='delete(question.id)']");
        private static By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private static By TEXT_INPUT = By.CssSelector("div[ng-model='html']");
        private static By SELECT_TYPE = By.CssSelector("select[ng-model='question.questionTypeId']");
        private static By IS_PUBLIC_INPUT = By.CssSelector("input[ng-model='question.isPublic']");
        private static By IS_EDITABLE_INPUT = By.CssSelector("input[ng-model='question.isEditable']");
        private static By SAVE_BUTTON = By.XPath("//*[@id='questionForm']/div[2]/div/div/button[1]");
        private static By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static By ADD_NEW_ANSWER_BUTTON = By.CssSelector("button[ng-click='addChoice()']");
        private static By ANSWER1_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/form/div[1]/div[10]/div[3]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static By ANSWER2_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/form/div[1]/div[10]/div[4]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static By ANSWER3_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/form/div[1]/div[10]/div[5]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static By ANSWER4_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/form/div[1]/div[10]/div[6]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        public PollQuestionsPage(IWebDriver wd, string user) : base(wd){
            _user = user;
        }
        public PollQuestionsPage searchNewlyAddedQuestionByName(string name){
            type(SEARCH_BOX, name);
            sleepms(1000);
            return this;
        }
        public PollQuestionsPage searchNewlyAddedQuestionByNameAndDeleteIt(string name){
            sleepms(3000);
            searchNewlyAddedQuestionByName(name);
            try{
                click3Points();
            }catch (Exception e){
                Console.WriteLine("Error while clicking 3dots. Looks like there is no record. Returning null." + e.Message);
                return null;
            }
            clickDeleteButton();
            clickAreUSure();
            assert();
            return this;
        }
        public PollQuestionsPage click3Points(){
            click(THREE_POINTS);
            return this;
        }
        public PollQuestionsPage clickDeleteButton(){
            click(DELETE_POLL_QUESTION);
            return this;
        }
        public PollQuestionsPage clickAreUSure(){
            click(ARE_U_SURE_OK);
            return this;
        }
        public PollQuestionsPage assert(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }
        public PollQuestionsPage clickAddButton(){
            click(ADD_BUTTON);
            return this;
        }
        public PollQuestionsPage enterText(string title){
            type(TEXT_INPUT, title);
            return this;
        }
        public PollQuestionsPage selectType(string type){
            selectDropDown(SELECT_TYPE, type);
            return this;
        }
        public PollQuestionsPage clickIsPublic(){
            if (isSelected(IS_PUBLIC_INPUT) == false)
                click(IS_PUBLIC_INPUT);
            return this;
        }
        public PollQuestionsPage clickIsEditable(){
            if (isSelected(IS_EDITABLE_INPUT) == false)
                click(IS_EDITABLE_INPUT);
            return this;
        }
        public PollQuestionsPage clickSaveButton(){
            click(SAVE_BUTTON);
            return this;
        }
        public PollQuestionsPage clickAddNewAnswerButton(){
            click(ADD_NEW_ANSWER_BUTTON);
            return this;
        }
        
        public PollQuestionsPage enterAnswer1(string answer){
            type(ANSWER1_INPUT, answer);
            return this;
        }
        public PollQuestionsPage enterAnswer2(string answer){
            type(ANSWER2_INPUT, answer);
            return this;
        }
        public PollQuestionsPage enterAnswer3(string answer){
            type(ANSWER3_INPUT, answer);
            return this;
        }
        public PollQuestionsPage enterAnswer4(string answer){
            type(ANSWER4_INPUT, answer);
            return this;
        }
    }
}
