namespace Dotnet_RPG.Services.CharacterService;

public interface ICharacterService
{
    List<Character> GetAllCharacters();
    Character GetCharacterById(int id);
    List<Character> AddCharacter(Character character);
}