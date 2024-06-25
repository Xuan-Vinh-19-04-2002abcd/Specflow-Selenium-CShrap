Feature: DeleteBook
	Simple calculator for adding two numbers

Scenario: Delete book successfully
	Given  I add book have account key "account_valid"
	And I navigate to login page
	And I have valid account with key "account_valid"
	And  I login with this account
	When I search title for the book previously added
	And  I delete this book with this title
	Then I confirm delete successfully