using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entidades.CC;

namespace Datos.CC {

  public interface IContratoDAO {

    List<ContratoE> GetContratos();
    List<ContratoE> GetContratos(string numeroContrato, string descripcion, int codigoServicio, string cliente);
    ContratoE GetContrato(int codigoContrato);
    void ActualizarSiguienteEstado(int codigoContrato, string estado, string motivo);
    void ActualizarAdendasYOtros(int codigoContrato, string estado, string motivo);

  }

}
