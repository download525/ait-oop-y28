using Itmo.ObjectOrientedProgramming.Lab1.Abstraction;

namespace Itmo.ObjectOrientedProgramming.Lab1.Errors;

public class NonPositiveSpeedError : IError
{
    public string Message => "Speed become non positive during travel";
}