using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Topics;

public sealed class Topic
{
    private readonly IReadOnlyCollection<IAddressee> _addressees;

    public Topic(string name, IReadOnlyCollection<IAddressee> addressees)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Topic name cannot be empty", nameof(name));
        }

        if (addressees.Count == 0)
        {
            throw new ArgumentException("Topic must have at least one addressee", nameof(addressees));
        }

        Name = name;
        _addressees = addressees;
    }

    public string Name { get; }

    public void SendMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.Receive(message);
        }
    }
}