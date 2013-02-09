using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.CC;
using Datos.GEN;
using System.Data;
using System.Data.SqlClient;

namespace Datos.CC
{
    public class TipoClausulaDAO : Datos.CC.ITipoClausulaDAO
    {
        public List<TipoClausulaE> ObteneTipoClausulas()
        {
            List<TipoClausulaE> lstTipoClausulas = new List<TipoClausulaE>();

            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_TIPO_CLAUSULA_SEL", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TipoClausulaE bean = new TipoClausulaE();
                        bean.Codigo = reader.GetInt32(0);
                        bean.Nombre = reader.GetString(1);
                        lstTipoClausulas.Add(bean);
                    }

                    cmd.Dispose();
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return lstTipoClausulas;
        }

        public List<TipoClausulaE> listAll()
        {
            ConexionDAO cn = new ConexionDAO();
            List<TipoClausulaE> listTipoClausula = new List<TipoClausulaE>();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_TIPO_CLAUSULA_SEL", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TipoClausulaE bean = new TipoClausulaE();
                        bean.CODIGO_TIPO_CLAUSULA = reader.GetInt32(0);
                        bean.NOMBRE = reader.GetString(1);
                        listTipoClausula.Add(bean);
                    }

                    cmd.Dispose();
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return listTipoClausula;
        }
    }
}
