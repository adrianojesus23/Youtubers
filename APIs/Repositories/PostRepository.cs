using APIs.Data;
using APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace APIs.Repositories;

public class PostRepository : IPostRepository
{
    private readonly AppDbContext _appDbContext;

    public PostRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<Post>> Get() => await _appDbContext.Posts.ToListAsync();

    public async Task<Post?> GetById(int id) => await _appDbContext.Posts.FindAsync(id);

    public async Task<Post> Create(Post post)
    {
        await _appDbContext.Posts.AddAsync(post);
        await _appDbContext.SaveChangesAsync();
        return post;
    }

    public async Task<Post?> Update(int id, Post post)
    {
        var existingPost = await FindById(id);
        if (existingPost is null) return null;

        existingPost.Title = post.Title;
        existingPost.Body = post.Body;

        await _appDbContext.SaveChangesAsync();
        return existingPost;
    }

    public async Task<bool> Delete(int id)
    {
        var existingPost = await FindById(id);
        if (existingPost is null) return false;

        _appDbContext.Remove(existingPost);
        await _appDbContext.SaveChangesAsync();
        return true;
    }

    private async Task<Post?> FindById(int id)
    {
        return await _appDbContext.Posts.FindAsync(id);
    }
}