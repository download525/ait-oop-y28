using Itmo.ObjectOrientedProgramming.Lab2.Errors;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public sealed class User
{
    private readonly Dictionary<Message, MessageStatus> _messages = new();

    public User(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("User name cannot be empty or whitespace", nameof(name));
        }

        Name = name;
    }

    public string Name { get; }

    public IReadOnlyDictionary<Message, MessageStatus> Messages => _messages.AsReadOnly();

    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (!_messages.TryAdd(message, MessageStatus.Unread))
        {
            _messages[message] = MessageStatus.Unread;
        }
    }

    public bool HasMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        return _messages.ContainsKey(message);
    }

    public MessageStatus GetMessageStatus(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        if (!_messages.TryGetValue(message, out MessageStatus status))
        {
            throw new InvalidOperationException("Message not found in user's messages");
        }

        return status;
    }

    public MarkAsReadResult MarkMessageAsRead(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        if (!_messages.ContainsKey(message))
        {
            return new MarkAsReadResult.Failed(new MessageNotFoundError());
        }

        if (_messages[message] == MessageStatus.Read)
        {
            return new MarkAsReadResult.Failed(new MessageAlreadyReadError());
        }

        _messages[message] = MessageStatus.Read;
        return new MarkAsReadResult.Success();
    }

    public int GetUnreadMessagesCount()
    {
        return _messages.Values.Count(status => status == MessageStatus.Unread);
    }

    public int GetReadMessagesCount()
    {
        return _messages.Values.Count(status => status == MessageStatus.Read);
    }
}