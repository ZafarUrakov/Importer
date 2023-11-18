using Importer.Models;
using System.Threading.Tasks;

namespace Importer.Brokers.Storages
{
    public interface IStorageBroker
    {
        ValueTask<Client> InsertClientAsync(Client client);
    }
}
