describe('Mars Rover Direction', function () {

	var position;
	
	beforeEach(function () {
		position = { direction: '' };
	});
	
	describe('when facing north and turning left', function () {
	
		it('should turn to face west', function () {
			
			var direction = MarsRover.Directions.north();
			direction.turnLeft(position);
			
			expect(position.direction.name).toEqual('west');
		});
		
	});
	
	describe('when facing north and turning right', function () {
	
		it('should turn to face east', function () {
			var direction = MarsRover.Directions.north();
			direction.turnRight(position);
			
			expect(position.direction.name).toEqual('east');
		});
		
	});
	
	describe('when facing east and turning left', function () {
	
		it('should turn to face north', function () {
			var direction = MarsRover.Directions.east();
			direction.turnLeft(position);
			
			expect(position.direction.name).toEqual('north');
		});
		
	});
	
	describe('when facing east and turning right', function () {
	
		it('should turn to face south', function () {
			var direction = MarsRover.Directions.east();
			direction.turnRight(position);
			
			expect(position.direction.name).toEqual('south');
		});
		
	});
	
	describe('when facing south and turning left', function () {
	
		it('should turn to face east', function () {
			var direction = MarsRover.Directions.south();
			direction.turnLeft(position);
			
			expect(position.direction.name).toEqual('east');
		});
		
	});
	
	describe('when facing south and turning right', function () {
	
		it('should turn to face west', function () {
			var direction = MarsRover.Directions.south();
			direction.turnRight(position);
			
			expect(position.direction.name).toEqual('west');
		});
		
	});
	
	describe('when facing west and turning left', function () {
	
		it('should turn to face south', function () {
			var direction = MarsRover.Directions.west();
			direction.turnLeft(position);
			
			expect(position.direction.name).toEqual('south');
		});
		
	});
	
	describe('when facing west and turning right', function () {
	
		it('should turn to face north', function () {
			var direction = MarsRover.Directions.west();
			direction.turnRight(position);
			
			expect(position.direction.name).toEqual('north');
		});
		
	});
	
	describe('when moving forwards when facing north', function () {
	
		it('should increment the y coordinate', function () {
			var position = { x: 1, y: 2 };
			var direction = MarsRover.Directions.north()
			direction.moveForwards(position);
			
			expect(position.x).toEqual(1);
			expect(position.y).toEqual(3);
		});
	});
	
	describe('when moving forwards when facing east', function () {
	
		it('should increment the x coordinate', function () {
			var position = { x: 1, y: 2 };
			var direction = MarsRover.Directions.east()
			direction.moveForwards(position);
			
			expect(position.x).toEqual(2);
			expect(position.y).toEqual(2);
		});
	});
	
	describe('when moving forwards when facing south', function () {
	
		it('should decrement the y coordinate', function () {
			var position = { x: 1, y: 2 };
			var direction = MarsRover.Directions.south()
			direction.moveForwards(position);
			
			expect(position.x).toEqual(1);
			expect(position.y).toEqual(1);
		});
	});
	
	describe('when moving forwards when facing west', function () {
	
		it('should decrement the x coordinate', function () {
			var position = { x: 1, y: 2 };
			var direction = MarsRover.Directions.west()
			direction.moveForwards(position);
			
			expect(position.x).toEqual(0);
			expect(position.y).toEqual(2);
		});
	});
});