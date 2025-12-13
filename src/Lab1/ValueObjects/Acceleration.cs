namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public readonly record struct Acceleration
{
    public Variables Value { get; }

    public Acceleration(float value)
    {
        Value = new Variables(value);
    }

    public static implicit operator Acceleration(float value) => new(value);

    public static implicit operator float(Acceleration value) => value.Value;
}