namespace MarsRovers.lib;

public enum Direction
{
    North,
    East,
    South,
    West
}

public record SpatialSituation(Coordinates coordinates, Direction orientation);