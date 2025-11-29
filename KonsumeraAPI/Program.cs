using KonsumeraAPI;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        // Skapa en HttpClient för att göra HTTP-anrop
        using var client = new HttpClient();
                
        client.DefaultRequestHeaders.UserAgent.ParseAdd("Lab4App");

        // URL för att hämta repositorier från GitHub
        string url = "https://api.github.com/orgs/dotnet/repos";

        // Hämta JSON-data från GitHub API
        string json = await client.GetStringAsync(url);

        // Deserialisera JSON-data till en lista av GitRepo-objekt
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var repos = JsonSerializer.Deserialize<List<GitRepo>>(json, options);

        // Kontrollera om deserialisering lyckades
        if (repos == null)
        {
            Console.WriteLine("Kunde inte läsa in data.");
            return;
        }

        // Skriv ut information om varje repository
        foreach (var repo in repos)
        {
            Console.WriteLine($"Name: {repo.Name}");
            Console.WriteLine($"Homepage: {repo.Homepage}");
            Console.WriteLine($"GitHub: {repo.HtmlUrl}");
            Console.WriteLine($"Description: {repo.Description}");
            Console.WriteLine($"Watchers: {repo.Watchers}");
            Console.WriteLine($"Last push: {repo.PushedAt:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine();  // tom rad mellan repos
        }

        Console.WriteLine("Tack för den här kursen, har varit kul =)");
        Console.WriteLine("\n\nPress any key to exit...");
        Console.ReadKey();
    }
}