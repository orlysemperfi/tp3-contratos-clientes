using System;
namespace Negocio.CC
{
    public interface IIndicadorBL
    {
        void insertar(Entidades.CC.IndicadorE indicador, int idContrato);
        void LLenarDrop(ref System.Web.UI.WebControls.DropDownList lista);
        System.Collections.Generic.List<Entidades.CC.IndicadorE> ObteneIndicadores();
    }
}
