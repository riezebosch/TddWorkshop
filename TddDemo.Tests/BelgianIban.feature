Feature: BelgianIban
	In order to enter iban from my country
	As a Belgian customer
	I want to be able to validate against our IBAN rules

@mytag
Scenario: Valid Belgian Iban
	Given I have entered "BE11000123456789"
	When I validate
	Then the result should be 'True'
