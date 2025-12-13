using Itmo.ObjectOrientedProgramming.Lab1.Abstraction;

namespace Itmo.ObjectOrientedProgramming.Lab1.Errors;

public class StationSpeedLimitExeedsError : IError
{
    public string Message => "Station speed exeeds limit";
}