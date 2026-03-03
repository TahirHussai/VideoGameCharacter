using Microsoft.EntityFrameworkCore;
using VideoGameCharacter.Domain.Entities;
using VideoGameCharacter.Domain.Interfaces;
using VideoGameCharacter.Infrastructure.Data;

namespace VideoGameCharacter.Infrastructure.Repositories;

public class VideoGameCharacterRepository(AppDbContext context) : IVideoGameCharacterRepository
{
    public async Task<List<Character>> GetAllCharactersAsync()
    {
        return await context.Characters.ToListAsync();
    }

    public async Task<Character?> GetCharacterByIdAsync(int id)
    {
        return await context.Characters.FindAsync(id);
    }

    public async Task<Character> AddCharacterAsync(Character character)
    {
        context.Characters.Add(character);
        await context.SaveChangesAsync();
        return character;
    }

    public async Task<bool> UpdateCharacterAsync(Character character)
    {
        var existing = await context.Characters.FindAsync(character.Id);
        if (existing == null) return false;

        existing.Name = character.Name;
        existing.Game = character.Game;
        existing.Role = character.Role;

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteCharacterAsync(int id)
    {
        var character = await context.Characters.FindAsync(id);
        if (character == null) return false;

        context.Characters.Remove(character);
        await context.SaveChangesAsync();
        return true;
    }
}
