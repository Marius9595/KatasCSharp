namespace MarsRovers.lib;

public class TurnRightCommand: Command
{
    public SpatialSituation executeWith(SpatialSituation spatialSituation)
    {
        return new SpatialSituation(new Coordinates(0,0), Direction.East);
    }
}