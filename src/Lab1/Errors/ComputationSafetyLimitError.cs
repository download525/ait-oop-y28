using Itmo.ObjectOrientedProgramming.Lab1.Abstraction;

namespace Itmo.ObjectOrientedProgramming.Lab1.Errors;

public class ComputationSafetyLimitError : IError
{
    public string Message => "Computation safeti limit reaached";
}