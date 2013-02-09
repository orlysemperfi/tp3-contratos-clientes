using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.CC;
using Entidades.CC;
using System.Web.UI.WebControls;

namespace Negocio.CC
{
   public class ServicioBL : Negocio.CC.IServicioBL
    {
        private IServicioDAO servicioDao = new ServicioDAO();

        public List<ServicioE> ObtenerServicios()
        {
            return servicioDao.ObtenerServicios();
        }

        public void LLenarDrop(ref DropDownList lista)
        {
            lista.Items.Add(new ListItem(@"Seleccione", @"Seleccione"));
            List<ServicioE> lstServicios = ObtenerServicios();

            foreach (ServicioE bean in lstServicios)
            {
                ListItem a = new ListItem();
                a.Text = bean.NombreLinea + @" - " + bean.DESCRIPCION;
                a.Value = bean.CODIGO_SERVICIO + "";
                lista.Items.Add(a); 
            }



        }

        private static ServicioBL _ServicioBL = null;

        //private ServicioBL()
        //{
        //}

        public static ServicioBL GetInstance()
        {
            if (_ServicioBL == null)
            {
                _ServicioBL = new ServicioBL();
            }
            return _ServicioBL;
        }

        public List<ServicioE> GetServicios()
        {
            return servicioDao.GetServicios();
        }
    }
}
