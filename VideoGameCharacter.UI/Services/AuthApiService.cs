using System.Net.Http.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using VideoGameCharacter.Application.Dtos.Auth;

namespace VideoGameCharacter.UI.Services;

/// <summary>
/// Service for interacting with the Authentication API.
/// </summary>
public class AuthApiService(
    HttpClient httpClient,
    ILocalStorageService localStorage,
    AuthenticationStateProvider authStateProvider,
    TokenService tokenService)
{
    /// <summary>
    /// Registers a new user.
    /// </summary>
    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("api/auth/register", request);
        return await response.Content.ReadFromJsonAsync<AuthResponse>() ?? new AuthResponse { IsSuccess = false, Message = "Unknown error" };
    }

    /// <summary>
    /// Logs in an existing user and stores the authentication token.
    /// </summary>
    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("api/auth/login", request);
        var result = await response.Content.ReadFromJsonAsync<AuthResponse>() ?? new AuthResponse { IsSuccess = false, Message = "Unknown error" };

        if (result.IsSuccess && !string.IsNullOrEmpty(result.Token))
        {
            await localStorage.SetItemAsync("authToken", result.Token);

            tokenService.Token = result.Token; // ⭐ important

            ((CustomAuthenticationStateProvider)authStateProvider)
                .MarkUserAsAuthenticated(result.Token);
        }

        return result;
    }

    public async Task LogoutAsync()
    {
        await localStorage.RemoveItemAsync("authToken");

        tokenService.Token = null;

        ((CustomAuthenticationStateProvider)authStateProvider)
            .MarkUserAsLoggedOut();
    }
}
