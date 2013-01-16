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

            return System.Configuration.ConfigurationManager.ConnectionStrings["ConexionConfig"].ToString();
        }

        public void EjecutaSentenciaSQL(String SQL)
        {
            string sCon = CadenaConexion();
            string sel = SQL;

            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(SQL, con);
                    cmd.ExecuteNonQuery();
                }
                catch (System.Exception excep)
                {
                    Console.WriteLine(excep.Message);
                }
            }

        }




    }
}
