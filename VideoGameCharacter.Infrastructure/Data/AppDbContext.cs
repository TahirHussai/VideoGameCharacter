using Microsoft.EntityFrameworkCore;
using VideoGameCharacter.Domain.Entities;

namespace VideoGameCharacter.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Character> Characters => Set<Character>();
}
