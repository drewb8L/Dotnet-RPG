namespace Dotnet_RPG.DTO.Character;

public class AddCharacterDto
{
    public string Name { get; set; } = "Frodo";
    public int HiPoints { get; set; } = 100;
    public int Strength { get; set; } = 10;
    public int Defense { get; set; } = 10;
    public int Intelligence { get; set; } = 10;

    public RpgClass Class { get; set; } = RpgClass.Paladin;
}