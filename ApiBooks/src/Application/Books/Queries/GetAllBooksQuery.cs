using MediatR;

public class GetAllBooksQuery : IRequest<IEnumerable<Book>>
{
}