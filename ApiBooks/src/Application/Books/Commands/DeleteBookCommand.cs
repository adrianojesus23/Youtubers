using MediatR;

namespace BookStore.Application.Books.Commands;

public class DeleteBookCommand: IRequest<Unit>
{
    public Guid BookId { get; set; }
}