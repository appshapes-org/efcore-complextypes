using Microsoft.EntityFrameworkCore;

namespace Database;

public class DbContextBase : DbContext
{
    public DbContextBase(DbContextOptions options) : base(options)
    {
    }

    protected DbContextBase()
    {
    }
}