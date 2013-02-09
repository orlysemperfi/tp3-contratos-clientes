using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.CC;
using Entidades.CC;
using System.Web.UI.WebControls;

namespace Negocio.CC
{
    public class ClienteBL : Negocio.CC.IClienteBL
    {
        private IClienteDAO clienteDao = new ClienteDAO();

        public ClienteE ObtenerCliente(string strRUC)
        {
            return clienteDao.ObtenerCliente(strRUC);
        }

        public void insertar(ClienteE o)
        {
            clienteDao.Insert(o);
        }
        public void actualizar(ClienteE o)
        {
            clienteDao.Update(o);
        }
        public List<ClienteE> Cliente_Lista(string razon_social, string ruc)
        {
            return clienteDao.Cliente_Lista(razon_social, ruc);
        }
        public List<ClienteE> ListarClientes()
        {
            return clienteDao.ListarClientes();
        }

        public void LLenarDrop(ref DropDownList lista)
        {
            lista.Items.Add(new ListItem(@"Todos", @"0"));

            List<ClienteE> lstClientes = ListarClientes();

            foreach (ClienteE bean in lstClientes)
            {
                ListItem a = new ListItem();
                a.Text = bean.RAZON_SOCIAL;
                a.Value = bean.CODIGO_CLIENTE.ToString();
                lista.Items.Add(a);
            }
        }
    }
}
