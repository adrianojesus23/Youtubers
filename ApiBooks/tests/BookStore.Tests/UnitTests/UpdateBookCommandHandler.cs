using FakeItEasy;
using FluentAssertions;
using System;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Application.Common.Interfaces;
using Xunit;

public class UpdateBookCommandHandlerTests
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UpdateBookCommandHandler _handler;
    private readonly IRepository<Book> _bookRepository;

    public UpdateBookCommandHandlerTests()
    {
        _unitOfWork = A.Fake<IUnitOfWork>();
        _bookRepository = A.Fake<IRepository<Book>>();
        _handler = new UpdateBookCommandHandler(_unitOfWork);
    }

    [Fact]
    public async Task Handle_ShouldReturnFalse_WhenBookNotFound()
    {
        // Arrange
        var command = new UpdateBookCommand { BookId = Guid.NewGuid() };

        A.CallTo(() => _unitOfWork.Repository<Book>().GetByIdAsync(command.BookId)).Returns(Task.FromResult<Book>(null));

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task Handle_ShouldUpdateBook_WhenBookExists()
    {
        // Arrange
        var book = A.Fake<Book>();
        var command = new UpdateBookCommand { BookId = Guid.NewGuid(), Title = "New Title", Author = "New Author", Isbn = "1234567890" };

        A.CallTo(() => _unitOfWork.Repository<Book>().GetByIdAsync(command.BookId)).Returns(Task.FromResult(book));

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().BeTrue();
        A.CallTo(() => _unitOfWork.Repository<Book>().UpdateAsync(book)).MustHaveHappenedOnceExactly();
        A.CallTo(() => _unitOfWork.SaveChangesAsync(CancellationToken.None)).MustHaveHappenedOnceExactly();
    }
}