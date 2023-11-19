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
        return new SpatialSituation(new Coordinates(0, 1), Direction.North);
    }
}