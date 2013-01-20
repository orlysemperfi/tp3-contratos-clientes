using System;
using System.Collections.Generic;

using Entidades.CC;

namespace Negocio.CC {

  public interface IContratoBL {

    List<ContratoE> GetContratos();
    ContratoE GetContrato(int codigoContrato);
    void ActualizarSiguienteEstado(int codigoContrato, string estado, string motivo);
    void ActualizarAdendasYOtros(int codigoContrato, string estado, string motivo);

  }

}
