using System;
using System.Collections.Generic;

using Entidades.CC;

namespace Negocio.CC {

  public interface IAdendaBL {

    List<AdendaE> GetAdendas();
    List<AdendaE> GetAdendas(string numeroContrato, string numeroAdenda, int codigoServicio, string cliente);
    AdendaE GetAdenda(int codigoAdenda);
    void ActualizarSiguienteEstado(int codigoAdenda, string estado);

  }

}
