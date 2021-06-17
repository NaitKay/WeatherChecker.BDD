Feature: Weather app integration
    
  Scenario: Match weather details against weather app api response
    When Weather App API is called with valid postcode
    And User open Weather Checker application
    When User search valid existing postcode
    Then Weather details should be presented to the user
    And Weather details should match with the Weather App API response
  
