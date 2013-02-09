using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.CC;
using Entidades.CC;
using System.Web.UI.WebControls;

namespace Negocio.CC
{
    public class EntregableBL : Negocio.CC.IEntregableBL
    {
        private IEntregableDAO entregableDao = new EntregableDAO();

        public List<EntregableE> ObteneEntregables()
        {
            return entregableDao.ObteneEntregables();
        }
        public void LLenarDrop(ref DropDownList lista)
        {
            lista.Items.Add(new ListItem(@"Seleccione", @"Seleccione"));

            List<EntregableE> lstEntregables = ObteneEntregables();

            foreach (EntregableE bean in lstEntregables)
            {
                ListItem a = new ListItem();
                a.Text = bean.Nombre;
                a.Value = bean.Codigo + "";
                lista.Items.Add(a);
            }



        }
        public void insertar(EntregableE entegable, int idContrato)
        {
            entregableDao.Agregar(entegable, idContrato);
        }
    }
}
