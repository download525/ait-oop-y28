using Itmo.ObjectOrientedProgramming.Lab1.Abstraction;
using Itmo.ObjectOrientedProgramming.Lab1.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routing.SectionsTypes;

public class RegularSection : IRouteSection
{
    private readonly Distance _distance;

    public RegularSection(Distance distance)
    {
        _distance = distance;
    }

    public SectionPassResult Pass(Train train)
    {
        train.StopAcceleration();
        ResultOfTrainTravel travel = train.Travel(_distance);

        if (travel is ResultOfTrainTravel.Success(var travelTime))
        {
            return new SectionPassResult.Success(travelTime);
        }
        else if (travel is ResultOfTrainTravel.Failed(var error))
        {
            return new SectionPassResult.Failed(error);
        }
        else
        {
            return new SectionPassResult.Failed(new ComputationSafetyLimitError());
        }
    }
}