using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class CustomFieldsPage : Page{
        private readonly By ADD_BUTTON = By.XPath("(//span[@translate='common.add'])[1]");
        private readonly By FIELD_TYPE = By.CssSelector("select[ng-model='customField.fieldTypeId']");
        private readonly By LANGUAGE = By.CssSelector("select[ng-model='customField.language']");
        private readonly By NAME = By.CssSelector("input[ng-model='customField.name']");
        private readonly By DESCRIPTION = By.CssSelector("input[ng-model='customField.description']");
        private readonly By ORDER_NUMBER = By.CssSelector("input[ng-model='customField.orderNumber']");
        private readonly By IS_REQUIRED = By.CssSelector("input[ng-model='customField.isRequired']");
        private readonly By OPTIONS = By.CssSelector("textarea[ng-model='customField.options']");
        private readonly By SAVE_BUTTON = By.XPath("(//button[@type='submit'])[2]");
        private readonly By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private readonly By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private readonly By DELETE = By.CssSelector("span[translate='common.delete']");
        private readonly By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private static string USER;
        
        public CustomFieldsPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public CustomFieldsPage ClickAddButton(){
            Click(ADD_BUTTON);
            return this;
        }
        public CustomFieldsPage SelectFieldType(String type){
            SelectDropDown(FIELD_TYPE, type);
            return this;
        }
        public CustomFieldsPage EnterName(String name){
            Type(NAME, name);
            return this;
        }
        public CustomFieldsPage EnterDescription(String description){
            Type(DESCRIPTION, description);
            return this;
        }
        public CustomFieldsPage EnterOrderNumber(int orderNumber){
            Type(ORDER_NUMBER, orderNumber);
            return this;
        }
        public CustomFieldsPage EnterOptions(String options){
            Type(OPTIONS, options);
            return this;
        }
        public CustomFieldsPage SelectLanguage(String language){
            SelectDropDown(LANGUAGE, language);
            return this;
        }
        public CustomFieldsPage SelectIsRequired(){
            if (IsSelected(IS_REQUIRED) == false)
                Click(IS_REQUIRED);
            return this;
        }
        public CustomFieldsPage ClickSaveButton(){
            Click(SAVE_BUTTON);
            return this;
        }
        public CustomFieldsPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, SUCCESS);
            return this;
        }
        public CustomFieldsPage SearchNewlyAddedCustomFieldByName(string name){
            Type(SEARCH_BOX, name);
            Sleepms(1000);
            return this;
        }
        public CustomFieldsPage ClearSearchBox() {
            Clear(SEARCH_BOX);
            return this;
        }
        public CustomFieldsPage ClickThreePoints(){
            Click(THREE_POINTS);
            return this;
        }
        public CustomFieldsPage ClickDelete(){
            Click(DELETE);
            return this;
        }
        public CustomFieldsPage ClickAreUSure(){
            Click(ARE_U_SURE_OK);
            return this;
        }
        public CustomFieldsPage SearchNewlyAddedCustomFieldByNameAndDeleteIt(string name){
            SearchNewlyAddedCustomFieldByName(name);
            try{
                ClickThreePoints();
            }catch (Exception e){
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
            ClickDelete();
            ClickAreUSure();
            Assert();
            return this;
        }
    }
}
