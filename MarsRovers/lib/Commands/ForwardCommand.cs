namespace MarsRovers.lib;

public class ForwardCommand : Command
{
    public SpatialSituation executeWith(SpatialSituation spatialSituation)
    {
        var coordinates = spatialSituation.Coordinates;
        var direction = spatialSituation.Direction;
        switch (direction)
        {
            case Direction.North:
                return new SpatialSituation(coordinates.toNextCoordinateY(), direction);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}