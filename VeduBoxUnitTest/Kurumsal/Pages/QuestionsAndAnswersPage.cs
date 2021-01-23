using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class QuestionsAndAnswersPage : Page{
    
        private readonly By BUTTON_NEW_TICKET = By.CssSelector("a[ui-sref='veduBox.student.me.studentQuestions.new']");
        private readonly By SELECT_COURSE = By.CssSelector("select[ng-model='selectedCourse']");
        private readonly By INPUT_SUBJECT = By.CssSelector("input[ng-model='studentQuestion.subject']");
        private readonly By BUTTON_NEXT = By.CssSelector("span[translate='common.next']");
        private readonly By BUTTON_UPLOAD_PICTURE = By.Id("askUploadImage");
        private readonly By BUTTON_SEND = By.CssSelector("span[translate='common.send']");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By DIV_MESSAGE = By.XPath("/html/body/div[3]/div/section/div/div[1]/div/div/div/div/form/div/div[1]/fieldset[3]/div/div/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By SPAN_VIEW_DETAIL = By.CssSelector("span[ng-click='getMessageDetails(questionAndAnswer.id,questionAndAnswer.instructorName)']");
        private readonly By P_ANSWER_FIELD = By.XPath("/html/body/div[3]/div/section/div/div[1]/div/section/div[2]/div/table/tbody/tr[2]/td/div[3]/div[1]/div[2]/div/div/vedu-box-text-angular/text-angular/div[2]/div[3]/p");
        private readonly By BUTTON_REPLY = By.CssSelector("div[translate='studentQuestion.Reply']");
        private readonly By BUTTON_DELETE_TICKET = By.XPath("(//span[@translate='routeStates.teacher.me.courses.edit.deleteTicket'])[1]");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private string USER;
        public QuestionsAndAnswersPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public QuestionsAndAnswersPage ClickNewTicket(){
            Click(BUTTON_NEW_TICKET);
            return this;
        }
        public QuestionsAndAnswersPage SelectCourse(string courseName){
            SelectDropDown(SELECT_COURSE, courseName);
            return this;
        }
        public QuestionsAndAnswersPage EnterSubject(string subject){
            Type(INPUT_SUBJECT,subject);
            return this;
        }
        public QuestionsAndAnswersPage EnterMessage(string message){
            Type(DIV_MESSAGE, message);
            return this;
        }
        public QuestionsAndAnswersPage ClickNextButton(){
            Click(BUTTON_NEXT);
            return this;
        }
        public QuestionsAndAnswersPage SelectFile(){
            Type(
                    BUTTON_UPLOAD_PICTURE,
                    Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\file.png"))
                );
            return this;
        }
        public QuestionsAndAnswersPage ClickSendButton(){
            Click(BUTTON_SEND);
            return this;
        }
        public QuestionsAndAnswersPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
        public QuestionsAndAnswersPage CheckQuestionIsExist(){
            try{
                OpenViewDetail();
            }catch (Exception e){
                Console.WriteLine("View(for question) was not found: " + e.Message);
                return null;
            }
            ClickDeleteThisTicket();
            ClickAreUSure();
            Assert();
            return this;
        }
        public QuestionsAndAnswersPage DeleteNewAddedQuestions(){
            OpenViewDetail(); 
            ClickDeleteThisTicket();
            ClickAreUSure();
            Assert();
            return this;
        }
        public QuestionsAndAnswersPage OpenViewDetail(){
            Click(SPAN_VIEW_DETAIL);
            return this;
        }
        public QuestionsAndAnswersPage EnterAnswer(string answer){
            Type(P_ANSWER_FIELD, answer);
            return this;
        }
        public QuestionsAndAnswersPage ClickReplyButton(){
            Click(BUTTON_REPLY);
            return this;
        }
        public QuestionsAndAnswersPage ClickDeleteThisTicket(){
            Click(BUTTON_DELETE_TICKET);
            return this;
        }
        public QuestionsAndAnswersPage ClickAreUSure(){
            Click(ALERT_ARE_U_SURE_OK);
            return this;
        }
    }
}