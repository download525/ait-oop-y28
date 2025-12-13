using Itmo.ObjectOrientedProgramming.Lab1.Abstraction;

namespace Itmo.ObjectOrientedProgramming.Lab1.Errors;

public class EndOfTravelSpeedToHigh : IError
{
    public string Message => "Terminal speed exeeds limit";
}