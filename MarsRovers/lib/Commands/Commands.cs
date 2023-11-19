namespace MarsRovers.lib;

public class Commands
{
    private readonly List<Command> commands;
    
    public Commands(List<Command> commands)
    {
        this.commands = commands;
    }
    
    public void forEach(Func<Command, SpatialSituation> func)
    {
        foreach (var command in commands)
        {
            func(command);
        }
    }
}