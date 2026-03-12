using Microsoft.AspNetCore.Identity;
using System;

public class Program
{
    public static void Main()
    {
        var hasher = new PasswordHasher<IdentityUser>();
        var user = new IdentityUser { UserName = "admin@videogame.com" };
        var hash = hasher.HashPassword(user, "Admin123!");
        Console.WriteLine(hash);
    }
}
