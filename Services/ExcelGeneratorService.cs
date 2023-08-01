using OfficeOpenXml;
using System.Collections.Generic;
using TestDotNetApp.Domain.Models;
using System.IO;

namespace TestDotNetApp.Services
{
    public class ExcelGeneratorService
    {
        public byte[] ExportUsersToExcel(List<User> users)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Users");

                    // Set the column headers
                    worksheet.Cells[1, 1].Value = "User ID";
                    worksheet.Cells[1, 2].Value = "Name";
                    worksheet.Cells[1, 3].Value = "Email";
                    worksheet.Cells[1, 4].Value = "Photo Url";

                    // Populate the data rows
                    int row = 2;
                    foreach (var user in users)
                    {
                        worksheet.Cells[row, 1].Value = user.Id;
                        worksheet.Cells[row, 2].Value = user.Name;
                        worksheet.Cells[row, 3].Value = user.Email;
                        worksheet.Cells[row, 4].Value = user.Photo;
                        row++;
                    }

                    worksheet.Cells.AutoFitColumns();

                    return package.GetAsByteArray();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
