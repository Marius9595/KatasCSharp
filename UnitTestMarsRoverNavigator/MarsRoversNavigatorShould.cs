using MarsRovers.lib;
using Moq;


namespace UnitTestMarsRoverNavigator;

public class MarsRoversNavigatorShould
{
    Mock<ObstacleDetector> obstacleDetectorMock;
    Mock<Satellite> satelliteMock;
    public MarsRoversNavigatorShould()
    {
        obstacleDetectorMock = new Mock<ObstacleDetector>();
        satelliteMock = new Mock<Satellite>();
    }
    
    
    [Fact]
    public void start_always_at_same_spatial_situation()
    {
        var marsRoverNavigator = new MarsRoverNavigator(obstacleDetectorMock.Object, satelliteMock.Object);
        
        marsRoverNavigator.spatialSituation().Should().BeEquivalentTo(new SpatialSituation(new Coordinates(0,0), Direction.North));
    }

        [Fact]
        public void determine_the_next_forward_coordinates()
        {
            var nextForwardCoordinates = new Coordinates(0,1);
            obstacleDetectorMock.(x => x.isThereAnObstacleAt(nextForwardCoordinates)).Returns(false);
            satelliteMock.Setup(x => x.isExceedingTheBoundaries(nextForwardCoordinates)).Returns(false);
            var marsRoverNavigator = new MarsRoverNavigator(obstacleDetectorMock.Object, satelliteMock.Object);
            
            marsRoverNavigator.executeCommands(new Commands(new List<Command> {new ForwardCommand()}));
            
            marsRoverNavigator.spatialSituation().Should().BeEquivalentTo(new SpatialSituation(nextForwardCoordinates, Direction.North));
            obstacleDetectorMock.Verify(x => x.isThereAnObstacleAt(nextForwardCoordinates), Times.Once);
            satelliteMock.Verify(x => x.isExceedingTheBoundaries(nextForwardCoordinates), Times.Once);
        }
        
        public static IEnumerable<object[]> CommandsToTurnLeftMultipleTimes
        {
            get
            {
                var turnLeftOneTime = new List<Command> { new TurnLeftCommand() };
                var turnLeftTwoTimes = new List<Command> {new TurnLeftCommand(), new TurnLeftCommand()};
                var turnLeftThreeTimes = new List<Command> {new TurnLeftCommand(), new TurnLeftCommand(), new TurnLeftCommand()};
                var turnLeftFourTimes = new List<Command> {new TurnLeftCommand(), new TurnLeftCommand(), new TurnLeftCommand(), new TurnLeftCommand()};
                var turnLeftFiveTimes = new List<Command> {new TurnLeftCommand(), new TurnLeftCommand(), new TurnLeftCommand(), new TurnLeftCommand(), new TurnLeftCommand()};
                
                yield return new object[] { new Commands(turnLeftOneTime), Direction.West };
                yield return new object[] { new Commands(turnLeftTwoTimes), Direction.South };
                yield return new object[] { new Commands(turnLeftThreeTimes), Direction.East };
                yield return new object[] { new Commands(turnLeftFourTimes), Direction.North };
                yield return new object[] { new Commands(turnLeftFiveTimes), Direction.West };
            }
        }
        [Theory]
        [MemberData(nameof(CommandsToTurnLeftMultipleTimes))]
        public void change_its_orientation_to_the_next_left_hand_direction_when_it_turns_left(
            Commands turnLeftMultipleTimes, Direction finalOrientation
            )
        {
            obstacleDetectorMock.Setup(x => x.isThereAnObstacleAt(It.IsAny<Coordinates>())).Returns(false);
            satelliteMock.Setup(x => x.isExceedingTheBoundaries(It.IsAny<Coordinates>())).Returns(false);
            var marsRoverNavigator = new MarsRoverNavigator(obstacleDetectorMock.Object, satelliteMock.Object);
            
            marsRoverNavigator.executeCommands(turnLeftMultipleTimes);
            
            marsRoverNavigator.spatialSituation().Should().BeEquivalentTo(new SpatialSituation(new Coordinates(0,0), finalOrientation));
            obstacleDetectorMock.Verify(x => x.isThereAnObstacleAt(It.IsAny<Coordinates>()), Times.AtLeastOnce);
            satelliteMock.Verify(x => x.isExceedingTheBoundaries(It.IsAny<Coordinates>()), Times.AtLeastOnce);
        }
        
        public static IEnumerable<object[]> CommandsToTurnRightMultipleTimes
        {
            get
            {
                var turnRightOneTime = new List<Command> { new TurnRightCommand() };
                var turnRightTwoTimes = new List<Command> {new TurnRightCommand(), new TurnRightCommand()};
                var turnRightThreeTimes = new List<Command> {new TurnRightCommand(), new TurnRightCommand(), new TurnRightCommand()};
                var turnRightFourTimes = new List<Command> {new TurnRightCommand(), new TurnRightCommand(), new TurnRightCommand(), new TurnRightCommand()};
                var turnRightFiveTimes = new List<Command> {new TurnRightCommand(), new TurnRightCommand(), new TurnRightCommand(), new TurnRightCommand(), new TurnRightCommand()};
                
                yield return new object[] { new Commands(turnRightOneTime), Direction.East };
                yield return new object[] { new Commands(turnRightTwoTimes), Direction.South };
                yield return new object[] { new Commands(turnRightThreeTimes), Direction.West };
                yield return new object[] { new Commands(turnRightFourTimes), Direction.North };
                yield return new object[] { new Commands(turnRightFiveTimes), Direction.East };
            }
        }
        
