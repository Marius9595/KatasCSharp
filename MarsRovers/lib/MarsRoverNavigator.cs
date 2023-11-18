namespace MarsRovers.lib;

public class MarsRoverNavigator
{
    private readonly ObstacleDetector _obstacleDetector;
    private readonly Satellite _satellite;
    public MarsRoverNavigator(ObstacleDetector obstacleDetector, Satellite satellite)
    {
        this._obstacleDetector = obstacleDetector;
        this._satellite = satellite;
    }
    public static SpatialSituation spatialSituation()
    {
        return new SpatialSituation(Coordinates.at(0,0), Direction.North);
    }
}