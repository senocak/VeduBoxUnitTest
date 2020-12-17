Feature: Instructor

Scenario: 1_instructor_add_live
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks live is exist
	Given instructor adds new live with
		| Key               | Value                  |
		| course_name       | defaultCourse1         |
		| meetingType       | pro                    |
		| title             | deneme                 |
		| timezone          | Turkey Time (GMT+3:00) |
		| duration          | 120                    |
		| registrationLimit | 50                     |
		| description       | Deneme 123             |
	Then instructor deletes live

Scenario: 2_instructor_live_start
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks live is exist
	Given instructor adds new live with
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
	Then verify start live and delete live with

Scenario: 3_instructor_add_student
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks student is exist
		| Key   | Value                            |
		| email | anil_instructor_student@anil.com |
	Given instructor adds new student with
		| Key       | Value                            |
		| firstName | deneme_user_first                |
		| lastName  | deneme_user_last                 |
		| branch    | defaultBranch1                   |
		| email     | anil_instructor_student@anil.com |
		| userName  | admin_deneme                     |
		| password  | admin_deneme_pass                |
		| catalog   | defaultKatalog1                  |
	Then instructor delete student
		| Key   | Value                            |
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
		| category | defaultCategory1               |
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
		| category | defaultCategory1               |
	Given instructor adds subject with
		| Key    | Value                          |
		| course | anil_vedubox_course_instructor |
		| title  | hello world                    |
	Then instructor delete course
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |

Scenario: 6_instructor_add_webinar_join_webinar
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks live is exist
	Given instructor adds new webinar with
		| Key               | Value                  |
		| course_name       | defaultCourse1         |
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
		| category | defaultCategory1    |
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
		| category | defaultCategory1    |
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
		| category | defaultCategory1    |
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

Scenario: 10_instructor_add_content_as_link
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks course is exist
		| Key  | Value               |
		| name | anil_vedubox_course |
	Given instructor adds new course with
		| Key      | Value               |
		| name     | anil_vedubox_course |
		| category | defaultCategory1    |
	Given instructor adds subject with
		| Key    | Value                |
		| course | anil_vedubox_course  |
		| title  | anil_vedubox_subject |
	Given instructor adds content as link
		| Key    | Value                                     |
		| course | anil_vedubox_course                       |
		| title  | anil_vedubox_course_content_as_link_title |
		| desc   | anil_vedubox_course_content_as_link_desc  |
		| link   | https://mail.google.com/mail/u/1/#inbox   |
	Then instructor delete course
		| Key  | Value               |
		| name | anil_vedubox_course |

Scenario: 11_instructor_add_content_as_embed_code
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks course is exist
		| Key  | Value               |
		| name | anil_vedubox_course |
	Given instructor adds new course with
		| Key      | Value               |
		| name     | anil_vedubox_course |
		| category | defaultCategory1    |
	Given instructor adds subject with
		| Key    | Value                |
		| course | anil_vedubox_course  |
		| title  | anil_vedubox_subject |
	Given instructor adds content as embed code
		| Key        | Value                                                                                       |
		| course     | anil_vedubox_course                                                                         |
		| title      | anil_vedubox_course_content_as_embed_code_title                                             |
		| desc       | anil_vedubox_course_content_as_embed_code_desc                                              |
		| embed_code | <iframe width="1280" height="968" src="https://www.youtube.com/embed/ZzBDAtbcFvM"></iframe> |
	Then instructor delete course
		| Key  | Value               |
		| name | anil_vedubox_course |

Scenario: 19_instructor_add_question_batch_question_from_excel
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks question is exist
		| Key  | Value                            |
		| name | anil_vedubox_question_from_excel |
	Given instructor batch create question with
		| Key          | Value                |
		| TestCategory | DefaultTestCategory1 |
	Then instructor deletes question with
		| Key  | Value                            |
		| name | anil_vedubox_question_from_excel |

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
		| TestCategory | DefaultTestCategory1           |
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
		| TestCategory | DefaultTestCategory1      |
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
		| TestCategory | DefaultTestCategory1      |
	Then instructor deletes question with
		| Key  | Value                     |
		| name | Soru - open ended By ANIL |

Scenario: 16_instrcutor_add_question_matching
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks question is exist
		| Key  | Value                   |
		| name | Soru - MATCHING By ANIL |
	Given instructor adds matching question with
		| Key          | Value                   |
		| question     | Soru - MATCHING By ANIL |
		| point        | 45                      |
		| matching1    | Apple = Elma            |
		| matching2    | Kalem = Pencil          |
		| TestCategory | DefaultTestCategory1    |
	Then instructor deletes question with
		| Key  | Value                   |
		| name | Soru - MATCHING By ANIL |

Scenario: 17_instructor_add_question_fill_in_the_blanks
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks question is exist
		| Key  | Value                                 |
		| name | Soru - FILL IN THE BLANKS By ((ANIL)) |
	Given instructor adds fill in the blanks question with
		| Key          | Value                                 |
		| question     | Soru - FILL IN THE BLANKS By ((ANIL)) |
		| point        | 20                                    |
		| TestCategory | DefaultTestCategory1                  |
	Then instructor deletes question with
		| Key  | Value                                 |
		| name | Soru - FILL IN THE BLANKS By ((ANIL)) |

