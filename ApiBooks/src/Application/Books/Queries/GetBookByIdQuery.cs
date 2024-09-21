using MediatR;

public class GetBookByIdQuery : IRequest<Book>
{
    public Guid BookId { get; set; }
}