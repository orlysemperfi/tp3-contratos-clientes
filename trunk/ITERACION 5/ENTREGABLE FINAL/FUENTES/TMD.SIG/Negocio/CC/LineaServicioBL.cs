using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.CC;
using Entidades.CC;
using System.Web.UI.WebControls;

namespace Negocio.CC
{
   public class LineaServicioBL : Negocio.CC.ILineaServicioBL
    {
        private ILineaServicioDAO lineaservicioDao = new LineaServicioDAO();

        public List<LineaServicioE> ObtenerLineaServicios()
        {
            return lineaservicioDao.ObtenerLineaServicios();
        }

        public void LLenarDrop(ref DropDownList lista)
        {
            lista.Items.Add(new ListItem(@"Todos", @"0"));
            List<LineaServicioE> lstLineaServicios = ObtenerLineaServicios();

            foreach (LineaServicioE bean in lstLineaServicios)
            {
                ListItem a = new ListItem();
                a.Text = bean.DESCRIPCION;
                a.Value = bean.CODIGO_LINEA_SERVICIO.ToString();
                lista.Items.Add(a); 
            }



        }

    }
}
