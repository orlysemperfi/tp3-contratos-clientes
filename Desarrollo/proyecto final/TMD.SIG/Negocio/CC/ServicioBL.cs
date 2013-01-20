using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entidades.CC;
using Datos.CC;

namespace Negocio.CC {

  public class ServicioBL : IServicioBL {

    private static ServicioBL _ServicioBL = null;

    private ServicioBL() {
    }

    public static ServicioBL GetInstance() {
      if (_ServicioBL == null) {
        _ServicioBL = new ServicioBL();
      }
      return _ServicioBL;
    }

    private IServicioDAO servicioDao = new SqlServerServicioDAO();

    public List<ServicioE> GetServicios() {
      return servicioDao.GetServicios();
    }

  }

}
