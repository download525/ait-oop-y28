using Itmo.ObjectOrientedProgramming.Lab1.Abstraction;

namespace Itmo.ObjectOrientedProgramming.Lab1.Errors;

public class PowerExeedsLimitError : IError
{
    public string Message => "Power exeeds limit";
}