using VideoGameCharacter.Application.Dtos;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace VideoGameCharacter.UI.Services;

/// <summary>
/// API client for managing video game character data.
/// </summary>
public class CharacterApiClient(HttpClient httpClient, ILocalStorageService localStorage)
{
    /// <summary>
    /// Adds the authentication token from LocalStorage to the request headers.
    /// </summary>
    private async Task AddAuthorizationHeader()
    {
        try
        {
            var token = await localStorage.GetItemAsync<string>("authToken");
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
        catch (InvalidOperationException)
        {
            // Fallback for unexpected static rendering
        }
    }

    /// <summary>
    /// Retrieves all characters from the API.
    /// </summary>
    public async Task<List<CharacterResponse>> GetAllCharactersAsync()
    {
        await AddAuthorizationHeader();
        return await httpClient.GetFromJsonAsync<List<CharacterResponse>>("api/VideoGameCharacters") ?? [];
    }

    public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
    {
        await AddAuthorizationHeader();
        return await httpClient.GetFromJsonAsync<CharacterResponse>($"api/VideoGameCharacters/{id}");
    }

    public async Task AddCharacterAsync(CreateCharacterRequest character)
    {
        await AddAuthorizationHeader();
        await httpClient.PostAsJsonAsync("api/VideoGameCharacters", character);
    }

    public async Task UpdateCharacterAsync(int id, UpdateCharacterRequest character)
    {
        await AddAuthorizationHeader();
        await httpClient.PutAsJsonAsync($"api/VideoGameCharacters/{id}", character);
    }

    public async Task DeleteCharacterAsync(int id)
    {
        await AddAuthorizationHeader();
        await httpClient.DeleteAsync($"api/VideoGameCharacters/{id}");
    }
}
