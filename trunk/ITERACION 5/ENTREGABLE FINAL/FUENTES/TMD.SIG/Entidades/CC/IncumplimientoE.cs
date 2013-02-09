using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.CC
{
    public class IncumplimientoE
    {
        public int Codigo_Incumplimiento { get; set; }
        public String Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int Codigo_Contrato { get; set; }
        public int Codigo_Clausula { get; set; }
        public decimal Monto { get; set; }
        public string Motivo { get; set; }
    }
}
