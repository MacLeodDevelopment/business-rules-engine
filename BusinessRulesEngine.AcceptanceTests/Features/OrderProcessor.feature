Feature: Order Processor
	Order processor for applying business rules to orders

@Scenario1
Scenario: A shipping packing slip is generated for orders containing a physical product
	Given an order containing a physical product
	When the order is processed
	Then a packing slip is generated for shipping the order

@Scenario2
Scenario: A duplicate packing slip for the royalty department is generated for orders containing a book
	Given an order containing a book
	When the order is processed
	Then a duplicate packing slip is generated for the royalty department

@Scenario3
Scenario: A membership order activates the membership
Given an order containing a membership
When the order is processed
Then the membership is activated

@Scenario4
Scenario: A membership upgrade order upgrades the membership
Given an order containing a membership upgrade
When the order is processed
Then the membership is upgraded

@Scenario5
Scenario: A membership order emails the membership owner
Given an order containing a membership
When the order is processed
Then the owner is emailed and informed of the activation

@Scenario6
Scenario: A membership upgrade order emails the membership owner
Given an order containing a membership upgrade
When the order is processed
Then the owner is emailed and informed of the upgrade

@Scenario7
Scenario: An order for the video Learning to Ski adds a free First Aid video to the packing slip
Given an order containing a video
And  the title of the video is Learning to Ski
And  and the order was placed after 1997
When the order is processed
Then a free First Aid video is added to the packing slip

@Scenario8
Scenario: A commission payment is generated for the agent when an order contains a physical product
Given an order containing a physical product
When the order is processed
Then a commission payment is generated for the physical product agent

@Scenario9
Scenario: A commission payment is generated for the agent when an order contains a book
Given an order containing a book
When the order is processed
Then a commission payment is generated for the book agent

#Scenarios
#
# Physical product, generate a packing slip for shipping
# Book (is physical) should create a duplicate packing slip for royalty department
# Video (Learning to Ski) add a free first aid video to the PACKING SLIP (Take into account year after 1997?)
# 
# If for physical product or book, generate commission payment to the agent 
# 
# Membership (non-physical) activate the membership 
# Upgrade to a membership, apply the upgrade. Remember to do a get and update the existing membership if it exists?
# Membership OR Upgrade (2 test scenarios needed) email the owner and inform them of the activation/upgrade
#
# TODO AMACLEOD Any more?
#