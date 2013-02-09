using System;
namespace Negocio.CC
{
    public interface ITipoClausulaBL
    {
        void LLenarDrop(ref System.Web.UI.WebControls.DropDownList lista);
        System.Collections.Generic.List<Entidades.CC.TipoClausulaE> ObteneTipoClausulas();
    }
}
