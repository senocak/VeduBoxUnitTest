using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class PaymentPage : Page{

        private string USER;
        private readonly By CHECK_AGREE = By.Id("open_policy");
        private readonly By BUTTON_NEXT = By.CssSelector("span[translate='common.next']");
        private readonly By INPUT_NAME = By.Id("makePaymentBuyerName");
        private readonly By INPUT_PACKAGE_NAME = By.CssSelector("input[ng-model='paymentInfo.billingName']");
        private readonly By INPUT_PACKAGE_SURNAME = By.CssSelector("input[ng-model='paymentInfo.billingSurname']");
        private readonly By INPUT_PACKAGE_CITY = By.CssSelector("input[ng-model='paymentInfo.billingCity']");
        private readonly By INPUT_PACKAGE_COUNTRY = By.CssSelector("input[ng-model='paymentInfo.billingCountry']");
        private readonly By INPUT_PACKAGE_PHONE = By.CssSelector("input[ng-model='paymentInfo.billingTel']");
        private readonly By INPUT_PACKAGE_ADDRESS = By.CssSelector("textarea[ng-model='paymentInfo.billingAdress']");
        private readonly By INPUT_SAME_DELIVERY = By.CssSelector("input[ng-model='sameBillingAndDeliveryInf']");
        private readonly By INPUT_SURNAME = By.Id("makePaymentBuyerLastName");
        private readonly By INPUT_CITY = By.Id("makePaymentBuyerCity");
        private readonly By INPUT_DISTRICT = By.Id("makePaymentBuyerCountry");
        private readonly By INPUT_PHONE = By.CssSelector("input[ng-model='paymentInfo.billingTel']");
        private readonly By INPUT_ADDRESS = By.Id("makePaymentBuyerAddress");
        private readonly By INPUT_CARD_NAME = By.Id("ccname");
        private readonly By INPUT_CARD_NUMBER = By.Id("ccnumber");
        private readonly By INPUT_CARD_DATE = By.Id("ccexp");
        private readonly By INPUT_CARD_CVC = By.Id("cccvc");
        private readonly By BUTTON_PAY = By.Id("iyz-payment-button");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='color_grey_blue bold ft24 ng-scope']");
        private readonly By INPUT_I_AGREE = By.CssSelector("input[ng-model='policy']");
        private readonly By ASSERT_PAYMENT_OK = By.CssSelector("span[translate='routeStates.payment.success']");
        private readonly By A_DISMISS_POLICY = By.CssSelector("a[ng-click='dismissPolicy()']");
        public PaymentPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public PaymentPage SelectAgree(){
            Click(CHECK_AGREE);
            return this;
        }
        public PaymentPage ClickNext(){
            Console.WriteLine("i am going to click next button after agree");
            Click(BUTTON_NEXT);
            Console.WriteLine("i clicked next button after agree");
            return this;
        }
        public PaymentPage EnterName(string name){
            Type(INPUT_NAME, name);
            return this;
        }
        public PaymentPage EnterPackageName(string name){
            Type(INPUT_PACKAGE_NAME, name);
            return this;
        }
        public PaymentPage EnterSurName(string surname){
            Type(INPUT_SURNAME, surname);
            return this;
        }
        public PaymentPage EnterPackageSurname(string surname){
            Type(INPUT_PACKAGE_SURNAME, surname);
            return this;
        }
        public PaymentPage EnterCity(string city){
            Type(INPUT_CITY, city);
            return this;
        }
        public PaymentPage EnterPackageCity(string city){
            Type(INPUT_PACKAGE_CITY, city);
            return this;
        }
        public PaymentPage EnterDistrict(string district){
            Type(INPUT_DISTRICT, district);
            return this;
        }
        public PaymentPage EnterPackageCountry(string country)
        {
            Type(INPUT_PACKAGE_COUNTRY, country);
            return this;
        }
        public PaymentPage EnterPhone(string phone){
            Type(INPUT_PHONE, phone);
            return this;
        }
        public PaymentPage EnterPackagePhone(string phone)
        {
            Type(INPUT_PACKAGE_PHONE, phone);
            return this;
        }
        public PaymentPage EnterAddress(string address){
            Type(INPUT_ADDRESS, address);
            return this;
        }
        public PaymentPage EnterPackageAddress(string address)
        {
            Type(INPUT_PACKAGE_ADDRESS, address);
            return this;
        }
        public PaymentPage EnterCardName(string cardName){
            Type(INPUT_CARD_NAME, cardName);
            return this;
        }
        public PaymentPage EnterCardNumber(string cardNumber){
            Type(INPUT_CARD_NUMBER, cardNumber);
            return this;
        }
        public PaymentPage EnterCardDate(string cardDate){
            Type(INPUT_CARD_DATE, cardDate);
            return this;
        }
        public PaymentPage EnterCardCvc(string cardCvc){
            Type(INPUT_CARD_CVC, cardCvc);
            return this;
        }
        public PaymentPage ClickPayButton(){
            Click(BUTTON_PAY);
            return this;
        }
        public PaymentPage AssertPaymentIsOk(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ASSERT_PAYMENT_OK);
            return this;
        }
        public PaymentPage CloseDismiss(){
            Sleepms(30000);
            try{
                Click(A_DISMISS_POLICY);
            }catch(Exception e){
                Console.WriteLine("popup is not visible, Hata:"+e.Message);
            }
            return this;
        }
        public PaymentPage SelectIsAgree(){
            Sleepms(3000);
            if (IsSelected(INPUT_I_AGREE) == false)
                Click(INPUT_I_AGREE);
            Console.WriteLine("i agree was selected successfully");
            return this;
        }
        public PaymentPage SelectSameDelivery(){
            if (IsSelected(INPUT_SAME_DELIVERY) == false)
                Click(INPUT_SAME_DELIVERY);
            return this;
        }
    }
}