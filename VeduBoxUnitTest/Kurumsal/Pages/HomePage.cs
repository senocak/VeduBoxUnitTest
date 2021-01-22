using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class HomePage : Page{
        private readonly By LIVE = By.CssSelector("a[title='Live']");
        private readonly By COURSES = By.CssSelector("a[title='Courses']");
        private readonly By MY_COURSES = By.CssSelector("a[title='My Courses']");
        private readonly By STUDENTS = By.CssSelector("a[title='Students']");
        private readonly By EXAM = By.CssSelector("a[title='Exams']");
        private readonly By PORTAL = By.CssSelector("a[title='Portal']");
        private readonly By EARNINGS = By.CssSelector("a[title='Earnings']");
        private readonly By QUESTIONS = By.CssSelector("a[title='Question pool']");
        private readonly By BRANCH = By.CssSelector("a[title='Branches']");
        private readonly By MODERATORS = By.CssSelector("a[title='Moderators']");
        private readonly By TEACHERS = By.CssSelector("a[title='Teachers']");
        private readonly By ANNOUNCEMENTS = By.CssSelector("a[title='Announcements']");
        private readonly By PARENTS = By.CssSelector("a[title='Parents']");
        private readonly By POLLS = By.CssSelector("a[title='Polls']");
        private readonly By POLL_QUESTIONS = By.CssSelector("a[title='Poll Questions']");
        private readonly By TESTS_POOL = By.CssSelector("a[title='Test pool']");
        private readonly By CATALOG = By.CssSelector("a[title='Catalogs']");
        private readonly By ADMINS = By.CssSelector("a[title='Admins']");
        private readonly By MANAGERS = By.CssSelector("a[title='Managers']");
        private readonly By QUESTIONSANSWERS = By.CssSelector("a[title='Q&A']");
        private readonly By CUSTOM_FIELDS = By.CssSelector("a[title='Custom Fields']");
        private readonly By LIBRARY = By.CssSelector("a[title='Library']");

        private readonly By USERNAME_LINK = By.CssSelector("span[ng-bind='$root.user.firstName | limitTo: 8']");
        private readonly By SWITCH_TO_ROLE = By.XPath("//*[@id='top-navbar']/ul[3]/li[5]/ul/li[3]/a");
        private readonly By ROLE_MODAL = By.CssSelector("a[ng-click='openSwitchRoleModal(role)']");
        private readonly By PASSWORD = By.CssSelector("input[ng-model='loginData.password']");
        private readonly By SAVE_BUTTON = By.XPath("/html/body/div[6]/div/div/div/div[2]/form/div[2]/button[1]");
        private readonly By ROLE_TEXT = By.XPath("//*[@id='top-navbar']/ul[3]/li[5]/a/span[2]");

        private string _user;
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
        public AdminsPage openADMINSpage(string user)
        {
            _user = user;
            try
            {
                click(ADMINS);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured in openADMINSpage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked openADMINSpage element");
            return new AdminsPage(driver, user);
        }
        public ManagersPage openManagersPage(string user)
        {
            _user = user;
            try
            {
                click(MANAGERS);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured in openManagersPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked openManagersPage element");
            return new ManagersPage(driver, user);
        }
        public QuestionsAndAnswersPage openQuestionsAndAnswersPage(string user)
        {
            _user = user;
            try
            {
                click(QUESTIONSANSWERS);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured in openQuestionsAndAnswersPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked openQuestionsAndAnswersPage element");
            return new QuestionsAndAnswersPage(driver, user);
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
            Console.WriteLine("asdddddddddddddddddddd");
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
        public CustomFieldsPage openCustomFieldPage(string user)
        {
            _user = user;
            try
            {
                click(CUSTOM_FIELDS);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured in CustomFieldsPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked CustomFieldsPage element");
            return new CustomFieldsPage(driver, user);
        }

        public LibraryPage openLibraryPage(string user)
        {
            _user = user;
            try
            {
                click(LIBRARY);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured in CustomFieldsPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked CustomFieldsPage element");
            return new LibraryPage(driver, user);
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
