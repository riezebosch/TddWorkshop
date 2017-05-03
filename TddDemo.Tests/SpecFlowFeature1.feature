Feature: IBAN Validation
	In order to avoid silly mistakes
	As a math idiot
	I want to be told if my IBAN is valid

@mytag
Scenario Outline: Validate IBAN
	Given I have entered "<iban>" into the validator
	When I execute Validate
	Then the result should be <expected>

Examples:
	| type       | iban                   | expected |
	| valid      | NL74 INGB 0671 5336 65 | true     |
	| whitespace | NL74INGB0671533665     | true     |
	| short      | NL74INGB067153366      | false    |
	| bankcode   | NL74ZZZZ0671533665     | false    |
