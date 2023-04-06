using Dotnet_RPG.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_RPG.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService;
    public CharacterController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<Character>>> Get()
    {
        return Ok(await _characterService.GetAllCharacters());
        
    }  
    
    [HttpGet("{id}")]
    public async  Task<ActionResult<List<Character>>> GetSingle(int id)
    {
        return Ok(await _characterService.GetCharacterById(id));
        
    }

    [HttpPost("NewCharacter")]
    public async Task<ActionResult<List<Character>>> AddCharacter(Character character)
    {
        
        return Ok(await _characterService.AddCharacter(character));
    }
}