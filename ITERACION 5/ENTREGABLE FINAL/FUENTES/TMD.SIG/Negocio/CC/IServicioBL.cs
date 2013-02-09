using System;
namespace Negocio.CC
{
    public interface IServicioBL
    {
        System.Collections.Generic.List<Entidades.CC.ServicioE> GetServicios();
        void LLenarDrop(ref System.Web.UI.WebControls.DropDownList lista);
        System.Collections.Generic.List<Entidades.CC.ServicioE> ObtenerServicios();
    }
}
