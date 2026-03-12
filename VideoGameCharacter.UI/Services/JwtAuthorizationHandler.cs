using System.Net.Http.Headers;
using Blazored.LocalStorage;

namespace VideoGameCharacter.UI.Services;

/// <summary>
/// A DelegatingHandler that automatically adds the JWT token from local storage to the Authorization header of outgoing requests.
/// </summary>
public class JwtAuthorizationHandler(ILocalStorageService localStorage) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            var token = await localStorage.GetItemAsync<string>("authToken", cancellationToken);
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
        catch (InvalidOperationException)
        {
            // Prerendering phase - JS Interop not available.
            // In Blazor Server, we just continue; the request will be unauthorized if required by the API.
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
