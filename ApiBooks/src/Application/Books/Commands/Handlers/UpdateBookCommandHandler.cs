using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Application.Common.Interfaces;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBookCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.Repository<Book>().GetByIdAsync(request.BookId);

        if (book == null)
        {
            return false; // Ou lançar uma exceção se preferir
        }

        var isbn = new ISBN(request.Isbn); // Assumindo que ISBN é um tipo de valor
        book.Update(request.Title, request.Author, isbn, request.PublishedDate);

        _unitOfWork.Repository<Book>().UpdateAsync(book);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}