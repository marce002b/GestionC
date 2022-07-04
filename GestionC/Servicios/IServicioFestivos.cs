using GestionC.Modelos;

namespace GestionC.Servicios
{
    public interface IServicioFestivos
    {
         Task<List<Festivos>?> BuscarDataFestivosAPIExterna(string codigopais);
    }
}