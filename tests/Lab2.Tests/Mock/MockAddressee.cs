using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mock;

public sealed class MockAddressee : IAddressee
{
    private readonly List<Message> _receivedMessages = new();

    public IReadOnlyCollection<Message> ReceivedMessages => _receivedMessages.AsReadOnly();

    public int ReceivedCount => _receivedMessages.Count;

    public void Receive(Message message)
    {
        _receivedMessages.Add(message);
    }
}