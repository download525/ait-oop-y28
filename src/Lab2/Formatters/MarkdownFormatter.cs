using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public sealed class MarkdownFormatter : IFormatter
{
    private readonly IFormatter _formatter;

    public MarkdownFormatter(IFormatter formatter)
    {
        _formatter = formatter;
    }

    public void WriteTitle(string title)
    {
        _formatter.WriteTitle($"## {title}");
    }

    public void WriteBody(string body)
    {
        _formatter.WriteTitle(string.Empty);
        _formatter.WriteBody(body);
        _formatter.WriteBody(string.Empty);
    }
}