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
    public ActionResult<List<Character>> Get()
    {
        return Ok(_characterService.GetAllCharacters());
        
    }  
    
    [HttpGet("{id}")]
    public ActionResult<List<Character>> GetSingle(int id)
    {
        return Ok(_characterService.GetCharacterById(id));
        
    }

    [HttpPost("NewCharacter")]
    public ActionResult<List<Character>> AddCharacter(Character character)
    {
        
        return Ok(_characterService.AddCharacter(character));
    }
}