using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.GEN;
using Entidades.GEN;

namespace Negocio.Generico
{
    class OrganizacionBL : IOrganizacionBL
    {
        private IOrganizacionDAO organizacion;

        public void Insert(OrganizacionE o)
        {
            organizacion.Insert(o);
        }
    }
}
