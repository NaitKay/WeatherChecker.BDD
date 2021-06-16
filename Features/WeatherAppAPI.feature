Feature: Weather APP API

  Scenario: Call with valid existing postcode
    When Weather App API is called with valid postcode
    Then 200 response returned with Time, Temperature and humidity

  Scenario: Call with valid non-existing postcode
    When Weather App API is called with non-existing valid postcode
    Then address not found error returned

  Scenario: Call with invalid non-existing postcode
    When Weather App API is called with invalid postcode
    Then invalid address error returned

  Scenario Outline: Call with any postcode
    When Weather App API is called with postcode <postcode>
    Then <status> response should returned

    Examples: 
    | postcode | status |
    | W6 0NW   | 200    |
    | B99 9AA  | 435    |
    | EC1A 1BB | 435    |
 

