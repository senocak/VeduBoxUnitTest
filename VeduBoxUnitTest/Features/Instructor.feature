Feature: Instructor

Scenario: 01_instructor_add_live
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks live is exist
	Given instructor adds new live with
		| Key               | Value                   |
		| course_name       | defaultCourse1          |
		| meetingType       | Pro                     |
		| title             | deneme                  |
		| timezone          | Europe/Istanbul (GMT+3) |
		| duration          | 120                     |
		| registrationLimit | 50                      |
		| description       | Deneme 123              |
	Then instructor deletes live

Scenario: 02_instructor_live_start
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks live is exist
	Given instructor adds new live with
		| Key               | Value                   |
		| course_name       | defaultCourse1          |
		| meetingType       | Pro                     |
		| title             | deneme                  |
		| hour              | 18                      |
		| min               | 00                      |
		| timezone          | Europe/Istanbul (GMT+3) |
		| duration          | 120                     |
		| registrationLimit | 50                      |
		| description       | Deneme 123              |
	Then verify start live and delete live with

Scenario: 03_instructor_add_student
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
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

Scenario: 04_instructor_add_course
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
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

Scenario: 05_instructor_add_subject
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
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

Scenario: 06_instructor_add_webinar_join_webinar
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks live is exist
	Given instructor adds new webinar with
		| Key               | Value                   |
		| course_name       | defaultCourse1          |
		| meetingType       | Webinar                 |
		| title             | deneme                  |
		| hour              | 18                      |
		| min               | 00                      |
		| timezone          | Europe/Istanbul (GMT+3) |
		| duration          | 120                     |
		| registrationLimit | 50                      |
		| description       | Deneme 123              |
	Then instructor copies webinar URL with
		| Key          | Value           |
		| firstName    | Lorem           |
		| lastName     | Ipsum           |
		| email        | lorem@ipsum.com |
		| confirmEmail | lorem@ipsum.com |
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Then instructor deletes webinar with

Scenario: 07_instructor_add_content_as_document
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
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
	 
Scenario: 08_instrcutor_add_content_as_video
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
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
	 
Scenario: 09_instructor_add_content_as_video_with_vimeo
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
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
		| Key      | Value                                  |
		| course   | anil_vedubox_course                    |
		| title    | anil_vedubox_video_to_subject_vimeo_id |
		| desc     | anil_vedubox_video_desc                |
		| vimeo_id | 444883013                              |
	Then instructor delete course
		| Key  | Value               |
		| name | anil_vedubox_course |

Scenario: 10_instructor_add_content_as_link
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
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
		| link   | https://github.com/senocak                |
	Then instructor delete course
		| Key  | Value               |
		| name | anil_vedubox_course |

Scenario: 11_instructor_add_content_as_embed_code
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
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
		| Key        | Value                                                             |
		| course     | anil_vedubox_course                                               |
		| title      | anil_vedubox_course_content_as_embed_code_title                   |
		| desc       | anil_vedubox_course_content_as_embed_code_desc                    |
		| embed_code | <iframe src="https://www.youtube.com/embed/ZzBDAtbcFvM"></iframe> |
	Then instructor delete course
		| Key  | Value               |
		| name | anil_vedubox_course |


Scenario: 19_instructor_add_question_batch_question_from_excel
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
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
	Given Login as "Instructor"
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
	Given Login as "Instructor"
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
	Given Login as "Instructor"
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

Scenario: 15_instrcutor_add_question_ordering
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks question is exist
		| Key  | Value                   |
		| name | Soru - ORDERING By ANIL |
	Given instructor adds ordering question with
		| Key          | Value                   |
		| question     | Soru - ORDERING By ANIL |
		| point        | 20                      |
		| ordering1    | 1st                     |
		| ordering2    | 2nd                     |
		| ordering3    | 3rd                     |
		| ordering4    | 4th                     |
		| TestCategory | DefaultTestCategory1    |
	Then instructor deletes question with
		| Key  | Value                   |
		| name | Soru - ORDERING By ANIL |

Scenario: 16_instrcutor_add_question_matching
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
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
	Given Login as "Instructor"
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

Scenario: 18_instructor_add_question_multiple_answer
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks question is exist
		| Key  | Value                          |
		| name | Soru - MULTIPLE ANSWER By ANIL |
	Given instructor adds multiple answer question with
		| Key          | Value                          |
		| question     | Soru - MULTIPLE ANSWER By ANIL |
		| point        | 10                             |
		| answer1      | Correct Answer 1               |
		| answer2      | Incorrect Answer 2             |
		| answer3      | Correct Answer 3               |
		| TestCategory | DefaultTestCategory1           |
	Then instructor deletes question with
		| Key  | Value                          |
		| name | Soru - MULTIPLE ANSWER By ANIL |

