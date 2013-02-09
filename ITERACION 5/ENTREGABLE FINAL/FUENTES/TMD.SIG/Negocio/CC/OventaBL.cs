using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.CC;
using Entidades.CC;

namespace Negocio.CC
{
    public class OventaBL:IOventaBL
    {
        private IOventaDAO oventaDao = new OventaDAO();
        public List<OventaE> Oventa_Lista(string razon_social, string ruc)
        {
            return oventaDao.Oventa_Lista(razon_social, ruc);
        }
    }
}
