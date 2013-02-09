using System;
namespace Negocio.CC
{
    public interface IMonedaBL
    {
        void LLenarDrop(ref System.Web.UI.WebControls.DropDownList lista);
        System.Collections.Generic.List<Entidades.CC.MonedaE> ObtenerMonedas();
    }
}
