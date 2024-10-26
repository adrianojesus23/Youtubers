using APIs.Models;
using APIs.Requests;

namespace APIs.Services;

public interface IPostService
{
    Task<List<Post>> Get();
    Task<Post?> GetById(int id);
    Task<Post> Create(PostRequest post);
    Task<Post?> Update(int id, PostRequest post);
    Task<bool> Delete(int id);
}