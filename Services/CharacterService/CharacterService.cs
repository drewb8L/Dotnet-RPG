using Microsoft.AspNetCore.Http.HttpResults;

namespace Dotnet_RPG.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private static List<Character> _characters = new()
    {
        new Character(),
        new Character { Id = 1, Name = "Sam" }
    };

    public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
    {
        var res = new ServiceResponse<List<Character>>
        {
            Data = _characters,
            Success = true,
            Message = "Complete"
        };
        return res;
    }

    public async Task<ServiceResponse<Character>> GetCharacterById(int id)
    {
        var res = new ServiceResponse<Character>();
        var character = _characters.FirstOrDefault(c => c.Id == id);

        res.Data = character;
        return res;
    }

    public async Task<ServiceResponse<List<Character>>> AddCharacter(Character character)
    {
        _characters.Add(character);
        var res = new ServiceResponse<List<Character>>
        {
            Data = _characters,
            Success = true,
            Message = "Complete"
        };


        return res;
    }
}