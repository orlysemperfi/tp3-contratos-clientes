using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entidades.CC;
using Datos.CC;

namespace Negocio.CC {

  public class AdendaBL : IAdendaBL {

    private static AdendaBL _AdendaBL = null;

    private AdendaBL() {
    }

    public static AdendaBL GetInstance() {
      if (_AdendaBL == null) {
        _AdendaBL = new AdendaBL();
      }
      return _AdendaBL;
    }

    private IAdendaDAO adendaDao = new SqlServerAdendaDAO();

    public List<AdendaE> GetAdendas() {
      return adendaDao.GetAdendas();
    }

    public List<AdendaE> GetAdendas(string numeroContrato, string numeroAdenda, int codigoServicio, string cliente) {
      return adendaDao.GetAdendas(numeroContrato, numeroAdenda, codigoServicio, cliente);
    }

    public AdendaE GetAdenda(int codigoAdenda) {
      return adendaDao.GetAdenda(codigoAdenda);
    }

    public void ActualizarSiguienteEstado(int codigoAdenda, string estado) {
      adendaDao.ActualizarSiguienteEstado(codigoAdenda, estado);
    }

  }

}
