using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public sealed class LoggingAddressee : IAddressee
{
    private readonly IAddressee _decorated;
    private readonly ILogger _logger;

    public LoggingAddressee(IAddressee decorated, ILogger logger)
    {
        _decorated = decorated;
        _logger = logger;
    }

    public void Receive(Message message)
    {
        _logger.Log(message);
        _decorated.Receive(message);
    }
}