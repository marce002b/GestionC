using GestionC.Modelos;
using Newtonsoft.Json;

namespace GestionC.Servicios
{
    public class ServicioFestivos : IServicioFestivos
    {
        public async Task<List<Festivos>?> BuscarDataFestivosAPIExterna(string codigopais)
        {
            //Console.WriteLine($"El mensaje es: {message}"); 
            var url = $"https://date.nager.at/api/v3/PublicHolidays/2022/{codigopais}";
            using (var http = new HttpClient())
            {
                var response = await http.GetStringAsync(url);
                return JsonConvert.DeserializeObject<List<Festivos>>(response);   

               
            }
        }
    }

}
  