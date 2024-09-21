using BookStore.Domain.Common.Interfaces;
using System;

public class Book : IAggregateRoot
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public ISBN Isbn { get; private set; }
    public DateTime PublishedDate { get; private set; }

    // Construtor protegido para EF
    protected Book() {}

    public static Book Create(string title, string author, ISBN isbn, DateTime publishedDate)
    {
        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Title and Author cannot be empty.");
        if (isbn is null)
            throw new ArgumentNullException(nameof(isbn));

        return new Book
        {
            Id = Guid.NewGuid(),
            Title = title,
            Author = author,
            Isbn = isbn,
            PublishedDate = publishedDate
        };
    }

    public void Update(string title, string author, ISBN isbn, DateTime publishedDate)
    {
        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Title and Author cannot be empty.");
        if (isbn is null)
            throw new ArgumentNullException(nameof(isbn));

        Title = title;
        Author = author;
        Isbn = isbn;
        PublishedDate = publishedDate;
    }
}