Feature: Magento_Register

Background: User navigates to homepage
	Given that user is on the homage

Scenario: User is able to register a new account
	When the user registers a new account
	Then user must be successfully logged into their account

Scenario: User is able to place an order
	When the user completes purchase of a random item
	Then the user should get order complete messages

#Scenario: User is able place an order via the nav bar
#	When the user navigates to 'Men' 'Tops' page
#	And complete purchase of 3 items
#	Then the user should get order complete messages
