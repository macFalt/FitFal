using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
    
namespace FitFalMVC.Infrastructure;

public class MyDbContextFactory : IDesignTimeDbContextFactory<Context>
{

    Context IDesignTimeDbContextFactory<Context>.CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()

                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../FitFal"))
                .AddJsonFile("appsettings.json")
                .Build();

        var builder = new DbContextOptionsBuilder<Context>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseSqlServer(connectionString);

        return new Context(builder.Options);
    }


}

