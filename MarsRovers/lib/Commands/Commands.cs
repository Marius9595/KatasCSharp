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
        var newSpatialSituation = spatialSituation;
        foreach (var command in commands)
        {
            newSpatialSituation = command.executeWith(newSpatialSituation);
        }
        
        return newSpatialSituation;
    }
}