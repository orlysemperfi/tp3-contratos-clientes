using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entidades.CC;
using Datos.CC;

namespace Negocio.CC {

  public class ContratoBL : IContratoBL {

    private static ContratoBL _ContratoBL = null;

    private ContratoBL() {
    }

    public static ContratoBL GetInstance() {
      if (_ContratoBL == null) {
        _ContratoBL = new ContratoBL();
      }
      return _ContratoBL;
    }

    private IContratoDAO contratoDao = new SqlServerContratoDAO();

    public List<ContratoE> GetContratos() {
      return contratoDao.GetContratos();
    }

  }

}
