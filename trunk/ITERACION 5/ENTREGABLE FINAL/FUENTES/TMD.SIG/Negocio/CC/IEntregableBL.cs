using System;
namespace Negocio.CC
{
    public interface IEntregableBL
    {
        void insertar(Entidades.CC.EntregableE entegable, int idContrato);
        void LLenarDrop(ref System.Web.UI.WebControls.DropDownList lista);
        System.Collections.Generic.List<Entidades.CC.EntregableE> ObteneEntregables();
    }
}
