using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.CC;
using Datos.CC;
using System.Data;

namespace Negocio.CC
{
    public class ContratoBL : Negocio.CC.IContratoBL
    {
        private IContratoDAO contratoDao = new ContratoDAO();

        public void insertar(ContratoE contrato)
        {
            contratoDao.Agregar(contrato);
        }

        //public List<ContratoE> GetContratos()
        //{
        //    return contratoDao.GetContratos();
        //}
        public ContratoE GetContratoXNro(string numeroContrato)
        {
            return contratoDao.GetContratoXNro(numeroContrato);
        }

        public DataTable GetMonitoreoContratos(string Param, int Cliente, int LineaServicio, DateTime FechaInicio, DateTime FechaFin)
        {
            return contratoDao.GetMonitoreoContratos(Param, Cliente, LineaServicio, FechaInicio, FechaFin);
        }
        public DataTable GetInfoContrato(string nroContrato)
        {
            return contratoDao.GetInfoContrato(nroContrato);
        }

        public ContratoE ObtenerContrato(string strContrato)
        {
            return contratoDao.ObtenerContrato(strContrato);
        }

        private static ContratoBL _ContratoBL = null;

        //private ContratoBL()
        //{
        //}

        public static ContratoBL GetInstance()
        {
            if (_ContratoBL == null)
            {
                _ContratoBL = new ContratoBL();
            }
            return _ContratoBL;
        }

        public List<ContratoE> GetContratos()
        {
            return contratoDao.GetContratos();
        }

        public List<ContratoE> GetContratos(string numeroContrato, string descripcion, int codigoServicio)
        {
            return contratoDao.GetContratos(numeroContrato, descripcion, codigoServicio);
        }

        public ContratoE GetContrato(int codigoContrato)
        {
            return contratoDao.GetContrato(codigoContrato);
        }

        public void ActualizarSiguienteEstado(int codigoContrato, string estado, string motivo)
        {
            contratoDao.ActualizarSiguienteEstado(codigoContrato, estado, motivo);
        }

        public void ActualizarAdendasYOtros(int codigoContrato, string estado, string motivo)
        {
            contratoDao.ActualizarAdendasYOtros(codigoContrato, estado, motivo);
        }

    }
}
