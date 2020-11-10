Feature: Instructor

Scenario: 1_instructor_add_live
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks live is exist
	Given instructor adds new live with
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

Scenario: 2_instructor_live_start
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks live is exist
	Given instructor adds new live with
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
	Then verify start live and delete live with

Scenario: 3_instructor_add_student
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks student is exist
		| Key   | Value                 |
		| email | anil_instructor_student@anil.com |
	Given instructor adds new student with
		| Key       | Value                 |
		| firstName | deneme_user_first     |
		| lastName  | deneme_user_last      |
		| branch    | Merkez/Center         |
		| email     | anil_instructor_student@anil.com |
		| userName  | admin_deneme          |
		| password  | admin_deneme_pass     |
		| catalog   | deneme_admin          |
	Then instructor delete student
		| Key   | Value                 |
		| email | anil_instructor_student@anil.com |

Scenario: 4_instructor_add_course
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks course is exist
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |
	Given instructor adds new course with
		| Key      | Value                          |
		| name     | anil_vedubox_course_instructor |
		| category | selenium                       |
	Then instructor delete course
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |

Scenario: 5_instructor_add_subject
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks course is exist
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |
	Given instructor adds new course with
		| Key      | Value                          |
		| name     | anil_vedubox_course_instructor |
		| category | selenium                       |
	Given instructor adds subject with
		| Key   | Value                          |
		| name  | anil_vedubox_course_instructor |
		| title | hello world                    |
	Then instructor delete course
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |

Scenario: 6_instructor_add_webinar_join_webinar
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks live is exist
	Given instructor adds new webinar with
		| Key               | Value                  |
		| course_name       | deneme_admin           |
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
		| Key  | Value               |
		| name | anil_vedubox_course |
	Given instructor adds new course with
		| Key      | Value               |
		| name     | anil_vedubox_course |
		| category | selenium            |
	Given instructor adds subject with
		| Key    | Value                |
		| course | anil_vedubox_course  |
		| title  | anil_vedubox_subject |
	Given instructor adds file source with
		| Key    | Value                        |
		| course | anil_vedubox_course          |
		| title  | anil_vedubox_file_to_subject |
		| desc   | anil_vedubox_file_desc       |
	Then instructor delete course
		| Key  | Value               |
		| name | anil_vedubox_course |
	 
Scenario: 8_instrcutor_add_content_as_video
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks course is exist
		| Key  | Value               |
		| name | anil_vedubox_course |
	Given instructor adds new course with
		| Key      | Value               |
		| name     | anil_vedubox_course |
		| category | selenium            |
	Given instructor adds subject with
		| Key    | Value                |
		| course | anil_vedubox_course  |
		| title  | anil_vedubox_subject |
	Given instructor adds video source with
		| Key    | Value                         |
		| course | anil_vedubox_course           |
		| title  | anil_vedubox_video_to_subject |
		| desc   | anil_vedubox_video_desc       |
	Then instructor delete course
		| Key  | Value               |
		| name | anil_vedubox_course |
	 
Scenario: 9_instructor_add_content_as_video_with_vimeo
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks course is exist
		| Key  | Value               |
		| name | anil_vedubox_course |
	Given instructor adds new course with
		| Key      | Value               |
		| name     | anil_vedubox_course |
		| category | selenium            |
	Given instructor adds subject with
		| Key    | Value                |
		| course | anil_vedubox_course  |
		| title  | anil_vedubox_subject |
	Given instructor adds video with vimeo
		| Key    | Value                                  |
		| course | anil_vedubox_course                    |
		| title  | anil_vedubox_video_to_subject_vimeo_id |
		| desc   | anil_vedubox_video_desc                |
		| id     | 444883013                              |
	Then instructor delete course
		| Key  | Value               |
		| name | anil_vedubox_course |
	 
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
		| TestCategory | EğitmenAnilTestKategori        |
	Then instructor deletes question with
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
		| TestCategory | EğitmenAnilTestKategori   |
	Then instructor deletes question with
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
		| TestCategory | EğitmenAnilTestKategori   |
	Then instructor deletes question with
		| Key  | Value                     |
		| name | Soru - open ended By ANIL |
	
Scenario: 20_instructor_add_test_multiple_choice
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
		| TestCategory | EğitmenAnilTestKategori        |
	Given instructor checks test poll question is exist
		| Key  | Value                          |
		| name | Soru - MULTIPLE CHOICE By ANIL |
	Given instructor adds test pool multiple choice with
		| Key          | Value                          |
		| name         | anil_vedubox_test              |
		| time         | 45                             |
		| TestCategory | EğitmenAnilTestKategori        |
		| question     | Soru - MULTIPLE CHOICE By ANIL |
	Given instructor delete tests with
		| Key  | Value             |
		| name | anil_vedubox_test |
	Then instructor deletes question with
		| Key  | Value                          |
		| name | Soru - MULTIPLE CHOICE By ANIL |

Scenario: 21_instructor_add_test_multiple_choice_adding_question_with_document
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks test poll question is exist
		| Key  | Value                                        |
		| name | TEST - MULTIPLE CHOICE WITH DOCUMENT By ANIL |
	Then instructor adds test pool multiple choice with document
		| Key            | Value                                        |
		| Name           | anil_vedubox_test                            |
		| Description    | TEST - MULTIPLE CHOICE WITH DOCUMENT By ANIL |
		| Duration       | 25                                           |
		| questionNumber | 8                                            |
		| points         | 15                                           |
		| choicesNumber  | 4                                            |
		| firstAnswer    | A                                            |
		| secondAnswer   | B                                            |
		| thirdAnswer    | C                                            |
		| fourthAnswer   | D                                            |
		| fifthAnswer    | A                                            |
		| sixthAnswer    | B                                            |
		| seventhAnswer  | C                                            |
		| eighthAnswer   | D                                            |
		| TestCategory   | EğitmenAnilTestKategori                      |
	Given instructor delete tests with
		| Key  | Value             |
		| name | anil_vedubox_test |