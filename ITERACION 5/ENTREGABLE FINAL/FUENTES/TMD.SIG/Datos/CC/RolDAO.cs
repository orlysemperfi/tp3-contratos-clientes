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
    public class RolDAO : Datos.CC.IRolDAO
    {
        public List<RolE> ObteneRoles()
        {
            List<RolE> lstRoles = new List<RolE>();

            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_ROL_SEL", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        RolE bean = new RolE();
                        bean.Codigo = reader.GetInt32(0);
                        bean.Nombre = reader.GetString(1);
                        lstRoles.Add(bean);
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
            return lstRoles;
        }

        public void Agregar(RolE rol, int idContrato)
        {
            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_CONTRATO_ROL_INS", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_CONTRATO", idContrato));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_ROL", rol.Codigo));
                    
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
