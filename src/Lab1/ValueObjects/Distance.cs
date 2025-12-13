namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public readonly record struct Distance
{
    private Variables Value { get; }

    public Distance(float value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Distance cant be negative");
        Value = new Variables(value);
    }

    public static implicit operator Distance(float value) => new(value);

    public static implicit operator float(Distance value) => value.Value;
}