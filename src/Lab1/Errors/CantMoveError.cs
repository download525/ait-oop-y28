using Itmo.ObjectOrientedProgramming.Lab1.Abstraction;

namespace Itmo.ObjectOrientedProgramming.Lab1.Errors;

public sealed record CantMoveError : IError
{
    public string Message => "Train can not move from rest without acceleration";
}