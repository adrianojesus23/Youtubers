using Bogus;
using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Tests.UnitTests;

public class BooksControllerTests
{
    private readonly IMediator _mediator;
    private readonly BooksController _booksController;
    private readonly Faker _faker;

    public BooksControllerTests()
    {
        _faker = new Faker();
        _booksController = new BooksController(_mediator);
        _mediator =A.Fake<IMediator>();
    }

    [Fact]
    public async Task Create_ShouldReturn_BadRequest_WhenIds_DoNotMatch()
    {
        //Arrange
        var id = Guid.NewGuid();
        var bookCommand = new UpdateBookCommand
        {
          BookId = Guid.NewGuid(),
          Title = _faker.Lorem.Sentence(),
          Author = _faker.Person.FullName,
          Isbn = _faker.Commerce.Ean13(),
          PublishedDate = DateTime.Now
        };
        //Act
        var result = await _booksController.Create(id, bookCommand);
        //Assert
        result.Should().BeOfType<BadRequestResult>();
    }

    [Fact]
    public async Task Create_ShouldReturn_NoContent_WhenIdsMatch()
    {
        //Arrange
        var id = Guid.NewGuid();
        var bookCommand = new UpdateBookCommand
        {
            BookId = Guid.NewGuid(),
            Title = _faker.Lorem.Sentence(),
            Author = _faker.Person.FullName,
            Isbn = _faker.Commerce.Ean13(),
            PublishedDate = DateTime.Now
        };
        //Act
        var result = await _booksController.Create(id, bookCommand);
        //Assert
        result.Should().BeOfType<NoContentResult>();
        A.CallTo(()=> _mediator.Send(bookCommand, A<CancellationToken>._)).MustHaveHappenedOnceExactly();
    }
}