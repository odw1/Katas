MarsRover.Direction = function(name, directionToLeft, directionToRight, movePositionForwards) {
	this.name = name;
	this.directionToLeft = directionToLeft;
	this.directionToRight = directionToRight;
	this.movePositionForwards = movePositionForwards;
};

MarsRover.Direction.prototype.turnLeft = function(position) {
	position.direction = this.directionToLeft();
};

MarsRover.Direction.prototype.turnRight = function(position) {
	position.direction = this.directionToRight();
};

MarsRover.Direction.prototype.moveForwards = function(position) {
	this.movePositionForwards(position);
};

MarsRover.Directions = {
	
	north: function () {
		var north = new MarsRover.Direction('north', MarsRover.Directions.west, MarsRover.Directions.east, function(position) { position.y++; });
		return north
	},
	
	east: function () {
		return new MarsRover.Direction('east', MarsRover.Directions.north, MarsRover.Directions.south, function(position) { position.x++; });
	},
	
	south: function () {
		return new MarsRover.Direction('south', MarsRover.Directions.east, MarsRover.Directions.west, function(position) { position.y--; });
	},
	
	west: function () {
		return new MarsRover.Direction('west', MarsRover.Directions.south, MarsRover.Directions.north, function(position) { position.x--; });
	}
};