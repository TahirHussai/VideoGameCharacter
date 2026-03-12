using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace VideoGameCharacter.UI.Services;

public sealed class ApiErrorHandlingHandler : DelegatingHandler
{
    private readonly ILogger<ApiErrorHandlingHandler> _logger;
    public ApiErrorHandlingHandler(ILogger<ApiErrorHandlingHandler> logger) => _logger = logger;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            // Log and return the response. Do not perform UI navigation from message handlers in Blazor Server.
            _logger.LogWarning("API returned 401 Unauthorized for {Method} {Url}", request.Method, request.RequestUri);
        }

        return response;
    }
}
