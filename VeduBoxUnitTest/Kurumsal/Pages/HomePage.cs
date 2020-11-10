using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class HomePage : Page{
        private static By LIVE = By.CssSelector("a[title='Live']");
        private static By COURSES = By.CssSelector("a[title='Courses']");
        private static By MY_COURSES = By.CssSelector("a[title='My Courses']");
        private static By STUDENTS = By.CssSelector("a[title='Students']");
        private static By EXAM = By.CssSelector("a[title='Exams']");
        private static By PORTAL = By.CssSelector("a[title='Portal']");
        private static By EARNINGS = By.CssSelector("a[title='Earnings']");
        private static By QUESTIONS = By.CssSelector("a[title='Question pool']");
        private static By BRANCH = By.CssSelector("a[title='Branches']");
        private static By MODERATORS = By.CssSelector("a[title='Moderators']");
        private static By TEACHERS = By.CssSelector("a[title='Teachers']");
        private static By ANNOUNCEMENTS = By.CssSelector("a[title='Announcements']");
        private static By PARENTS = By.CssSelector("a[title='Parents']");
        private static By POLLS = By.CssSelector("a[title='Polls']");
        private static By POLL_QUESTIONS = By.CssSelector("a[title='Poll Questions']");
        private static By TESTS_POOL = By.CssSelector("a[title='Test pool']");
        private static By CATALOG = By.CssSelector("a[title='Catalogs']");

        private static By USERNAME_LINK = By.CssSelector("span[ng-bind='$root.user.firstName | limitTo: 8']");
        private static By SWITCH_TO_ROLE = By.XPath("//*[@id='top-navbar']/ul[3]/li[5]/ul/li[2]/a");
        private static By ROLE_MODAL = By.CssSelector("a[ng-click='openSwitchRoleModal(role)']");
        private static By PASSWORD = By.CssSelector("input[ng-model='loginData.password']");
        private static By SAVE_BUTTON = By.XPath("/html/body/div[6]/div/div/div/div[2]/form/div[2]/button[1]");
        private static By ROLE_TEXT = By.XPath("//*[@id='top-navbar']/ul[3]/li[5]/a/span[2]");

        private static string _user;
        public HomePage(IWebDriver wd) : base(wd){}
        public HomePage clickUpdateAcceptButton(){
            try{
                click(By.CssSelector("a[ng-click='acceptGdprPolicy(gdprPolicy.id);']"));
                Console.WriteLine("Popup found and clicked accept button");
            }catch (Exception e){
                Console.WriteLine("Popup not found. Keep working. Error is : " + e.Message);
            }
            return this;
        }
        public LivePage openLIVEpage(string user){
            //scroll(LIVE);
            _user = user;
            try{
                click(LIVE);
            }catch(Exception e){
                Console.WriteLine("Error occured in OpenLivePage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked Live page element");
            return new LivePage(driver, user);
        }
        public CoursesPage openCOURSESpage(string user){
            _user = user;
            try{
                if(_user == "admin"){
                    click(COURSES);
                }else if (_user == "instructor"){
                    click(MY_COURSES);
                }
            }catch (Exception e){
                Console.WriteLine("Error occured in openCOURSESpage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked Courses page element");
            return new CoursesPage(driver, user);
        }
        public StudentsPage openStudentsPage(string user){
            _user = user;
            try{
                click(STUDENTS);
            }catch (Exception e){
                Console.WriteLine("Error occured in openUserPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked User page element");
            return new StudentsPage(driver, user);
        }
        public ExamPage openExamPage(string user){
            _user = user;
            try{
                click(EXAM);
            }catch (Exception e){
                Console.WriteLine("Error occured in openExamPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked Exam page element");
            return new ExamPage(driver, user);
        }
        public PortalPage openPortalPage(string user){
            _user = user;
            try{
                click(PORTAL);
            }catch (Exception e){
                Console.WriteLine("Error occured in openPortalPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked PORTAL page element");
            return new PortalPage(driver, user);
        }
        public EarningsPage openEarningsPage(string user){
            _user = user;
            try{
                click(EARNINGS);
            }catch (Exception e){
                Console.WriteLine("Error occured in openEarningsPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked EARNINGS page element");
            return new EarningsPage(driver, user);
        }
        public QuestionsPage openQuestionsPage(string user){
            _user = user;
            try{
                click(QUESTIONS);
            }catch (Exception e){
                Console.WriteLine("Error occured in openQuestionsPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked QUESTIONS page element");
            return new QuestionsPage(driver, user);
        }
        public BranchPage openBranchPage(string user){
            _user = user;
            try{
                click(BRANCH);
            }catch (Exception e){
                Console.WriteLine("Error occured in BranchPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked Branch page element");
            return new BranchPage(driver, user);
        }
        public TeachersPage openTeachersPage(string user){
            _user = user;
            try{
                click(TEACHERS);
            }catch (Exception e){
                Console.WriteLine("Error occured in ModeratorsPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked Moderators page element");
            return new TeachersPage(driver, user);
        }
        public AnnouncementsPage openAnnouncementsPage(string user){
            _user = user;
            try{
                click(ANNOUNCEMENTS);
            }catch (Exception e){
                Console.WriteLine("Error occured in AnnouncementsPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked Announcements page element");
            return new AnnouncementsPage(driver, user);
        }
        public ParentPage openParentPage(string user){
            _user = user;
            try{
                click(PARENTS);
            }catch (Exception e){
                Console.WriteLine("Error occured in ParentPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked Parent page element");
            return new ParentPage(driver, user);
        }
        public PollsPage openPollsPage(string user){
            _user = user;
            try{
                click(POLLS);
            }catch (Exception e){
                Console.WriteLine("Error occured in openUserPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked User page element");
            return new PollsPage(driver, user);
        }
        public PollQuestionsPage openPollQuestionsPage(string user){
            _user = user;
            try{
                click(POLL_QUESTIONS);
            }catch (Exception e){
                Console.WriteLine("Error occured in openPollQuestionsPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked User page element");
            return new PollQuestionsPage(driver, user);
        }
        public TestPoolPage openTestPoolPage(string user){
            _user = user;
            try{
                click(TESTS_POOL);
            }catch (Exception e){
                Console.WriteLine("Error occured in openTestPoolPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked TestPoolPage element");
            return new TestPoolPage(driver, user);
        }
        public CatalogPage openCatalogPage(string user){
            _user = user;
            try{
                click(CATALOG);
            }catch (Exception e){
                Console.WriteLine("Error occured in openCatalogPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked openCatalogPage element");
            return new CatalogPage(driver, user);
        }
        public HomePage assertRoleIs(string role){
            AssertionCustom.assertTextToBePresentInElementLocated(driver, ROLE_TEXT, role, "Element Not Found");
            Console.WriteLine("Assertion is ok. Text: " + role);
            return this;
        }
        public HomePage clickUserName(){
            click(USERNAME_LINK);
            return this;
        }
        public HomePage clickRoleModal(){
            Actions hover = new Actions(driver);
            IWebElement elementToHover = driver.FindElement(SWITCH_TO_ROLE);
            hover.MoveToElement(elementToHover);
            hover.Perform();
            click(ROLE_MODAL);
            return this;
        }
        public HomePage enterPassword(string password){
            type(PASSWORD, password);
            return this;
        }
        public HomePage clickChangeButton(){
            click(SAVE_BUTTON);
            sleepms(3000);
            return this;
        }
    }
}
