Feature: Processing Instructions
	In order to move the Rover on the plateau
	As a controlling program
	I want to be told the Rovers new position

Scenario: Turning Left
	Given The Rover is on coordinates 1,2 facing north
	When I send the Rover a turn left instruction
	Then The Rover should be facing west

Scenario: Turning Right
	Given The Rover is on coordinates 1,2 facing north
	When I send the Rover a turn right instruction
	Then The Rover should be facing east

Scenario: Processing a set of instructions
	Given The Rover is on coordinates 1,2 facing north
	When I send the Rover a series of instructions LMLMLMLMM
	Then The Rover should be at x coordinate 1, y coordinate 3 and facing north

Scenario: Processing a different set of instructions
	Given The Rover is on coordinates 3,3 facing east
	When I send the Rover a series of instructions MMRMMRMRRM
	Then The Rover should be at x coordinate 5, y coordinate 1 and facing east