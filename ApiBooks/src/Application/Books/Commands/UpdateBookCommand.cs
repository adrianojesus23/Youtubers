using MediatR;

public class UpdateBookCommand:  IRequest<bool>
{
    public Guid BookId { get; set; }
    public string Title { get;  set; }
    public string Author { get;  set; }
    public string Isbn { get;  set; }
    public DateTime PublishedDate { get;  set; }
}