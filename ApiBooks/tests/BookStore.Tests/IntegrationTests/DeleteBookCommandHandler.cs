using Bogus;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Application.Books.Commands;
using BookStore.Application.Common.Interfaces;
using MediatR;
using Xunit;

public class DeleteBookCommandHandlerTests
{
    private readonly IRepository<Book> _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DeleteBookCommandHandler _handler;

    public DeleteBookCommandHandlerTests()
    {
        _bookRepository = A.Fake<IRepository<Book>>();
        _unitOfWork = A.Fake<IUnitOfWork>();
        _handler = new DeleteBookCommandHandler(_bookRepository, _unitOfWork);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenBookNotFound()
    {
        // Arrange
        var command = new DeleteBookCommand { BookId = Guid.NewGuid() };
        A.CallTo(() => _bookRepository.GetByIdAsync(command.BookId)).Returns(Task.FromResult<Book>(null));

        // Act
        Func<Task> action = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await action.Should().ThrowAsync<KeyNotFoundException>()
            .WithMessage($"Book with Id {command.BookId} not found.");
    }

    [Fact]
    public async Task Handle_ShouldDeleteBook_WhenBookExists()
    {
        // Arrange
        var book = A.Fake<Book>();
        var command = new DeleteBookCommand { BookId = Guid.NewGuid() };

        A.CallTo(() => _bookRepository.GetByIdAsync(command.BookId)).Returns(Task.FromResult(book));

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().Be(Unit.Value);
        A.CallTo(() => _bookRepository.DeleteAsync(book)).MustHaveHappenedOnceExactly();
        A.CallTo(() => _unitOfWork.SaveChangesAsync(CancellationToken.None)).MustHaveHappenedOnceExactly();
    }
}