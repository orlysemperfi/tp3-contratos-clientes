using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.CC
{
    public class ServicioE
    {
        public int CODIGO_SERVICIO { get; set; }
        public String DESCRIPCION { get; set; }
        public int CODIGO_LINEA_SERVICIO { get; set; } 
        public String NombreLinea { get; set; }
        public LineaServicioE LineaServicio { get; set; }
    }
}
