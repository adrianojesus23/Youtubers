using BookStore.Application.Common.Interfaces;
using MediatR;

namespace BookStore.Application.Books.Commands;

public class DeleteBookCommandHandler: IRequestHandler<DeleteBookCommand, Unit>
{
    private readonly IRepository<Book> _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBookCommandHandler(IRepository<Book> repository, IUnitOfWork unitOfWork)
    {
        _bookRepository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.BookId);
        if (book == null)
        {
            throw new KeyNotFoundException($"Book with Id {request.BookId} not found.");
        }

        await _bookRepository.DeleteAsync(book);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}