Feature: Student

Scenario: 1_student_live_register
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor checks live is exist
	Given instructor adds new live with
		| Key               | Value                  |
		| course_name       | defaultCourse1         |
		| meetingType       | basic                  |
		| title             | deneme                 |
		| hour              | 18                     |
		| min               | 00                     |
		| timezone          | Turkey Time (GMT+3:00) |
		| duration          | 120                    |
		| registrationLimit | 50                     |
		| description       | Deneme 123             |
	Given Open Kurumsal Login Page
	Given Login as "student"
	Then student registers live
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Then instructor deletes live
	 
Scenario: 3_student_portal_single_course_purchase_and_reflection
	Given Open Kurumsal Login Page
	Given Login as "student"
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

Scenario: 4_student_course_package_purchase_and_reflection
	Given Open Kurumsal Login Page
	Given Login as "student"
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

Scenario: 5_student_portal_Shopping_Cart_Shopping
	Given Open Kurumsal Login Page
	Given Login as "student"
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

Scenario: 6_student_exam_start_finish_multiple_choice
	Given Open Kurumsal Login Page
	Given Login as "instructor"
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
	Given Login as "student"
	Then student takes exam
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor delete exam with
		| Key  | Value                |
		| name | anil_instructor_exam |

Scenario: 7_student_exam_start_finish_mixed
	Given Open Kurumsal Login Page
	Given Login as "instructor"
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
	Given Login as "student"
	Then student takes exam
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor delete exam with
		| Key  | Value                |
		| name | anil_instructor_exam |

Scenario: 8_student_exam_start_finish_open_ended
	Given Open Kurumsal Login Page
	Given Login as "instructor"
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
	Given Login as "student"
	Then student takes exam
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Given instructor delete exam with
		| Key  | Value                |
		| name | anil_instructor_exam |

Scenario: 9_student_live_start
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
    Given Open Kurumsal Login Page
	Given Login as "student"
    Then  student verify start live
	Given Open Kurumsal Login Page
	Given Login as "instructor"
	Then instructor deletes live

Scenario: 11_student_add_Question_And_Answer
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
	Then instructor deletes new Q&A
   

