using System.Text.Json.Serialization;

namespace Dotnet_RPG.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RpgClass
{
    Kinght = 1,
    Mage = 2,
    Paladin = 3
}