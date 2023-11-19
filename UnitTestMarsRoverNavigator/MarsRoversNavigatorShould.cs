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
    public void start_always_with_the_same_spatial_situation()
    {
        var marsRoverNavigator = new MarsRoverNavigator(obstacleDetectorMock.Object, satelliteMock.Object);
        
        marsRoverNavigator.spatialSituation().Should().BeEquivalentTo(new SpatialSituation(new Coordinates(0,0), Direction.North));
    }

        [Fact]
        public void determine_the_next_forward_coordinates()
        {
            var nextForwardCoordinates = new Coordinates(0,1);
            obstacleDetectorMock.Setup(x => x.isThereAnObstacleAt(nextForwardCoordinates)).Returns(false);
            satelliteMock.Setup(x => x.isExceedingTheBoundaries(nextForwardCoordinates)).Returns(false);
            var marsRoverNavigator = new MarsRoverNavigator(obstacleDetectorMock.Object, satelliteMock.Object);
            
            marsRoverNavigator.executeCommands(new Commands(new List<Command> {new ForwardCommand()}));
            
            marsRoverNavigator.spatialSituation().Should().BeEquivalentTo(new SpatialSituation(nextForwardCoordinates, Direction.North));
            obstacleDetectorMock.Verify(x => x.isThereAnObstacleAt(nextForwardCoordinates), Times.Once);
            satelliteMock.Verify(x => x.isExceedingTheBoundaries(nextForwardCoordinates), Times.Once);
        }
        
        
        [Fact]
        public void change_its_orientation_to_the_next_left_hand_direction_when_it_turns_left()
        {
            obstacleDetectorMock.Setup(x => x.isThereAnObstacleAt(It.IsAny<Coordinates>())).Returns(false);
            satelliteMock.Setup(x => x.isExceedingTheBoundaries(It.IsAny<Coordinates>())).Returns(false);
            var marsRoverNavigator = new MarsRoverNavigator(obstacleDetectorMock.Object, satelliteMock.Object);
            
            marsRoverNavigator.executeCommands(new Commands(new List<Command> {new TurnLeftCommand()}));
            
            marsRoverNavigator.spatialSituation().Should().BeEquivalentTo(new SpatialSituation(new Coordinates(0,0), Direction.West));
            obstacleDetectorMock.Verify(x => x.isThereAnObstacleAt(It.IsAny<Coordinates>()), Times.Once);
            satelliteMock.Verify(x => x.isExceedingTheBoundaries(It.IsAny<Coordinates>()), Times.Once);
        }
        
        [Fact]
        public void change_its_orientation_to_the_next_right_hand_direction_when_it_turns_right()
        {
            obstacleDetectorMock.Setup(x => x.isThereAnObstacleAt(It.IsAny<Coordinates>())).Returns(false);
            satelliteMock.Setup(x => x.isExceedingTheBoundaries(It.IsAny<Coordinates>())).Returns(false);
            var marsRoverNavigator = new MarsRoverNavigator(obstacleDetectorMock.Object, satelliteMock.Object);
            
            marsRoverNavigator.executeCommands(new Commands(new List<Command> {new TurnRightCommand()}));
            
            marsRoverNavigator.spatialSituation().Should().BeEquivalentTo(new SpatialSituation(new Coordinates(0,0), Direction.East));
            obstacleDetectorMock.Verify(x => x.isThereAnObstacleAt(It.IsAny<Coordinates>()), Times.Once);
            satelliteMock.Verify(x => x.isExceedingTheBoundaries(It.IsAny<Coordinates>()), Times.Once);
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
            marsRoverNavigator.spatialSituation().Should().BeEquivalentTo(new SpatialSituation(new Coordinates(0,2), Direction.North));
            obstacleDetectorMock.Verify(x => x.isThereAnObstacleAt(finalCoordinates), Times.Once);
            satelliteMock.Verify(x => x.isExceedingTheBoundaries(finalCoordinates), Times.Once);
        }
}       