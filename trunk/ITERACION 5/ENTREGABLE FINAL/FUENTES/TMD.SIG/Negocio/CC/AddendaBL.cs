using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.CC;
using Entidades.CC;

namespace Negocio.CC
{
    public class AddendaBL : Negocio.CC.IAddendaBL
    {
        private IAddendaDAO addendaDao = new AddendaDAO();

        public void insertar(AddendaE o)
        {
            addendaDao.Insert(o);
        }

        private static AddendaBL _AdendaBL = null;

    //private AddendaBL() {
    //}

    public static AddendaBL GetInstance() {
      if (_AdendaBL == null) {
        _AdendaBL = new AddendaBL();
      }
      return _AdendaBL;
    }

    private IAddendaDAO adendaDao = new AddendaDAO();

    public List<AddendaE> GetAdendas() {
      return adendaDao.GetAdendas();
    }

    public List<AddendaE> GetAdendas(string numeroContrato, string numeroAdenda, int codigoServicio) {
      return adendaDao.GetAdendas(numeroContrato, numeroAdenda, codigoServicio);
    }

    public AddendaE GetAdenda(int codigoAdenda) {
      return adendaDao.GetAdenda(codigoAdenda);
    }

    public void ActualizarSiguienteEstado(int codigoAdenda, string estado) {
      adendaDao.ActualizarSiguienteEstado(codigoAdenda, estado);
    }
    }
}
