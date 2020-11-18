Feature: Admin

Scenario: 1_admin_create_live
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks live is exist
	Given admin adds new live with
		| Key               | Value                  |
		| course_name       | defaultCourse1         |
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
		| branch      | defaultBranch1        |
		| email       | admin_deneme@anil.com |
		| userName    | admin_deneme          |
		| password    | admin_deneme_pass     |
		| catalog     | defaultKatalog1       |
		| description | Deneme 123            |
    Then Delete User
		| Key   | Value                 |
		| email | admin_deneme@anil.com |
	

Scenario: 3_admin_create_course
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks course is exist
		| Key  | Value               |
		| name | anil_vedubox_course |
	Given admin adds new course with
		| Key         | Value               |
		| name        | anil_vedubox_course |
		| tags        | anil,vedubox,course |
		| description | Anil Vedubox Course |
		| category    | defaultCategory1    |
		| teacher     | Anil Senocak        |
		| catalog     | defaultKatalog1     |
	Then admin deletes added Course
		| Key  | Value              |
		| name | anil_vedubox_course|

Scenario: 4_admin_earnings_payment_control
	Given Open Kurumsal Login Page
	Given Login as "student"
	Then student purchase course
		| Key        | Value                         |
		| entry      | Default Course1               |
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
	Then admin adds instructor
		| Key        | Value                             |
		| first_name | anil_vedubox_instructor_firstname |
		| last_name  | anil_vedubox_instructor_lastname  |
		| branch     | defaultBranch1               |
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
	
Scenario: 5_1_admin_add_branch
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks branch is exist
		| Key   | Value               |
		| name  | anil_vedubox_branch |
	Then admin adds new branch
		| Key   | Value               |
		| name  | anil_vedubox_branch |
		| limit | 100                 |
	Then admin deletes added branch
		| Key   | Value               |
		| name  | anil_vedubox_branch |

Scenario: 6_admin_add_announcement
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks announcement is exist
		| Key  | Value                     |
		| name | anil_vedubox_announcement |
	Given admin adds new announcement with
		| Key         | Value                            |
		| title       | anil_vedubox_announcement        |
		| description | announcement description by Anil |
	Then admin deletes announcement
		| Key  | Value                     |
		| name | anil_vedubox_announcement |
	 
Scenario: 7_admin_add_poll_question_multiple_choice
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given Admin checks poll question is exist
		| Key      | Value                                      |
		| question | anıl_vedubox_poll_questıon_multıple_choıce |
	Given Admin adds multiple choice question with
		| Key      | Value                                      |
		| question | anıl_vedubox_poll_questıon_multıple_choıce |
		| answer1  | Answer 1                                   |
		| answer2  | Answer 2                                   |
		| answer3  | Answer 3                                   |
		| answer4  | Answer 4                                   |
	Then Admin delete poll question with
		| Key      | Value                                      |
		| question | anıl_vedubox_poll_questıon_multıple_choıce |
		 
Scenario: 8_admin_add_poll_question_open_ended
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given Admin checks poll question is exist
		| Key      | Value                                 |
		| question | anıl_vedubox_poll_questıon_open_ended |
	Given Admin adds open ended question with
		| Key      | Value                                 |
		| question | anıl_vedubox_poll_questıon_open_ended |
	Then Admin delete poll question with
		| Key      | Value                                 |
		| question | anıl_vedubox_poll_questıon_open_ended |
		 
Scenario: 9_admin_add_poll_auestion_true_false
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given Admin checks poll question is exist
		| Key      | Value                                 |
		| question | anıl_vedubox_poll_questıon_true_false |
	Given Admin adds true false question with
		| Key      | Value                                 |
		| question | anıl_vedubox_poll_questıon_true_false |
	Then Admin delete poll question with
		| Key      | Value                                 |
		| question | anıl_vedubox_poll_questıon_true_false |

Scenario: 10_admin_add_poll
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given Admin checks poll is exist
		| Key  | Value             |
		| Name | New Anket by Anil |
	Then Admin adds poll
		| Key          | Value                         |
		| Name         | New Anket by Anil             |
		| Description  | Deneme Anket by Anil          |
		| RepeatNumber | 3                             |
		| question     | DefaultTrueFalsePoolQuestion1 |
	Then Admin deletes Newly added polls
		| Key  | Value             |
		| Name | New Anket by Anil |
	

