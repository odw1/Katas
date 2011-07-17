MarsRover.Rover = function (x, y, direction, plateau) {
	this.position = { 
		x: x, 
		y: y, 
		direction: direction
	};
	this.plateau = plateau;
};

MarsRover.Rover.prototype.processInstructions = function (instructions) {
	var individualInstructions = instructions.split('')
	
	for (var i = 0; i < individualInstructions.length; i++) {
		this.executeInstruction(individualInstructions[i]);
	}
};

MarsRover.Rover.prototype.executeInstruction = function (instruction) {
	if (instruction !== 'L' && instruction !== 'M' && instruction != 'R') {
		throw {
			name: 'ArgumentError',
			message: 'Invalid instruction specified'
		};
	}
	
	if (instruction === 'L') {
		this.position.direction.turnLeft(this.position);
	}
	else if (instruction === 'R') {
		this.position.direction.turnRight(this.position);
	}
	else if (instruction === 'M') {
		this.position.direction.moveForwards(this.position);
	}
};