using Importer.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Importer.Services.Orchestrations
{
    public interface IOrchestrationService
    {
        ValueTask<List<Client>> ProcessImportRequest(MemoryStream memoryStream);
    }
}
