using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.GEN;


namespace Datos.GEN
{
    class organizacionDAO: IOrganizacionDAO
    {

        public void Insert(OrganizacionE o)
        {

            ConexionDAO cn = new ConexionDAO();

            cn.EjecutaSentenciaSQL("EXEC GEN.ORGANIZACION_INS " +
                o.getCODIGO_ORGANIZACION() + "," + o.getNOMBRE() +
                "," + o.getMISION() + "," + o.getVISION());
        }

    }
}
