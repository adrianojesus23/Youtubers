using APIs.Models;
using APIs.Requests;
using APIs.Services;

namespace APIs.Extensions;

public static class Endpoints
{
    public static void MapPostEndpoints(this IEndpointRouteBuilder app)
    {
// GET - Retorna todos os posts
        app.MapGet("/posts", async (IPostService postService) => await postService.Get())
            .WithName("GetPosts")
            .WithOpenApi();

// GET - Retorna um post pelo ID
        app.MapGet("/posts/{id:int}", async (int id, IPostService postService) =>
            {
                var post = await postService.GetById(id);
                if (post is null) return Results.NotFound();
                return Results.Ok(post);
            })
            .WithName("GetPostById")
            .WithOpenApi();

// POST - Cria um novo post
        app.MapPost("/posts", async (PostRequest newPost, IPostService postService) =>
            {
                var post = await postService.Create(newPost);

                return Results.Created($"/posts/{post.Id}", post);
            })
            .WithName("CreatePost")
            .WithOpenApi();

// PUT - Atualiza um post existente
        app.MapPut("/posts/{id:int}", async (int id, PostRequest updatedPost, IPostService postService) =>
            {
                var post = await postService.Update(id, updatedPost);

                if (post is null) return Results.NotFound();

                return Results.Ok(post);
            })
            .WithName("UpdatePost")
            .WithOpenApi();

// DELETE - Exclui um post
        app.MapDelete("/posts/{id:int}", async (int id, IPostService postService) =>
            {
                var isPost = await postService.Delete(id);
                if (!isPost) return Results.NotFound();

                return Results.NoContent();
            })
            .WithName("DeletePost")
            .WithOpenApi();
    }
}