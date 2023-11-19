namespace MarsRovers.lib;

public class MarsRoverNavigator
{
    private SpatialSituation _spatialSituation;
    private readonly ObstacleDetector _obstacleDetector;
    private readonly Satellite _satellite;
    public MarsRoverNavigator(ObstacleDetector obstacleDetector, Satellite satellite)
    {
        _obstacleDetector = obstacleDetector;
        _satellite = satellite;
        _spatialSituation = new SpatialSituation(new Coordinates(0, 0), Direction.North);
    }
    public  SpatialSituation spatialSituation()
    {
        return _spatialSituation;
    }

    public void executeCommands(Commands commands)
    {
        var newSpatialSituation = _spatialSituation;
        commands.forEach((command) =>
        {
            newSpatialSituation = command.executeFrom(newSpatialSituation);
            if (_obstacleDetector.isThereAnObstacleAt(newSpatialSituation.Coordinates))
            {
                newSpatialSituation =  _spatialSituation;
            }
                
            if (_satellite.isExceedingTheBoundaries(newSpatialSituation.Coordinates))
            {
            }

            return newSpatialSituation;
        });
        _spatialSituation = newSpatialSituation;
    }
}