# Andrew MacLeod Business Rules Engine

## Introduction

Initial plan is as follows:

1. Create a console app to emulate a UI or API to allow user input of orders. I probably won't test drive this as it only exists for the purposes of the test - to allow us to get orders into the engine. 
2. Create an acceptance test project and write some scenarios.
3. Create a Domain (& associated unit tests) project to hold business models and interfaces.
4. Create a Service (& associated unit tests) project to hold an order processor and rules engine.
5. Create an infrastructure project to emulate a message system where events can be raised and exposed to acceptance tests. I probably won't test-drive this as it only exists to support the acceptance tests.

## Assumptions

TODO

## Notes

Commits up to commit 6 are mainly setting up the projects and installing  NuGet packages. 

Commits 7 & 8 show the first unit test and implementation of code to make it pass. 