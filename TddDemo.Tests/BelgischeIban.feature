Feature: BelgischeIban
	In order to not mistakenly enter a wrong account number
	As a citizen with a Belgian bank account
	I want to have good feedback if the bank account I entered is correct.

@mytag
Scenario: Valid Belgian Iban
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
