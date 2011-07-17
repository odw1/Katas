describe('Mars Rover Direction', function () {
	
	describe('when facing north and turning left', function () {
	
		it('should turn to face west', function () {
			var direction = MarsRover.Directions.north();
			var newDirection = direction.turnLeft();
			
			expect(newDirection.name).toEqual('west');
		});
		
	});
	
	describe('when facing north and turning right', function () {
	
		it('should turn to face east', function () {
			var direction = MarsRover.Directions.north();
			var newDirection = direction.turnRight();
			
			expect(newDirection.name).toEqual('east');
		});
		
	});
	
	describe('when facing east and turning left', function () {
	
		it('should turn to face north', function () {
			var direction = MarsRover.Directions.east();
			var newDirection = direction.turnLeft();
			
			expect(newDirection.name).toEqual('north');
		});
		
	});
	
	describe('when facing east and turning right', function () {
	
		it('should turn to face south', function () {
			var direction = MarsRover.Directions.east();
			var newDirection = direction.turnRight();
			
			expect(newDirection.name).toEqual('south');
		});
		
	});
	
	describe('when facing south and turning left', function () {
	
		it('should turn to face east', function () {
			var direction = MarsRover.Directions.south();
			var newDirection = direction.turnLeft();
			
			expect(newDirection.name).toEqual('east');
		});
		
	});
	
	describe('when facing south and turning right', function () {
	
		it('should turn to face west', function () {
			var direction = MarsRover.Directions.south();
			var newDirection = direction.turnRight();
			
			expect(newDirection.name).toEqual('west');
		});
		
	});
	
	describe('when facing west and turning left', function () {
	
		it('should turn to face south', function () {
			var direction = MarsRover.Directions.west();
			var newDirection = direction.turnLeft();
			
			expect(newDirection.name).toEqual('south');
		});
		
	});
	
	describe('when facing west and turning right', function () {
	
		it('should turn to face north', function () {
			var direction = MarsRover.Directions.west();
			var newDirection = direction.turnRight();
			
			expect(newDirection.name).toEqual('north');
		});
		
	});
	
});