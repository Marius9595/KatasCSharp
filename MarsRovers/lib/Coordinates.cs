using System.Runtime.CompilerServices;

namespace MarsRovers.lib;

public class Coordinates
{
    private readonly int _x;
    private readonly int _y;
    
    private Coordinates(int x, int y)
    {
        this._x = x;
        this._y= y;
    }
    public static Coordinates at(int x, int y)
    {
       return new Coordinates(x, y);
    }
}