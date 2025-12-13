using Itmo.ObjectOrientedProgramming.Lab2.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Archivers;
using Itmo.ObjectOrientedProgramming.Lab2.Errors;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.Mock;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public sealed class MessageTests
{
    [Fact]
    public void User_ReceivesMessage_MessageShouldBeUnread()
    {
        // Arrange
        var user = new User("Alice");
        var message = new Message("Test Title", "Test Body", MessageImportanceLevel.Normal);

        // Act
        user.ReceiveMessage(message);

        // Assert
        Assert.Single(user.Messages);
        Assert.Contains(message, user.Messages);
        Assert.Equal(MessageStatus.Unread, user.GetMessageStatus(message));
    }

    [Fact]
    public void User_MarksUnreadMessageAsRead_StatusShouldChangeToRead()
    {
        // Arrange
        var user = new User("Alice");
        var message = new Message("Test Title", "Test Body", MessageImportanceLevel.Normal);
        user.ReceiveMessage(message);

        // Act
        MarkAsReadResult result = user.MarkMessageAsRead(message);

        // Assert
        Assert.IsType<MarkAsReadResult.Success>(result);
        Assert.Equal(MessageStatus.Read, user.GetMessageStatus(message));
    }

    [Fact]
    public void User_MarksReadMessageAsRead_ShouldReturnError()
    {
        // Arrange
        var user = new User("Alice");
        var message = new Message("Test Title", "Test Body", MessageImportanceLevel.Normal);
        user.ReceiveMessage(message);
        user.MarkMessageAsRead(message);

        // Act
        MarkAsReadResult result = user.MarkMessageAsRead(message);

        // Assert
        MarkAsReadResult.Failed failedResult = Assert.IsType<MarkAsReadResult.Failed>(result);
        Assert.IsType<MessageAlreadyReadError>(failedResult.Error);
    }

    [Fact]
    public void FilteringDecorator_FiltersLowImportanceMessage_AddresseeShouldNotReceive()
    {
        // Arrange
        var mockAddressee = new MockAddressee();
        var filtering = new FilteringAddressee(mockAddressee, MessageImportanceLevel.High);
        var lowMessage = new Message("Low", "Body", MessageImportanceLevel.Low);

        // Act
        filtering.Receive(lowMessage);

        // Assert
        Assert.Equal(0, mockAddressee.ReceivedCount);
    }

    [Fact]
    public void LoggingDecorator_ReceivesMessage_ShouldLogMessage()
    {
        // Arrange
        var mockAddressee = new MockAddressee();
        var mockLogger = new MockLogger();
        var logging = new LoggingAddressee(mockAddressee, mockLogger);
        var message = new Message("Test", "Body", MessageImportanceLevel.Normal);

        // Act
        logging.Receive(message);

        // Assert
        Assert.Equal(1, mockLogger.LogCount);
        Assert.Equal(message, mockLogger.LastLoggedMessage);
        Assert.Equal(1, mockAddressee.ReceivedCount);
    }

    [Fact]
    public void FormattingArchiver_ArchivesMessage_ShouldCallFormatterMethods()
    {
        // Arrange
        var mockFormatter = new MockFormatter();
        var archiver = new FormattingArchiver(mockFormatter);
        var message = new Message("Test Title", "Test Body", MessageImportanceLevel.Normal);

        // Act
        archiver.Archive(message);

        // Assert
        Assert.Equal(1, mockFormatter.TitleWriteCount);
        Assert.Equal(1, mockFormatter.BodyWriteCount);
        Assert.Contains("Test Title", mockFormatter.WrittenTitles);
        Assert.Contains("Test Body", mockFormatter.WrittenBodies);
    }

    [Fact]
    public void GroupWithFilteredAddressee_SendsLowImportanceMessage_UserShouldReceiveOnce()
    {
        // Arrange
        var user = new User("Alice");
        var addressee1 = new UserAddressee(user);
        var addressee2 = new FilteringAddressee(
            new UserAddressee(user),
            MessageImportanceLevel.High);

        var group = new GroupAddressee([addressee1, addressee2]);
        var lowMessage = new Message("Test", "Body", MessageImportanceLevel.Low);

        // Act
        group.Receive(lowMessage);

        // Assert
        Assert.Single(user.Messages);
    }
}