using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Abstractions;

public interface ILogger
{
    void Log(Message message);
}