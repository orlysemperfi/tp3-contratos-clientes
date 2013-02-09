using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.CC;
using Entidades.CC;
using System.Web.UI.WebControls;

namespace Negocio.CC
{
    public class IndicadorBL : Negocio.CC.IIndicadorBL
    {
        private IIndicadorDAO indicadorDao = new IndicadorDAO();

        public List<IndicadorE> ObteneIndicadores()
        {
            return indicadorDao.ObteneIndicadores();
        }
        public void LLenarDrop(ref DropDownList lista)
        {
            lista.Items.Add(new ListItem(@"Seleccione", @"Seleccione"));

            List<IndicadorE> lstIndicadores = ObteneIndicadores();

            foreach (IndicadorE bean in lstIndicadores)
            {
                ListItem a = new ListItem();
                a.Text = bean.Nombre;
                a.Value = bean.Codigo + "";
                lista.Items.Add(a);
            }



        }
        public void insertar(IndicadorE indicador, int idContrato)
        {
            indicadorDao.Agregar(indicador, idContrato);
        }
    }
}
