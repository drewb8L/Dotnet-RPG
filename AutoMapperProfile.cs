using AutoMapper;
using Dotnet_RPG.DTO.Character;

namespace Dotnet_RPG;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Character, GetCharacterResponseDto>();
        CreateMap<AddCharacterDto, Character>();
    }
}