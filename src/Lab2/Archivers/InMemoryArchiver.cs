using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivers;

public sealed class InMemoryArchiver : IArchiver
{
    private readonly List<Message> _messages = new();

    public IReadOnlyCollection<Message> Messages => _messages.AsReadOnly();

    public void Archive(Message message)
    {
        _messages.Add(message);
    }
}