Scenario: 20_instructor_add_test_pool_multiple_choice
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
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
	Given Login as "Instructor"
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
	Given Login as "Instructor"
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
	Given Login as "Instructor"
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
	Given Login as "Instructor"
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
	#Given Login as "Instructor"
	#Given instructor checks Q&A is exist
	Given Open Kurumsal Login Page
	Given Login as "Student"
    Given student adds new Q&A
		| Key        | Value                           |
		| courseName | defaultCourse2 (Anil Senocak)   |
		| subject    | defaultQuestionAndAnswer        |
		| message    | defaultQuestionAndAnswerMessage |
    Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Then  instructor answers the question
	| Key    | Value                    |
	| answer | anil answer the question |
	Then instructor deletes new Q&A

Scenario: 27_instructor_add_new_support
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor adds new support
		| Key          	| Value                 |
		| subject		| anil_vedubox_support	|
		| description	| anil_vedubox_support	|
		| new_course 	| false 				|

Scenario: 28_instructor_add_new_support_is_new_course_demand
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor adds new support
		| Key          	| Value                 |
		| subject		| anil_vedubox_support	|
		| description	| anil_vedubox_support	|
		| new_course 	| true 				|

Scenario: 22_instructor_add_test_poll_open_ended
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
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
	Given Login as "Instructor"
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
	
Scenario: 30_instructor_add_new_picture_image_pool
	Given Open Kurumsal Login Page
	Given Login as "Admin"
	Given instructor checks images category is exist
		| Key  | Value                   |
		| name | instructor anil new images category  |
	Then instructor adds new images category
		| Key  | Value                   |
		| name | instructor anil new images category  |
	Then instructor update images category
		| Key  | Value                   |
		| name | instructor anil new images category  |
	Given instructor deletes added images category
		| Key  | Value                   |
		| name | instructor anil new images category  |
	
	

Scenario: 31_instructor_add_poll_question_multiple
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks poll question is exist
		| Key      | Value                                 |
		| question | Soru - MULTIPLE POLL QUESTION By ANIL |
	Given instructor adds multiple poll question with
		| Key      | Value                                 |
		| question | Soru - MULTIPLE POLL QUESTION By ANIL |
		| answer1  | Answer 1                              |
		| answer2  | Answer 2                              |
		| answer3  | Answer 3                              |
		| answer4  | Answer 4                              |
	Then instructor delete poll question with
		| Key      | Value                                 |
		| question | Soru - MULTIPLE POLL QUESTION By ANIL |
		
Scenario: 32_instructor_add_poll_question_open_ended
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks poll question is exist
		| Key      | Value                                   |
		| question | Soru - OPEN ENDED POLL QUESTION By ANIL |
	Given instructor adds open ended poll question with
		| Key      | Value                                   |
		| question | Soru - OPEN ENDED POLL QUESTION By ANIL |
		| answer1  | Answer 1                                |
		| answer2  | Answer 2                                |
		| answer3  | Answer 3                                |
		| answer4  | Answer 4                                |
	Then instructor delete poll question with
		| Key      | Value                                   |
		| question | Soru - OPEN ENDED POLL QUESTION By ANIL |
		
Scenario: 33_instructor_add_poll_question_true_false
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks poll question is exist
		| Key      | Value                                   |
		| question | Soru - TRUE FALSE POLL QUESTION By ANIL |
	Given instructor adds true false poll question with
		| Key      | Value                                   |
		| question | Soru - TRUE FALSE POLL QUESTION By ANIL |
	Then instructor delete poll question with
		| Key      | Value                                   |
		| question | Soru - TRUE FALSE POLL QUESTION By ANIL |

Scenario: 35_instructor_query_live
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks live is exist
	Given instructor adds new live with
		| Key               | Value                   |
		| course_name       | defaultCourse1          |
		| meetingType       | Pro                     |
		| title             | deneme                  |
		| timezone          | Europe/Istanbul (GMT+3) |
		| duration          | 120                     |
		| registrationLimit | 50                      |
		| description       | Deneme 123              |
    Then instructor query live
	| Key              | Value          |
	| startHourParam   | 00             |
	| startMinuteParam | 00             |
	| endHourParam     | 23             |
	| endMinuteParam   | 55             |
	| courseName       | defaultCourse1 |
	Then instructor deletes live

Scenario: 36_instructor_add_document_in_files
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks course is exist
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |
	Given instructor adds new course with
		| Key      | Value                          |
		| name     | anil_vedubox_course_instructor |
		| category | defaultCategory1               |
    Then instructor add document in files
	    | Key                 | Value                          |
	    | coursename          | anil_vedubox_course_instructor |
	    | categoryName        | anil_category                  |
	    | addedCategoryName   | anil_category                  |
	    | categoryTitle       | anil_title                     |
	    | categoryDescription | anil_description               |
    Then instructor delete course
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |

