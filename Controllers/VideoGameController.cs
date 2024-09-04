using DapperBeginners.Models;
using DapperBeginners.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DapperBeginners.Controllers;

[ApiController]
[Route("api/videogame")]
public class VideoGameController(IVideoGameRepository videoGameRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<VideoGame>>> GetAllAsync()
    {
        var videoGames = await videoGameRepository.GetAllAsync();
        return Ok(videoGames);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<VideoGame>> FindById(int id)
    {
        var videoGame = await videoGameRepository.FindByIdAsync(id);
        if (videoGame == null)
            return NotFound( "The game searched is not available" );

        return Ok(videoGame);
    }
    
    // TODO POST DELETE UPDATE, PATCH IF POSIBLE
}