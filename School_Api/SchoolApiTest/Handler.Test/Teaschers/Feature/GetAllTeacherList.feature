Feature: GetAllTeacherList

Unit test to get teachers list
@tag1
Scenario: Return teshers list
	Given Query to get all teachers list
	When Query is handled to get teacher list
	Then Teacher list will be retrive
