using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entidades.CR;

namespace Entidades.CC {

  public class ContratoE {

    public int CODIGO_CONTRATO { get; set; }
    public string NUMERO_CONTRATO { get; set; }
    public string NUMERO_BUENA_PRO { get; set; }
    public string NUMERO_CARTA_FIANZA { get; set; }
    public DateTime FECHA_INICIO { get; set; }
    public DateTime FECHA_FIN { get; set; }
    public decimal MONTO { get; set; }
    public string DESCRIPCION { get; set; }
    public DateTime FECHA_TERMINO { get; set; }
    public string MOTIVO_TERMINO { get; set; }
    public int CODIGO_CLIENTE { get; set; }
    public int CODIGO_SERVICIO { get; set; }
    public string CODIGO_MONEDA { get; set; }
    public int CODIGO_EMPLEADO_APROB_LEGAL { get; set; }
    public int CODIGO_EMPLEADO_APROB_COMERCIAL { get; set; }
    public int CODIGO_EMPLEADO_TERM_COMERCIAL { get; set; }
    public int CODIGO_EMPLEADO_TERM_LEGAL { get; set; }
    public int CODIGO_EMPLEADO_ANUL_COMERCIAL { get; set; }
    public int CODIGO_EMPLEADO_ANUL_LEGAL { get; set; }
    public string ESTADO { get; set; }
    public DateTime FECHA_REGISTRO { get; set; }

    public ClienteE Cliente { get; set; }
    public ServicioE Servicio { get; set; }
    public MonedaE Moneda { get; set; }

    public string ESTADO_DESCRIPCION {
      get {
        if (!string.IsNullOrEmpty(ESTADO)) {
          if (ESTADO.Equals("R")) {
            return "RESCINDIDO";
          } else if (ESTADO.Equals("F")) {
            return "FIRMADO";
          } else if (ESTADO.Equals("E")) {
            return "ELABORADO";
          } else if (ESTADO.Equals("C")) {
            return "CONCLUIDO";
          }
        }
        return "DESCONOCIDO";
      }
    }

  }

}