Scenario: 11_admin_add_instructor
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks instructor is exist
		| Key  | Value                             |
		| name | anil_vedubox_instructor_firstname |
	Then admin adds instructor
		| Key        | Value                             |
		| first_name | anil_vedubox_instructor_firstname |
		| last_name  | anil_vedubox_instructor_lastname  |
		| branch     | defaultBranch1                    |
		| email      | anil@instructor.com               |
		| username   | anil_instructor_com               |
		| password   | anil_instructor_com               |
   Then admin delete instructor
		| Key  | Value                             |
		| name | anil_vedubox_instructor_firstname |
	

Scenario: 12_admin_add_admin
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks admin is exist
		| Key  | Value                             |
		| name | anil_vedubox_admin_firstname      |
	Then admin adds admin
		| Key        | Value                        |
		| first_name | anil_vedubox_admin_firstname |
		| last_name  | anil_vedubox_admin_lastname  |
		| email      | anil@admin.com               |
		| username   | anil_admin_com               |
		| password   | anil_admin_com               |
   Then admin delete admin
		| Key  | Value                        |
		| name | anil_vedubox_admin_firstname |

Scenario: 13_admin_add_manager
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks manager is exist
		| Key  | Value                          |
		| name | anil_vedubox_manager_firstname |
	Then admin adds manager
		| Key        | Value                          |
		| first_name | anil_vedubox_manager_firstname |
		| last_name  | anil_vedubox_manager_lastname  |
		| branchName | defaultBranch1                 |
		| email      | anil@manager.com               |
		| username   | anil_manager_com               |
		| password   | anil_manager_com               |
   Then admin delete manager
		| Key  | Value                          |
		| name | anil_vedubox_manager_firstname |

Scenario: 14_admin_addes_parent
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks parent is exist
		| Key   | Value           |
		| email | anil@parent.com |
	Then admin adds parent
		| Key              | Value                           |
		| first_name       | anil_vedubox_parent_firstname   |
		| last_name        | anil_vedubox_parent_lastname    |
		| firstBranchName  | defaultBranch1                  |
		| firstStudents    | defaultStudent1 defaultStudent1 |
		| secondBranchName | defaultBranch1                  |
		| secondStudents   | defaultStudent1 defaultStudent1 |
		| email            | anil@parent.com                 |
		| username         | anil_parent_com                 |
		| password         | anil_parent_com                 |
	Then admin deletes added parent
		| Key   | Value           |
		| email | anil@parent.com |
	
Scenario: 15_admin_switch_to_role
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks parent is exist
		| Key   | Value           |
		| email | anil@parent.com |
	Then admin adds parent
		| Key              | Value                           |
		| first_name       | anil_vedubox_parent_firstname   |
		| last_name        | anil_vedubox_parent_lastname    |
		| firstBranchName  | defaultBranch1                  |
		| firstStudents    | defaultStudent1 defaultStudent1 |
		| secondBranchName | defaultBranch1                  |
		| secondStudents   | defaultStudent1 defaultStudent1 |
		| email            | anil@parent.com                 |
		| username         | anil_parent_com                 |
		| password         | anil_parent_com                 |
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

Scenario: 0_admin_add_catalog
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks catalog is exist
		| Key   | Value               |
		| name  | anil_vedubox_catalog|
	Then admin adds new catalog
		| Key         | Value                |
		| name        | anil_vedubox_catalog |
		| tags        | anil,senocak,catalog |
		| description | Catalog Description  |
		| category    | defaultCategory1     |
		| teacher     | Anil Senocak         |
	Then admin adds new catalog subscription to existing catalog
		| Key           | Value                             |
		| name          | anil_vedubox_catalog              |
		| title         | anil_vedubox_catalog_subscription |
		| currency      | TL                                |
		| type          | Permanent                         |
		| duration_time | 100                               |
		| duration_type | Year                              |
	Given admin deletes added catalog
		| Key   | Value               |
		| name  | anil_vedubox_catalog|
	
