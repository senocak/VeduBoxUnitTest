using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class QuestionsPage : Page{

        private static string _user;
        private static By ADD_NEW_QUESTION_BUTTON = By.CssSelector("button[ui-sref='veduBox.testExam.questions.new']");
        private static By QUESTION_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[2]/div/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static By POINT_INPUT = By.Id("teacherQuesPoolPoint");
        private static By DELETE_CHOICE_5 = By.XPath("(//*[@id='teacherQuesPoolChoiceAnsDel'])[5]");
        private static By ANSWER_A_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[2]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static By ANSWER_B_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[3]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static By ANSWER_C_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[4]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static By ANSWER_D_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[5]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static By RIGHT_ANSWER_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[4]/div/div[1]/div/label/input");
        private static By IS_PUBLIC_INPUT = By.Id("teacherQuesPoolPublic");
        private static By IS_EDITABLE_INPUT= By.Id("teacherQuesPoolEdit");
        private static By SUBMIT_BUTTON= By.Id("teacherQuesPoolSaveBtn");
        private static By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static By SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private static By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private static By DELETE_SINGLE_QUESTION_POPUP = By.CssSelector("a[ng-click='delete(question.questionId)']");
        private static By QUESTION_TYPE = By.Id("teacherQuesPoolTypeQues");
        private static By ANSWER_TRUE = By.XPath("(//*[@id='teacherQuesPoolChoiceCorrectAns'])[1]");
        private static By ANSWER_FALSE = By.XPath("(//*[@id='teacherQuesPoolChoiceCorrectAns'])[2]");

        public QuestionsPage(IWebDriver wd, string user) : base(wd) {
            _user = user;
        }
        public QuestionsPage clickAddNewButton(){
            click(ADD_NEW_QUESTION_BUTTON);
            return this;
        }
        public QuestionsPage typeQuestionInput(string question){
            type(QUESTION_INPUT, question);
            return this;
        }
        public QuestionsPage enterPoint(int point){
            type(POINT_INPUT, point);
            return this;
        }
        public QuestionsPage clickDeleteButtonLastElementOfAnswers(){
            click(DELETE_CHOICE_5);
            return this;
        }
        public QuestionsPage selectQuestionType(string type){
            selectDropDown(QUESTION_TYPE, type);
            return this;
        }
        public QuestionsPage selectTrueFalseAnswer(bool answer){
            if (answer == true) click(ANSWER_TRUE);
            if (answer == false) click(ANSWER_FALSE);
            return this;
        }
        public QuestionsPage enterAnswerA(string answer){
            type(ANSWER_A_INPUT, answer);
            return this;
        }
        public QuestionsPage enterAnswerB(string answer){
            type(ANSWER_B_INPUT, answer);
            return this;
        }
        public QuestionsPage enterAnswerC(string answer){
            type(ANSWER_C_INPUT, answer);
            return this;
        }
        public QuestionsPage enterAnswerD(string answer){
            type(ANSWER_D_INPUT, answer);
            return this;
        }
        public QuestionsPage clickRigthAnswerAsC(){
            click(RIGHT_ANSWER_INPUT);
            return this;
        }
        public QuestionsPage clickIsPublic(){
            if (isSelected(IS_PUBLIC_INPUT) == false)
                click(IS_PUBLIC_INPUT);
            return this;
        }
        public QuestionsPage clickIsEDITABLE(){
            if (isSelected(IS_EDITABLE_INPUT) == false)
                click(IS_EDITABLE_INPUT);
            return this;
        }
        public QuestionsPage selectTestCategory(string testCategories){
            string[] names = testCategories.Split(',');
            foreach (var name in names){
                click(By.XPath("//a[contains(text(), '" + name + "')]"));
            }
            return this;
        }
        public QuestionsPage submit(){
            click(SUBMIT_BUTTON);
            return this;
        }
        public QuestionsPage assert(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }
        public QuestionsPage searchNewlyAddedQuestionByNameAndDeleteIt(string name){
            searchNewlyAddedQuestionByName(name);
            try{
                clickThreePoints();
            }catch (Exception e){
                Console.WriteLine("Error while clicking 3dots. Looks like there is no record. Returning null." + e.Message);
                return null;
            }
            clickDeleteSingleQuestionPopup();
            assert();
            return this;
        }
        public QuestionsPage searchNewlyAddedQuestionByName(string name){
            type(SEARCH_BOX, name);
            sleepms(1000);
            return this;
        }
        public QuestionsPage clickThreePoints(){
            click(THREE_POINTS);
            return this;
        }
        public QuestionsPage clickDeleteSingleQuestionPopup(){
            click(DELETE_SINGLE_QUESTION_POPUP);
            return this;
        }
    }
}
