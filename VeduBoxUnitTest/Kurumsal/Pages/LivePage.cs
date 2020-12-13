using OpenQA.Selenium;
using System;
using System.Globalization;
using System.Linq;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages
{
    class LivePage : Page
    {
        private static By ADD_NEW = By.Id("liveLesson-addNew");
        private static By COURSE = By.Id("liveLesson-selectCourseModal");
        //private static string COURSE_VALUE = "deneme";
        private static By MEETING_TYPE_BASIC = By.Id("liveLessons-addNewModalTypeVideoMeetingBasic");
        private static By MEETING_TYPE_PRO = By.Id("liveLessons-addNewModalTypeVideoMeetingPro");
        private static By MEETING_TYPE_WEBINAR = By.Id("liveLessons-addNewModalTypeVideoWebinar");
        private static By COURSE_OK_BUTTON = By.Id("liveLesson-selectCourseModalConfirm");
        private static By TITLE = By.Id("liveLessons-addNewModalCourseInput");
        //private static string DATE = "input[ng-model='startDates[n-1]']";
        private static By TIME_HOUR = By.Id("liveLessons-addNewModalTimeHoursSelect");
        private static By TIME_MIN = By.Id("liveLessons-addNewModalTimeMinutesSelect");
        private static By TIMEZONE = By.Id("liveLessons-addNewModalTimeZonesSelect");
        private static By DURATION = By.Id("liveLessons-addNewModalSelectDuration");
        private static By REGISTRATION_LIMIT = By.Id("liveLessons-addNewModalRegistrationLimitInput");
        private static By DESCRIPTION = By.CssSelector("div[ng-model='html']"); // id: taTextElement5949993084175542
        private static By TRAINER = By.Id("liveLessons-addNewModalTeacherSelect");
        private static By PRIVATE = By.Id("liveLessons-addNewModalPrivateCheckbox");
        private static By SUBMIT = By.Id("liveLessons-addNewModalSave");
        private static By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private static By REGISTER = By.Id("liveLesson-sessionStatusRegister");
        private static By LIVE_RECORD = By.Id("liveLesson-sessionShowDetails");
        private static By RECORD_DETAIL_BUTTON = By.Id("liveLesson-sessionLink");
        private static By COPY_BUTTON = By.CssSelector("input[ng-click='copyClicked()']");
        

       public static string RandomString(int length){
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[new Random().Next(s.Length)]).ToArray());
        }
        //private static string titleRandom = RandomString(10);
        //private static string title = "deneme";
        private static string _user;
        
        private int year = Int32.Parse(DateTime.Now.ToString("yyyy"));
        private string month = DateTime.Now.ToString("MM");
        private string day =DateTime.Now.ToString("dd");
        private int hour = Int32.Parse(DateTime.Now.ToString("HH"));
        private static int minute = Int32.Parse(DateTime.Now.ToString("mm"));
        public LivePage(IWebDriver wd, string user) : base(wd){
            _user = user;
       
           
        }
        public LivePage AddNew(){
            try{
                click(ADD_NEW);
            }catch(Exception e){
                Console.WriteLine("Error occured in AddNew in Live page, user: " + _user + ", Error is: " + e.Message);
            }
            Console.WriteLine(_user + ": clicked AddNew element in Live Page");
            return this;
        }
        public LivePage SelectCourse(string course_name){
            selectDropDown(COURSE, course_name);
            return this;
        }
        public LivePage SubmitSelectedCourse(){
            click(COURSE_OK_BUTTON);
            return this;
        }
        public LivePage selectMeetingType(string type){
            try{
                if (type == "pro")
                    click(MEETING_TYPE_PRO);
                else if (type == "basic")
                    click(MEETING_TYPE_BASIC);
                else if (type == "webinar")
                    click(MEETING_TYPE_WEBINAR);
                else
                    throw new Exception("Meeting Type is incorrect or null.");
                Console.WriteLine("Meeting Type is selected as :" + type);
            }catch (Exception e) {
                Console.WriteLine("Error occured during selecting metting type. Error is: " + e);
            }
            return this;
        }
        public LivePage enterTitle(string title){
            type(TITLE, title);
            return this;
        }

        public LivePage register(){
            click(By.XPath("//*[@id='mainSection']/div/div[2]/div[3]/div/div[3]/div[3]/div[2]/div/div[6]/div/button[1]"));
            return this;
        }
        public LivePage setDate(){

            click(By.CssSelector("button[ng-click='openDatepicker($event,(n-1))']"));
            click(By.XPath("//*[@id='liveLessonForm']/div[1]/div[5]/div[2]/div/p/ul/li/div/table/thead/tr/th[2]/button"));
            if (year < 2020){
                for (int i = 2020; i > year; i--){
                    click(By.XPath("//*[@id='liveLessonForm']/div[1]/div[5]/div[2]/div/p/ul/li/div/table/thead/tr/th[1]/button"));
                }
            }
            if (year > 2020){
                for (int i = 2020; i < year; i++){
                    click(By.XPath("//*[@id='liveLessonForm']/div[1]/div[5]/div[2]/div/p/ul/li/div/table/thead/tr/th[3]/button"));
                }
            }
            var month = DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
            click(By.XPath("//span[contains(text(),'" + month + "')]"));
            click(By.XPath("(//span[@class='ng-binding' and contains(text(),'"+day+"')])[2]"));
            sleepms(500);
            /*
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("document.querySelector(\"" + DATE + "\").value='2021-01-01'");
            js.ExecuteScript("document.querySelector(\""+ DATE +"\").removeAttribute('readonly')");
            type(By.CssSelector(DATE), "06/01/2019");
            */
            return this;
        }

        public LivePage selectTime(){
            try{
                click(By.XPath("//*[@id='pageBody']/div[2]/div[2]/div[1]/div[2]/table/tbody/tr[9]/td[3]/a[1]"));
                Console.WriteLine("Clicked time in Fast Schedule Table page");
            }catch (Exception e){
                Console.WriteLine("Error occured in adding time to Live record, user: " + _user + ", Error: " + e);
            }
            return this;
        }

        public LivePage saveScheduleButton(){
            try{
                click(By.CssSelector("button[ng-click='saveMultiple()']"));
                Console.WriteLine("Clicked save button in Fast Schedule Table page");
            }catch (Exception e){
                Console.WriteLine("Error occured in clicking save button to Schedule page, user: " + _user + ", Error: " + e);
            }
            return this;
        }

        public LivePage checkLiveIsExist(){
            try{
                openLiveRecordDetail();
            }catch (Exception e){
                Console.WriteLine("Live not found: " + e.Message);
                return null;
            }
            clickDeleteButtonInRecordDetail();
            clickAreUSure();
            assertLive();
            return this;
        }
        public LivePage clickDeleteButtonInRecordDetail(){
            click(By.Id("liveLesson-sessionDel"));
            Console.WriteLine("Clicked delete button in record detail");
            return this;
        }
        public LivePage clickAreUSure(){
            click(ARE_U_SURE_OK);
            Console.WriteLine("Clicked ARE_U_SURE_OK in popup");
            return this;
        }
        public WebinarPage goToWebinar(){
            try{
                openLiveRecordDetail();
                clickRECORD_DETAIL_BUTTON();
                clickCopyButton();
            }catch (Exception e){
                Console.WriteLine("Error occured in deleting Live record, user: " + _user + ", Error: " + e);
            }
            return new WebinarPage(driver, _user);
        }
        public LivePage openLiveRecordDetail(){
            click(LIVE_RECORD);
            Console.WriteLine("Clicked opened record details element");
            return this;
        }
        private void clickRECORD_DETAIL_BUTTON(){
            click(RECORD_DETAIL_BUTTON);
            Console.WriteLine("Clicked Link button in record detail");
        }
        private void clickCopyButton() {
            driver.Url = driver.FindElement(COPY_BUTTON).GetAttribute("ng-click-copy");
        }
        public LivePage assertStart(){
            try{
                AssertionCustom.assertElementVisible("Element Not Found", driver, By.XPath("//*[@id='mainSection']/div/div[2]/div[3]/div/div[3]/div[3]/div/div/div[6]/button"));
                Console.WriteLine("Element is clickable");
            }catch (Exception e){
                Console.WriteLine("Error occured in deleting Live record, user: " + _user + ", Error: " + e);
            }
            return this;
        }

        public LivePage setTime(string timeZone){

            minute = minute + 2; 
           selectDropDown(TIME_HOUR, hour);
            Console.WriteLine("hour was setted as : --- " + hour);
           // selectDropDown(TIME_MIN, minute);
            Console.WriteLine("minute was setted as : --- " + minute);
            selectDropDown(TIMEZONE, timeZone);
            return this;
        }
        public LivePage setDuration(int duration){
            selectDropDown(DURATION, duration);
            return this;
        }
        public LivePage setRegistrationLimit(int limit){
            type(REGISTRATION_LIMIT, limit);
            return this;
        }
        public LivePage setDescription(String description){
            type(DESCRIPTION, description);
            return this;
        }
        public LivePage setTrainer(string trainer){
            selectDropDown(TRAINER, trainer);
            return this;
        }
        public LivePage setPrivate(){
            if (!isSelected(PRIVATE))
                click(PRIVATE);
            else
                Console.WriteLine("Already private is selected");
            return this;
        }
        public LivePage submit(){
            click(SUBMIT);
            return this;
        }
        public LivePage assertLive(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }

        public LivePage goDate(){
            try{
                click(By.Id("liveLesson-selectDate"));
                click(By.XPath("/html/body/div[3]/div/section/div/div[2]/div[2]/div[2]/ul/li/div/table/thead/tr[1]/th[2]/button"));

                if (year < 2020){
                    for (int i = 2020; i > year; i--){
                        click(By.XPath("//*[@id='mainSection']/div/div[2]/div[2]/div[2]/ul/li/div/table/thead/tr[1]/th[1]/button"));
                    }
                }
                if (year > 2020){
                    for (int i = 2020; i < year; i++){
                        click(By.XPath("//*[@id='mainSection']/div/div[2]/div[2]/div[2]/ul/li/div/table/thead/tr[1]/th[3]/button"));
                    }
                }
                var month = DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
                Console.WriteLine("month is : ------  " + month + "--------");
                click(By.XPath("//span[contains(text(),'" + month + "')]"));
                click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])"));
            }catch(Exception e){
                Console.WriteLine("Element not found:" + e);
            }
            sleepms(500);
            return this;
        }

        public LivePage studentRegister(){
            click(REGISTER);
            return this;
        }
    }
}
