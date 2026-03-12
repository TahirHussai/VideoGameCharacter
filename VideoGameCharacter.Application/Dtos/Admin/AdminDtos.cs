using System.ComponentModel.DataAnnotations;

namespace VideoGameCharacter.Application.Dtos.Admin;

public class AdminCreateUserRequest
{
    [Required]
    public required string Username { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [MinLength(6)]
    public required string Password { get; set; }

    [Required]
    public required string Role { get; set; }
}

public class UserDto
{
    public required string Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required List<string> Roles { get; set; }
}

public class UpdateRoleRequest
{
    [Required]
    public required string UserId { get; set; }
    [Required]
    public required string Role { get; set; }
}
