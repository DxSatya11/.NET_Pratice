Feature: AddSchool

Unit test for add School

@tag1
Scenario: When School Id is not null 
	Given SchoolCommand request
	When SchoolCommand is handled to add
	Then School is added successfully
