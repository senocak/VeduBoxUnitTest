using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class AnnouncementsPage : Page{
        
        private static By INPUT_SEARCH_BOX = By.CssSelector("input[ng-model='filter.$']");
        private static By BUTTON_ADD = By.CssSelector("button[ui-sref='veduBox.admin.announcements.new({ typeId:announcementTypeId })']");
        private static By INPUT_TITLE = By.CssSelector("input[ng-model='announcement.title']");
        private static By INPUT_DESC = By.CssSelector("div[ng-model='html']");
        private static By CHECKBOX_SHOW_TO_STUDENTS = By.CssSelector("input[ng-model='announcement.showStudents']");
        private static By CHECKBOX_SHOW_TO_TEACHERS = By.CssSelector("input[ng-model='announcement.showTeachers']");
        private static By CHECKBOX_SHOW_TO_PARENTS = By.CssSelector("input[ng-model='announcement.showParents']");
        private static By INPUT_END_DATE = By.Id("dpEndDate");
        private static By BUTTON_SAVE = By.CssSelector("button[type='submit'][form='announcementForm']");
        private static By BUTTON_THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private static By BUTTON_DELETE_USER = By.CssSelector("button[ng-click='delete(announcement)']");
        private static By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private static By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");

        private static string USER;
        public AnnouncementsPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public AnnouncementsPage SearchNewlyAddedAnnouncementAndDeleteIt(string name){
            SearchNewlyAddedAnnouncement(name);
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
        public AnnouncementsPage SearchNewlyAddedAnnouncement(string name){
            Type(INPUT_SEARCH_BOX, name);
            Sleepms(1000);
            return this;
        }
        public AnnouncementsPage ClickAddButton(){
            Click(BUTTON_ADD);
            return this;
        }
        public AnnouncementsPage EnterTitle(string title){
            Type(INPUT_TITLE, title);
            return this;
        }
        public AnnouncementsPage EnterDesc(string desc){
            Type(INPUT_DESC, desc);
            return this;
        }
        public AnnouncementsPage SelectShowToStudents(){
            if (IsSelected(CHECKBOX_SHOW_TO_STUDENTS) == false)
                Click(CHECKBOX_SHOW_TO_STUDENTS);
            return this;
        }
        public AnnouncementsPage SelectShowToTeachers(){
            if (IsSelected(CHECKBOX_SHOW_TO_TEACHERS) == false)
                Click(CHECKBOX_SHOW_TO_TEACHERS);
            return this;
        }
        public AnnouncementsPage SelectShowToParents(){
            if (IsSelected(CHECKBOX_SHOW_TO_PARENTS) == false)
                Click(CHECKBOX_SHOW_TO_PARENTS);
            return this;
        }
        public AnnouncementsPage EnterEndDate(){
            //DateTime dob = DateTime.Now.AddDays(10);
            //type(INPUT_END_DATE, dob.Day + "/" + dob.Month + "/" + dob.Year);
            Click(INPUT_END_DATE);
            SelectDropDown(By.CssSelector("select[data-handler='selectMonth']"), DateTime.Now.AddDays(60).ToString("MMM"));
            SelectDropDown(By.CssSelector("select[data-handler='selectYear']"), DateTime.Now.AddDays(60).ToString("yyyy"));
            Click(By.XPath("(//a[@class='ui-state-default'][contains(text(), '" + DateTime.Now.AddDays(60).ToString("%d") + "')])[1]"));
            return this;
        }
        public AnnouncementsPage ClickSaveButton(){
            Click(BUTTON_SAVE);
            return this;
        }
        public AnnouncementsPage Click3Points(){
            Click(BUTTON_THREE_POINTS);
            return this;
        }
        public AnnouncementsPage ClickDeleteButton(){
            Click(BUTTON_DELETE_USER);
            return this;
        }
        public AnnouncementsPage ClickAreUSure(){
            Click(ALERT_ARE_U_SURE_OK);
            return this;
        }
        public AnnouncementsPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
    }
}
