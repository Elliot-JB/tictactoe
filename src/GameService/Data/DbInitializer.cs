using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Entities;

namespace GameService;

public class DbInitializer
{
    public async static Task InitDb(WebApplication app) {
        await DB.InitAsync("GameDb", MongoClientSettings.FromConnectionString(app.Configuration.GetConnectionString("MongoDBConnection")));

        await DB.Index<TicTacToeMatch>()
            .Key(m => m.NaughtsPlayer, KeyType.Text)
            .Key(m => m.CrossesPlayer, KeyType.Text)
            .CreateAsync();


        var count = await DB.CountAsync<TicTacToeMatch>();

        if (count == 0) {
            Console.WriteLine("No Data - will attempt to seed");
            var matchData = await File.ReadAllTextAsync("Data/matches.json");

            var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

            var matches = JsonSerializer.Deserialize<List<TicTacToeMatch>>(matchData, options);

            await DB.InsertAsync(matches);
        }
    }
}
