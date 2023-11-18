using Importer.Brokers.Spreadsheets;
using Importer.Models;
using System.Collections.Generic;
using System.IO;

namespace Importer.Services.Foundations.Spreadsheets
{
    public class SpreadsheetService : ISpreadsheetService
    {
        private readonly ISpreadsheetBroker spreadsheetBroker;

        public SpreadsheetService(ISpreadsheetBroker spreadsheetBroker)
        {
            this.spreadsheetBroker = spreadsheetBroker;
        }

        public List<ExternalClient> GetExternalClients(MemoryStream memoryStream)
        {
            List<ExternalClient> externalClients = this.spreadsheetBroker.ImportClients(memoryStream);

            return externalClients;
        }
    }
}
