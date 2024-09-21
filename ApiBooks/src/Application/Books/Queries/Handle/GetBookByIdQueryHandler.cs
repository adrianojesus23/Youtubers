using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Application.Common.Interfaces;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBookByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.Repository<Book>().GetByIdAsync(request.BookId);
        if (book == null)
        {
            throw new KeyNotFoundException($"Book with ID {request.BookId} not found.");
        }
        return book;
    }
}