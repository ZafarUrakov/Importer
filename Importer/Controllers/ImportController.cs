using Importer.Models;
using Importer.Services.Orchestrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Importer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportController : Controller
    {
        private readonly IOrchestrationService orchestrationService;

        public ImportController(IOrchestrationService orchestrationService)
        {
            this.orchestrationService = orchestrationService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<List<Client>>> ImprotClientsAsync(IFormFile formFile)
        {
            using(MemoryStream memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);

                memoryStream.Position = 0;

                return Ok(await this.orchestrationService.ProcessImportRequest(memoryStream));
            }
        }
    }
}
