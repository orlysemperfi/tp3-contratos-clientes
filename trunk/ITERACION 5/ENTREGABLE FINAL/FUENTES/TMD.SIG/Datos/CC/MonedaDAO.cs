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
    public class MonedaDAO : Datos.CC.IMonedaDAO
    {
        public List<MonedaE> ObtenerMonedas()
        {
            List<MonedaE> lsrMonedas = new List<MonedaE>();

            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_MONEDA_SEL", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        MonedaE bean = new MonedaE();
                        bean.CODIGO_MONEDA = reader.GetString(0);
                        bean.NOMBRE = reader.GetString(1);
                        lsrMonedas.Add(bean);
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
            return lsrMonedas;
        }
        

    }
}
