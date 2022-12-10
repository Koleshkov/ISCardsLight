using ISCardsLight.Models;
using Microsoft.JSInterop;
using OfficeOpenXml;

namespace ISCardsLight.Services.PassengerCardServices
{
    public class PassengerCardService : IPassengerCardService
    {
        private readonly HttpClient client;

        private readonly IJSRuntime JS;

        public PassengerCardService(IJSRuntime jS, HttpClient client)
        {
            JS=jS;
            this.client=client;
        }


        public async Task<bool> SendPassagnerCardAsync(PassengerCard passengerCard)
        {
            try
            {

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage package = new(await client.GetStreamAsync("templates/PassengerCard.xlsx")))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    byte[] buffer;

                    worksheet.Cells["P14"].Value = passengerCard.NameOfOrganization;
                    worksheet.Cells["P17"].Value = passengerCard.NumberOfAuto;

                    worksheet.Cells["F20"].Value=passengerCard.TypeOfAuto=="0" ? "V" : "";
                    worksheet.Cells["F22"].Value=passengerCard.TypeOfAuto=="1" ? "V" : "";
                    worksheet.Cells["S20"].Value=passengerCard.TypeOfAuto=="2" ? "V" : "";
                    worksheet.Cells["s22"].Value=passengerCard.TypeOfAuto=="3" ? "V" : "";


                    if (passengerCard.EmergencyKit) worksheet.Cells["AB30"].Value="V";
                    else worksheet.Cells["AE30"].Value="V";

                    if (passengerCard.MonitoringSystem) worksheet.Cells["AB32"].Value="V";
                    else worksheet.Cells["AE32"].Value="V";

                    if (passengerCard.ForeignObjects) worksheet.Cells["AB34"].Value="V";
                    else worksheet.Cells["AE34"].Value="V";

                    if (passengerCard.RoutePassport) worksheet.Cells["AB36"].Value="V";
                    else worksheet.Cells["AE36"].Value="V";

                    if (passengerCard.BusPassport) worksheet.Cells["AB38"].Value="V";
                    else worksheet.Cells["AE38"].Value="V";

                    if (passengerCard.SeatBeltsFastened) worksheet.Cells["AB40"].Value="V";
                    else worksheet.Cells["AE40"].Value="V";

                    if (passengerCard.CargoFixed) worksheet.Cells["AB42"].Value="V";
                    else worksheet.Cells["AE42"].Value="V";

                    if (passengerCard.SafeLaneChange) worksheet.Cells["AB47"].Value="V";
                    else worksheet.Cells["AE47"].Value="V";

                    if (passengerCard.KeepingDistance) worksheet.Cells["AB49"].Value="V";
                    else worksheet.Cells["AE49"].Value="V";

                    if (passengerCard.SpeedLimit) worksheet.Cells["AB51"].Value="V";
                    else worksheet.Cells["AE51"].Value="V";

                    if (passengerCard.SafeBehavior) worksheet.Cells["AB53"].Value="V";
                    else worksheet.Cells["AE53"].Value="V";

                    if (passengerCard.NoCell) worksheet.Cells["AB55"].Value="V";
                    else worksheet.Cells["AE55"].Value="V";

                    if (passengerCard.ControlOfAuto) worksheet.Cells["AB57"].Value="V";
                    else worksheet.Cells["AE57"].Value="V";

                    if (passengerCard.NotEat) worksheet.Cells["AB59"].Value="V";
                    else worksheet.Cells["AE59"].Value="V";

                    if (passengerCard.UnderstandsRoadConditions) worksheet.Cells["AB61"].Value="V";
                    else worksheet.Cells["AE61"].Value="V";

                    if (passengerCard.RoadSignRequirements) worksheet.Cells["AB63"].Value="V";
                    else worksheet.Cells["AE63"].Value="V";

                    if (passengerCard.TimelyTurnOffTheLights) worksheet.Cells["AB65"].Value="V";
                    else worksheet.Cells["AE65"].Value="V";

                    if (passengerCard.AttentionToPedestrians) worksheet.Cells["AB67"].Value="V";
                    else worksheet.Cells["AE67"].Value="V";

                    if (passengerCard.GiveWay) worksheet.Cells["AB70"].Value="V";
                    else worksheet.Cells["AE70"].Value="V";

                    if (passengerCard.AutoSafelyInReverse) worksheet.Cells["AB72"].Value="V";
                    else worksheet.Cells["AE72"].Value="V";

                    if (passengerCard.HandbrakeUsing) worksheet.Cells["AB74"].Value="V";
                    else worksheet.Cells["AE74"].Value="V";

                    if (passengerCard.RestRegime) worksheet.Cells["AB76"].Value="V";
                    else worksheet.Cells["AE76"].Value="V";

                    if (passengerCard.WorkStopped) worksheet.Cells["BG6"].Value="V";
                    else worksheet.Cells["BG6"].Value="";

                    worksheet.Cells["E81"].Value = passengerCard.Clear ? "V" : "";
                    worksheet.Cells["E83"].Value = passengerCard.Snow ? "V" : "";
                    worksheet.Cells["E85"].Value = passengerCard.Cloud ? "V" : "";
                    worksheet.Cells["E87"].Value = passengerCard.RainHail ? "V" : "";
                    worksheet.Cells["E89"].Value = passengerCard.Sun ? "V" : "";
                    worksheet.Cells["L81"].Value = passengerCard.Night ? "V" : "";
                    worksheet.Cells["L85"].Value = passengerCard.Rain ? "V" : "";
                    worksheet.Cells["L87"].Value = passengerCard.Dirt ? "V" : "";

                    worksheet.Cells["S81"].Value = passengerCard.Asphalt ? "V" : "";
                    worksheet.Cells["S83"].Value = passengerCard.Ice ? "V" : "";
                    worksheet.Cells["S85"].Value = passengerCard.Gravel ? "V" : "";
                    worksheet.Cells["Z81"].Value = passengerCard.OffRoad ? "V" : "";
                    worksheet.Cells["Z83"].Value = passengerCard.Ground ? "V" : "";

                    worksheet.Cells["AL16"].Value = passengerCard.PassengerComment;
                    worksheet.Cells["AL36"].Value = passengerCard.Actions;
                    worksheet.Cells["AT69"].Value = passengerCard.Responsible;
                    worksheet.Cells["AV71"].Value = passengerCard.Deadline==null ? "" : ((DateTime)passengerCard.Deadline).ToShortDateString();

                    worksheet.Cells["AO77"].Value = passengerCard.FullName;
                    worksheet.Cells["AV81"].Value = passengerCard.CreationDate.ToShortDateString();



                    buffer = await package.GetAsByteArrayAsync();

                    await JS.InvokeVoidAsync(
                    "saveAsFile",
                    $"{passengerCard.CardName}.xlsx",
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
