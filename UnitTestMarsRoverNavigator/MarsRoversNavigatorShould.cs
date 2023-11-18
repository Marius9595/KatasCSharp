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
        
        var spatialSituation = MarsRoverNavigator.spatialSituation();
        
        spatialSituation.Should().Be(new SpatialSituation(Coordinates.at(0,0), Direction.North));
    }
}