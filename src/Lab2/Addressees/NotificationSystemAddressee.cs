using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public sealed class NotificationSystemAddressee : IAddressee
{
    private readonly INotificationSystem _notificationSystem;
    private readonly IReadOnlyCollection<string> _keywords;

    public NotificationSystemAddressee(INotificationSystem notificationSystem, IReadOnlyCollection<string> keywords)
    {
        _notificationSystem = notificationSystem;
        _keywords = keywords;
    }

    public void Receive(Message message)
    {
        bool containsSuspiciousText = _keywords.Any(keyword =>
            message.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            message.Body.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        if (containsSuspiciousText)
        {
            _notificationSystem.Notify();
        }
    }
}