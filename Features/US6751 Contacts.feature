Feature: Sprint 8_US6751-Contacts API
	6751 - Validate the Contacts APi works as expected

		@6751 @Sprint8 @Contacts @API
Scenario Outline: Test 1 Contacts API-Addition of new contact
	Given the 'Contact' api endpoint
	When I add a new Contact with details  '<Fname>', '<Lname>' and '<EmailId>'
	Then status code of response should be 'Accepted'
	And the data entered in the application for Contacts should be correct

	Examples: 
	| Fname   | Lname   | EmailId |
	| AutoGen | AutoGen | AutoGen |
#	| Test1			| Numbers	| test1.numbers@testing.co.uk		|


			@6751 @Sprint8 @Contacts @API
Scenario Outline: Test 2 Contacts API-Updation of existing contact
	Given the 'Contact' api endpoint
	When I update an existing Contact with details  '<Fname>', '<Lname>' and '<EmailId>'
	Then status code of response should be 'Accepted'
	And the data entered in the application for Contacts should be correct

	Examples: 
	| Fname			| Lname		| EmailId							|
	| AutoGen		| AutoGen	| Email20060521@automation.co.uk	|
#	| Test1			| Numbers	| test1.numbers@testing.co.uk		|



		@6751 @Sprint8 @Contacts @API
Scenario: Test 3 Contacts API-Unauthorised request validation
	Given the 'Contact' api endpoint
	When I add a new Contact with invalid token with details '<Fname>', '<Lname>' and '<EmailId>'
	Then status code of response should be 'Unauthorised'

	

		@6751 @Sprint8 @Contacts @API
Scenario: Test 4 Contacts API-Bad request validation
	Given the 'Contact' api endpoint
	When I create a bad request for Contact with details '<Fname>', '<Lname>' and '<EmailId>'
	Then status code of response should be 'Bad Request'
