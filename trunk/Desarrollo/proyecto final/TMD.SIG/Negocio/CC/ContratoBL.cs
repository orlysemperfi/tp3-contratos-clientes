﻿using System;
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

    public List<ContratoE> GetContratos(string numeroContrato, string descripcion, int codigoServicio, string cliente) {
      return contratoDao.GetContratos(numeroContrato, descripcion, codigoServicio, cliente);
    }

    public ContratoE GetContrato(int codigoContrato) {
      return contratoDao.GetContrato(codigoContrato);
    }

    public void ActualizarSiguienteEstado(int codigoContrato, string estado, string motivo) {
      contratoDao.ActualizarSiguienteEstado(codigoContrato, estado, motivo);
    }

    public void ActualizarAdendasYOtros(int codigoContrato, string estado, string motivo) {
      contratoDao.ActualizarAdendasYOtros(codigoContrato, estado, motivo);
    }

  }

}