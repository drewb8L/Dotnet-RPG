using AutoMapper;
using Dotnet_RPG.DTO.Character;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Dotnet_RPG.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private readonly IMapper _mapper;

    public CharacterService(IMapper mapper)
    {
        _mapper = mapper;
    }

    private static List<Character> _characters = new()
    {
        new Character(),
        new Character { Id = 1, Name = "Sam" }
    };

    public async Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters()
    {
        var res = new ServiceResponse<List<GetCharacterResponseDto>>
        {
            // Object initializer version
            Data = _characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList()
        };

        return res;
    }

    public async Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id)
    {
        var res = new ServiceResponse<GetCharacterResponseDto>();
        var character = _characters.FirstOrDefault(c => c.Id == id);

        res.Data = _mapper.Map<GetCharacterResponseDto>(character);
        return res;
    }


    public async Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterDto character)
    {
        var newCharacter = _mapper.Map<Character>(character);
        newCharacter.Id = _characters.Max(c => c.Id) + 1;
        _characters.Add(newCharacter);
        var res = new ServiceResponse<List<GetCharacterResponseDto>>();
        res.Data = _characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();
        return res;
    }

    public async Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterDTO updatedCharacter)
    {
        var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();
        try
        {
            var character = _characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
            if (character is null)
            {
                throw new Exception($"Character with '{updatedCharacter.Id} is not found.");
            }

            character.Name = updatedCharacter.Name;
            character.HiPoints = updatedCharacter.HiPoints;
            character.Defense = updatedCharacter.Defense;
            character.Strength = updatedCharacter.Strength;
            character.Intelligence = updatedCharacter.Intelligence;
            character.Class = updatedCharacter.Class;

            serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(character);
            serviceResponse.Message = "Updated successfully";
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterResponseDto>>> DeleteCharacter(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
        try
        {
            var character = _characters.FirstOrDefault(c => c.Id == id);
            if (character is null)
            {
                throw new Exception($"Character with id: {id} is not found.");
            }
            _characters.Remove(character);
            serviceResponse.Data = _characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }

        return serviceResponse;
    }
}