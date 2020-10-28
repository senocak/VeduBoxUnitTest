﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.4.0.0
//      SpecFlow Generator Version:3.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace VeduBoxUnitTest.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Admin")]
    public partial class AdminFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "Admin.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Admin", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("1_admin_create_live")]
        public virtual void _1_Admin_Create_Live()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("1_admin_create_live", null, tagsOfScenario, argumentsOfScenario);
#line 3
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
 testRunner.Given("Open Kurumsal Login Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 5
 testRunner.Given("Login as \"admin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 6
 testRunner.Given("admin checks live is exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table1.AddRow(new string[] {
                            "course_name",
                            "deneme_admin"});
                table1.AddRow(new string[] {
                            "meetingType",
                            "pro"});
                table1.AddRow(new string[] {
                            "title",
                            "deneme"});
                table1.AddRow(new string[] {
                            "hour",
                            "18"});
                table1.AddRow(new string[] {
                            "min",
                            "00"});
                table1.AddRow(new string[] {
                            "timezone",
                            "Turkey Time (GMT+3:00)"});
                table1.AddRow(new string[] {
                            "duration",
                            "120"});
                table1.AddRow(new string[] {
                            "registrationLimit",
                            "50"});
                table1.AddRow(new string[] {
                            "description",
                            "Deneme 123"});
#line 7
 testRunner.Given("admin adds new live with", ((string)(null)), table1, "Given ");
#line hidden
#line 18
 testRunner.Then("Delete LIVE", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("2_admin_add_user")]
        public virtual void _2_Admin_Add_User()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("2_admin_add_user", null, tagsOfScenario, argumentsOfScenario);
#line 20
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 21
 testRunner.Given("Open Kurumsal Login Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 22
 testRunner.Given("Login as \"admin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table2.AddRow(new string[] {
                            "email",
                            "admin_deneme@anil.com"});
#line 23
 testRunner.Given("admin checks user is exist", ((string)(null)), table2, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table3.AddRow(new string[] {
                            "user",
                            "admin"});
                table3.AddRow(new string[] {
                            "firstName",
                            "deneme_user_first"});
                table3.AddRow(new string[] {
                            "lastName",
                            "deneme_user_last"});
                table3.AddRow(new string[] {
                            "branch",
                            "Merkez"});
                table3.AddRow(new string[] {
                            "email",
                            "admin_deneme@anil.com"});
                table3.AddRow(new string[] {
                            "userName",
                            "admin_deneme"});
                table3.AddRow(new string[] {
                            "password",
                            "admin_deneme_pass"});
                table3.AddRow(new string[] {
                            "catalog",
                            "ASP 1,ASP 3"});
                table3.AddRow(new string[] {
                            "description",
                            "Deneme 123"});
#line 26
 testRunner.Given("admin adds new user with", ((string)(null)), table3, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table4.AddRow(new string[] {
                            "email",
                            "admin_deneme@anil.com"});
#line 37
 testRunner.Then("Delete User", ((string)(null)), table4, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("3_admin_create_course")]
        public virtual void _3_Admin_Create_Course()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("3_admin_create_course", null, tagsOfScenario, argumentsOfScenario);
#line 41
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 42
 testRunner.Given("Open Kurumsal Login Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 43
 testRunner.Given("Login as \"admin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table5.AddRow(new string[] {
                            "name",
                            "project management"});
#line 44
 testRunner.Given("admin checks course is exist", ((string)(null)), table5, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table6.AddRow(new string[] {
                            "name",
                            "project management"});
                table6.AddRow(new string[] {
                            "tags",
                            "py,pmot,projectmanagemet"});
                table6.AddRow(new string[] {
                            "description",
                            "Py Deneme"});
                table6.AddRow(new string[] {
                            "category",
                            "DevTest"});
                table6.AddRow(new string[] {
                            "moderator",
                            "Anil Senocak"});
                table6.AddRow(new string[] {
                            "catalog",
                            "ASP 3,ASP 4"});
#line 47
 testRunner.Given("admin adds new course with", ((string)(null)), table6, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table7.AddRow(new string[] {
                            "name",
                            "project management"});
#line 55
 testRunner.Then("Delete COURSE", ((string)(null)), table7, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("4_admin_earnings_payment_control")]
        public virtual void _4_Admin_Earnings_Payment_Control()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("4_admin_earnings_payment_control", null, tagsOfScenario, argumentsOfScenario);
#line 59
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 60
 testRunner.Given("Open Kurumsal Login Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 61
 testRunner.Given("Login as \"student\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table8.AddRow(new string[] {
                            "entry",
                            "ÜyelikDönemi08112019"});
                table8.AddRow(new string[] {
                            "name",
                            "Ahmet1234"});
                table8.AddRow(new string[] {
                            "surname",
                            "Can"});
                table8.AddRow(new string[] {
                            "city",
                            "Adana"});
                table8.AddRow(new string[] {
                            "district",
                            "Merkez"});
                table8.AddRow(new string[] {
                            "phone",
                            "5246123811"});
                table8.AddRow(new string[] {
                            "address",
                            "Süleyman Şah camii yanı. No71"});
                table8.AddRow(new string[] {
                            "cardName",
                            "sapdf sdff"});
                table8.AddRow(new string[] {
                            "cardNumber",
                            "5528790000000008"});
                table8.AddRow(new string[] {
                            "cardDate",
                            "11/22"});
                table8.AddRow(new string[] {
                            "cardCVC",
                            "123"});
#line 62
 testRunner.Then("student purchase course", ((string)(null)), table8, "Then ");
#line hidden
#line 75
 testRunner.Given("Open Kurumsal Login Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 76
 testRunner.Given("Login as \"admin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table9.AddRow(new string[] {
                            "name",
                            "Ahmet1234"});
#line 77
 testRunner.Then("Verify earnings payment", ((string)(null)), table9, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("5_admin_add_role")]
        public virtual void _5_Admin_Add_Role()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("5_admin_add_role", null, tagsOfScenario, argumentsOfScenario);
#line 81
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 82
 testRunner.Given("Open Kurumsal Login Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 83
 testRunner.Given("Login as \"admin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table10.AddRow(new string[] {
                            "name",
                            "anil_vedubox_instructor_firstname"});
#line 84
 testRunner.Given("admin checks instructor is exist", ((string)(null)), table10, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table11.AddRow(new string[] {
                            "name",
                            "anil_vedubox_branch"});
#line 87
 testRunner.Given("admin checks branch is exist", ((string)(null)), table11, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table12.AddRow(new string[] {
                            "name",
                            "anil_vedubox_branch"});
                table12.AddRow(new string[] {
                            "limit",
                            "100"});
#line 90
 testRunner.Then("admin adds new branch", ((string)(null)), table12, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table13.AddRow(new string[] {
                            "first_name",
                            "anil_vedubox_instructor_firstname"});
                table13.AddRow(new string[] {
                            "last_name",
                            "anil_vedubox_instructor_lastname"});
                table13.AddRow(new string[] {
                            "branch",
                            "anil_vedubox_branch"});
                table13.AddRow(new string[] {
                            "email",
                            "anil@instructor.com"});
                table13.AddRow(new string[] {
                            "username",
                            "anil_instructor_com"});
                table13.AddRow(new string[] {
                            "password",
                            "anil_instructor_com"});
#line 94
 testRunner.Then("admin adds instructor", ((string)(null)), table13, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table14.AddRow(new string[] {
                            "name",
                            "anil_vedubox_instructor_firstname"});
                table14.AddRow(new string[] {
                            "role1",
                            "Admin"});
                table14.AddRow(new string[] {
                            "role2",
                            "Parent"});
#line 102
 testRunner.Then("admin adds role to instructor", ((string)(null)), table14, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table15.AddRow(new string[] {
                            "name",
                            "anil_vedubox_instructor_firstname"});
#line 107
 testRunner.Then("admin delete instructor", ((string)(null)), table15, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table16.AddRow(new string[] {
                            "name",
                            "anil_vedubox_branch"});
#line 110
 testRunner.Then("admin deletes added branch", ((string)(null)), table16, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("6_admin_add_announcement")]
        public virtual void _6_Admin_Add_Announcement()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("6_admin_add_announcement", null, tagsOfScenario, argumentsOfScenario);
#line 114
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 115
 testRunner.Given("Open Kurumsal Login Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 116
 testRunner.Given("Login as \"admin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table17.AddRow(new string[] {
                            "name",
                            "announcement title by Anil"});
#line 117
 testRunner.Given("admin checks announcement is exist", ((string)(null)), table17, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table18.AddRow(new string[] {
                            "title",
                            "announcement title by Anil"});
                table18.AddRow(new string[] {
                            "description",
                            "announcement description by Anil"});
#line 120
 testRunner.Given("admin adds new announcement with", ((string)(null)), table18, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table19.AddRow(new string[] {
                            "name",
                            "announcement title by Anil"});
#line 124
 testRunner.Then("admin deletes announcement", ((string)(null)), table19, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("10_admin_add_poll")]
        public virtual void _10_Admin_Add_Poll()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("10_admin_add_poll", null, tagsOfScenario, argumentsOfScenario);
#line 128
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 129
 testRunner.Given("Open Kurumsal Login Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 130
 testRunner.Given("Login as \"admin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table20.AddRow(new string[] {
                            "question",
                            "Soru - TRUE FALSE By ANIL"});
#line 131
 testRunner.Given("Admin checks multiple choice question is exist", ((string)(null)), table20, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table21.AddRow(new string[] {
                            "question",
                            "Soru - TRUE FALSE By ANIL"});
                table21.AddRow(new string[] {
                            "type",
                            "True False"});
#line 134
 testRunner.Given("Admin adds multiple choice question with", ((string)(null)), table21, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table22.AddRow(new string[] {
                            "Name",
                            "New Anket by Anil"});
#line 138
 testRunner.Given("Admin checks poll is exist", ((string)(null)), table22, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table23.AddRow(new string[] {
                            "Name",
                            "New Anket by Anil"});
                table23.AddRow(new string[] {
                            "Description",
                            "Deneme Anket by Anil"});
                table23.AddRow(new string[] {
                            "RepeatNumber",
                            "3"});
                table23.AddRow(new string[] {
                            "question",
                            "Soru - TRUE FALSE By ANIL"});
#line 141
 testRunner.Then("Admin adds poll", ((string)(null)), table23, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table24.AddRow(new string[] {
                            "Name",
                            "New Anket by Anil"});
#line 147
 testRunner.Then("Admin deletes Newly added polls", ((string)(null)), table24, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table25.AddRow(new string[] {
                            "question",
                            "Soru - TRUE FALSE By ANIL"});
#line 150
 testRunner.Then("Admin delete multiple choice question with", ((string)(null)), table25, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("15_admin_switch_to_role")]
        public virtual void _15_Admin_Switch_To_Role()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("15_admin_switch_to_role", null, tagsOfScenario, argumentsOfScenario);
#line 154
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 155
 testRunner.Given("Open Kurumsal Login Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 156
 testRunner.Given("Login as \"admin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table26.AddRow(new string[] {
                            "email",
                            "anil@parent.com"});
#line 157
 testRunner.Given("admin checks parent is exist", ((string)(null)), table26, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table27.AddRow(new string[] {
                            "first_name",
                            "anil_vedubox_parent_firstname"});
                table27.AddRow(new string[] {
                            "last_name",
                            "anil_vedubox_parent_lastname"});
                table27.AddRow(new string[] {
                            "email",
                            "anil@parent.com"});
                table27.AddRow(new string[] {
                            "username",
                            "anil_parent_com"});
                table27.AddRow(new string[] {
                            "password",
                            "anil_parent_com"});
#line 160
 testRunner.Then("admin adds parent", ((string)(null)), table27, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table28.AddRow(new string[] {
                            "email",
                            "anil@parent.com"});
                table28.AddRow(new string[] {
                            "role1",
                            "Admin"});
#line 167
 testRunner.Then("admin adds role to parent", ((string)(null)), table28, "Then ");
#line hidden
#line 171
 testRunner.Given("Open Kurumsal Login Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 172
 testRunner.Given("Login as \"custom@anil_parent_com:anil_parent_com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table29.AddRow(new string[] {
                            "password",
                            "anil_parent_com"});
#line 173
 testRunner.When("custom parent switch to admin", ((string)(null)), table29, "When ");
#line hidden
#line 176
 testRunner.Given("Open Kurumsal Login Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 177
 testRunner.Given("Login as \"admin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table30.AddRow(new string[] {
                            "email",
                            "anil@parent.com"});
#line 178
 testRunner.Then("admin deletes added parent", ((string)(null)), table30, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