        [Theory]
        [MemberData(nameof(CommandsToTurnRightMultipleTimes))]
        public void change_its_orientation_to_the_next_right_hand_direction_when_it_turns_right(
            Commands turnRightMultipleTimes, Direction finalOrientation
            )
        {
            obstacleDetectorMock.Setup(x => x.isThereAnObstacleAt(It.IsAny<Coordinates>())).Returns(false);
            satelliteMock.Setup(x => x.isExceedingTheBoundaries(It.IsAny<Coordinates>())).Returns(false);
            var marsRoverNavigator = new MarsRoverNavigator(obstacleDetectorMock.Object, satelliteMock.Object);
            
            marsRoverNavigator.executeCommands(turnRightMultipleTimes);
            
            marsRoverNavigator.spatialSituation().Should().BeEquivalentTo(new SpatialSituation(new Coordinates(0,0), finalOrientation));
            obstacleDetectorMock.Verify(x => x.isThereAnObstacleAt(It.IsAny<Coordinates>()), Times.AtLeastOnce);
            satelliteMock.Verify(x => x.isExceedingTheBoundaries(It.IsAny<Coordinates>()), Times.AtLeastOnce);
        }
        
        
        [Fact]
        public void determine_the_coordinates_after_multiple_forward_commands()
        {
            var finalCoordinates = new Coordinates(0,2);
            obstacleDetectorMock.Setup(x => x.isThereAnObstacleAt(finalCoordinates)).Returns(false);
            satelliteMock.Setup(x => x.isExceedingTheBoundaries(finalCoordinates)).Returns(false);
            var marsRoverNavigator = new MarsRoverNavigator(obstacleDetectorMock.Object, satelliteMock.Object);
            var moveMultipleTimesForward = new Commands(new List<Command> {new ForwardCommand(),new ForwardCommand()});
            
            marsRoverNavigator.executeCommands(moveMultipleTimesForward);
            marsRoverNavigator.spatialSituation().Should().BeEquivalentTo(new SpatialSituation(finalCoordinates, Direction.North));
            obstacleDetectorMock.Verify(x => x.isThereAnObstacleAt(finalCoordinates), Times.AtLeastOnce);
            satelliteMock.Verify(x => x.isExceedingTheBoundaries(finalCoordinates), Times.AtLeastOnce);
        }

        [Fact]
        public void stop_when_an_obstacle_is_detected_in_the_previous_coordinate_than_obstacle()
        {
            var obstacleCoordinates = new Coordinates(0,1);
            obstacleDetectorMock.Setup(x => x.isThereAnObstacleAt(obstacleCoordinates)).Returns(true);
            satelliteMock.Setup(x => x.isExceedingTheBoundaries(It.IsAny<Coordinates>())).Returns(false);
            var marsRoverNavigator = new MarsRoverNavigator(obstacleDetectorMock.Object, satelliteMock.Object);
            
            marsRoverNavigator.executeCommands(new Commands(new List<Command> {new ForwardCommand()}));
            
            marsRoverNavigator.spatialSituation().Should().BeEquivalentTo(new SpatialSituation(new Coordinates(0,0), Direction.North));
            obstacleDetectorMock.Verify(x => x.isThereAnObstacleAt(obstacleCoordinates), Times.Once);
            satelliteMock.Verify(x => x.isExceedingTheBoundaries(It.IsAny<Coordinates>()), Times.Once);
        }
        
        [Fact]
        public void allow_going_around_the_boundaries_set_by_satellite()
        {
            var coordinatesOutOfBoundaries = new Coordinates(0,3);
            satelliteMock.Setup(x => x.isExceedingTheBoundaries(coordinatesOutOfBoundaries)).Returns(true);
            obstacleDetectorMock.Setup(x => x.isThereAnObstacleAt(It.IsAny<Coordinates>())).Returns(false);
            var marsRoverNavigator = new MarsRoverNavigator(obstacleDetectorMock.Object, satelliteMock.Object);
            
            marsRoverNavigator.executeCommands(new Commands(new List<Command> {new ForwardCommand()}));
            
            marsRoverNavigator.spatialSituation().Should().BeEquivalentTo(new SpatialSituation(new Coordinates(0,0), Direction.North));
            obstacleDetectorMock.Verify(x => x.isThereAnObstacleAt(It.IsAny<Coordinates>()), Times.AtLeastOnce);
            satelliteMock.Verify(x => x.isExceedingTheBoundaries(coordinatesOutOfBoundaries), Times.AtLeastOnce);
        }
}       