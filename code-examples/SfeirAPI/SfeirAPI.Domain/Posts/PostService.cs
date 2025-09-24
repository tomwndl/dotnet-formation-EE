using System.Net.Http.Json;

namespace SfeirAPI.Domain.Posts;

public interface IPostService
{
    Task<List<Post>?> GetPosts();
}

public class PostService(HttpClient httpClient) : IPostService
{
    public async Task<List<Post>?> GetPosts()
    {
        var response = await httpClient.GetAsync("posts");
        var posts = await response.Content.ReadFromJsonAsync<List<Post>>(); // désérialisation JSON en objet fort typé
        return posts;
    }
}
