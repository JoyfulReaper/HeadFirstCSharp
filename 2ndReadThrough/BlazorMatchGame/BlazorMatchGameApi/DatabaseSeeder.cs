using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;

namespace BlazorMatchGameApi;

public static class DatabaseSeeder
{
    public static void EnsureDatabaseCreated(this IApplicationBuilder app)
    {
        Seed(app).GetAwaiter().GetResult();
    }

    private async static Task Seed(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        IConfiguration config =
            scope.ServiceProvider.GetRequiredService<IConfiguration>();

        
        using IDbConnection connection = new SqliteConnection(config.GetConnectionString("DefaultConnection"));
        connection.Open();

        var sql = "CREATE TABLE IF NOT EXISTS HighScore (Id INTEGER UNIQUE, Name TEXT, Score REAL, PRIMARY KEY (\"Id\" AUTOINCREMENT))";
        connection.Execute(sql);
    }
}
