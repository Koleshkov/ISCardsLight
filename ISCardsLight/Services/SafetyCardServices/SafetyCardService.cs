using ISCardsLight.Models;
using Microsoft.JSInterop;
using OfficeOpenXml;

namespace ISCardsLight.Services.SafetyCardServices
{
    public class SafetyCardService : ISafetyCardService
    {
        private readonly HttpClient client;

        private readonly IJSRuntime js;

        public SafetyCardService(HttpClient client, IJSRuntime js)
        {
            this.client=client;
            this.js=js;
        }

        public async Task<bool> CreateSafetyCardAsync(SafetyCard safetyCard)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage package = new(await client.GetStreamAsync("templates/SafetyCard.xlsx")))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    byte[] buffer;

                    worksheet.Cells["B9"].Value = safetyCard.CreationDate.ToShortDateString();
                    worksheet.Cells["C9"].Value = safetyCard.FullName;
                    worksheet.Cells["D9"].Value = safetyCard.Position;
                    worksheet.Cells["E9"].Value = safetyCard.Phone;
                    worksheet.Cells["F9"].Value = safetyCard.Email;
                    worksheet.Cells["G9"].Value = safetyCard.Organization;
                    worksheet.Cells["H9"].Value = safetyCard.Department;
                    worksheet.Cells["I9"].Value = safetyCard.JobObject;
                    worksheet.Cells["J9"].Value = safetyCard.TypeOfAction=="0" ? "Опасное условие" : "Опасное действие";
                    worksheet.Cells["K9"].Value = safetyCard.Description;
                    worksheet.Cells["L9"].Value = safetyCard.Actions;
                    worksheet.Cells["M9"].Value = safetyCard.Reasons;
                    worksheet.Cells["N9"].Value = safetyCard.PlannedEvents;
                    worksheet.Cells["O9"].Value = safetyCard.Deadline==null ? "" : ((DateTime)safetyCard.Deadline).ToShortDateString();
                    worksheet.Cells["P9"].Value = safetyCard.Responsible;
                    worksheet.Cells["Q9"].Value = safetyCard.Status=="0" ? "Не выполнено" : "Выполнено";

                    buffer = await package.GetAsByteArrayAsync();

                    await js.InvokeVoidAsync(
                    "save AsFile",
                    $"{safetyCard.CardName}.xlsx",
                    Convert.ToBase64String(buffer)
                    );
                }
                return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }
    }
}
