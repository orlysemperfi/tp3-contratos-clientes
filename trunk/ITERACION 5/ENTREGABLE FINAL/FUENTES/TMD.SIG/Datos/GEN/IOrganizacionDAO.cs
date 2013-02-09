using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.GEN;

namespace Datos.GEN
{
    public interface IOrganizacionDAO
    {
        void Insert(OrganizacionE o);
        List<OrganizacionE> listAll();

    }
}
