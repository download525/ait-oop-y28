namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public readonly record struct Variables
{
    public float Value { get; }

    public Variables(float value)
    {
        if (float.IsNaN(value))
            throw new ArgumentOutOfRangeException(nameof(value), "Variables can not be NaN");

        Value = value;
    }

    public static implicit operator Variables(float value) => new(value);

    public static implicit operator float(Variables variables) => variables.Value;

    public static Variables operator +(Variables a, Variables b) => new(a.Value + b.Value);

    public static Variables operator -(Variables a, Variables b) => new(a.Value - b.Value);

    public static Variables operator *(Variables speed, float multiplier) => new(speed.Value * multiplier);

    public static Variables operator *(Variables speed, Variables multiplier) => new(speed.Value * multiplier.Value);

    public static Variables operator *(float multiplier, Variables speed) => new(multiplier * speed.Value);

    public static Variables operator /(Variables speed, float divisor) => new(speed.Value / divisor);

    public static Variables operator /(float divisor, Variables speed) => new(divisor / speed.Value);

    public static bool operator <(Variables left, Variables right) => left.Value < right.Value;

    public static bool operator >(Variables left, Variables right) => left.Value > right.Value;

    public static bool operator <=(Variables left, Variables right) => left.Value <= right.Value;

    public static bool operator >=(Variables left, Variables right) => left.Value >= right.Value;

    public bool Equals(Variables other)
    {
        return Value.Equals(other.Value);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public bool Equals(Variables other, float tolerance)
    {
        return Math.Abs(Value - other.Value) <= tolerance;
    }

    public bool Equals(Variables other, Variables tolerance)
    {
        return Math.Abs(Value - other.Value) <= (float)tolerance;
    }
}