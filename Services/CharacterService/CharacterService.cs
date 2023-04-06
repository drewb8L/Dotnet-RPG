using Microsoft.AspNetCore.Http.HttpResults;

namespace Dotnet_RPG.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private static List<Character> _characters = new()
    {
        new Character(),
        new Character { Id = 1, Name = "Sam" }
    };

    public async Task<List<Character>> GetAllCharacters()
    {
        return _characters;
    }

    public async Task<Character> GetCharacterById(int id)
    {
        var character = _characters.FirstOrDefault(c => c.Id == id);
        if (character is not null)
        {
            return character;
        }

        throw new Exception("Character does not exist!");
    }

    public async Task<List<Character>> AddCharacter(Character character)
    {
        _characters.Add(character);
        return _characters;
    }
}