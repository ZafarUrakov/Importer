using Importer.Models;
using System.Collections.Generic;
using System.IO;

namespace Importer.Services.Foundations.Spreadsheets
{
    public interface ISpreadsheetService
    {
        List<ExternalClient> GetExternalClients(MemoryStream memoryStream);
    }
}
