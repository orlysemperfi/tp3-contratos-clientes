using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entidades.CR;

namespace Entidades.CC {

  public class AdendaE {

    public int CODIGO_ADDENDA { get; set; }
    public string NUMERO_ADDENDA { get; set; }
    public string DESCRIPCION { get; set; }
    public DateTime FECHA_REGISTRO { get; set; }
    public string ESTADO { get; set; }
    
    public ContratoE Contrato { get; set; }

    public string ESTADO_DESCRIPCION {
      get {
        if (!string.IsNullOrEmpty(ESTADO)) {
          if (ESTADO.Equals("P")) {
            return "PROCESO";
          } else if (ESTADO.Equals("F")) {
            return "FIRMADO";
          }
        }
        return "DESCONOCIDO";
      }
    }

  }

}
