using Itmo.ObjectOrientedProgramming.Lab1.Abstraction;
using Itmo.ObjectOrientedProgramming.Lab1.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.Routing.SectionsTypes;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routing;

public sealed class Route
{
    private readonly IReadOnlyList<IRouteSection> _sections;
    private readonly Speed _maxAllowedStopSpeed;

    public Route(IReadOnlyList<IRouteSection> sections, Speed maxAllowedSpeed)
        {
        _sections = sections;
        _maxAllowedStopSpeed = maxAllowedSpeed;
        }

    public RouteSegmentPassResult Pass(Train train)
    {
        TimeSpan totalTime = TimeSpan.Zero;

        foreach (IRouteSection section in _sections)
        {
            SectionPassResult result = section.Pass(train);
            if (result is SectionPassResult.Failed failedError)
            {
                return new RouteSegmentPassResult.Failed(failedError.Error);
            }
            else if (result is SectionPassResult.Success(var time))
            {
                totalTime += time;
            }
            else
            {
                return new RouteSegmentPassResult.Failed(new ComputationSafetyLimitError());
            }
        }

        if (train.Speed > _maxAllowedStopSpeed) return new RouteSegmentPassResult.Failed(new EndOfTravelSpeedToHigh());

        train.Stop();

        return new RouteSegmentPassResult.Success(totalTime);
    }
}