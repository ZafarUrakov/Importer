using EFxceptions;
using Importer.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Importer.Brokers.Storages
{
    public class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        public DbSet<Client> Clients { get; set; }

        public StorageBroker() => this.Database.EnsureCreated();


        public async ValueTask<Client> InsertClientAsync(Client client)
        {
            await this.Clients.AddAsync(client);
            await this.SaveChangesAsync();

            return client;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data source=Improter.db";
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
