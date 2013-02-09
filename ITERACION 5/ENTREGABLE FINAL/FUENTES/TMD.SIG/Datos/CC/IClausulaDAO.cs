using System;
namespace Datos.CC
{
    public interface IClausulaDAO
    {
        void Agregar(Entidades.CC.ClausulaE clausula, int idContrato);
        System.Collections.Generic.List<Entidades.CC.ClausulaE> ClausulasxContrato(int codigoContrato);
        Entidades.CC.ClausulaE ClausulaxCodigo(int codigoClausula);
        void Insert(Entidades.CC.ClausulaE o);
        System.Collections.Generic.List<Entidades.CC.ClausulaE> ObtenerClausulasPenalidad(string numero_contrato);
    }
}
