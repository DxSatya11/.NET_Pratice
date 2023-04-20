Feature: GetDepartmentById

A short summary of the feature

@tag1
Scenario: Return Department By Id
	Given GetDepartmentByIdQuery to get Department By Id
	When GetDepartmentByIdQuery is handled to get Department
	Then Department data is retrive using it's Id
