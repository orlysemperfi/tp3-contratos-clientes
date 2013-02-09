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
    public class ServicioDAO : Datos.CC.IServicioDAO
    {
        public List<ServicioE> ObtenerServicios()
        {
            List<ServicioE> lstServicios = new List<ServicioE>();

            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_SERVICIO_SEL_DET", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ServicioE bean = new ServicioE();
                        bean.CODIGO_SERVICIO = reader.GetInt32(0);
                        bean.DESCRIPCION = reader.GetString(1);
                        bean.CODIGO_LINEA_SERVICIO = reader.GetInt32(2);
                        bean.NombreLinea = reader.GetString(3);
                        lstServicios.Add(bean);
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
            return lstServicios;
        }

        public ServicioDAO()
        {
            //
        }


        public List<ServicioE> GetServicios()
        {
            ConexionDAO cn = new ConexionDAO();
            List<ServicioE> listaServicios = new List<ServicioE>();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_SERVICIO_LINEA", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ServicioE bean = new ServicioE()
                        {
                            CODIGO_SERVICIO = Convert.ToInt32(reader["CODIGO_SERVICIO"]),
                            DESCRIPCION = reader["DESCRIPCION"].ToString(),
                            LineaServicio = new LineaServicioE()
                            {
                                CODIGO_LINEA_SERVICIO = Convert.ToInt32(reader["CODIGO_LINEA_SERVICIO"]),
                                DESCRIPCION = reader["DESCRIPCION_LINEA_SERVICIO"].ToString()
                            }
                        };
                        listaServicios.Add(bean);
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
            return listaServicios;
        }
    }
}
