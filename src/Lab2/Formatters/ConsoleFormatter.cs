using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public sealed class ConsoleFormatter : IFormatter
{
    public void WriteTitle(string title)
    {
        Console.WriteLine(title);
    }

    public void WriteBody(string body)
    {
        Console.WriteLine(body);
    }
}