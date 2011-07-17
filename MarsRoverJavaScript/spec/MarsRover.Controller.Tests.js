describe('Mars Rover Controller', function () {
	
	describe('when getting the plateau', function () {
		var plateau;
		
		beforeEach(function () {
			MarsRover.Controller.topXCoordinate = 5;
			MarsRover.Controller.topYCoordinate = 10;
			plateau = MarsRover.Controller.getPlateau();
		});
	
		it('should return a plateau with the correct top x coordinate', function (){
			expect(plateau.topX).toEqual(5);
		});
		
		it('should return a plateau with the correct bottom x coordinate', function (){
			expect(plateau.bottomX).toEqual(0);
		});
		
		it('should return a plateau with the correct top y coordinate', function (){
			expect(plateau.topY).toEqual(10);
		});
		
		it('should return a plateau with the correct bottom y coordinate', function (){
			expect(plateau.bottomY).toEqual(0);
		});
	});
	
	describe('when validating if a position is on the plateau', function () {
		it('should validate the position', function () {
			MarsRover.Controller.topXCoordinate = 5;
			MarsRover.Controller.topYCoordinate = 10;
			plateau = MarsRover.Controller.getPlateau();
			
			plateau.isPositionOnPlateau({ x: 4, y : 8});
		});
	});
	
	describe('when validating if a position is on the plateau and the X coordinate is to high', function () {
		it('should validate the position', function () {
			MarsRover.Controller.topXCoordinate = 5;
			MarsRover.Controller.topYCoordinate = 10;
			plateau = MarsRover.Controller.getPlateau();
			
			var f = function () { plateau.isPositionOnPlateau({ x: 7, y : 8}) };
			
			expect(f).toThrow('Position is not on the plateau');
		});
	});
	
	describe('when validating if a position is on the plateau and the X coordinate is to low', function () {
		it('should validate the position', function () {
			MarsRover.Controller.topXCoordinate = 5;
			MarsRover.Controller.topYCoordinate = 10;
			plateau = MarsRover.Controller.getPlateau();
			
			var f = function () { plateau.isPositionOnPlateau({ x: -7, y : 8}) };
			
			expect(f).toThrow('Position is not on the plateau');
		});
	});
	
	describe('when validating if a position is on the plateau and the Y coordinate is to high', function () {
		it('should validate the position', function () {
			MarsRover.Controller.topXCoordinate = 5;
			MarsRover.Controller.topYCoordinate = 10;
			plateau = MarsRover.Controller.getPlateau();
			
			var f = function () { plateau.isPositionOnPlateau({ x: 4, y : 11}) };
			
			expect(f).toThrow('Position is not on the plateau');
		});
	});
	
	describe('when validating if a position is on the plateau and the Y coordinate is to low', function () {
		it('should validate the position', function () {
			MarsRover.Controller.topXCoordinate = 5;
			MarsRover.Controller.topYCoordinate = 10;
			plateau = MarsRover.Controller.getPlateau();
			
			var f = function () { plateau.isPositionOnPlateau({ x: 4, y : -1}) };
			
			expect(f).toThrow('Position is not on the plateau');
		});
	});
	
	describe('when getting a rover', function () {
		var rover;
		var plateau = 'plateau';
		
		beforeEach(function () {
			spyOn(MarsRover.Controller, 'getPlateau').andReturn(plateau);
			rover = MarsRover.Controller.getRover(1, 2, MarsRover.Directions.north());
		});
		
		it('should return a rover with the correct starting x coordinate', function () {
			expect(rover.position.x).toEqual(1);
		});
		
		it('should return a rover with the correct starting y coordinate', function () {
			expect(rover.position.y).toEqual(2);
		});
		
		it('should return a rover with the correct starting direction', function () {
			expect(rover.position.direction.name).toEqual('north');
		});
		
		it('should return a rover with the correct plateau', function () {
			expect(rover.plateau).toEqual('plateau');
		});
	});
});