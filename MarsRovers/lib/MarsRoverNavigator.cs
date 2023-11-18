namespace MarsRovers.lib;

public class MarsRoverNavigator
{
    private SpatialSituation _spatialSituation;
    private readonly ObstacleDetector _obstacleDetector;
    private readonly Satellite _satellite;
    public MarsRoverNavigator(ObstacleDetector obstacleDetector, Satellite satellite)
    {
        this._obstacleDetector = obstacleDetector;
        this._satellite = satellite;
        this._spatialSituation = new SpatialSituation(Coordinates.at(0, 0), Direction.North);
    }
    public  SpatialSituation spatialSituation()
    {
        return new SpatialSituation(Coordinates.at(0,0), Direction.North);
    }

    public void executeCommands(Commands commands)
    {

    }
}