using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab2.NotificationSystems;

public sealed class TextNotificationSystem : INotificationSystem
{
    private readonly string _notificationMessage;

    public TextNotificationSystem(string notificationMessage)
    {
        if (string.IsNullOrEmpty(notificationMessage))
        {
            throw new ArgumentException("Notification message cannot be empty", nameof(notificationMessage));
        }

        _notificationMessage = notificationMessage;
    }

    public void Notify()
    {
        Console.WriteLine(_notificationMessage);
    }
}