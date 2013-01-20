using System;
using System.Collections.Generic;

using Entidades.CC;

namespace Negocio.CC {

  public interface IContratoBL {

    List<ContratoE> GetContratos();
    List<ContratoE> GetContratos(string numeroContrato, string descripcion, int codigoServicio, string cliente);
    ContratoE GetContrato(int codigoContrato);
    void ActualizarSiguienteEstado(int codigoContrato, string estado, string motivo);
    void ActualizarAdendasYOtros(int codigoContrato, string estado, string motivo);

  }

}
