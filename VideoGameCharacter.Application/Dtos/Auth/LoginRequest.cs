using System.ComponentModel.DataAnnotations;

namespace VideoGameCharacter.Application.Dtos.Auth;

public class LoginRequest
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [MinLength(6)]
    public required string Password { get; set; }
}
