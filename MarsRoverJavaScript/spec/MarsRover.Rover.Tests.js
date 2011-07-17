describe('Rover', function () {

	describe('when rover processes instructions', function () {

		var rover;
		var executeInstructionSpy;
		
		beforeEach(function () {
			rover = new MarsRover.Rover(1, 2, MarsRover.Directions.north());
			executeInstructionSpy = spyOn(rover, 'executeInstruction');
			
			rover.processInstructions('LMR');
		});
		
		it('should execute each instruction in turn', function () {
			expect(executeInstructionSpy.callCount).toEqual(3);
		});
		
		it('should passing the "L" argument to the executionInstruction function', function () {
			expect(rover.executeInstruction).toHaveBeenCalledWith('L');
		});
		
		it('should passing the "M" argument to the executionInstruction function', function () {
			expect(rover.executeInstruction).toHaveBeenCalledWith('M');
		});
		
		it('should passing the "R" argument to the executionInstruction function', function () {
			expect(rover.executeInstruction).toHaveBeenCalledWith('R');
		});
	});
	
	describe('when executing an invalid instruction', function () {
	
		it('should throw an exception', function () {
			var rover = new MarsRover.Rover(1, 2, MarsRover.Directions.north());
			
			expect(rover.executeInstruction).toThrow('Invalid instruction specified');
		});
	});
	
	describe('when executing an instruction to turn left', function () {
		
		it('should update the rovers direction', function () {
			var rover = new MarsRover.Rover(1, 2, MarsRover.Directions.north());
			rover.executeInstruction('L');
			
			expect(rover.position.direction.name).toEqual('west');
		});
	});
	
	describe('when executing an instruction to turn right', function () {
	
		it('should update the rovers direction', function () {
			var rover = new MarsRover.Rover(1, 2, MarsRover.Directions.north());
			rover.executeInstruction('R');
			
			expect(rover.position.direction.name).toEqual('east');
		});
	});
	
	describe('when executing an instruction to move forwards', function () {
	
		it('should update the rovers direction', function () {
			var rover = new MarsRover.Rover(1, 2, MarsRover.Directions.north());
			rover.executeInstruction('M');
			
			expect(rover.position.x).toEqual(1);
			expect(rover.position.y).toEqual(3);
		});
	});

});