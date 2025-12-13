namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public readonly record struct Speed
{
    private Variables Value { get; }

    public Speed(float value)
    {
        if (float.IsNaN(value))
            throw new ArgumentOutOfRangeException(nameof(value), "Speed cant be NaN");
        Value = new Variables(value);
    }

    public static implicit operator Speed(float value) => new(value);

    public static implicit operator float(Speed value) => value.Value;
}