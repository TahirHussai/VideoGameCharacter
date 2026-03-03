using VideoGameCharacter.Domain.Entities;

namespace VideoGameCharacter.Domain.Interfaces;

public interface IVideoGameCharacterRepository
{
    Task<List<Character>> GetAllCharactersAsync();
    Task<Character?> GetCharacterByIdAsync(int id);
    Task<Character> AddCharacterAsync(Character character);
    Task<bool> UpdateCharacterAsync(Character character);
    Task<bool> DeleteCharacterAsync(int id);
}
