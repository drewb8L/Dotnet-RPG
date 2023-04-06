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

    public Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(Character character)
    {
        throw new NotImplementedException();
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
}