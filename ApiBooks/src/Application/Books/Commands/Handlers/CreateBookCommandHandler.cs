using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Application.Common.Interfaces;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBookCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var isbn = new ISBN(request.Isbn); // Assumindo que ISBN é um tipo de valor

        var book = Book.Create(request.Title, request.Author, isbn, request.PublishedDate);

        await _unitOfWork.Repository<Book>().AddAsync(book);
        await _unitOfWork.SaveChangesAsync();

        return book.Id;
    }
}