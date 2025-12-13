using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public sealed class UserAddressee : IAddressee
{
    private readonly User _user;

    public UserAddressee(User user)
    {
        _user = user;
    }

    public void Receive(Message message)
    {
        _user.ReceiveMessage(message);
    }
}