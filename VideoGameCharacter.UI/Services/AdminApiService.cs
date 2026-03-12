using System.Net.Http.Json;
using VideoGameCharacter.Application.Dtos.Admin;

namespace VideoGameCharacter.UI.Services;

public class AdminApiService(HttpClient httpClient)
{
    public async Task<List<UserDto>> GetUsersAsync()
    {
        return await httpClient.GetFromJsonAsync<List<UserDto>>("api/admin/users") ?? new List<UserDto>();
    }

    public async Task<bool> CreateUserAsync(AdminCreateUserRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("api/admin/create-user", request);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> SetUserRoleAsync(UpdateRoleRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("api/admin/set-role", request);
        return response.IsSuccessStatusCode;
    }

    public async Task<List<string>> GetRolesAsync()
    {
        return await httpClient.GetFromJsonAsync<List<string>>("api/admin/roles") ?? new List<string>();
    }
}
