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
    public class LineaServicioDAO : Datos.CC.ILineaServicioDAO
    {
        public List<LineaServicioE> ObtenerLineaServicios()
        {
            List<LineaServicioE> lstLineaServicios = new List<LineaServicioE>();

            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_LINEA_SERVICIO_SEL", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        LineaServicioE bean = new LineaServicioE();
                        bean.CODIGO_LINEA_SERVICIO = reader.GetInt32(0);
                        bean.DESCRIPCION = reader.GetString(1);
                        lstLineaServicios.Add(bean);
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
            return lstLineaServicios;
        }

    }
}
