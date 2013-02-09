using System;
namespace Datos.CC
{
    public interface IAddendaDAO
    {
        void ActualizarSiguienteEstado(int codigoAdenda, string estado);
        Entidades.CC.AddendaE GetAdenda(int codigoAdenda);
        System.Collections.Generic.List<Entidades.CC.AddendaE> GetAdendas();
        System.Collections.Generic.List<Entidades.CC.AddendaE> GetAdendas(string numeroContrato, string numeroAdenda, int codigoServicio);
        void Insert(Entidades.CC.AddendaE o);
    }
}
