using System;
namespace Datos.CC
{
    public interface IContratoDAO
    {
        void ActualizarAdendasYOtros(int codigoContrato, string estado, string motivo);
        void ActualizarSiguienteEstado(int codigoContrato, string estado, string motivo);
        void Agregar(Entidades.CC.ContratoE contrato);
        Entidades.CC.ContratoE GetContrato(int codigoContrato);
        System.Collections.Generic.List<Entidades.CC.ContratoE> GetContratos();
        System.Collections.Generic.List<Entidades.CC.ContratoE> GetContratos(string numeroContrato, string descripcion, int codigoServicio);
        Entidades.CC.ContratoE GetContratoXNro(string numeroContrato);
        System.Data.DataTable GetInfoContrato(string nroContrato);
        System.Data.DataTable GetMonitoreoContratos(string Param, int Cliente, int LineaServicio, DateTime FechaInicio, DateTime FechaFin);
        Entidades.CC.ContratoE ObtenerContrato(string strContrato);
    }
}
