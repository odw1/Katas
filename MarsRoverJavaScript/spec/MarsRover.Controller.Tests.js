describe('Mars Rover Controller', function () {
	
	describe('when getting the plateau', function () {
		var plateau;
		
		beforeEach(function () {
			plateau = MarsRover.Controller.getPlateau(5, 10);
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
	
	describe('when getting a rover', function () {
		var rover;
		
		beforeEach(function () {
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
	
	});
});