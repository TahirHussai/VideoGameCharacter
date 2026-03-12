using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace VideoGameCharacter.UI.Services;

public abstract class BaseApiService(HttpClient httpClient, ILocalStorageService localStorageService)
{
    protected async Task<ApiResponse<T>> GetAsync<T>(string url)
    {
        try
        {
            httpClient.DefaultRequestHeaders.Authorization =
              new AuthenticationHeaderValue("bearer", await GetBearerToken());
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<T>();
                return ApiResponse<T>.Success(data!);
            }
            
            var error = await response.Content.ReadAsStringAsync();
            return ApiResponse<T>.Failure(error ?? "Unknown error", (int)response.StatusCode);
        }
        catch (HttpRequestException ex)
        {
            return ApiResponse<T>.Failure(ex.Message, (int)(ex.StatusCode ?? System.Net.HttpStatusCode.InternalServerError));
        }
        catch (Exception ex)
        {
            return ApiResponse<T>.Failure(ex.Message, 500);
        }
    }

    protected async Task<ApiResponse<bool>> PostAsync<TRequest>(string url, TRequest request)
    {
        try
        {
            httpClient.DefaultRequestHeaders.Authorization =
              new AuthenticationHeaderValue("bearer", await GetBearerToken());
            var response = await httpClient.PostAsJsonAsync(url, request);
            if (response.IsSuccessStatusCode)
            {
                return ApiResponse<bool>.Success(true);
            }

            var error = await response.Content.ReadAsStringAsync();
            return ApiResponse<bool>.Failure(error ?? "Unknown error", (int)response.StatusCode);
        }
        catch (HttpRequestException ex)
        {
            return ApiResponse<bool>.Failure(ex.Message, (int)(ex.StatusCode ?? System.Net.HttpStatusCode.InternalServerError));
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.Failure(ex.Message, 500);
        }
    }

    protected async Task<ApiResponse<bool>> PutAsync<TRequest>(string url, TRequest request)
    {
        try
        {
            httpClient.DefaultRequestHeaders.Authorization =
              new AuthenticationHeaderValue("bearer", await GetBearerToken());
            var response = await httpClient.PutAsJsonAsync(url, request);
            if (response.IsSuccessStatusCode) return ApiResponse<bool>.Success(true);
            return ApiResponse<bool>.Failure(await response.Content.ReadAsStringAsync(), (int)response.StatusCode);
        }
        catch (Exception ex) { return ApiResponse<bool>.Failure(ex.Message, 500); }
    }

    protected async Task<ApiResponse<bool>> DeleteAsync(string url)
    {
        try
        {
            httpClient.DefaultRequestHeaders.Authorization =
              new AuthenticationHeaderValue("bearer", await GetBearerToken());
            var response = await httpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode) return ApiResponse<bool>.Success(true);
            return ApiResponse<bool>.Failure(await response.Content.ReadAsStringAsync(), (int)response.StatusCode);
        }
        catch (Exception ex) { return ApiResponse<bool>.Failure(ex.Message, 500); }
    }
    public async Task<string> GetBearerToken()
    {
        return await localStorageService.GetItemAsync<string>("authToken");
    }
}

//public class ApiErrorHandlingHandler : DelegatingHandler
//{
//    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//    {
//        var response = await base.SendAsync(request, cancellationToken);
//        // do not call NavigationManager here; return 401 to caller
//        return response;
//    }
//}
