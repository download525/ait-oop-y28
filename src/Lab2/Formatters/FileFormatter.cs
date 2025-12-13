using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public sealed class FileFormatter : IFormatter
{
    private readonly TextWriter _writer;

    public FileFormatter(TextWriter writer)
    {
        _writer = writer;
    }

    public void WriteTitle(string title)
    {
        _writer.WriteLine(title);
    }

    public void WriteBody(string body)
    {
        _writer.WriteLine(body);
    }
}