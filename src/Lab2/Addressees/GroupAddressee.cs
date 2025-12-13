using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public sealed class GroupAddressee : IAddressee
{
    private readonly IReadOnlyCollection<IAddressee> _addressees;

    public GroupAddressee(IReadOnlyCollection<IAddressee> addressees)
    {
        if (addressees.Count == 0)
        {
            throw new ArgumentException("Group must contain at least one addressee", nameof(addressees));
        }

        _addressees = addressees;
    }

    public void Receive(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.Receive(message);
        }
    }
}