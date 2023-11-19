namespace MarsRovers.lib;

public class TurnLeftCommand: Command
{
    public SpatialSituation executeWith(SpatialSituation spatialSituation)
    {
        var coordinates = spatialSituation.Coordinates;
        var direction = spatialSituation.Orientation;
        
        switch (direction)
        {
            case Direction.North:
                return new SpatialSituation(coordinates, Direction.West);
            case Direction.East:
                return new SpatialSituation(coordinates, Direction.North);
            case Direction.South:
                return new SpatialSituation(coordinates, Direction.East);
            case Direction.West:
                return new SpatialSituation(coordinates, Direction.South);
            default:
                return spatialSituation;
        }
    }
}