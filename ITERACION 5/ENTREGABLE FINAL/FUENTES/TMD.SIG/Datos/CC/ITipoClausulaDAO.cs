using System;
namespace Datos.CC
{
    public interface ITipoClausulaDAO
    {
        System.Collections.Generic.List<Entidades.CC.TipoClausulaE> listAll();
        System.Collections.Generic.List<Entidades.CC.TipoClausulaE> ObteneTipoClausulas();
    }
}
