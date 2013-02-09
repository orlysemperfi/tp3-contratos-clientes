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
    public class EntregableDAO : Datos.CC.IEntregableDAO
    {
        public List<EntregableE> ObteneEntregables()
        {
            List<EntregableE> lista = new List<EntregableE>();

            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_ENTREGABLE_SEL", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        EntregableE bean = new EntregableE();
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

        public void Agregar(EntregableE entregable, int idContrato)
        {
            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_CONTRATO_ENTREGABLE_INS", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_CONTRATO", idContrato));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_ENTREGABLE", entregable.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_ROL", entregable.CodigoRol));
                    cmd.Parameters.Add(new SqlParameter("@FECHA_PACTADA", entregable.FechaPactada));

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
