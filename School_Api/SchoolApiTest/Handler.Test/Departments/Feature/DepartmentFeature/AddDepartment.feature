Feature: AddDepartment

A short summary of the feature

@tag1
Scenario: When Dep Id is Not Nullvalue
	Given Command Request
	When Command is handled to Add
	Then Department is added Successfully
