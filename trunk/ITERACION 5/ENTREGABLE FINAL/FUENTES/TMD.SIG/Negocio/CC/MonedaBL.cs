using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.CC;
using Entidades.CC;
using System.Web.UI.WebControls;

namespace Negocio.CC
{
    public class MonedaBL : Negocio.CC.IMonedaBL
    {
        private IMonedaDAO monedaDao = new MonedaDAO();

        public List<MonedaE> ObtenerMonedas()
        {
            return monedaDao.ObtenerMonedas();
        }

        public void LLenarDrop(ref DropDownList lista)
        {
            lista.Items.Add(new ListItem(@"Seleccione", @"Seleccione"));

            List<MonedaE> lstMonedas = ObtenerMonedas();

                foreach (MonedaE bean in lstMonedas)
                {
                    ListItem a = new ListItem();
                    a.Text = bean.NOMBRE;
                    a.Value = bean.CODIGO_MONEDA;
                    lista.Items.Add(a); 
                }
                    
             

        }
    }
}
