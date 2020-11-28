Feature: Sprint 8_US6751-Sites API
	6751 - Validate the Sites APi works as expected

		@6751 @Sprint8 @Sites @API
Scenario Outline: Test 1 Sites API-Addition of new Site
	Given the 'Sites' api endpoint
	When I add a new Site with details '<SiteArea>', '<Name>' and '<OppId>'
	Then status code of response should be 'Accepted'
	And the data entered in the application for Site should be correct

	Examples: 
	| SiteArea			| Name			| OppId	|
	| 500.591			| AutoGen		| 1700	|
#	| 200.592			| Automation	| 1900	|


			@6751 @Sprint8 @Sites @API
Scenario: Test 2 Sites API-Updation of existing Site
	Given the 'Sites' api endpoint
	When I update an existing Site with details '<SiteArea>', '<Name>' and '<OppId>'
	Then status code of response should be 'Accepted'
	And the data entered in the application for Site should be correct

	Examples: 
	| SiteArea	| Name					| OppId		|
	| 222.999	| Automation06030124	| 1900		|
#	| Test1		| Numbers				|			|


			@6751 @Sprint8 @Sites @API
Scenario: Test 3 Sites API-Unauthorised request validation
	Given the 'Sites' api endpoint
	When I add a new Site with invalid token with details '222.999', 'Automation06030124' and '1900'
	Then status code of response should be 'Unauthorised'

	
			@6751 @Sprint8 @Sites @API
Scenario: Test 4 Sites API-Bad Request validation
	Given the 'Sites' api endpoint
	When I create a bad request for Site with details '222.999', 'Automation06030124' and '1900'
	Then status code of response should be 'Bad Request'