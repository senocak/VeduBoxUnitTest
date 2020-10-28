﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages
{
    class PaymentPage : Page{
        private static string _user;
        private static By AGREE = By.Id("//*[@id='mainSection']/div/div/div[1]/div[2]/div/div[2]/div/div[2]/div[2]/input");
        private static By NEXT = By.CssSelector("span[translate='common.next']");
        private static By NAME = By.Id("makePaymentBuyerName");
        private static By PACKAGE_NAME = By.CssSelector("input[ng-model='paymentInfo.billingName']");
        private static By PACKAGE_SURNAME = By.CssSelector("input[ng-model='paymentInfo.billingSurname']");
        private static By PACKAGE_CITY = By.CssSelector("input[ng-model='paymentInfo.billingCity']");
        private static By PACKAGE_COUNTRY = By.CssSelector("input[ng-model='paymentInfo.billingCountry']");
        private static By PACKAGE_PHONE = By.CssSelector("input[ng-model='paymentInfo.billingTel']");
        private static By PACKAGE_ADRESS = By.CssSelector("textarea[ng-model='paymentInfo.billingAdress']");
        private static By SAME_DELIVERY = By.CssSelector("input[ng-model='sameBillingAndDeliveryInf']");
        private static By SURNAME = By.Id("makePaymentBuyerLastName");
        private static By CITY = By.Id("makePaymentBuyerCity");
        private static By DISTRICT = By.Id("makePaymentBuyerCountry");
        private static By PHONE = By.Id("makePaymentBuyerTelephone");
        private static By ADDRESS = By.Id("makePaymentBuyerAddress");
        private static By CARD_NAME = By.Id("ccname");
        private static By CARD_NUMBER = By.Id("ccnumber");
        private static By CARD_DATE = By.Id("ccexp");
        private static By CARD_CVC = By.Id("cccvc");
        private static By PAY_BUTTON = By.Id("iyz-payment-button");
        private static By SUCCESS = By.CssSelector("[class='color_grey_blue bold ft24 ng-scope']");
        private static By I_AGREE = By.CssSelector("input[ng-model='policy']");
        private static By DISMISS_POLICY = By.CssSelector("a[ng-click='dismissPolicy()']");
        public PaymentPage(IWebDriver wd, string user) : base(wd){
            _user = user;
        }
        public PaymentPage selectAgree(){
            click(AGREE);
            return this;
        }
        public PaymentPage clickNext(){
            Console.WriteLine("i am going to click next button after agree");
            click(NEXT);
            Console.WriteLine("i clicked next button after agree");
            return this;
        }
        public PaymentPage enterName(string name){
            type(NAME, name);
            return this;
        }
        public PaymentPage enterPackageName(string name)
        {
            type(PACKAGE_NAME, name);
            return this;
        }
        public PaymentPage enterSurName(string surname){
            type(SURNAME, surname);
            return this;
        }
        public PaymentPage enterPackageSurname(string surname)
        {
            type(PACKAGE_SURNAME, surname);
            return this;
        }
        public PaymentPage enterCity(string city){
            type(CITY, city);
            return this;
        }
        public PaymentPage enterPackageCity(string city)
        {
            type(PACKAGE_CITY, city);
            return this;
        }
        public PaymentPage enterDistrict(string district){
            type(DISTRICT, district);
            return this;
        }
        public PaymentPage enterPackageCountry(string country)
        {
            type(PACKAGE_COUNTRY, country);
            return this;
        }
        public PaymentPage enterPhone(string phone){
            type(PHONE, phone);
            return this;
        }
        public PaymentPage enterPackagePhone(string phone)
        {
            type(PACKAGE_PHONE, phone);
            return this;
        }
        public PaymentPage enterAddress(string address){
            type(ADDRESS, address);
            return this;
        }
        public PaymentPage enterPackageAddress(string address)
        {
            type(PACKAGE_ADRESS, address);
            return this;
        }
        public PaymentPage enterCardName(string cardName){
            type(CARD_NAME, cardName);
            return this;
        }
        public PaymentPage enterCardNumber(string cardNumber){
            type(CARD_NUMBER, cardNumber);
            return this;
        }
        public PaymentPage enterCardDate(string cardDate){
            type(CARD_DATE, cardDate);
            return this;
        }
        public PaymentPage enterCardCVC(string cardCVC){
            type(CARD_CVC, cardCVC);
            return this;
        }
        public PaymentPage clickPayButton(){
            click(PAY_BUTTON);
            return this;
        }
        public PaymentPage assertPaymentIsOK(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, By.CssSelector("span[translate='routeStates.payment.success']"));
            return this;
        }

       
        public PaymentPage closeDismiss()
        {
            sleepms(30000);
            try
            {
                click(DISMISS_POLICY);
            }catch(Exception e)
            {
                Console.WriteLine("popup is not visible, Hata:"+e.Message);
            }
            return this;
        }

        public PaymentPage selectIsAgree(){
            sleepms(3000);
            if (isSelected(I_AGREE) == false)
                click(I_AGREE);
            Console.WriteLine("i agree was selected successfully");
            return this;
        }

        public PaymentPage selectSameDelivery()
        {
            if (isSelected(SAME_DELIVERY) == false)
                click(SAME_DELIVERY);
            return this;
        }
    }
}
