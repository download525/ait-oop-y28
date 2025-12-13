using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public sealed class FilteringAddressee : IAddressee
{
    private readonly IAddressee _decoratee;
    private readonly MessageImportanceLevel _minimalImportance;

    public FilteringAddressee(IAddressee decoratee, MessageImportanceLevel minimalImportance)
    {
        _decoratee = decoratee;
        _minimalImportance = minimalImportance;
    }

    public void Receive(Message message)
    {
        if (message.Importance < _minimalImportance)
        {
            return;
        }

        _decoratee.Receive(message);
    }
}