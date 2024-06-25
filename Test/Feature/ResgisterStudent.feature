Feature: ResgisterStudent
	

Scenario: Register student successfully with all field
	Given I navigate to form register
	When I have an Student Data with key "StudentWithAllFields"
	And  I fill in all field student
	Then I confirm that register student all field successfully