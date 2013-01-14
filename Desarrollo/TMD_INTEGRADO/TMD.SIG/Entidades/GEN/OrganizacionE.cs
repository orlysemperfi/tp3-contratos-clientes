using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.GEN
{
    public class OrganizacionE
    {
        private String CODIGO_ORGANIZACION;
        private string NOMBRE;
        private string VISION;
        private string MISION;

        public void setCODIGO_ORGANIZACION(String CODIGO_ORGANIZACION)
        {
            this.CODIGO_ORGANIZACION = CODIGO_ORGANIZACION;
        }

        public String getCODIGO_ORGANIZACION()
        {
            return CODIGO_ORGANIZACION;
        }

        public void setNOMBRE(string NOMBRE)
        {
            this.NOMBRE = NOMBRE;
        }

        public string getNOMBRE()
        {
            return NOMBRE;
        }

        public void setMISION(string MISION)
        {
            this.MISION = MISION;
        }

        public string getMISION()
        {
            return MISION;
        }

        public void setVISION(string VISION)
        {
            this.VISION = VISION;
        }

        public string getVISION()
        {
            return VISION;
        }

    }
}
