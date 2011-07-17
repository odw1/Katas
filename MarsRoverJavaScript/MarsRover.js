MarsRover = {
	
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
		var rover = {
			position: { 
				x: x,
				y: y,
				direction: direction
			}
		};
		
		return rover;
	}

};