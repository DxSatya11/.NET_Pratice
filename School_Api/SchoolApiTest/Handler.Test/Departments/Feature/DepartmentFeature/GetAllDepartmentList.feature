Feature: GetAllDepartmentList

Unit test to get all Department list
@tag1
Scenario: Return Department list
	Given Query to get all Departmrnt list
	When  Query is handled to get all Department
	Then Department list will retrive
