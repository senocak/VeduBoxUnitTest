using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class PortalPage : Page{

        private string USER;
        private readonly By INPUT_SEARCH = By.Id("packageDetailSearch");
        private readonly By INPUT_COURSE_PACKAGE_SEARCH = By.Id("packageDetailCourseSearch");
        private readonly By BUTTON_VIEW = By.Id("packageDetailCourseView");
        private readonly By BUTTON_COURSE_PACKAGE_VIEW = By.Id("packageDetailPredefinedCourseView");
        private readonly By BUTTON_COURSES_PACKAGES = By.CssSelector("[ng-click='gTab = 2;']");
        private readonly By BUTTON_COURSES = By.CssSelector("[ng-click='gTab = 1;']");
        private readonly By INPUT_LOGIN = By.Id("packageDetailCourseViewLogin");
        private readonly By INPUT_REGISTER = By.Id("packageDetailCourseViewRegister");
        private readonly By BUTTON_CONTINUE = By.Id("packageDetailCourseViewContinue");
        private readonly By BUTTON_COURSES_PACKAGE_CONTINUE = By.XPath("(//button[@ng-click='go()'])[2]");
        private readonly By A_DISMISS_POLICY = By.CssSelector("a[ng-click='dismissPolicy()']");
        private readonly By BUTTON_ADD_CART = By.CssSelector("#packageDetailCourseAddToCart");
        private readonly By BUTTON_COURSE_PACKAGE_ADD_CART = By.CssSelector("#packageDetailPredefinedCourseAddToCart");
        private readonly By BUTTON_GO_TO_CART = By.XPath("(//button[@ng-click=' goToCart()'])[2]");

        public PortalPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public PortalPage ClickSearch(){
            Click(INPUT_SEARCH);
            return this;
        }
        public PortalPage SearchEntry(string entry){
            Type(INPUT_SEARCH, entry);
            return this;
        }
        public PortalPage SearchCoursesPackageEntry(string entry){
            Type(INPUT_COURSE_PACKAGE_SEARCH, entry);
            return this;
        }
        public PortalPage ClickCoursesPackages(){
            Click(BUTTON_COURSES_PACKAGES);
            return this;
        }
        public PortalPage ClickCourses(){
            Click(BUTTON_COURSES);
            return this;
        }
        public PortalPage ClickView(){
            Click(BUTTON_VIEW);
            return this;
        }
        public PortalPage ClickCoursePackagesView(){
            Click(BUTTON_COURSE_PACKAGE_VIEW);
            return this;
        }
        public PortalPage SelectLogin(){
            Click(INPUT_LOGIN);
            return this;
        }
        public PaymentPage SelectContinue(){
            Sleepms(500);
            Click(BUTTON_COURSES_PACKAGE_CONTINUE);
            return new PaymentPage(Driver, USER);
        }
        public PaymentPage SelectCoursesPackageContinue(){
            Click(BUTTON_COURSES_PACKAGE_CONTINUE);
           /* 
            try{
                 WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
                 wait.IgnoreExceptionTypes(typeof(WebDriverException));

                 wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(DISMISS_POLICY));
                 IAlert alert = driver.SwitchTo().Alert();
                 alert.Accept();
                
                sleepms(1000);
            }catch{
                Console.WriteLine("Alert is not exist");
            }
           */
            return new PaymentPage(Driver, USER);
        }
        public PortalPage AddToCart(){
            Click(BUTTON_ADD_CART);
            return this;
        }
        public PortalPage AddtoCoursePackageCart(){
            Click(BUTTON_COURSE_PACKAGE_ADD_CART);
            return this;
        }
        public PortalPage GoToCart(){
            Click(BUTTON_GO_TO_CART);
            return this;
        }
    }
}