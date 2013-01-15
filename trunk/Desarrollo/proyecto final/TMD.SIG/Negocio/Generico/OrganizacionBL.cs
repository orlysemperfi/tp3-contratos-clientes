using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.GEN;
using Entidades.GEN;

namespace Negocio.Generico
{
    public class OrganizacionBL : Negocio.Generico.IOrganizacionBL
    {
        private IOrganizacionDAO orgDao = new OrganizacionDAO();

        public void insertar(OrganizacionE o) {
            orgDao.Insert(o);    
        }

        public List<OrganizacionE> listAll(){
            return orgDao.listAll();
        }

    }
}
