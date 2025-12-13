using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mock;

public sealed class MockFormatter : IFormatter
{
    private readonly List<string> _writtenTitles = new();
    private readonly List<string> _writtenBodies = new();

    public IReadOnlyCollection<string> WrittenTitles => _writtenTitles.AsReadOnly();

    public IReadOnlyCollection<string> WrittenBodies => _writtenBodies.AsReadOnly();

    public int TitleWriteCount => _writtenTitles.Count;

    public int BodyWriteCount => _writtenBodies.Count;

    public void WriteTitle(string title)
    {
        _writtenTitles.Add(title);
    }

    public void WriteBody(string body)
    {
        _writtenBodies.Add(body);
    }
}