using Itmo.ObjectOrientedProgramming.Lab1.Abstraction;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity;

public abstract record ResultOfTrainTravel
{
    private ResultOfTrainTravel() { }

    public sealed record Success(TimeSpan TravelTime) : ResultOfTrainTravel;

    public sealed record Failed(IError Error) : ResultOfTrainTravel;
}