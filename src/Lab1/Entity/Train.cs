using Itmo.ObjectOrientedProgramming.Lab1.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity;

public class Train
{
    private readonly Mass _weightOfTrain;

    private readonly Power _maxAllowedPower;

    private readonly Variables _precision;

    public Speed Speed { get; private set; }

    public Acceleration Acceleration { get; private set; }

    public Train(Mass weight, Power maxPower, Variables precision)
    {
        if (precision.Value <= 0)
            throw new ArgumentOutOfRangeException(nameof(precision), "Precision must be greater than zero");
        _weightOfTrain = weight;
        _maxAllowedPower = maxPower;
        _precision = precision;

        Speed = new Speed(0);
        Acceleration = new Acceleration(0);
    }

    public ResultOfApplyingPower ApplyPower(Power power)
    {
        if (power > _maxAllowedPower)
            return new ResultOfApplyingPower.Failed(new PowerExeedsLimitError());

        Acceleration = new Acceleration(power / _weightOfTrain);
        return new ResultOfApplyingPower.Success();
    }

    public ResultOfTrainTravel Travel(Distance distance)
    {
        if (Speed == 0 && Acceleration == 0)
            return new ResultOfTrainTravel.Failed(new CantMoveError());

        double remaining = distance;
        double time = 0;

        while (remaining > 0)
        {
            Speed newSpeedValue = Speed + (Acceleration * _precision);

            if (newSpeedValue <= 0) return new ResultOfTrainTravel.Failed(new NonPositiveSpeedError());

            Speed = newSpeedValue;

            remaining -= Speed * _precision;
            time += _precision.Value;
        }

        return new ResultOfTrainTravel.Success(TimeSpan.FromSeconds(time));
    }

    public void StopAcceleration()
    {
        Acceleration = new Acceleration(0);
    }

    public void Stop()
    {
        Acceleration = new Acceleration(0);
        Speed = new Speed(0);
    }
}
