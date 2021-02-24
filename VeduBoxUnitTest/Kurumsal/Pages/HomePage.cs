using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using VeduBoxUnitTest.Assertion;
using VeduBoxUnitTest.Utils;

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
        private readonly By QUESTIONS_ANSWERS = By.CssSelector("a[title='Q&A']");
        private readonly By DISCOUNT_CODES= By.CssSelector("a[title='Discount Codes']");
        private readonly By CUSTOM_FIELDS = By.CssSelector("a[title='Custom Fields']");
        private readonly By LIBRARY = By.CssSelector("a[title='Library']");
        private readonly By TEST_CATEGORIES = By.CssSelector("a[title='Test Categories']");
        private readonly By USERNAME_LINK = By.CssSelector("span[ng-bind='$root.user.firstName | limitTo: 8']");
        private readonly By SWITCH_TO_ROLE = By.XPath("//*[@id='top-navbar']/ul[3]/li[5]/ul/li[3]/a");
        private readonly By ROLE_MODAL = By.CssSelector("a[ng-click='openSwitchRoleModal(role)']");
        private readonly By PASSWORD = By.CssSelector("input[ng-model='loginData.password']");
        private readonly By SAVE_BUTTON = By.XPath("/html/body/div[6]/div/div/div/div[2]/form/div[2]/button[1]");
        private readonly By ROLE_TEXT = By.XPath("//*[@id='top-navbar']/ul[3]/li[5]/a/span[2]");
        
        private string USER;
        public HomePage(IWebDriver wd) : base(wd){}
        public HomePage ClickUpdateAcceptButton(){
            try{
                Click(By.CssSelector("a[ng-click='acceptGdprPolicy(gdprPolicy.id);']"));
                Console.WriteLine("Popup found and clicked accept button");
            }catch (Exception e){
                Console.WriteLine("Popup not found. Keep working. Error is : " + e.Message);
            }
            return this;
        }
        public LivePage OpenLivePage(string user){
            USER = user;
            try{
                Click(LIVE);
            }catch(Exception e){
                Console.WriteLine("Error occured in OpenLivePage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked Live page element");
            return new LivePage(Driver, user);
        }
        public AdminsPage OpenAdminsPage(string user){
            USER = user;
            try{
                Click(ADMINS);
            }catch (Exception e){
                Console.WriteLine("Error occured in openADMINSpage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked openADMINSpage element");
            return new AdminsPage(Driver, user);
        }
        public ManagersPage OpenManagersPage(string user){
            USER = user;
            try{
                Click(MANAGERS);
            }catch (Exception e){
                Console.WriteLine("Error occured in openManagersPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked openManagersPage element");
            return new ManagersPage(Driver, user);
        }
        public QuestionsAndAnswersPage OpenQuestionsAndAnswersPage(string user){
            USER = user;
            try{
                Click(QUESTIONS_ANSWERS);
            }catch (Exception e){
                Console.WriteLine("Error occured in openQuestionsAndAnswersPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked openQuestionsAndAnswersPage element");
            return new QuestionsAndAnswersPage(Driver, user);
        }
        public CoursesPage OpenCoursesPage(string user){
            USER = user;
            try{
                if(USER == Constants.Roles.Admin.ToString()){
                    Click(COURSES);
                }else if (USER == Constants.Roles.Instructor.ToString()){
                    Click(MY_COURSES);
                }
            }catch (Exception e){
                Console.WriteLine("Error occured in openCOURSESpage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked Courses page element");
            return new CoursesPage(Driver, user);
        }
        public StudentsPage OpenStudentsPage(string user){
            USER = user;
            try{
                Click(STUDENTS);
            }catch (Exception e){
                Console.WriteLine("Error occured in openUserPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked User page element");
            return new StudentsPage(Driver, user);
        }
        public ExamPage OpenExamPage(string user){
            USER = user;
            try{
                Click(EXAM);
            }catch (Exception e){
                Console.WriteLine("Error occured in openExamPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked Exam page element");
            return new ExamPage(Driver, user);
        }
        public PortalPage OpenPortalPage(string user){
            USER = user;
            try{
                Click(PORTAL);
            }catch (Exception e){
                Console.WriteLine("Error occured in openPortalPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked PORTAL page element");
            return new PortalPage(Driver, user);
        }
        public EarningsPage OpenEarningsPage(string user){
            USER = user;
            try{
                Click(EARNINGS);
            }catch (Exception e){
                Console.WriteLine("Error occured in openEarningsPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked EARNINGS page element");
            return new EarningsPage(Driver, user);
        }
        public QuestionsPage OpenQuestionsPage(string user){
            USER = user;
            try{
                Click(QUESTIONS);
            }catch (Exception e){
                Console.WriteLine("Error occured in openQuestionsPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked QUESTIONS page element");
            return new QuestionsPage(Driver, user);
        }
        public BranchPage OpenBranchPage(string user){
            USER = user;
            try{
                Click(BRANCH);
            }catch (Exception e){
                Console.WriteLine("Error occured in BranchPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked Branch page element");
            return new BranchPage(Driver, user);
        }
        public TeachersPage OpenTeachersPage(string user){
            USER = user;
            try{
                Click(TEACHERS);
            }catch (Exception e){
                Console.WriteLine("Error occured in ModeratorsPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked Moderators page element");
            return new TeachersPage(Driver, user);
        }
        public AnnouncementsPage OpenAnnouncementsPage(string user){
            USER = user;
            try{
                Click(ANNOUNCEMENTS);
            }catch (Exception e){
                Console.WriteLine("Error occured in AnnouncementsPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked Announcements page element");
            return new AnnouncementsPage(Driver, user);
        }
        public ParentPage OpenParentPage(string user){
            USER = user;
            try{
                Click(PARENTS);
            }catch (Exception e){
                Console.WriteLine("Error occured in ParentPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked Parent page element");
            return new ParentPage(Driver, user);
        }
        public PollsPage OpenPollsPage(string user){
            USER = user;
            try{
                Click(POLLS);
            }catch (Exception e){
                Console.WriteLine("Error occured in openUserPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked User page element");
            return new PollsPage(Driver, user);
        }
        public PollQuestionsPage OpenPollQuestionsPage(string user){
            USER = user;
            try{
                Click(POLL_QUESTIONS);
            }catch (Exception e){
                Console.WriteLine("Error occured in openPollQuestionsPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked User page element");
            return new PollQuestionsPage(Driver, user);
        }
        public TestPoolPage OpenTestPoolPage(string user){
            USER = user;
            try{
                Click(TESTS_POOL);
            }catch (Exception e){
                Console.WriteLine("Error occured in openTestPoolPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked TestPoolPage element");
            return new TestPoolPage(Driver, user);
        }
        public CatalogPage OpenCatalogPage(string user){
            USER = user;
            try{
                Click(CATALOG);
            }catch (Exception e){
                Console.WriteLine("Error occured in openCatalogPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked openCatalogPage element");
            return new CatalogPage(Driver, user);
        }
        public HomePage AssertRoleIs(string role){
            AssertionCustom.AssertTextToBePresentInElementLocated(Driver, ROLE_TEXT, role, "Element Not Found");
            Console.WriteLine("Assertion is ok. Text: " + role);
            return this;
        }
        public CustomFieldsPage OpenCustomFieldPage(string user) {
            USER = user;
            try{
                Click(CUSTOM_FIELDS);
            }catch (Exception e){
                Console.WriteLine("Error occured in CustomFieldsPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked CustomFieldsPage element");
            return new CustomFieldsPage(Driver, user);
        }
        public LibraryPage OpenLibraryPage(string user){
            USER = user;
            try{
                Click(LIBRARY);
            }catch (Exception e){
                Console.WriteLine("Error occured in CustomFieldsPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked CustomFieldsPage element");
            return new LibraryPage(Driver, user);
        }
        public TestCategoriesPage OpenTestCategoriesPage(string user){
            USER = user;
            try{
                Click(TEST_CATEGORIES);
            }catch (Exception e){
                Console.WriteLine("Error occured in CustomFieldsPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked CustomFieldsPage element");
            return new TestCategoriesPage(Driver, user);
        }
        public HomePage ClickUserName(){
            Click(USERNAME_LINK);
            return this;
        }
        public HomePage ClickRoleModal(){
            Actions hover = new Actions(Driver);
            IWebElement elementToHover = Driver.FindElement(SWITCH_TO_ROLE);
            hover.MoveToElement(elementToHover);
            hover.Perform();
            Click(ROLE_MODAL);
            return this;
        }
        public HomePage EnterPassword(string password){
            Type(PASSWORD, password);
            return this;
        }
        public HomePage ClickChangeButton(){
            Click(SAVE_BUTTON);
            Sleepms(3000);
            return this;
        }
        public DiscountCodesPage OpenDiscountCodesPage(string user){
            USER = user;
            try{
                Click(DISCOUNT_CODES);
            }catch (Exception e){
                Console.WriteLine("Error occured in openDiscountCodesPage, user: " + user + ", Error is: " + e.Message);
            }
            Console.WriteLine(user + ": clicked openDiscountCodesPage element");
            return new DiscountCodesPage(Driver, user);
        }
    }
}
