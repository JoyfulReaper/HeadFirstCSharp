using BlazorMatchGameApi.Data;
using BlazorMatchGameApi.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Data.SqlClient;

namespace BlazorMatchGameApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class HighScoreController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly HighScores _highScores;

    public HighScoreController(IConfiguration config,
        HighScores highScores)
    {
        _config = config;
        _highScores = highScores;
    }


    [HttpGet(Name = "GetHighScores")]
    public async Task<IEnumerable<HighScore>> Get()
    {
        return await _highScores.GetHighScores();
    }

    [HttpPost(Name = "PostHighScore")]
    public async Task<HighScoreResult> Post(HighScore score)
    {
        var result = new HighScoreResult();
        
        var scores = (await _highScores.GetHighScores()).ToList();
        if (!scores.Any() || score.Score < scores.Max(s => s.Score))
        {
            if(scores.Count >= 5)
            {
                await _highScores.RemoveHighScore(scores.Max(s => s.Score));
            }

            var highScore = new HighScore
            {
                Name = score.Name,
                Score = score.Score
            };

            await _highScores.AddHighScore(highScore);
            result.NewHighScore = true;
        }

        return result;
    }
}
