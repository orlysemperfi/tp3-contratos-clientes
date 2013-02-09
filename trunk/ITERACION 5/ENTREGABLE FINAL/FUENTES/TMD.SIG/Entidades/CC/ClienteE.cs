using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.CC
{
    public class ClienteE 
    {
        public int CODIGO_CLIENTE { get; set; }
        public String RAZON_SOCIAL { get; set; }
        public String RUC { get; set; }
        public string TIPO_CLIENTE { get; set; }
        public String DIRECCION { get; set; }
        public String TELEFONO { get; set; }
        public String CORREO { get; set; }
        public String FAX { get; set; }
        public String CONTACTO { get; set; }
        public bool ESTADO { get; set; }
        public DateTime FECHA_INGRESO { get; set; }
        public String TIPO_CLIENTE_DESCRIPCION { get; set; }


        //public String TipoCliente { get; set; }
        //public String RazonSocial { get; set; }
        //public String Ruc { get; set; }
        public String RUBRO { get; set; }
        public String CARGO { get; set; }
    }
}
