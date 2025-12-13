using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Errors;

public class MessageNotFoundError : IError
{
    public string Message => "Message not found in user's messages";
}