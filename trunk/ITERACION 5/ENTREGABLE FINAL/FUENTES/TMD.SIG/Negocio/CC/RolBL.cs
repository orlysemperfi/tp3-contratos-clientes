using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.CC;
using Entidades.CC;
using System.Web.UI.WebControls;

namespace Negocio.CC
{
    public class RolBL : Negocio.CC.IRolBL
    {
        private IRolDAO rolDao = new RolDAO();

        public List<RolE> ObteneRoles()
        {
            return rolDao.ObteneRoles();
        }

        public void insertar(RolE rol, int idContrato)
        {
            rolDao.Agregar(rol, idContrato);
        }
    }
}
