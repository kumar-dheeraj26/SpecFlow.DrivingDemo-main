Feature: DrivingRegulations

Check if a person is allowed to drive a car in particular country

@tag1
Scenario: Permitted driving in Switerzland
	Given The driver is 21 years old
	When they live in Switzerland
	Then They are permitted to drive

Scenario: Permitted driving in UnitedStates
	Given The driver is 16 years old
	When they live in UnitedStates
	Then They are permitted to drive

Scenario: Permitted driving in Germany
	Given The driver is 16 years old
	When they live in Germany
	Then They are not permitted to drive
