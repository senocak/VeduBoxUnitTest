using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages
{
    class AnnouncementsPage : Page{
        private static By SEARCH_BOX = By.CssSelector("input[ng-model='filter.$']");
        private static By ADD_BUTTON = By.CssSelector("button[ui-sref='veduBox.admin.announcements.new({ typeId:announcementTypeId })']");
        private static By INPUT_TITLE = By.CssSelector("input[ng-model='announcement.title']");
        private static By INPUT_DESC = By.CssSelector("div[ng-model='html']");
        private static By SHOW_TO_STUDENTS = By.CssSelector("input[ng-model='announcement.showStudents']");
        private static By SHOW_TO_TEACHERS = By.CssSelector("input[ng-model='announcement.showTeachers']");
        private static By SHOW_TO_PARENTS = By.CssSelector("input[ng-model='announcement.showParents']");
        private static By INPUT_END_DATE = By.Id("dpEndDate");
        private static By SAVE_BUTTON = By.CssSelector("button[type='submit'][form='announcementForm']");
        private static By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private static By DELETE_USER = By.CssSelector("button[ng-click='delete(announcement)']");
        private static By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private static By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");

        private static string _user;
        public AnnouncementsPage(IWebDriver wd, string user) : base(wd){
            _user = user;
        }
        public AnnouncementsPage searchNewlyAddedAnnouncementAndDeleteIt(string name){
            searchNewlyAddedAnnouncement(name);
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
        public AnnouncementsPage searchNewlyAddedAnnouncement(string name){
            type(SEARCH_BOX, name);
            sleepms(1000);
            return this;
        }
        public AnnouncementsPage clickAddButton(){
            click(ADD_BUTTON);
            return this;
        }
        public AnnouncementsPage enterTitle(string title){
            type(INPUT_TITLE, title);
            return this;
        }
        public AnnouncementsPage enterDesc(string desc){
            type(INPUT_DESC, desc);
            return this;
        }
        public AnnouncementsPage selectShowToStudents(){
            if (isSelected(SHOW_TO_STUDENTS) == false)
                click(SHOW_TO_STUDENTS);
            return this;
        }
        public AnnouncementsPage selectShowToTeachers(){
            if (isSelected(SHOW_TO_TEACHERS) == false)
                click(SHOW_TO_TEACHERS);
            return this;
        }
        public AnnouncementsPage selectShowToParents(){
            if (isSelected(SHOW_TO_PARENTS) == false)
                click(SHOW_TO_PARENTS);
            return this;
        }
        public AnnouncementsPage enterEndDate(){
            //DateTime dob = DateTime.Now.AddDays(10);
            //type(INPUT_END_DATE, dob.Day + "/" + dob.Month + "/" + dob.Year);
            click(INPUT_END_DATE);
            selectDropDown(By.CssSelector("select[data-handler='selectMonth']"), DateTime.Now.AddDays(60).ToString("MMM"));
            selectDropDown(By.CssSelector("select[data-handler='selectYear']"), DateTime.Now.AddDays(60).ToString("yyyy"));
            click(By.XPath("(//a[@class='ui-state-default'][contains(text(), '" + DateTime.Now.AddDays(60).ToString("dd") + "')])[1]"));
            return this;
        }
        public AnnouncementsPage clickSaveButton(){
            click(SAVE_BUTTON);
            return this;
        }
        public AnnouncementsPage click3Points(){
            click(THREE_POINTS);
            return this;
        }
        public AnnouncementsPage clickDeleteButton(){
            click(DELETE_USER);
            return this;
        }
        public AnnouncementsPage clickAreUSure(){
            click(ARE_U_SURE_OK);
            return this;
        }
        public AnnouncementsPage assert(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }
    }
}
