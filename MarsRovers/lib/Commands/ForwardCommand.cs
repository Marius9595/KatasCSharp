namespace MarsRovers.lib;

public class ForwardCommand : Command
{
    public SpatialSituation executeWith(SpatialSituation spatialSituation)
    {
        return new SpatialSituation(new Coordinates(0, 1), Direction.North);
    }
}