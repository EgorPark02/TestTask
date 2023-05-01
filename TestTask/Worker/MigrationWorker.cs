using Microsoft.EntityFrameworkCore;

namespace TestTask.Worker;

public class MigrationWorker : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public MigrationWorker(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            await context.Database.EnsureCreatedAsync(cancellationToken);
            await context.Database.MigrateAsync(cancellationToken);
            Console.WriteLine("Migrations successfully applied ");
        }
        catch (Exception e)
        {
            Console.WriteLine("Database migration had been failed");
            throw new Exception(e.Message);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}