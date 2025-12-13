namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public readonly record struct Mass
{
    private Variables Value { get; }

    public Mass(float value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Mass cant be negative");
        Value = new Variables(value);
    }

    public static implicit operator Mass(float value) => new(value);

    public static implicit operator float(Mass value) => value.Value;
}