using System.Runtime.CompilerServices;

namespace MarsRovers.lib;

public record Coordinates (int x , int y)
{
    public Coordinates toNextCoordinateY()
    {
        return new Coordinates(x, y + 1);
    }
}   