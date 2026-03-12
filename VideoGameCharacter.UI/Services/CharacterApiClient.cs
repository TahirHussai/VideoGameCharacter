using VideoGameCharacter.Application.Dtos;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace VideoGameCharacter.UI.Services;

/// <summary>
/// API client for managing video game character data.
/// </summary>
public class CharacterApiClient(HttpClient httpClient, ILocalStorageService localStorageService) : BaseApiService(httpClient, localStorageService)
{
    /// <summary>
    /// Retrieves all characters from the API.
    /// </summary>
    public async Task<ApiResponse<List<CharacterResponse>>> GetAllCharactersAsync()
    {
        return await GetAsync<List<CharacterResponse>>("api/VideoGameCharacters");
    }

    public async Task<ApiResponse<CharacterResponse>> GetCharacterByIdAsync(int id)
    {
        return await GetAsync<CharacterResponse>($"api/VideoGameCharacters/{id}");
    }

    public async Task<ApiResponse<bool>> AddCharacterAsync(CreateCharacterRequest character)
    {
        return await PostAsync("api/VideoGameCharacters", character);
    }

    public async Task<ApiResponse<bool>> UpdateCharacterAsync(int id, UpdateCharacterRequest character)
    {
        return await PutAsync($"api/VideoGameCharacters/{id}", character);
    }

    public async Task<ApiResponse<bool>> DeleteCharacterAsync(int id)
    {
        return await DeleteAsync($"api/VideoGameCharacters/{id}");
    }
}
