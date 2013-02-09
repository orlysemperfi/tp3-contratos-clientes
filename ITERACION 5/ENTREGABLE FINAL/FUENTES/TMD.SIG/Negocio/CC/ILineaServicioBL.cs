using System;
namespace Negocio.CC
{
    public interface ILineaServicioBL
    {
        void LLenarDrop(ref System.Web.UI.WebControls.DropDownList lista);
        System.Collections.Generic.List<Entidades.CC.LineaServicioE> ObtenerLineaServicios();
    }
}
