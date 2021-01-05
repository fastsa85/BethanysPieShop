Feature: UserManagement

Scenario: Register new user
	When User clicks Register link on the Navigation Bar
	And User enters "JohnDoe" into User Name input on the Register New User page
	And User enters "QWEasd123!" into Password input on the Register New User page
	And User clicks Register button on the Register New User page
	Then User is redirected to the Home page