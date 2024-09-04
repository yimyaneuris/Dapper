using DapperBeginners.Models;

namespace DapperBeginners.Repository;

public interface IVideoGameRepository
{
    Task<List<VideoGame>> GetAllAsync();
    Task<VideoGame?> FindByIdAsync(int id);
}