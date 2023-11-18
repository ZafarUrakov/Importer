using Importer.Models;
using Importer.Services.Foundations.Clients;
using Importer.Services.Foundations.Spreadsheets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Importer.Services.Orchestrations
{
    public class OrchestrationService : IOrchestrationService
    {
        private readonly ISpreadsheetService spreadsheetService;
        private readonly IClientService clientService;

        public OrchestrationService(
            ISpreadsheetService spreadsheetService, 
            IClientService clientService)
        {
            this.spreadsheetService = spreadsheetService;
            this.clientService = clientService;
        }

        public async ValueTask<List<Client>> ProcessImportRequest(MemoryStream memoryStream)
        {
            List<Client> clients = new List<Client>();

            List<ExternalClient> externalClients = 
                this.spreadsheetService.GetExternalClients(memoryStream);

            foreach(ExternalClient externalClient in externalClients)
            {
                Client client = MapToClient(externalClient);

                clients.Add(client);

                await this.clientService.AddClientAsync(client);
            }

            return clients;
        }

        private Client MapToClient(ExternalClient externalClient)
        {
            return new Client
            {
                Id = externalClient.Id,
                Name = externalClient.Name,
                Age = externalClient.Age,
                GroupName = externalClient.GroupName
            };
        }
    }
}
