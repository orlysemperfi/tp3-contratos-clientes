using System;
namespace Negocio.CC
{
    public interface IAddendaBL
    {
        void ActualizarSiguienteEstado(int codigoAdenda, string estado);
        Entidades.CC.AddendaE GetAdenda(int codigoAdenda);
        System.Collections.Generic.List<Entidades.CC.AddendaE> GetAdendas();
        System.Collections.Generic.List<Entidades.CC.AddendaE> GetAdendas(string numeroContrato, string numeroAdenda, int codigoServicio);
        void insertar(Entidades.CC.AddendaE o);
    }
}