Scenario: 37_instructor_add_video_in_files
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks course is exist
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |
	Given instructor adds new course with
		| Key      | Value                          |
		| name     | anil_vedubox_course_instructor |
		| category | defaultCategory1               |
    Then instructor add video in files
	    | Key                 | Value                          |
	    | coursename          | anil_vedubox_course_instructor |
	    | categoryName        | anil_category                  |
	    | addedCategoryName   | anil_category                  |
	    | categoryTitle       | anil_title                     |
	    | categoryDescription | anil_description               |
    Then instructor wait
		| Key  | Value                          |
		| time | 10 |
    Then instructor delete course
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |
    
Scenario: 38_instructor_add_link_in_files
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks course is exist
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |
	Given instructor adds new course with
		| Key      | Value                          |
		| name     | anil_vedubox_course_instructor |
		| category | defaultCategory1               |
    Then instructor add link in files
	    | Key                 | Value                          |
	    | coursename          | anil_vedubox_course_instructor |
	    | categoryName        | anil_category                  |
	    | addedCategoryName   | anil_category                  |
	    | categoryTitle       | anil_title                     |
	    | categoryDescription | anil_description               |
	    | link                | https://github.com/senocak     |
	Then instructor delete course
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |	

Scenario: 39_instructor_add_embed_in_files
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks course is exist
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |
	Given instructor adds new course with
		| Key      | Value                          |
		| name     | anil_vedubox_course_instructor |
		| category | defaultCategory1               |
    Then instructor add embed in files
	    | Key                 | Value                                                             |
	    | coursename          | anil_vedubox_course_instructor                                    |
	    | categoryName        | anil_category                                                     |
	    | addedCategoryName   | anil_category                                                     |
	    | categoryTitle       | anil_title                                                        |
	    | categoryDescription | anil_description                                                  |
	    | embed_code          | <iframe src="https://www.youtube.com/embed/ZzBDAtbcFvM"></iframe> |
	Then instructor delete course
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |

Scenario: 40_instructor_add_poll_in_courses
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks course is exist
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |
	Given instructor adds new course with
		| Key      | Value                          |
		| name     | anil_vedubox_course_instructor |
		| category | defaultCategory1               |
    Then instructor add polls in courses
	    | Key                      | Value                          |
	    | coursename               | anil_vedubox_course_instructor |
	    | polls_title              | polls_title                    |
	    | polls_description        | polls_description              |
	    | polls_test_repeat_number | 10                             |
	Then instructor delete course
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |

Scenario: 41_instructor_add_test_content_in_courses
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
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
	Given instructor adds test content in courses
		| Key                | Value                        |
		| course             | anil_vedubox_course          |
		| title              | anil_vedubox_file_to_subject |
		| desc               | desc                         |
		| test_pass_point    | 5                            |
		| test_repeat_number | 10                           |
	Then instructor delete course
		| Key  | Value               |
		| name | anil_vedubox_course |

Scenario: 42_instructor_add_interactive_video_content_in_courses
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks course is exist
		| Key  | Value               |
		| name | anil_vedubox_course_instructor |
	Given instructor adds new course with
		| Key         | Value               |
		| name        | anil_vedubox_course_instructor |
		| tags        | anil,vedubox,course |
		| description | Anil Vedubox Course |
		| category    | defaultCategory1    |
		| teacher     | Anil Senocak        |
		| catalog     | defaultKatalog1     |
	Given instructor adds new resource as interactive video
		| Key                  | Value                                    |
		| name                 | anil_vedubox_course_instructor                      |
		| subject_title        | anil_vedubox_course_instructor_subject              |
		| resource_title       | anil_vedubox_course_instructor_resource_title       |
		| resource_description | anil_vedubox_course_instructor_resource_description |
		| vimeo_id             | 444883013                                |
	Then instructor delete course
		| Key  | Value              |
		| name | anil_vedubox_course_instructor|

