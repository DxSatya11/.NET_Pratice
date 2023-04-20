Feature: GetAllSchoolList

Unit test fro retrive schoollist

@tag1
Scenario: Return School List
	Given Query to get all School list
	When Query is handled to get all school list
	Then School list will be retrive successfully
