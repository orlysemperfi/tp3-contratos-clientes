using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.CC;
using Entidades.CC;
using System.Web.UI.WebControls;

namespace Negocio.CC
{
    public class TipoClausulaBL : Negocio.CC.ITipoClausulaBL
    {
        private ITipoClausulaDAO tipoClausulaDao = new TipoClausulaDAO();

        public List<TipoClausulaE> ObteneTipoClausulas()
        {
            return tipoClausulaDao.ObteneTipoClausulas();
        }

        public void LLenarDrop(ref DropDownList lista)
        {
            lista.Items.Add(new ListItem(@"Seleccione", @"Seleccione"));

            List<TipoClausulaE> lstTipoClausulas = ObteneTipoClausulas();

            foreach (TipoClausulaE bean in lstTipoClausulas)
                {
                    ListItem a = new ListItem();
                    a.Text = bean.Nombre;
                    a.Value = bean.Codigo+"";
                    lista.Items.Add(a); 
                }
                    
             

        }

        public List<TipoClausulaE> listAll()
        {
            return tipoClausulaDao.listAll();
        }
    }
}
