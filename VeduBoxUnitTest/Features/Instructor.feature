Feature: Instructor

Scenario: 1_instructor_add_live
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks live is exist
	Given instructor adds new live with
		| Key               | Value                  |
		| course_name       | deneme_instructor      |
		| meetingType       | pro                    |
		| title             | deneme                 |
		| hour              | 18                     |
		| min               | 00                     |
		| timezone          | Turkey Time (GMT+3:00) |
		| duration          | 120                    |
		| registrationLimit | 50                     |
		| description       | Deneme 123             |
	Then Delete LIVE

Scenario: 2_instructor_live_start
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks live is exist
	Given instructor adds new live with
		| Key               | Value                  |
		| course_name       | deneme_instructor      |
		| meetingType       | pro                    |
		| title             | deneme                 |
		| hour              | 18                     |
		| min               | 00                     |
		| timezone          | Turkey Time (GMT+3:00) |
		| duration          | 120                    |
		| registrationLimit | 50                     |
		| description       | Deneme 123             |
	Then verify start live and delete live with

Scenario: 3_instructor_add_user
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks user is exist
		| Key   | Value                 |
		| email | admin_deneme@anil.com |
	Given instructor adds new user with
		| Key       | Value                 |
		| firstName | deneme_user_first     |
		| lastName  | deneme_user_last      |
		| branch    | Merkez                |
		| email     | admin_deneme@anil.com |
		| userName  | admin_deneme          |
		| password  | admin_deneme_pass     |
		| catalog   | deneme_instructor     |
	Then instructor delete User
		| Key   | Value                 |
		| email | admin_deneme@anil.com |

Scenario: 4_instructor_add_course
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks course is exist
		| Key  | Value              |
		| name | project management |
	Given instructor adds new course with
		| Key      | Value              |
		| name     | project management |
		| category | DevTest            |
	Then instructor delete course
		| Key  | Value              |
		| name | project management |

Scenario: 5_instructor_add_subject
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks course is exist
		| Key  | Value              |
		| name | project management |
	Given instructor adds new course with
		| Key      | Value              |
		| name     | project management |
		| category | DevTest            |
	Given instructor adds subject with
		| Key   | Value              |
		| name  | project management |
		| title | hello world        |
	Then instructor delete course
		| Key  | Value              |
		| name | project management |

Scenario: 6_instructor_add_webinar_join_webinar
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks live is exist
	Given instructor adds new webinar with
		| Key               | Value                  |
		| course_name       | deneme_instructor      |
		| meetingType       | webinar                |
		| title             | deneme                 |
		| hour              | 18                     |
		| min               | 00                     |
		| timezone          | Turkey Time (GMT+3:00) |
		| duration          | 120                    |
		| registrationLimit | 50                     |
		| description       | Deneme 123             |
	Then instructor copies webinar URL with
		| Key       | Value           |
		| firstName | Lorem           |
		| lastName  | Ipsum           |
		| phone     | 123456789012    |
		| email     | lorem@ipsum.com |
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Then instructor deletes webinar with

Scenario: 7_instructor_add_content_as_document
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks course is exist
		| Key  | Value              |
		| name | project management |
	Given instructor adds new course with
		| Key      | Value              |
		| name     | project management |
		| category | DevTest            |
	Given instructor adds subject with
		| Key   | Value              |
		| name  | project management |
		| title | hello world        |
	Given instructor adds file source with
		| Key   | Value              |
		| name  | project management |
		| title | Döküman Ekleme     |
		| desc  | Test               |
	Then instructor delete course
		| Key  | Value              |
		| name | project management |
	 
Scenario: 8_instrcutor_add_content_as_video
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks course is exist
		| Key  | Value              |
		| name | project management |
	Given instructor adds new course with
		| Key      | Value              |
		| name     | project management |
		| category | DevTest            |
	Given instructor adds subject with
		| Key   | Value              |
		| name  | project management |
		| title | hello world        |
	Given instructor adds video source with
		| Key   | Value              |
		| name  | project management |
		| title | Döküman Ekleme     |
		| desc  | Test               |
	Then instructor delete course
		| Key  | Value              |
		| name | project management |
	 
Scenario: 9_instructor_add_content_as_video_with_vimeo
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks course is exist
		| Key  | Value              |
		| name | project management |
	Given instructor adds new course with
		| Key      | Value              |
		| name     | project management |
		| category | DevTest            |
	Given instructor adds subject with
		| Key   | Value              |
		| name  | project management |
		| title | hello world        |
	Given instructor adds video with vimeo
		| Key   | Value                       |
		| name  | project management          |
		| title | Video Ekleme (Vimeo ID ile) |
		| desc  | Test                        |
		| id    | 444883013                   |
	Then instructor delete course
		| Key  | Value              |
		| name | project management |
	 
Scenario: 12_instructor_add_question_multiple_choice
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks question is exist
		| Key  | Value                          |
		| name | Soru - MULTIPLE CHOICE By ANIL |
	Given instructor adds multiple choice question with
		| Key          | Value                          |
		| question     | Soru - MULTIPLE CHOICE By ANIL |
		| point        | 25                             |
		| choiceA      | A Şıkkı                        |
		| choiceB      | B Şıkkı                        |
		| choiceC      | C Şıkkı                        |
		| choiceD      | D Şıkkı                        |
		| TestCategory | EğitmenBurakTestKategori       |
	Then instructor delete multiple choice question with
		| Key  | Value                          |
		| name | Soru - MULTIPLE CHOICE By ANIL |

Scenario: 13_instructor_add_question_true_false
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks question is exist
		| Key  | Value                     |
		| name | Soru - TRUE FALSE By ANIL |
	Given instructor adds true false question with
		| Key          | Value                     |
		| question     | Soru - TRUE FALSE By ANIL |
		| point        | 35                        |
		| answer       | False                     |
		| TestCategory | EğitmenBurakTestKategori  |
	Then instructor delete multiple choice question with
		| Key  | Value                     |
		| name | Soru - TRUE FALSE By ANIL |
	
Scenario: 14_instructor_add_question_open_ended
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks question is exist
		| Key  | Value                     |
		| name | Soru - open ended By ANIL |
	Given instructor adds open_ended question with
		| Key          | Value                     |
		| question     | Soru - open ended By ANIL |
		| point        | 45                        |
		| TestCategory | EğitmenBurakTestKategori  |
	Then instructor delete multiple choice question with
		| Key  | Value                     |
		| name | Soru - open ended By ANIL |
	
Scenario: 20_instructor_add_test_multiple_choice
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor adds multiple choice question with
		| Key          | Value                          |
		| question     | Soru - MULTIPLE CHOICE By ANIL |
		| point        | 25                             |
		| choiceA      | A Şıkkı                        |
		| choiceB      | B Şıkkı                        |
		| choiceC      | C Şıkkı                        |
		| choiceD      | D Şıkkı                        |
		| TestCategory | EğitmenBurakTestKategori       |
	Given instructor adds tests with
		| Key          | Value                          |
		| name         | new test added by ANIL         |
		| time         | 45                             |
		| TestCategory | EğitmenBurakTestKategori       |
		| question     | Soru - MULTIPLE CHOICE By ANIL |
	Given instructor delete tests with
		| Key  | Value                  |
		| name | new test added by ANIL |
	Then instructor delete multiple choice question with
		| Key  | Value                          |
		| name | Soru - MULTIPLE CHOICE By ANIL |