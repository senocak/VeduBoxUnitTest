Feature: Admin

Scenario: 1_admin_add_live
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks live is exist
	Given admin adds new live with
		| Key               | Value                  |
		| course_name       | defaultCourse1         |
		| meetingType       | pro                    |
		| title             | deneme                 |
		| timezone          | Turkey Time (GMT+3:00) |
		| duration          | 120                    |
		| registrationLimit | 50                     |
		| description       | Deneme 123             |
	Then admin deletes live

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
		| branch     | defaultBranch1                    |
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
	Given Admin adds multiple choice poll question with
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
	Given Admin adds open ended poll question with
		| Key      | Value                                 |
		| question | anıl_vedubox_poll_questıon_open_ended |
	Then Admin delete poll question with
		| Key      | Value                                 |
		| question | anıl_vedubox_poll_questıon_open_ended |
		 
Scenario: 9_admin_add_poll_question_true_false
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given Admin checks poll question is exist
		| Key      | Value                                 |
		| question | anıl_vedubox_poll_questıon_true_false |
	Given Admin adds true false poll question with
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

Scenario: 17_admin_add_catalog_subscription_type_permanent
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
	Then admin adds new catalog subscription type to existing catalog
		| Key           | Value                             |
		| name          | anil_vedubox_catalog              |
		| description   | anil_vedubox_description          |
		| title         | anil_vedubox_catalog_subscription |
		| currency      | TL                                |
		| amount        | 10                                |
		| salePrice     | 15                                |
		| type          | Permanent                         |
		| duration_time | 5                                 |
		| duration_type | Month                             |
    Given admin deletes added catalog
		| Key   | Value               |
		| name  | anil_vedubox_catalog|

Scenario: 18_admin_add_catalog_subscription_type_temporary
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
	Then admin adds new catalog subscription type temporary to existing catalog
		| Key           | Value                             |
		| name          | anil_vedubox_catalog              |
		| description   | anil_vedubox_description          |
		| title         | anil_vedubox_catalog_subscription |
		| currency      | TL                                |
		| amount        | 35                                |
		| salePrice     | 25                                |
		| type          | Temporary                         |
		| duration_time | 5                                 |
		| duration_type | Month                             |
    Given admin deletes added catalog
		| Key   | Value               |
		| name  | anil_vedubox_catalog|
	

Scenario: 19_admin_live_query
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks live is exist
	Given admin adds new live with
		| Key               | Value                  |
		| course_name       | defaultCourse1         |
		| meetingType       | pro                    |
		| title             | deneme                 |
		| timezone          | Turkey Time (GMT+3:00) |
		| duration          | 120                    |
		| registrationLimit | 50                     |
		| description       | Deneme 123             |
    Then admin query live
	| Key              | Value          |
	| startHourParam   | 00             |
	| startMinuteParam | 00             |
	| endHourParam     | 23             |
	| endMinuteParam   | 55             |
	| courseName       | defaultCourse1 |
	Then admin deletes live

Scenario: 20_admin_add_content_document
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
	Given admin adds new resource as document
		| Key                  | Value                                    |
		| name                 | anil_vedubox_course                      |
		| subject_title        | anil_vedubox_course_subject              |
		| resource_title       | anil_vedubox_course_resource_title       |
		| resource_description | anil_vedubox_course_resource_description |
	Then admin deletes added Course
		| Key  | Value              |
		| name | anil_vedubox_course|

Scenario: 21_admin_add_content_video_with_dekstop
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
	Given admin adds new resource as video
		| Key                  | Value                                    |
		| name                 | anil_vedubox_course                      |
		| subject_title        | anil_vedubox_course_subject              |
		| resource_title       | anil_vedubox_course_resource_title       |
		| resource_description | anil_vedubox_course_resource_description |
	Then admin deletes added Course
		| Key  | Value              |
		| name | anil_vedubox_course|

