Feature: GetAllStudentList

Unit test to get all student list

@tag1
Scenario: Return Students list
	Given StudentQuery to get all students list
	When StudentQuery is handled to get Student list
	Then Student list is retrived
