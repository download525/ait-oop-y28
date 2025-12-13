using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab2.NotificationSystems;

public sealed class SoundNotificationSystem : INotificationSystem
{
    public void Notify()
    {
        Console.Beep();
    }
}