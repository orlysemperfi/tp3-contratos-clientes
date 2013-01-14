using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Datos.GEN
{
    class ConexionDAO
    {

        public string CadenaConexion()
        {
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.DataSource = @"(local)\SQLEXPRESS";
            csb.InitialCatalog = "TMD";
            csb.IntegratedSecurity = true;
            return csb.ConnectionString;
        }

        public void EjecutaSentenciaSQL(String SQL)
        {
            string sCon = CadenaConexion();
            string sel = SQL;

            using (SqlConnection con = new SqlConnection(sCon))
            {
                con.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (System.Exception excep)
                {
                    Console.WriteLine(excep.Message);
                }
            }

        }




    }
}
