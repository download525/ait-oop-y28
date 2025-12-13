using Itmo.ObjectOrientedProgramming.Lab1.Abstraction;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routing.SectionsTypes;

public abstract record SectionPassResult
{
    private SectionPassResult() { }

    public sealed record Success(TimeSpan TotalTime) : SectionPassResult;

    public sealed record Failed(IError Error) : SectionPassResult;
}