using BlazorMatchGame.Models;
using System.Net.Http;

namespace BlazorMatchGame.Helpers;

public class ApiHelper
{
    private readonly IHttpClientFactory _clientFactory;

    public ApiHelper(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<IEnumerable<HighScore>> GetHighScores()
    {
        var client = _clientFactory.CreateClient("HighScore");
        var response = await client.GetAsync("/api/highscore");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<IEnumerable<HighScore>>();
    }

    public async Task<bool> PostHighScore(string name, decimal score)
    {
        var client = _clientFactory.CreateClient("HighScore");
        var response = await client.PostAsJsonAsync("/api/highscore", new { name, score });
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadAsAsync<HighScoreResult>()).NewHighScore;
    }
}

public class HighScoreResult
{ 
    public bool NewHighScore { get; set; }
}
