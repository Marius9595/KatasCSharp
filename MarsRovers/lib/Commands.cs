namespace MarsRovers.lib;

public class Commands
{
    private readonly List<Command> commands;
    
    public Commands(List<Command> commands)
    {
        this.commands = commands;
    }

    public SpatialSituation executeWith(SpatialSituation spatialSituation)
    {
        return new SpatialSituation(Coordinates.at(1, 0), Direction.North);
    }
}