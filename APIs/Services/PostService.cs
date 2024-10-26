using APIs.Extensions;
using APIs.Models;
using APIs.Repositories;
using APIs.Requests;

namespace APIs.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;

    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<List<Post>> Get() => await _postRepository.Get();

    public async Task<Post?> GetById(int id) => await _postRepository.GetById(id);

    public async Task<Post> Create(PostRequest post) => await _postRepository.Create(post.ToModel());

    public async Task<Post?> Update(int id, PostRequest post) =>
        await _postRepository.Update(id, post.ToModel());

    public async Task<bool> Delete(int id) => await _postRepository.Delete(id);
}