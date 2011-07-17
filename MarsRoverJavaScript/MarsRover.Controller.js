MarsRover.Controller = {
	
	topXCoordinate: 0,
	topYCoordinate: 0,
	
	getPlateau: function(topX, topY) {
		var plateau = { 
				bottomX: 0,
				bottomY: 0,
				topX: MarsRover.Controller.topXCoordinate,
				topY: MarsRover.Controller.topYCoordinate,
				isPositionOnPlateau: function (position) {
					if (position.x > this.topX || position.x < this.bottomX || position.y > this.topY || position.y < this.bottomY) {
						throw {
							name: 'InvalidOperationError',
							message: 'Position is not on the plateau'
						};
					}
				}
		};
		
		return plateau;
	},
	
	getRover: function(x, y, direction) {
		var rover = new MarsRover.Rover(x, y, direction, MarsRover.Controller.getPlateau());
		return rover;
	}

};