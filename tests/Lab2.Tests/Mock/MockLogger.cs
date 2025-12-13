using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mock;

public sealed class MockLogger : ILogger
{
    private readonly List<Message> _loggedMessages = new();

    public IReadOnlyCollection<Message> LoggedMessages => _loggedMessages.AsReadOnly();

    public int LogCount => _loggedMessages.Count;

    public Message? LastLoggedMessage => _loggedMessages.Count > 0 ? _loggedMessages[^1] : null;

    public void Log(Message message)
    {
        _loggedMessages.Add(message);
    }
}