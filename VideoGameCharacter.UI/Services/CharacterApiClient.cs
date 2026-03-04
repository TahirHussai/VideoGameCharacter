using VideoGameCharacter.Application.Dtos;
using System.Net.Http.Json;

namespace VideoGameCharacter.UI.Services;

public class CharacterApiClient(HttpClient httpClient)
{
    public async Task<List<CharacterResponse>> GetAllCharactersAsync()
    {
        return await httpClient.GetFromJsonAsync<List<CharacterResponse>>("api/VideoGameCharacters") ?? [];
    }

    public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
    {
        return await httpClient.GetFromJsonAsync<CharacterResponse>($"api/VideoGameCharacters/{id}");
    }

    public async Task AddCharacterAsync(CreateCharacterRequest character)
    {
        await httpClient.PostAsJsonAsync("api/VideoGameCharacters", character);
    }

    public async Task UpdateCharacterAsync(int id, UpdateCharacterRequest character)
    {
        await httpClient.PutAsJsonAsync($"api/VideoGameCharacters/{id}", character);
    }

    public async Task DeleteCharacterAsync(int id)
    {
        await httpClient.DeleteAsync($"api/VideoGameCharacters/{id}");
    }
}
