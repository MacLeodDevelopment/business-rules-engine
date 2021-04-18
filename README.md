# Andrew MacLeod Business Rules Engine

## Introduction

For this test I have chosen Problem 2: Business Rules Engine.

Please take into account the notes and assumptions below when reviewing the code.

To run the project, simply check out the code from GitHub and open in Visual Studio. 

You can then hit F5 to run the project.

## Notes

* I have approached this problem as I would if I were writing a system for a large company which has a distributed architecture. 
  * I have focussed on the implementation of the rules engine which can raise events when certain conditions are met. 
  * As such, the implementation of the order processing application does **not** execute operations such as sending emails or updating membership records. The application raises business events to a dummy service bus, which subscribing systems could react to. For example when an email member event is raised, an email system might send an email. To illustrate this I have implemented a mock service bus which events can be raised to. This in turn logs the events to the console for the user to see. 
  * Please do not treat the code in the Infrastructure layer or the UI layer as "real" code. It exists either for demonstration purposes or to allow the application to be acceptance tested in a realistic way. 
* I have spent longer than 2 hours on this, but I wanted to demonstrate the approach I take to code in a professional environment.
* I have used an Onion architecture approach, where Domain forms the centre of the onion, and Services, Infrastructure etc. form the outer layers. See the project dependencies in the Solution for details.  
* Cyclomatic complexity is generally low - only one object is over 10 (`Order`, which is 11).
* The application has been test driven. 
  * Please review the commit log to see the approach taken. Commits up to commit 6 are mainly setting up the projects and installing  NuGet packages. Commits 7 & 8 show the first unit test and implementation of code to make it pass. 
* The code is covered by both BDD Acceptance Tests and TDD Unit Tests. 
* Adding new rules to the application is a relatively small task, simply add an implementation of `IRule` and any `IBusinessEvents` you want to raise. Then register the rule in the `RuleRepositoryEmulator`. 
* I have tried to anticipate any questions in the code by using `<remarks / >`  tags on any methods which I felt needed some explanation.  
* I have tried to steer clear of anaemic domain models, though in some cases these were appropriate. 
  * The rules and events in a real application would likely have business logic in them. 
* Limited validation has been created for this test due to time constraints. In a real world app I would implement more try/catch behaviour and exception handling. 
* Please see the [Code Coverage Report](https://github.com/MacLeodDevelopment/business-rules-engine/blob/master/TestCoverageReport.html).

## Assumptions

* The application is for a large organisation, so other systems will subscribe to events and carry out the operations to fulfil orders, send emails etc.
* Implementation of actual code to send emails or react to creation of packing slips etc. is not important for the purposes of this test.
* Orders contain single rows to keep things simpler for the purposes of this test.
* No product prices, quantities etc. have been included for the purposes of this test.
* Books and videos are assumed to be physical products.
* Memberships and membership upgrades are assumed to be non-physical products.
* Input of orders in a real application would be via an API or another system. For this test I have used JSON files which are read into memory via a RESX resource file. 
* No persistence mechanism is required for the purposes of the test. Processing of orders is stateless.
* For simplicity I've used strings for all of the properties in the orders and products. This means that some "magic" strings are used. In a real-world application I would not do this. 
* I have built limited error-handling in to the app. Normally all public methods would have their arguments validated and calls to other objects be wrapped in try/catch to allow for exception handling or logging. 

