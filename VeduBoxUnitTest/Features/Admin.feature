Feature: Admin

Scenario: 1_admin_create_live
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks live is exist
	Given admin adds new live with
	 | Key               | Value                  |
	 | course_name       | deneme_admin           |
	 | meetingType       | pro                    |
	 | title             | deneme                 |
	 | hour              | 18                     |
	 | min               | 00                     |
	 | timezone          | Turkey Time (GMT+3:00) |
	 | duration          | 120                    |
	 | registrationLimit | 50                     |
	 | description       | Deneme 123             |
	Then Delete LIVE

Scenario: 2_admin_add_user
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks user is exist
	 | Key   | Value                 |
	 | email | admin_deneme@anil.com |
	Given admin adds new user with
	 | Key         | Value                 |
	 | user        | admin                 |
	 | firstName   | deneme_user_first     |
	 | lastName    | deneme_user_last      |
	 | branch      | Merkez                |
	 | email       | admin_deneme@anil.com |
	 | userName    | admin_deneme          |
	 | password    | admin_deneme_pass     |
	 | catalog     | ASP 1,ASP 3           |
	 | description | Deneme 123            |
	Then Delete User
	 | Key   | Value                 |
	 | email | admin_deneme@anil.com |

Scenario: 3_admin_create_course
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks course is exist
	 | Key  | Value              |
	 | name | project management |
	Given admin adds new course with
	 | Key         | Value                    |
	 | name        | project management       |
	 | tags        | py,pmot,projectmanagemet |
	 | description | Py Deneme                |
	 | category    | DevTest                  |
	 | moderator   | Anil Senocak             |
	 | catalog     | ASP 3,ASP 4              |
	Then Delete COURSE
	 | Key  | Value              |
	 | name | project management |

Scenario: 4_admin_earnings_payment_control
	Given Open Kurumsal Login Page
	Given Login as "student"
	Then student purchase course
	 | Key        | Value                         |
	 | entry      | ÜyelikDönemi08112019          |
	 | name       | Ahmet1234                     |
	 | surname    | Can                           |
	 | city       | Adana                         |
	 | district   | Merkez                        |
	 | phone      | 5246123811                    |
	 | address    | Süleyman Şah camii yanı. No71 |
	 | cardName   | sapdf sdff                    |
	 | cardNumber | 5528790000000008              |
	 | cardDate   | 11/22                         |
	 | cardCVC    | 123                           |
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Then Verify earnings payment
	 | Key  | Value     |
	 | name | Ahmet1234 |

Scenario: 5_admin_add_role
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks instructor is exist
	 | Key  | Value                             |
	 | name | anil_vedubox_instructor_firstname |
	Given admin checks branch is exist
	 | Key   | Value               |
	 | name  | anil_vedubox_branch |
	Then admin adds new branch
	 | Key   | Value               |
	 | name  | anil_vedubox_branch |
	 | limit | 100                 |
	Then admin adds instructor
	 | Key        | Value                             |
	 | first_name | anil_vedubox_instructor_firstname |
	 | last_name  | anil_vedubox_instructor_lastname  |
	 | branch     | anil_vedubox_branch               |
	 | email      | anil@instructor.com               |
	 | username   | anil_instructor_com               |
	 | password   | anil_instructor_com               |
	Then admin adds role to instructor
	 | Key   | Value                             |
	 | name  | anil_vedubox_instructor_firstname |
	 | role1 | Admin                             |
	 | role2 | Parent                            |
	Then admin delete instructor
	 | Key  | Value                             |
	 | name | anil_vedubox_instructor_firstname |
	Then admin deletes added branch
	 | Key   | Value               |
	 | name  | anil_vedubox_branch |

Scenario: 6_admin_add_announcement
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks announcement is exist
	 | Key  | Value                      |
	 | name | announcement title by Anil |
	Given admin adds new announcement with
	 | Key         | Value                            |
	 | title       | announcement title by Anil       |
	 | description | announcement description by Anil |
	Then admin deletes announcement
	 | Key  | Value                      |
	 | name | announcement title by Anil |

Scenario: 10_admin_add_poll
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given Admin checks multiple choice question is exist
	 | Key      | Value                     |
	 | question | Soru - TRUE FALSE By ANIL |
	Given Admin adds multiple choice question with
	 | Key      | Value                     |
	 | question | Soru - TRUE FALSE By ANIL |
	 | type     | True False                |
	Given Admin checks poll is exist
	| Key  | Value             |
	| Name | New Anket by Anil |
	Then Admin adds poll
	| Key          | Value                     |
	| Name         | New Anket by Anil         |
	| Description  | Deneme Anket by Anil      |
	| RepeatNumber | 3                         |
	| question     | Soru - TRUE FALSE By ANIL |
	Then Admin deletes Newly added polls
    | Key  | Value             |
    | Name | New Anket by Anil |
	Then Admin delete multiple choice question with
	| Key      | Value                     |
	| question | Soru - TRUE FALSE By ANIL |
	
Scenario: 15_admin_switch_to_role
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks parent is exist
	 | Key   | Value           |
	 | email | anil@parent.com |
	Then admin adds parent
	 | Key        | Value                         |
	 | first_name | anil_vedubox_parent_firstname |
	 | last_name  | anil_vedubox_parent_lastname  |
	 | email      | anil@parent.com               |
	 | username   | anil_parent_com               |
	 | password   | anil_parent_com               |
	Then admin adds role to parent
	 | Key   | Value           |
	 | email | anil@parent.com |
	 | role1 | Admin           |
	Given Open Kurumsal Login Page
	Given Login as "custom@anil_parent_com:anil_parent_com"
	When custom parent switch to admin
	 | Key      | Value           |
	 | password | anil_parent_com |
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Then admin deletes added parent
	 | Key   | Value           |
	 | email | anil@parent.com |
	 