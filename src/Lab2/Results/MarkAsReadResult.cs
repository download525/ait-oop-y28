using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Results;

public abstract record MarkAsReadResult
{
    private MarkAsReadResult() { }

    public sealed record Success : MarkAsReadResult;

    public sealed record Failed(IError Error) : MarkAsReadResult;
}