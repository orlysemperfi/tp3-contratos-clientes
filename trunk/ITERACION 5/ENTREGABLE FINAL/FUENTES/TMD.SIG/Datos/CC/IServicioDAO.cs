using System;
namespace Datos.CC
{
    public interface IServicioDAO
    {
        System.Collections.Generic.List<Entidades.CC.ServicioE> GetServicios();
        System.Collections.Generic.List<Entidades.CC.ServicioE> ObtenerServicios();
    }
}
