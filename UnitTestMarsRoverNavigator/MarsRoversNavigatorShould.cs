using MarsRovers.lib;
using Moq;


namespace UnitTestMarsRoverNavigator;

public class MarsRoversNavigatorShould
{
    [Fact]
    public void start_always_with_the_same_spatial_situation()
    {
        var obstacleDetectorMock = new Mock<ObstacleDetector>();
        var satelliteMock = new Mock<Satellite>();
        
        var marsRoverNavigator = new MarsRoverNavigator(obstacleDetectorMock.Object, satelliteMock.Object);
        
        marsRoverNavigator.spatialSituation().Should().BeEquivalentTo(new SpatialSituation(Coordinates.at(0,0), Direction.North));
    }

    [Fact]
    public void determine_the_next_forward_position()
    {
        var nextForwardCoordinates = Coordinates.at(0,1);
        var obstacleDetectorMock = new Mock<ObstacleDetector>();
        obstacleDetectorMock.Setup(x => x.isThereAnObstacleAt(Coordinates.at(0,1))).Returns(false);
        var satelliteMock = new Mock<Satellite>();
        satelliteMock.Setup(x => x.isExceedingTheBoundaries(nextForwardCoordinates)).Returns(false);
        var marsRoverNavigator = new MarsRoverNavigator(obstacleDetectorMock.Object, satelliteMock.Object);
        
        marsRoverNavigator.executeCommands(new Commands(new List<Command> {new ForwardCommand()}));
        
        marsRoverNavigator.spatialSituation().Should().BeEquivalentTo(new SpatialSituation(nextForwardCoordinates, Direction.North));
        obstacleDetectorMock.Verify(x => x.isThereAnObstacleAt(nextForwardCoordinates), Times.Once);
        satelliteMock.Verify(x => x.isExceedingTheBoundaries(nextForwardCoordinates), Times.Once);
    }
}