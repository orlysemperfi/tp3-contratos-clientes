using System;
namespace Negocio.CC
{
    public interface IClausulaBL
    {
        System.Collections.Generic.List<Entidades.CC.ClausulaE> ClausulasxContrato(int codigoContrato);
        Entidades.CC.ClausulaE ClausulaxCodigo(int codigoClausula);
        void Insert(Entidades.CC.ClausulaE o);
        void insertar(Entidades.CC.ClausulaE clausula, int idContrato);
        void LLenarClausulasPenalidad(ref System.Web.UI.WebControls.DropDownList lista, string numero_contrato);
        System.Collections.Generic.List<Entidades.CC.ClausulaE> ObtenerClausulasPenalidad(string numero_contrato);
    }
}
