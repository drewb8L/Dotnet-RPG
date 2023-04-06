using Dotnet_RPG.DTO.Character;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Dotnet_RPG.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private static List<Character> _characters = new()
    {
        new Character(),
        new Character { Id = 1, Name = "Sam" }
    };

    public async Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters()
    {
        var res = new ServiceResponse<List<GetCharacterResponseDto>>
        {
            Data = _characters,
            Success = true,
            Message = "Complete"
        };
        return res;
    }

    public async Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id)
    {
        var res = new ServiceResponse<GetCharacterResponseDto>();
        var character = _characters.FirstOrDefault(c => c.Id == id);

        res.Data = character;
        return res;
    }

    public async Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(SendCharacterDto character)
    {
        _characters.Add(character);
        var res = new ServiceResponse<List<GetCharacterResponseDto>>
        {
            Data = _characters,
            Success = true,
            Message = "Complete"
        };


        return res;
    }
}