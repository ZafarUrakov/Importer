using Importer.Models;
using System.Threading.Tasks;

namespace Importer.Services.Foundations.Clients
{
    public interface IClientService
    {
        ValueTask<Client> AddClientAsync(Client client);
    }
}
