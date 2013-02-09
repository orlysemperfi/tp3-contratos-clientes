using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.CC;
using Entidades.CC;
using System.Web.UI.WebControls;

namespace Negocio.CC
{
    public class ClausulaBL : Negocio.CC.IClausulaBL
    {
        private IClausulaDAO clausulaDao = new ClausulaDAO();

        public void Insert(ClausulaE o)
        {
            clausulaDao.Insert(o);
        }

        public void insertar(ClausulaE clausula, int idContrato)
        {
            clausulaDao.Agregar(clausula, idContrato);
        }

        public List<ClausulaE> ClausulasxContrato(int codigoContrato)
        {
            return clausulaDao.ClausulasxContrato(codigoContrato);
        }

        public ClausulaE ClausulaxCodigo(int codigoClausula)
        {
            return clausulaDao.ClausulaxCodigo(codigoClausula);
        }

        public List<ClausulaE> ObtenerClausulasPenalidad(string numero_contrato)
        {
            return clausulaDao.ObtenerClausulasPenalidad(numero_contrato);
        }

        public void LLenarClausulasPenalidad(ref DropDownList lista, string numero_contrato)
        {
            List<ClausulaE> lstClausulas = ObtenerClausulasPenalidad(numero_contrato);


            if (lstClausulas.Count > 0)
            {
                lista.Items.Add(new ListItem(@"Seleccione", @"0"));
            }
            foreach (ClausulaE obj in lstClausulas)
            {
                ListItem a = new ListItem();
                a.Text = obj.DESCRIPCION.ToString();
                a.Value = obj.IdClausula.ToString();
                lista.Items.Add(a);
            }
        }

    }
}
