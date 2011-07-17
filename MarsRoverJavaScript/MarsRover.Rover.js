MarsRover.Rover = function (x, y, direction) {
	this.position = { 
		x: x, 
		y: y, 
		direction: direction 
	};
};

MarsRover.Rover.prototype.processInstructions = function (instructions) {
	var individualInstructions = instructions.split('')
	
	for (var i = 0; i < individualInstructions.length; i++) {
		this.executeInstruction(individualInstructions[i]);
	}
};

MarsRover.Rover.prototype.executeInstruction = function (instruction) {
	if (instruction !== 'L' || instruction !== 'M' || instruction != 'R') {
		throw {
			name: 'ArgumentError',
			message: 'Invalid instruction specified'
		};
	}
};