using APIs.Models;

namespace APIs.Data;

public static class MockData
{
    public static List<Post> GetPosts()
    {
        var posts = new List<Post>
        {
            new Post { Id = 1, Title = "First Post", Body = "This is the first post." },
            new Post { Id = 2, Title = "Second Post", Body = "This is the second post." }
        };

        return posts;
    }
}