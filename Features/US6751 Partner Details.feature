Feature: Sprint 8_US6751-Partner Details API
	6751 - Validate the Partner Details APi works as expected

		@6751 @Sprint8 @PartnerDetails @API
Scenario Outline: Test 1 Partner Details API-Addition of new Partner Details
	Given the 'PartnerDetails' api endpoint
	When I add new Partner Details with details '<Partner_Name>', '<Account_Type>', '<Account_No>' and '<Org_Name>'
	Then status code of response should be 'Accepted'
	And the data entered in the application for Partner Details should be correct

	Examples: 
	| Partner_Name | Account_Type	| Account_No	| Org_Name  |
	| Automation   | Developer		| AutoGen		| TestAuto  |



			@6751 @Sprint8 @PartnerDetails @API
Scenario Outline: Test 2 Partner Details API-Updation of existing Partner Details
	Given the 'PartnerDetails' api endpoint
	When I update existing Partner Details with details '<Partner_Name>', '<Account_Type>', '<Account_No>' and '<Org_Name>'
	Then status code of response should be 'Accepted'
	And the data entered in the application for Partner Details should be correct

	Examples: 
	| Partner_Name | Account_Type	| Account_No	| Org_Name  |
	| AutoGen	   | SME			| 20060228		| TestAuto  |


			@6751 @Sprint8 @PartnerDetails @API
Scenario: Test 3 Partner Details API-Unauthorised request validation
	Given the 'PartnerDetails' api endpoint
	When I add new Partner Details with invalid token with details 'Automation', 'Developer', 'AutoGen' and 'TestAuto'
	Then status code of response should be 'Unauthorised'

	
			@6751 @Sprint8 @PartnerDetails @API
Scenario: Test 4 Partner Details API-Bad request validation
	Given the 'PartnerDetails' api endpoint
	When I create a bad request for Partner Details with details 'Automation', 'Developer', 'AutoGen' and 'TestAuto'
	Then status code of response should be 'Bad Request'