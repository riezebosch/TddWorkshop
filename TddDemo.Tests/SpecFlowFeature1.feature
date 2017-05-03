Feature: IBAN Validation
	In order to avoid silly mistakes
	As a math idiot
	I want to be told if my IBAN is valid

@mytag
Scenario: Valid IBAN
	Given I have entered "NL74 INGB 0671 5336 65" into the validator
	When I execute Validate
	Then the result should be true
