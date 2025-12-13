using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivers;

public sealed class FormattingArchiver : IArchiver
{
    private readonly IFormatter _formatter;

    public FormattingArchiver(IFormatter formatter)
    {
        _formatter = formatter;
    }

    public void Archive(Message message)
    {
        _formatter.WriteTitle(message.Title);
        _formatter.WriteBody(message.Body);
    }
}