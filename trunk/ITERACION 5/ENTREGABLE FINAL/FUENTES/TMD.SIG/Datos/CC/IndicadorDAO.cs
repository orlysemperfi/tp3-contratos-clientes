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
    public class IndicadorDAO : Datos.CC.IIndicadorDAO
    {
        public List<IndicadorE> ObteneIndicadores()
        {
            List<IndicadorE> lista = new List<IndicadorE>();

            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_INDICADOR_SEL", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        IndicadorE bean = new IndicadorE();
                        bean.Codigo = reader.GetInt32(0);
                        bean.Nombre = reader.GetString(1);
                        lista.Add(bean);
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
            return lista;
        }

        public void Agregar(IndicadorE indicador, int idContrato)
        {
            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_CONTRATO_INDICADOR_INS", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_CONTRATO", idContrato));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_INDICADOR", indicador.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@VALOR_OBJETIVO", indicador.ValorObjetivo));
                    cmd.Parameters.Add(new SqlParameter("@FRECUENCIA", indicador.Frecuencia));

                    int response = cmd.ExecuteNonQuery();

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

        }
    }
}
