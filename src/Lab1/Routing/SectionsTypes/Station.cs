using Itmo.ObjectOrientedProgramming.Lab1.Abstraction;
using Itmo.ObjectOrientedProgramming.Lab1.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routing.SectionsTypes;

public class Station : IRouteSection
{
    private readonly Speed _maxAllowedArrivalSpeed;
    private readonly TimeSpan _stopTime;

    public Station(Speed maxAllowedArrivalSpeed, TimeSpan stopTime)
    {
        _maxAllowedArrivalSpeed = maxAllowedArrivalSpeed;
        _stopTime = stopTime;
    }

    public SectionPassResult Pass(Train train)
    {
        if (train.Speed > _maxAllowedArrivalSpeed)
        {
            return new SectionPassResult.Failed(new StationSpeedLimitExeedsError());
        }

        train.StopAcceleration();
        return new SectionPassResult.Success(_stopTime);
    }
}