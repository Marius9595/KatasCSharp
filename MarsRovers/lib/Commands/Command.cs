namespace MarsRovers.lib;

public interface Command
{
    SpatialSituation executeFrom(SpatialSituation spatialSituation);
}