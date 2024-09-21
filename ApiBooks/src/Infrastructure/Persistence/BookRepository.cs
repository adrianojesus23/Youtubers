
using BookStore.Application.Common.Interfaces;
using BookStore.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class BookRepository: IRepository<Book>
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Book> GetByIdAsync(Guid id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task AddAsync(Book entity)
    {
        await _context.Books.AddAsync(entity);
    }

    public  Task UpdateAsync(Book entity)
    {
        _context.Books.Update(entity);
        
        return Task.CompletedTask;
    }

    public  Task DeleteAsync(Book entity)
    {
        _context.Books.Remove(entity);
        
        return Task.CompletedTask;
    }
}