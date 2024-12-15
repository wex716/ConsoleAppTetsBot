using System.Text.Json.Serialization;

namespace ConsoleAppTetsBot.org.example.ApiWorker;

public class ApplicationEntity
{
    //  [JsonPropertyName("id")]
    // public string Id { get; set; }
    
   // public int TgId { get; set; }
   
    public int IdAddress { get; set; }
    public string NumberCabinet { get; set; }
    public string FullName { get; set; }
    public string NumberPhone { get; set; }
    public string DescriptionProblem { get; set; }
}