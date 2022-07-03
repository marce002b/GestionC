using GestionC;
using System.Net;

namespace GestionC.Controllers;

public static class FestivosEndpointsClass 
{


    public static void MapFestivosEndpoints(this IEndpointRouteBuilder routes)
    {

        routes.MapGet("Festivos", async (IHttpClientFactory httpClientFactory, string pais) =>
        {
            bool permitidos = new string[] { "AR", "CO", "CL" }.Any(s => pais.Contains(s));
            if (permitidos)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://date.nager.at/api/v3/PublicHolidays/2022/" + pais);
                var httpClient = httpClientFactory.CreateClient();
                var response = await httpClient.SendAsync(request);
                return await response.Content.ReadFromJsonAsync<List<Festivos>>();
            }
            throw new Exception("Unauthorized access");
          
        });



    }
}
