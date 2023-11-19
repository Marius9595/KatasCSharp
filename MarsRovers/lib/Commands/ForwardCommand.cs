namespace MarsRovers.lib;

public class ForwardCommand : Command
{
    public SpatialSituation executeFrom(SpatialSituation spatialSituation)
    {
        var coordinates = spatialSituation.Coordinates;
        var direction = spatialSituation.Orientation;
        switch (direction)
        {
            case Direction.North:
                return new SpatialSituation(coordinates.toNextCoordinateY(), direction);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}