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
        throw new NotImplementedException();
    }
}