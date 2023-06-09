using Dotnet_RPG.DTO.Character;

namespace Dotnet_RPG.Services.CharacterService;

public interface ICharacterService
{
   Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters();
    Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id);
    Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterDto character);
    Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterDTO updatedCharacter);

    Task<ServiceResponse<List<GetCharacterResponseDto>>> DeleteCharacter(int id);
}