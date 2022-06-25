using BlazorMatchGameApi.Models;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;

namespace BlazorMatchGameApi.Data;

public class HighScores
{
    private readonly IConfiguration _config;

    public HighScores(IConfiguration config)
    {
        _config = config;
    }
    
    public async Task<IEnumerable<HighScore>> GetHighScores()
    {
        using IDbConnection connection = new SqliteConnection(_config.GetConnectionString("DefaultConnection"));
        var scores = await connection.QueryAsync<HighScore>("SELECT * FROM HighScore ORDER BY Score DESC");
        return scores;
    }

    public async Task RemoveHighScore(decimal value)
    {
        using IDbConnection connection = new SqliteConnection(_config.GetConnectionString("DefaultConnection"));
        await connection.ExecuteAsync("DELETE FROM HighScore WHERE Score = @Value", new { Value = value });
    }

    public async Task AddHighScore(HighScore score)
    {
        using IDbConnection connection = new SqliteConnection(_config.GetConnectionString("DefaultConnection"));
        await connection.ExecuteAsync("INSERT INTO HighScore (Name, Score) VALUES (@Name, @Score)", score);
    }
}
