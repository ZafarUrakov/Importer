using Importer.Models;
using System.Collections.Generic;
using System.IO;

namespace Importer.Brokers.Spreadsheets
{
    public interface ISpreadsheetBroker
    {
        List<ExternalClient> ImportClients(MemoryStream memoryStream);
    }
}
