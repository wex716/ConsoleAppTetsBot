using System.Text;
using System.Text.Json;

namespace ConsoleAppTetsBot.org.example.ApiWorker;

public class ApplicationApiWorker
{
    
    public ApplicationEntity GetByIdApplication(int id) // ???????
    {
        HttpClient httpClient = new HttpClient();
        string jsonAsString = httpClient.GetStringAsync($"https://jsonplaceholder.typicode.com/posts/{id}").Result;

        ApplicationEntity applicationEntity = JsonSerializer.Deserialize<ApplicationEntity>(jsonAsString);

        return applicationEntity;
    }
    
    public ApplicationEntity AddNewApplication(ApplicationEntity insertFakePost)
    {
        HttpClient httpClient = new HttpClient();
        string insertFakePostAsJson = JsonSerializer.Serialize(insertFakePost);

        HttpContent httpContent = new StringContent(insertFakePostAsJson, Encoding.UTF8, "application/json");

        string addedFakePostAsJson = httpClient.PostAsync("https://jsonplaceholder.typicode.com/posts", httpContent)
            .Result.Content.ReadAsStringAsync().Result;

        ApplicationEntity addedFakePost = JsonSerializer.Deserialize<ApplicationEntity>(addedFakePostAsJson);

        return addedFakePost;
    }
    public List<ApplicationEntity> GetByAllApplication(int id)
    {
        HttpClient httpClient = new HttpClient();
        string jsonAsString = httpClient.GetStringAsync($"https://jsonplaceholder.typicode.com/posts/{id}").Result;

        List<ApplicationEntity> applicationEntities = JsonSerializer.Deserialize<List<ApplicationEntity>>(jsonAsString);

        return applicationEntities;
    }
}