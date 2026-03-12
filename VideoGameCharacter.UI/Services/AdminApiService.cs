using Blazored.LocalStorage;
using System.Net.Http.Json;
using VideoGameCharacter.Application.Dtos.Admin;

namespace VideoGameCharacter.UI.Services;

public class AdminApiService(HttpClient httpClient, ILocalStorageService localStorageService) : BaseApiService(httpClient,  localStorageService)
{
    public async Task<ApiResponse<List<UserDto>>> GetUsersAsync()
    {
        return await GetAsync<List<UserDto>>("api/admin/users");
    }

    public async Task<ApiResponse<bool>> CreateUserAsync(AdminCreateUserRequest request)
    {
        return await PostAsync("api/admin/create-user", request);
    }

    public async Task<ApiResponse<bool>> SetUserRoleAsync(UpdateRoleRequest request)
    {
        return await PostAsync("api/admin/set-role", request);
    }

    public async Task<ApiResponse<List<string>>> GetRolesAsync()
    {
        return await GetAsync<List<string>>("api/admin/roles");
    }
}
