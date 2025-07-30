@Login

Feature: User Login Functionality

  Background: User is on Home Page
     Given User is on the Pyramidcore Home Page

@Login_Scenario1
  Scenario: User logs in with valid credentials
    When User enters username and password with valid credentials
    Then User click on the Login button
    Then User should navigate to Dashboard
  
  @Login_Scenario2
  Scenario Outline: User logs in with invalid credentials
    When User enters "<Username>", "<Password>" invalid credentials 
    Then User click on the Login button
    Then User should see an error message indicating invalid credentials
    
    Examples:
      | Username              | Password  |
      | 123456789@gmail.com   | 123456    |