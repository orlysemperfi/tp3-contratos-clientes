using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.CC
{
    public class ClausulaE
    {
        public int IdClausula { get; set; }
        public int IdContrato { get; set; }
        public int IdTipo { get; set; }
        public String Tipo { get; set; }
        public int Penalidad { get; set; }
        public int IdTipoSancion { get; set; }
        public String TipoSancion { get; set; }
        //public decimal Sancion { get; set; }
        //public String Descripcion { get; set; }
        public int CODIGO_CLAUSULA { get; set; }
        public int CODIGO_CONTRATO { get; set; }
        public int CODIGO_ADDENDA { get; set; }
        public int NUMERO_CLAUSULA { get; set; }
        public string DESCRIPCION { get; set; }
        public bool SUJETO_PENALIDAD { get; set; }
        public string TIPO_SANCION { get; set; }
        public double SANCION { get; set; }
        public string ESTADO { get; set; }
        public int CODIGO_TIPO_CLAUSULA { get; set; }

    }
}
