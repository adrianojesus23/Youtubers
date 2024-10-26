using APIs.Models;
using APIs.Requests;

namespace APIs.Extensions;

public static class ConvertModels
{
    public static Post ToModel(this PostRequest postRequest)
    {
        if (postRequest is null)
            return default;

        return new Post
        {
           Title = postRequest.Title,
           Body = postRequest.Body
        };
    }
}