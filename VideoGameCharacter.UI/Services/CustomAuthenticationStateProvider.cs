using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace VideoGameCharacter.UI.Services;

/// <summary>
/// Provides a custom authentication state based on specialized logic, such as retrieving a JWT token from LocalStorage.
/// </summary>
public class CustomAuthenticationStateProvider(
    ILocalStorageService localStorage,
    HttpClient httpClient,
    TokenService tokenService) : AuthenticationStateProvider
{
    /// <summary>
    /// Retrieves the current authentication state of the user.
    /// </summary>
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await localStorage.GetItemAsync<string>("authToken");

        if (string.IsNullOrWhiteSpace(token))
        {
            return new AuthenticationState(
                new ClaimsPrincipal(new ClaimsIdentity()));
        }

        // ⭐ IMPORTANT
        tokenService.Token = token;

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        return new AuthenticationState(
            new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));
    }

    /// <summary>
    /// Notifies the application that the user has successfully authenticated.
    /// </summary>
    /// <param name="token">The JWT token received from the API.</param>
    public void MarkUserAsAuthenticated(string token)
    {
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"));
        var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
        NotifyAuthenticationStateChanged(authState);
    }

    /// <summary>
    /// Notifies the application that the user has logged out.
    /// </summary>
    public void MarkUserAsLoggedOut()
    {
        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        var authState = Task.FromResult(new AuthenticationState(anonymousUser));
        NotifyAuthenticationStateChanged(authState);
    }

    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        var claims = new List<Claim>();

        foreach (var kvp in keyValuePairs!)
        {
            var claimType = kvp.Key switch
            {
                "sub" => ClaimTypes.NameIdentifier,
                "unique_name" => ClaimTypes.Name,
                "role" => ClaimTypes.Role,
                _ => kvp.Key
            };

            if (kvp.Value is JsonElement element && element.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in element.EnumerateArray())
                {
                    claims.Add(new Claim(claimType, item.ToString()));
                }
            }
            else
            {
                claims.Add(new Claim(claimType, kvp.Value.ToString()!));
            }
        }

        return claims;
    }

    private byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}
