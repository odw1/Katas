MarsRover.Direction = function(name, directionToLeft, directionToRight) {
	this.name = name;
	this.directionToLeft = directionToLeft;
	this.directionToRight = directionToRight;
};

MarsRover.Direction.prototype.turnLeft = function() {
	return this.directionToLeft();
};

MarsRover.Direction.prototype.turnRight = function() {
	return this.directionToRight();
};

MarsRover.Directions = {
	
	north: function () {
		return new MarsRover.Direction('north', MarsRover.Directions.west, MarsRover.Directions.east);
	},
	
	east: function () {
		return new MarsRover.Direction('east', MarsRover.Directions.north, MarsRover.Directions.south);
	},
	
	south: function () {
		return new MarsRover.Direction('south', MarsRover.Directions.east, MarsRover.Directions.west);
	},
	
	west: function () {
		return new MarsRover.Direction('west', MarsRover.Directions.south, MarsRover.Directions.north);
	}
};