using Itmo.ObjectOrientedProgramming.Lab1.Abstraction;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity;

public record ResultOfApplyingPower
{
    private ResultOfApplyingPower() { }

    public sealed record Success : ResultOfApplyingPower;

    public sealed record Failed(IError Error) : ResultOfApplyingPower;
}