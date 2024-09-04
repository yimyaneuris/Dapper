using Dapper;
using DapperBeginners.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;

namespace DapperBeginners.Repository;

public class VideoGameRepository(IConfiguration configuration) : IVideoGameRepository
{
    public async Task<List<VideoGame>> GetAllAsync()
    {
        await using var connection = GetConnection();
        var videoGames = await connection.QueryAsync<VideoGame>("SELECT * FROM VIDEOGAMES");
        return videoGames.ToList();
    }

    public async Task<VideoGame?> FindByIdAsync(int id)
    {
        await using var connection = GetConnection();
        var videoGame = await connection.QuerySingleOrDefaultAsync<VideoGame>("SELECT * FROM VIDEOGAMES WHERE ID = @Id", new { Id = id });
        return videoGame;
    }

    private SqlConnection GetConnection()
    {
        return new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }
}