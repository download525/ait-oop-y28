namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public readonly record struct Power
{
    public Variables Value { get; }

    public Power(float value)
    {
        Value = new Variables(value);
    }

    public static implicit operator Power(float value) => new(value);

    public static implicit operator float(Power value) => value.Value;
}