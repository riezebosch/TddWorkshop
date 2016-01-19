Feature: BelgianIban
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Valid Belgian Iban
	Given I have entered BE61310126985517 into the calculator
	When I press add
	Then the result should be true on the screen
