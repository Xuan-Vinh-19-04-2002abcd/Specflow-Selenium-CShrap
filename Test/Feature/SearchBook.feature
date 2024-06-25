Feature: SearchBook


Scenario: Search Book Successfully With Multiple Result
	Given I navigate to book storage
	When I search book with key "design"
	Then I confirm search multiple book successfully