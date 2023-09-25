using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

public class ServiceTestsSetup : IDesignTimeDbContextFactory<DatabaseContext>, IDesignTimeServices
{
    public ServiceTestsSetup()
    {
        using DbContext context = CreateDbContext(Array.Empty<string>());
        context.Database.Migrate();
    }

    public virtual void ConfigureDesignTimeServices(IServiceCollection services)
    {
        services.AddEntityFrameworkNpgsql();
        new EntityFrameworkRelationalDesignServicesBuilder(services).TryAddCoreServices();
    }

    public virtual DatabaseContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<DatabaseContext> builder = new DbContextOptionsBuilder<DatabaseContext>();
        builder.UseNpgsql(new GetConnectionStringCommand().Execute());
        return new DatabaseContext(builder.Options);
    }
}