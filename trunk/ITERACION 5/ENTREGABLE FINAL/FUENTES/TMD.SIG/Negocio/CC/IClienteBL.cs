using System;
namespace Negocio.CC
{
    public interface IClienteBL
    {
        void actualizar(Entidades.CC.ClienteE o);
        System.Collections.Generic.List<Entidades.CC.ClienteE> Cliente_Lista(string razon_social, string ruc);
        void insertar(Entidades.CC.ClienteE o);
        System.Collections.Generic.List<Entidades.CC.ClienteE> ListarClientes();
        void LLenarDrop(ref System.Web.UI.WebControls.DropDownList lista);
        Entidades.CC.ClienteE ObtenerCliente(string strRUC);
    }
}