Scenario: 43_instructor_add_announcements
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks course is exist
		| Key  | Value               |
		| name | anil_vedubox_course_instructor |
	Given instructor adds new course with
		| Key         | Value               |
		| name        | anil_vedubox_course_instructor |
		| tags        | anil,vedubox,course |
		| description | Anil Vedubox Course |
		| category    | defaultCategory1    |
		| teacher     | Anil Senocak        |
		| catalog     | defaultKatalog1     |
	Given instructor adds new announcements
		| Key                  | Value                                    |
		| name                 | anil_vedubox_course_instructor                      |
		| title        | anil_vedubox_course_instructor_subject              |
		| description | anil_vedubox_course_instructor_resource_description |
	Then instructor delete course
		| Key  | Value              |
		| name | anil_vedubox_course_instructor|

	Scenario: 44_instructor_add_document_in_homeworks
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks course is exist
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |
	Given instructor adds new course with
		| Key      | Value                          |
		| name     | anil_vedubox_course_instructor |
		| category | defaultCategory1               |
    Then instructor add document in homework
	    | Key                      | Value                          |
	    | coursename               | anil_vedubox_course_instructor |
	    | homework_title           | homework_title                 |
	    | homework_description     | homework_desc                  |
	    | pass_point               | 10                             |
	    | weight_percentage        | 50                             |
	    | homework_doc_title       | homework_doc_title             |
	    | homework_doc_description | homework_doc_description       |
    Then instructor delete course
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |

Scenario: 45_instructor_add_video_in_homeworks
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks course is exist
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |
	Given instructor adds new course with
		| Key      | Value                          |
		| name     | anil_vedubox_course_instructor |
		| category | defaultCategory1               |
    Then instructor add video in homework
	    | Key                      | Value                          |
	    | coursename               | anil_vedubox_course_instructor |
	    | homework_title           | homework_title                 |
	    | homework_description     | homework_desc                  |
	    | pass_point               | 25                             |
	    | weight_percentage        | 40                             |
	    | homework_doc_title       | homework_doc_title             |
	    | homework_doc_description | homework_doc_description       |
	Then instructor wait
		| Key  | Value                          |
		| time | 10 |
    Then instructor delete course
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |

Scenario: 46_instructor_add_link_in_homeworks
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks course is exist
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |
	Given instructor adds new course with
		| Key      | Value                          |
		| name     | anil_vedubox_course_instructor |
		| category | defaultCategory1               |
    Then instructor add link in homework
	    | Key                      | Value                          |
	    | coursename               | anil_vedubox_course_instructor |
	    | homework_title           | homework_title                 |
	    | homework_description     | homework_desc                  |
	    | pass_point               | 50                             |
	    | weight_percentage        | 15                             |
	    | homework_doc_title       | homework_doc_title             |
	    | homework_doc_description | homework_doc_description       |
	    | link                     | https://github.com/senocak     |
    Then instructor delete course
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |

Scenario: 47_instructor_add_embed_in_homeworks
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks course is exist
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |
	Given instructor adds new course with
		| Key      | Value                          |
		| name     | anil_vedubox_course_instructor |
		| category | defaultCategory1               |
    Then instructor add embed in homework
	    | Key                      | Value                                                             |
	    | coursename               | anil_vedubox_course_instructor                                    |
	    | homework_title           | homework_title                                                    |
	    | homework_description     | homework_desc                                                     |
	    | pass_point               | 25                                                                |
	    | weight_percentage        | 25                                                                |
	    | homework_doc_title       | homework_doc_title                                                |
	    | homework_doc_description | homework_doc_description                                          |
	    | embed_code               | <iframe src="https://www.youtube.com/embed/ZzBDAtbcFvM"></iframe> |
    Then instructor delete course
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |
 
Scenario: 48_instructor_add_text_in_homeworks
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks course is exist
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |
	Given instructor adds new course with
		| Key      | Value                          |
		| name     | anil_vedubox_course_instructor |
		| category | defaultCategory1               |
    Then instructor add text in homework
	    | Key                      | Value                          |
	    | coursename               | anil_vedubox_course_instructor |
	    | homework_title           | homework_title                 |
	    | homework_description     | homework_desc                  |
	    | pass_point               | 25                             |
	    | weight_percentage        | 10                             |
	    | homework_doc_title       | homework_doc_title             |
	    | homework_doc_description | homework_doc_description       |
    Then instructor delete course
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |

Scenario: 49_instructor_add_test_in_homeworks
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks course is exist
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |
	Given instructor adds new course with
		| Key      | Value                          |
		| name     | anil_vedubox_course_instructor |
		| category | defaultCategory1               |
    Then instructor add test in homework
	    | Key                         | Value                          |
	    | coursename                  | anil_vedubox_course_instructor |
	    | homework_title              | homework_title                 |
	    | homework_description        | homework_desc                  |
	    | pass_point                  | 30                             |
	    | weight_percentage           | 20                             |
	    | homework_test_title         | homework_test_title            |
	    | homework_test_description   | homework_test_description      |
	    | homework_test_pass_point    | 5                              |
	    | homework_test_repeat_number | 10                             |
    Then instructor delete course
		| Key  | Value                          |
		| name | anil_vedubox_course_instructor |