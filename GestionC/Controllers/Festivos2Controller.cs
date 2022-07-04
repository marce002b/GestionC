using GestionC.Modelos;
using GestionC.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Festivos2Controller : ControllerBase
    {
        //viejo uso sin inyeccion dependencia, pues Festivos2Controller depende directamente de ServicioFestivos
        //private readonly ServicioFestivos _servicioFestivos = new ServicioFestivos();

        //Con inyeccion de dependencias: patron q permite registrar clases en un container que inyectara las dependencias y no ServicioFestivos

        private readonly IServicioFestivos _servicioFestivos;

        //creamos un constructor con una dependencia de la I
        public Festivos2Controller(IServicioFestivos servicioFestivos)
        {
            this._servicioFestivos = servicioFestivos;
        }

        [HttpGet("{pais}")]
        public async Task<ActionResult<IEnumerable<Festivos>>> DevolverFestivos2(string pais)

        {
            bool permitidos = new string[] { "AR", "CO", "CL" }.Any(s => pais.Contains(s));
            if (!permitidos)
            {
                return Unauthorized();
            }
            return await _servicioFestivos.BuscarDataFestivosAPIExterna(pais);

        }
    }
}

