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