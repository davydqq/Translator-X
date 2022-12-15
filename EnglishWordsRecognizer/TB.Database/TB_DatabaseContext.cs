using Microsoft.EntityFrameworkCore;
using TB.Database.Entities;

namespace TB.Database;

public class TB_DatabaseContext : DbContext
{
    public TB_DatabaseContext(DbContextOptions<TB_DatabaseContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    public DbSet<TelegramUser> Users { get; set; }
}
