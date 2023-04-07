using Dotnet_RPG.DTO.Character;
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
    public async Task<ActionResult<ServiceResponse<List<GetCharacterResponseDto>>>> Get()
    {
        return Ok(await _characterService.GetAllCharacters());
        
    }  
    
    [HttpGet("{id}")]
    public async  Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> GetSingle(int id)
    {
        return Ok(await _characterService.GetCharacterById(id));
        
    }

    [HttpPost("NewCharacter")]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterResponseDto>>>> AddCharacter(AddCharacterDto character)
    {
        
        return Ok(await _characterService.AddCharacter(character));
    }
    
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterResponseDto>>>> UpdateCharacter(UpdateCharacterDTO updatedCharacter)
    {
        var response = await _characterService.UpdateCharacter(updatedCharacter);
        if (response.Data is null)
        {
            return NotFound(response);
        }
        return Ok(await _characterService.UpdateCharacter(updatedCharacter));
    }
}