using Itmo.ObjectOrientedProgramming.Lab1.Abstraction;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routing;

public abstract record RouteSegmentPassResult
{
    private RouteSegmentPassResult() { }

    public sealed record Success(TimeSpan TravelTime) : RouteSegmentPassResult;

    public sealed record Failed(IError Error) : RouteSegmentPassResult;
}