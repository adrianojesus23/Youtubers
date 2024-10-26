using APIs.Models;

namespace APIs.Repositories;

public interface IPostRepository
{
    Task<List<Post>> Get();
    Task<Post?> GetById(int id);
    Task<Post> Create(Post post);
    Task<Post?> Update(int id, Post post);
    Task<bool> Delete(int id);
}