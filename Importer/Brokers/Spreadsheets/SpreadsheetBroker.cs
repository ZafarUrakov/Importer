using Importer.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace Importer.Brokers.Spreadsheets
{
    public class SpreadsheetBroker : ISpreadsheetBroker
    {
        public List<ExternalClient> ImportClients(MemoryStream memoryStream)
        {
            List<ExternalClient> externalClients = new List<ExternalClient>();

            using(ExcelPackage package = new ExcelPackage(memoryStream)) 
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                ExcelWorksheet excelWorksheet = package.Workbook.Worksheets[0];

                for(int row = 2; row <= excelWorksheet.Dimension.End.Row; row++)
                {
                    ExternalClient externaClient = new ExternalClient();

                    externaClient.Id = Guid.NewGuid();
                    externaClient.Name = excelWorksheet.Cells[row, 1].Value?.ToString();
                    externaClient.Age = excelWorksheet.Cells[row, 2].Value?.ToString();
                    externaClient.GroupName = excelWorksheet.Cells[row, 3].Value?.ToString();

                    externalClients.Add(externaClient);
                }

                return externalClients;
            }
        }
    }
}
