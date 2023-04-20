Feature: AddStudent

A short summary of the feature

@tag1
Scenario:When Student Id is not null Add it
	Given Handel StudentCommand request
	When StudentCommand is handled to add
	Then Student added successfully
