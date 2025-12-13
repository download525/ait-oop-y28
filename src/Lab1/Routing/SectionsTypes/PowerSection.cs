using Itmo.ObjectOrientedProgramming.Lab1.Abstraction;
using Itmo.ObjectOrientedProgramming.Lab1.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routing.SectionsTypes;

public class PowerSection : IRouteSection
{
    private readonly Distance _distance;
    private readonly Power _power;

    public PowerSection(Distance distance, Power power)
    {
        _distance = distance;
        _power = power;
    }

    public SectionPassResult Pass(Train train)
    {
        ResultOfApplyingPower result = train.ApplyPower(_power);
        if (result is ResultOfApplyingPower.Failed resultOfApplyingPower)
        {
            return new SectionPassResult.Failed(resultOfApplyingPower.Error);
        }

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