using VideoGameCharacter.Application.Dtos;
using VideoGameCharacter.Application.Interfaces;
using VideoGameCharacter.Domain.Entities;
using VideoGameCharacter.Domain.Interfaces;

namespace VideoGameCharacter.Application.Services;

public class VideoGameCharacterService(IVideoGameCharacterRepository repository) : IVideoGameCharacterService
{
    public async Task<CharacterResponse> AddCharacterAsync(CreateCharacterRequest character)
    {
        var newCharacter = new Character
        {
            Name = character.Name,
            Game = character.Game,
            Role = character.Role
        };

        var created = await repository.AddCharacterAsync(newCharacter);

        return new CharacterResponse
        {
            Id = created.Id,
            Name = created.Name,
            Game = created.Game,
            Role = created.Role
        };
    }

    public async Task<bool> DeleteCharacterAsync(int id)
    {
        return await repository.DeleteCharacterAsync(id);
    }

    public async Task<List<CharacterResponse>> GetAllCharactersAsync()
    {
        var characters = await repository.GetAllCharactersAsync();
        return characters.Select(c => new CharacterResponse
        {
            Id = c.Id,
            Name = c.Name,
            Game = c.Game,
            Role = c.Role
        }).ToList();
    }

    public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
    {
        var character = await repository.GetCharacterByIdAsync(id);
        if (character == null) return null;

        return new CharacterResponse
        {
            Id = character.Id,
            Name = character.Name,
            Game = character.Game,
            Role = character.Role
        };
    }

    public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character)
    {
        var characterToUpdate = new Character
        {
            Id = id,
            Name = character.Name,
            Game = character.Game,
            Role = character.Role
        };

        return await repository.UpdateCharacterAsync(characterToUpdate);
    }
}
