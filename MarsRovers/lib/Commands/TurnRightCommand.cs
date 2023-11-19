namespace MarsRovers.lib;

public class TurnRightCommand: Command
{
    public SpatialSituation executeFrom(SpatialSituation spatialSituation)
    {
        var coordinates = spatialSituation.Coordinates;
        var direction = spatialSituation.Orientation;
        
        switch (direction)
        {
            case Direction.North:
                return new SpatialSituation(coordinates, Direction.East);
            case Direction.East:
                return new SpatialSituation(coordinates, Direction.South);
            case Direction.South:
                return new SpatialSituation(coordinates, Direction.West);
            case Direction.West:
                return new SpatialSituation(coordinates, Direction.North);
            default:
                return spatialSituation;
        }
    }
}