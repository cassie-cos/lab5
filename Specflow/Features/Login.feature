Feature: NW
	As NorthWind user
	I want to verify login to the application
	I want to add a new product, test the product and remove it
	I want to logout

Scenario: All Tests

	Given I open "http://localhost:5000" url
	When I login with "user" username and "user" password
	Then Login is successfull
	When I click All Product link
	Then Open the All Product page 
	When I click Create new 
	Then Open Product Editing page 
	And I create New Product
	Then I check if the product exists
	And Delete New Product
	And Logout
	And close browser






