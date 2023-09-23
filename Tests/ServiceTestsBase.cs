using Database;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests;

[Collection("Service")]
[Trait("Category", "Service")]
public abstract class ServiceTestsBase : IDisposable
{
    private DatabaseContext _context;

    protected ServiceTestsBase()
    {
        DbContextOptionsBuilder<DatabaseContext> builder = new DbContextOptionsBuilder<DatabaseContext>()
            .UseNpgsql(new GetConnectionStringCommand().Execute());
        _context = new DatabaseContext(builder.Options);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    protected virtual DatabaseContext GetContext()
    {
        return _context;
    }
}