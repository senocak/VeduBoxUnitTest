﻿Feature: Student

Scenario: 01_student_live_register
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks live is exist
	Given instructor adds new live with
		| Key               | Value                   |
		| course_name       | defaultCourse1          |
		| meetingType       | Basic                   |
		| title             | deneme                  |
		| hour              | 18                      |
		| min               | 00                      |
		| timezone          | Europe/Istanbul (GMT+3) |
		| duration          | 120                     |
		| registrationLimit | 50                      |
		| description       | Deneme 123              |
	Given Open Kurumsal Login Page
	Given Login as "Student"
	Then student registers live
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Then instructor deletes live
	 
Scenario: 03_student_portal_single_course_purchase_and_reflection
	Given Open Kurumsal Login Page
	Given Login as "Student"
	Then student purchase course
		| Key        | Value                         |
		| entry      | Default Course1               |
		| name       | Ahmet                         |
		| surname    | Can                           |
		| city       | Adana                         |
		| district   | Merkez                        |
		| phone      | 5246123811                    |
		| address    | Süleyman Şah camii yanı. No71 |
		| cardName   | sapdf sdff                    |
		| cardNumber | 5528790000000008              |
		| cardDate   | 11/22                         |
		| cardCVC    | 123                           |

Scenario: 04_student_course_package_purchase_and_reflection
	Given Open Kurumsal Login Page
	Given Login as "Student"
	Then  Student add course package purchase and reflection
		| Key        | Value                           |
		| entry      | Default Course Package1         |
		| name       | Ahmetss                         |
		| surname    | Canss                           |
		| city       | Adanass                         |
		| country    | Merkezss                        |
		| phone      | 5246123856                      |
		| address    | Süleymanss Şah camii yanı. No71 |
		| cardName   | sapdf sdff                      |
		| cardNumber | 5528790000000008                |
		| cardDate   | 11/22                           |
		| cardCVC    | 123                             |

Scenario: 05_student_portal_Shopping_Cart_Shopping
	Given Open Kurumsal Login Page
	Given Login as "Student"
	Then  Student make portal shopping both course and course package
		| Key           | Value                           |
		| course        | Default Course1                 |
		| coursePackage | Default Course Package1         |
		| name          | Ahmetgg                         |
		| surname       | Cangg                           |
		| city          | Adanagg                         |
		| country       | Merkezgg                        |
		| phone         | 5246123843                      |
		| address       | Süleymangg Şah camii yanı. No71 |
		| cardName      | sapdf sdff                      |
		| cardNumber    | 5528790000000008                |
		| cardDate      | 11/22                           |
		| cardCVC       | 123                             |

Scenario: 06_student_exam_start_finish_multiple_choice
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks exam is exist
		| Key  | Value                |
		| name | anil_instructor_exam |
	Then instructor adds exam with document
		| Key         | Value                            |
		| name        | anil_instructor_exam_name        |
		| description | anil_instructor_exam_description |
		| catalogs    | defaultKatalog1,defaultKatalog2  |
		| tests       | Default Multiple Choice Test1    |
	Given Open Kurumsal Login Page
	Given Login as "Student"
	Then student takes exam
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor delete exam with
		| Key  | Value                |
		| name | anil_instructor_exam |

Scenario: 07_student_exam_start_finish_mixed
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks exam is exist
		| Key  | Value                |
		| name | anil_instructor_exam |
	Then instructor adds exam with document
		| Key         | Value                            |
		| name        | anil_instructor_exam_name        |
		| description | anil_instructor_exam_description |
		| catalogs    | defaultKatalog1,defaultKatalog2  |
		| tests       | Default Multiple Choice Test1    |
	Given Open Kurumsal Login Page
	Given Login as "Student"
	Then student takes exam
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor delete exam with
		| Key  | Value                |
		| name | anil_instructor_exam |

Scenario: 08_student_exam_start_finish_open_ended
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks exam is exist
		| Key  | Value                |
		| name | anil_instructor_exam |
	Then instructor adds exam with document
		| Key         | Value                            |
		| name        | anil_instructor_exam_name        |
		| description | anil_instructor_exam_description |
		| catalogs    | defaultKatalog1,defaultKatalog2  |
		| tests       | Default Open Ended Test1         |
	Given Open Kurumsal Login Page
	Given Login as "Student"
	Then student takes exam
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor delete exam with
		| Key  | Value                |
		| name | anil_instructor_exam |

Scenario: 09_student_live_start
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
    Given Open Kurumsal Login Page
	Given Login as "Student"
    Then  student verify start live
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Then instructor deletes live

Scenario: 11_student_add_Question_And_Answer
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
	Then instructor deletes new Q&A


Scenario: 13_student_query_live
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Given instructor checks live is exist
	Given instructor adds new live with
		| Key               | Value                   |
		| course_name       | defaultCourse1          |
		| meetingType       | Basic                   |
		| title             | deneme                  |
		| hour              | 18                      |
		| min               | 00                      |
		| timezone          | Europe/Istanbul (GMT+3) |
		| duration          | 120                     |
		| registrationLimit | 50                      |
		| description       | Deneme 123              |
	Given Open Kurumsal Login Page
	Given Login as "Student"
	 Then instructor query live
	| Key              | Value          |
	| startHourParam   | 00             |
	| startMinuteParam | 00             |
	| endHourParam     | 23             |
	| endMinuteParam   | 55             |
	| courseName       | defaultCourse1 |
	Given Open Kurumsal Login Page
	Given Login as "Instructor"
	Then instructor deletes live
   

