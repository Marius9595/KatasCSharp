namespace MarsRovers.lib;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class SpatialSituation
{
    private readonly Coordinates _coordinates;
    private readonly Direction _orientation;

    public SpatialSituation(Coordinates coordinates, Direction direction)
    {
        this._coordinates = coordinates;
        this._orientation = direction;
    }

    public Direction Orientation => _orientation;

    public Coordinates Coordinates => _coordinates;
}