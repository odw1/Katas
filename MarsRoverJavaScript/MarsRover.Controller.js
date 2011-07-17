MarsRover.Controller = {
	
	getPlateau: function(topX, topY) {
		var plateau = { 
				bottomX: 0,
				bottomY: 0,
				topX: topX,
				topY: topY
		};
		
		return plateau;
	},
	
	getRover: function(x, y, direction) {
		var rover = new MarsRover.Rover(x, y, direction);
		return rover;
	}

};