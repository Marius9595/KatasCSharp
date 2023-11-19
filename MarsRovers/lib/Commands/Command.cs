namespace MarsRovers.lib;

public interface Command
{
    SpatialSituation executeWith(SpatialSituation spatialSituation);
}