Scenario: 20_instructor_add_test_pool_multiple_choice
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks test poll question is exist
		| Key  | Value                                  |
		| name | anil_vedubox_test_pool_multiple_choice |
	Given instructor adds test pool multiple choice with
		| Key          | Value                                  |
		| name         | anil_vedubox_test_pool_multiple_choice |
		| time         | 45                                     |
		| TestCategory | DefaultTestCategory1                   |
		| question     | Default Multiple Choice Question1      |
	Given instructor delete tests with
		| Key  | Value                                  |
		| name | anil_vedubox_test_pool_multiple_choice |

Scenario: 21_instructor_add_test_multiple_choice_adding_question_with_document
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks test poll question is exist
		| Key  | Value                                                |
		| name | anil_vedubox_test_pool_multiple_choice_with_document |
	Then instructor adds test pool multiple choice with document
		| Key            | Value                                                |
		| name           | anil_vedubox_test_pool_multiple_choice_with_document |
		| Duration       | 25                                                   |
		| questionNumber | 8                                                    |
		| points         | 15                                                   |
		| choicesNumber  | 4                                                    |
		| firstAnswer    | A                                                    |
		| secondAnswer   | B                                                    |
		| thirdAnswer    | C                                                    |
		| fourthAnswer   | D                                                    |
		| fifthAnswer    | A                                                    |
		| sixthAnswer    | B                                                    |
		| seventhAnswer  | C                                                    |
		| eighthAnswer   | D                                                    |
		| TestCategory   | DefaultTestCategory1                                 |
	Given instructor delete tests with
		| Key  | Value                                                |
		| name | anil_vedubox_test_pool_multiple_choice_with_document |

Scenario: 23_instructor_add_exam_multiple_choice
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks exam is exist
		| Key  | Value                                |
		| name | anil_instructor_exam_multiple_choice |
	Then instructor adds exam with multiple choice
		| Key          | Value                                            |
		| name         | anil_instructor_exam_multiple_choice_name        |
		| description  | anil_instructor_exam_multiple_choice_description |
		| repeatNumber | 3                                                |
		| catalogs     | defaultKatalog1                                  |
		| tests        | Default Multiple Choice Test1                    |
	Given instructor delete exam with
		| Key  | Value                                |
		| name | anil_instructor_exam_multiple_choice |

Scenario: 24_instructor_add_exam_multiple_choice_with_pdf
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks exam is exist
		| Key  | Value                                         |
		| name | anil_instructor_exam_multiple_choice_with_pdf |
	Then instructor adds exam with multiple choice
		| Key          | Value                                                     |
		| name         | anil_instructor_exam_multiple_choice_with_pdf_name        |
		| description  | anil_instructor_exam_multiple_choice_with_pdf_description |
		| repeatNumber | 5                                                         |
		| catalogs     | defaultKatalog1                                           |
		| tests        | Default Multiple Choice With Pdf Test1                    |
	Given instructor delete exam with
		| Key  | Value                                         |
		| name | anil_instructor_exam_multiple_choice_with_pdf |

Scenario: 25_instructor_add_exam_open_ended
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks exam is exist
		| Key  | Value                           |
		| name | anil_instructor_exam_open_ended |
	Then instructor adds exam with open ended
		| Key          | Value                                       |
		| name         | anil_instructor_exam_open_ended_name        |
		| description  | anil_instructor_exam_open_ended_description |
		| repeatNumber | 2                                           |
		| catalogs     | defaultKatalog1                             |
		| tests        | Default Open Ended Test1                    |
	Given instructor delete exam with
		| Key  | Value                           |
		| name | anil_instructor_exam_open_ended |

Scenario: 26_instructor_answers_Question_And_Answer
    #Given Open Kurumsal Login Page
	#Given Login as "instructor"
	#Given instructor checks Q&A is exist
	Given Open Kurumsal Login Page
	Given Login as "student"
    Given student adds new Q&A
		| Key        | Value                           |
		| courseName | defaultCourse2 (Anil Senocak)   |
		| subject    | defaultQuestionAndAnswer        |
		| message    | defaultQuestionAndAnswerMessage |
    Given Open Kurumsal Login Page
	Given Login as "instructor"
	Then  instructor answers the question
	| Key    | Value                    |
	| answer | anil answer the question |
	Then instructor deletes new Q&A

Scenario: 22_instructor_add_test_poll_open_ended
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks test poll question is exist
		| Key  | Value                             |
		| name | anil_vedubox_test_pool_open_ended |
	Given instructor adds test pool open ended with
		| Key          | Value                             |
		| name         | anil_vedubox_test_pool_open_ended |
		| time         | 45                                |
		| TestCategory | DefaultTestCategory1              |
		| question     | Default Open Ended Question1      |
	Given instructor delete tests with
		| Key  | Value                             |
		| name | anil_vedubox_test_pool_open_ended |

Scenario: 0_instructor_add_exam_with_default_params
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks exam is exist
		| Key  | Value                |
		| name | anil_instructor_exam |
	Then instructor adds exam with document
		| Key         | Value                                                                           |
		| name        | anil_instructor_exam_name                                                       |
		| description | anil_instructor_exam_description                                                |
		| catalogs    | defaultKatalog1,defaultKatalog2                                                 |
		| tests       | Default Multiple Choice Test1,Default True False Test1,Default Open Ended Test1 |
	Given instructor delete exam with
		| Key  | Value                |
		| name | anil_instructor_exam |
