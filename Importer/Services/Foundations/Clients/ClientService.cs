using Importer.Brokers.Storages;
using Importer.Models;
using System.Threading.Tasks;

namespace Importer.Services.Foundations.Clients
{
    public class ClientService : IClientService
    {
        private readonly IStorageBroker storageBroker;

        public ClientService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<Client> AddClientAsync(Client client) =>
            await this.storageBroker.InsertClientAsync(client);
    }
}
