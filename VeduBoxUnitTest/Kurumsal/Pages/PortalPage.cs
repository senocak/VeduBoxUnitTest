using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class PortalPage : Page{
        private static string _user;
        private static By SEARCH = By.Id("packageDetailSearch");
        private static By COURSE_PACKAGE_SEARCH = By.Id("packageDetailCourseSearch");
        private static By VIEW = By.Id("packageDetailCourseView");
        private static By COURSE_PACKAGE_VIEW = By.Id("packageDetailPredefinedCourseView");
        private static By COURSES_PACKAGES = By.CssSelector("[ng-click='gTab = 2;']");
        private static By COURSES = By.CssSelector("[ng-click='gTab = 1;']");
        private static By INPUT_LOGIN = By.Id("packageDetailCourseViewLogin");
        private static By INPUT_REGISTER = By.Id("packageDetailCourseViewRegister");
        private static By CONTINUE = By.Id("packageDetailCourseViewContinue");
        private static By COURSES_PACKAGE_CONTINUE = By.XPath("(//button[@ng-click='go()'])[2]");
        private static By DISMISS_POLICY = By.CssSelector("a[ng-click='dismissPolicy()']");
        private static By ADD_CART = By.CssSelector("#packageDetailCourseAddToCart");
        private static By COURSE_PACKAGE_ADD_CART = By.CssSelector("#packageDetailPredefinedCourseAddToCart");
        
        private static By GO_TO_CART = By.XPath("(//button[@ng-click=' goToCart()'])[2]");

        public PortalPage(IWebDriver wd, string user) : base(wd){
            _user = user;
        }
        public PortalPage clickSearch()
        {
            click(SEARCH);
            return this;
        }
        public PortalPage searchEntry(string entry){
            type(SEARCH, entry);
            return this;
        }
        public PortalPage searchCoursesPackageEntry(string entry)
        {
            type(COURSE_PACKAGE_SEARCH, entry);
            return this;
        }
        public PortalPage clickCoursesPackages()
        {
            click(COURSES_PACKAGES);
            return this;
        }

        public PortalPage clickCourses()
        {
            click(COURSES);
            return this;
        }

        public PortalPage clickView(){
            click(VIEW);
            return this;
        }
        public PortalPage clickCoursePackagesView()
        {
            click(COURSE_PACKAGE_VIEW);
            return this;
        }
        public PortalPage selectLogin(){
            click(INPUT_LOGIN);
            return this;
        }

        public PaymentPage selectContinue(){
            sleepms(500);
            click(COURSES_PACKAGE_CONTINUE);
            Console.WriteLine("clicked to continue");
            return new PaymentPage(driver, _user);
        }
        public PaymentPage selectCoursesPackageContinue()
        {
            click(COURSES_PACKAGE_CONTINUE);
            Console.WriteLine("clicked successfully to the COURSES PACKAGES CONTINUE");

           /* 
            try
            {
                 WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
                 wait.IgnoreExceptionTypes(typeof(WebDriverException));

                 wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(DISMISS_POLICY));
                 IAlert alert = driver.SwitchTo().Alert();
                 alert.Accept();
                
                sleepms(1000);
            }
            catch
            {
                Console.WriteLine("Alert is not exist");
            }
           */
           
            return new PaymentPage(driver, _user);
        }
        public PortalPage addtoCart()
        {
            click(ADD_CART);
            return this;
        }
        public PortalPage addtoCoursePackageCart()
        {
            click(COURSE_PACKAGE_ADD_CART);
            return this;
        }
        public PortalPage goToCart()
        {
            click(GO_TO_CART);
            return this;
        }


    }
}