Scenario: 22_admin_add_content_video_with_vimeo_id
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
	Given admin adds new resource as video with vimeo id
		| Key                  | Value                                    |
		| name                 | anil_vedubox_course                      |
		| subject_title        | anil_vedubox_course_subject              |
		| resource_title       | anil_vedubox_course_resource_title       |
		| resource_description | anil_vedubox_course_resource_description |
		| vimeo_id             | 444883013                                |
	Then admin deletes added Course
		| Key  | Value              |
		| name | anil_vedubox_course|

Scenario: 23_admin_add_content_link
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
	Given admin adds new resource as link
		| Key                  | Value                                    |
		| name                 | anil_vedubox_course                      |
		| subject_title        | anil_vedubox_course_subject              |
		| resource_title       | anil_vedubox_course_resource_title       |
		| resource_description | anil_vedubox_course_resource_description |
		| link                 | http://github.com/senocak                |
	Then admin deletes added Course
		| Key  | Value              |
		| name | anil_vedubox_course|

Scenario: 24_admin_add_content_embed
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
	Given admin adds new resource as embed
		| Key                  | Value                                                             |
		| name                 | anil_vedubox_course                                               |
		| subject_title        | anil_vedubox_course_subject                                       |
		| resource_title       | anil_vedubox_course_resource_title                                |
		| resource_description | anil_vedubox_course_resource_description                          |
		| embed_code           | <iframe src="https://www.youtube.com/embed/ZzBDAtbcFvM"></iframe> |
	Then admin deletes added Course
		| Key  | Value              |
		| name | anil_vedubox_course|

Scenario: 26_admin_add_content_text
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
	Given admin adds new resource as text
		| Key                  | Value                                    |
		| name                 | anil_vedubox_course                      |
		| subject_title        | anil_vedubox_course_subject              |
		| resource_title       | anil_vedubox_course_resource_title       |
		| resource_description | anil_vedubox_course_resource_description |
	Then admin deletes added Course
		| Key  | Value              |
		| name | anil_vedubox_course|

Scenario: 27_admin_disccount_codes_add_is_limited
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks discount code is exist
		| Key  | Value  |
		| name | code12 |
	Given admin adds new discount code with
		| Key         | Value                      |
		| code        | code12                     |
		| description | Anil Vedubox Discount Code |
		| percentage  | 34                         |
		| limit       | true                       |
		| usage_limit | 10			               |
	Then admin deletes added discount code
		| Key  | Value              |
		| name | code12             |

Scenario: 28_admin_disccount_codes_add_is_not_limited
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks discount code is exist
		| Key  | Value  |
		| name | code12 |
	Given admin adds new discount code with
		| Key         | Value                      |
		| code        | code12                     |
		| description | Anil Vedubox Discount Code |
		| percentage  | 34                         |
		| limit       | false                      |
	Then admin deletes added discount code
		| Key  | Value              |
		| name | code12             |

Scenario: 30_admin_add_student_batch_create
	Given Open Kurumsal Login Page
	Given Login as "admin"
	Given admin checks user is exist
		| Key   | Value                 |
		| email | admin_deneme@anil.com |
	Given admin adds new batch user with
		| Key         | Value                 |
		| user        | admin                 |
		| branch      | defaultBranch1        |
		| catalog     | Default Course1       |
	Then Delete User
		| Key   | Value                 |
		| email | admin_deneme@anil.com |


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
	Then admin adds new catalog subscription type to existing catalog
		| Key           | Value                             |
		| name          | anil_vedubox_catalog              |
		| description   | anil_vedubox_description          |
		| title         | anil_vedubox_catalog_subscription |
		| currency      | TL                                |
		| amount        | 20                                |
		| salePrice     | 30                                |
		| type          | Permanent                         |
		| duration_time | 1                                 |
		| duration_type | Year                              |
	Given admin deletes added catalog
		| Key   | Value               |
		| name  | anil_vedubox_catalog|