using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Errors;

public sealed record MessageAlreadyReadError : IError
{
    public string Message => "Message has already been marked as read";
}