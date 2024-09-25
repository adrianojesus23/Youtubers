using Bogus;
using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public class BooksControllerTests_GetAll
{
    private readonly IMediator _mediator;
    private readonly BooksController _controller;

    public BooksControllerTests_GetAll()
    {
        _mediator = A.Fake<IMediator>();
        _controller = new BooksController(_mediator);
    }

    [Fact]
    public async Task GetAll_ShouldReturnOk_WithListOfBooks()
    {
        // Arrange
        var books = new List<Book>
        {
            new Faker<Book>()
                .RuleFor(b => b.Id, f => f.Random.Guid())
                .RuleFor(b => b.Title, f => f.Lorem.Sentence())
                .RuleFor(b => b.Author, f => f.Person.FullName)
                .Generate()
        };

        // Set up the mediator to return Task<IEnumerable<Book>>
        A.CallTo(() => _mediator.Send(A<GetAllBooksQuery>.Ignored, A<CancellationToken>._))
            .Returns(Task.FromResult<IEnumerable<Book>>(books));

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        var returnedBooks = okResult.Value as IEnumerable<Book>;

        returnedBooks.Should().NotBeNull();
        returnedBooks.Should().HaveCount(1);
    }
}