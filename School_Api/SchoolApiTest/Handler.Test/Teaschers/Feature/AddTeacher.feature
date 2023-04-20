Feature: AddTeacher

Unit test to add teacher data

@tag1
Scenario: When teacher id is not null then add the teacher
	Given HAndel Teachercommand request
	When Teachercommand is handled to add teacher data
	Then Teacher data added successfully
