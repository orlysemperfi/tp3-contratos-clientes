using System;
namespace Datos.CC
{
    public interface IClienteDAO
    {
        System.Collections.Generic.List<Entidades.CC.ClienteE> Cliente_Lista(string razon_social, string ruc);
        void Insert(Entidades.CC.ClienteE o);
        System.Collections.Generic.List<Entidades.CC.ClienteE> ListarClientes();
        Entidades.CC.ClienteE ObtenerCliente(string strRUC);
        void Update(Entidades.CC.ClienteE o);
    }
}
