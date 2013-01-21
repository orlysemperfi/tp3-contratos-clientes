using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entidades.CC;

namespace Datos.CC {

  public interface IAdendaDAO {

    List<AdendaE> GetAdendas();
    List<AdendaE> GetAdendas(string numeroContrato, string numeroAdenda, int codigoServicio, string cliente);
    AdendaE GetAdenda(int codigoAdenda);
    void ActualizarSiguienteEstado(int codigoAdenda, string estado);

  }

}
