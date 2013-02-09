using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Entidades.CC;
using System.Data.SqlClient;
using System.Data;
using Datos.GEN;
using System.Data.Common;

namespace Datos.CC
{
    public class ContratoDAO : Datos.CC.IContratoDAO
    {
        public void Agregar(ContratoE contrato)
        {
            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_CONTRATO_INS", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@CODIGO_CLIENTE", contrato.CODIGO_CLIENTE));
                    cmd.Parameters.Add(new SqlParameter("@NUMERO_BUENA_PRO", contrato.NUMERO_BUENA_PRO));
                    cmd.Parameters.Add(new SqlParameter("@NUMERO_CARTA_FIANZA", contrato.NUMERO_CARTA_FIANZA));
                    cmd.Parameters.Add(new SqlParameter("@FECHA_INICIO", contrato.FECHA_INICIO));
                    cmd.Parameters.Add(new SqlParameter("@FECHA_FIN", contrato.FECHA_FIN));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_MONEDA", contrato.CODIGO_MONEDA));
                    cmd.Parameters.Add(new SqlParameter("@MONTO", contrato.MONTO));
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION   ", contrato.DESCRIPCION));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_SERVICIO", contrato.CODIGO_SERVICIO));

                    SqlParameter parameterIdContrato = new SqlParameter("@CODIGO_CONTRATO", SqlDbType.Int, contrato.CODIGO_CONTRATO);
                    parameterIdContrato.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parameterIdContrato); 

                    //cmd.Parameters.Add(new SqlParameter("@CODIGO_CONTRATO", SqlDbType.Int,contrato.CODIGO_CONTRATO,ParameterDirection.Output,false,1,1,"",DataRowVersion.Default,1));
                    
                    //SqlParameter parameterCount = new SqlParameter("@Count", SqlDbType.Int, 4);
                    //parameterCount.Direction = ParameterDirection.Output;
                    //myCommand.Parameters.Add(parameterCount); 

                    int response = cmd.ExecuteNonQuery();

                    contrato.CODIGO_CONTRATO = Convert.ToInt32(cmd.Parameters["@CODIGO_CONTRATO"].Value);

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
        public ContratoE GetContratoXNro(string numeroContrato)
        {
            ConexionDAO cn = new ConexionDAO();
            ContratoE contrato = new ContratoE();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_DATOS_X_NRO_CONTRATO", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NumeroContrato", numeroContrato));
                    IDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        contrato.CODIGO_CONTRATO = reader.GetInt32(0);
                        contrato.CLIENTE = reader.GetString(1);
                        contrato.ESTADO = reader.GetString(2);
                        contrato.DESCRIPCION = reader.GetString(3);
                        contrato.NRO_ADDENDAS_PROCESO = reader.GetInt32(4);
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
            return contrato;
        }

        public DataTable GetMonitoreoContratos(string Param, int Cliente, int LineaServicio, DateTime FechaInicio, DateTime FechaFin)
        {
            ConexionDAO cn = new ConexionDAO();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_CONTRATO_SEL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PARAMETRO", Param));
                    cmd.Parameters.Add(new SqlParameter("@CLIENTE", Cliente));
                    cmd.Parameters.Add(new SqlParameter("@LINEASERVICIO", LineaServicio));
                    cmd.Parameters.Add(new SqlParameter("@FECHAINICIO", FechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@FECHAFIN", FechaFin));
                    cmd.ExecuteNonQuery();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
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
            return dt;
        }

        public DataTable GetInfoContrato(string nroContrato)
        {
            ConexionDAO cn = new ConexionDAO();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_CONTRATO_DET", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NroContrato", nroContrato));
                    cmd.ExecuteNonQuery();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
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
            return dt;
        }

        public ContratoE ObtenerContrato(string strContrato)
        {
            ContratoE obj = null;

            ConexionDAO cnx = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cnx.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_CONTRATO_CONSULTA", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CONTRATO", strContrato));

                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        obj = new ContratoE();
                        obj.CODIGO_CONTRATO = reader.GetInt32(0);
                        obj.RAZONSOCIAL = reader.GetString(1);
                        obj.RUC = reader.GetString(2);
                        obj.ESTADO = reader.GetString(3);
                        obj.MONTO = reader.GetDecimal(4);
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
            return obj;
        }


        public ContratoDAO()
        {
            //
        }


        public List<ContratoE> GetContratos()
        {
            ConexionDAO cn = new ConexionDAO();
            List<ContratoE> listaContratos = new List<ContratoE>();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_CONTRATO_ALL", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ContratoE contrato = GetInternalContrato(reader);
                        listaContratos.Add(contrato);
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
            return listaContratos;
        }


        public List<ContratoE> GetContratos(string numeroContrato, string descripcion, int codigoServicio)
        {
            ConexionDAO cn = new ConexionDAO();
            List<ContratoE> listaContratos = new List<ContratoE>();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_CONTRATO_X_NUMERO_DESCRIPCION_SERVICIO", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NumeroContrato", numeroContrato));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", descripcion));
                    cmd.Parameters.Add(new SqlParameter("@CodigoServicio", codigoServicio));

                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ContratoE Contrato = GetInternalContrato(reader);
                        listaContratos.Add(Contrato);
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
            return listaContratos;
        }


        public ContratoE GetContrato(int codigoContrato)
        {
            ConexionDAO cn = new ConexionDAO();
            ContratoE Contrato = new ContratoE();
            bool ExisteContrato = false;

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_CONTRATO_X_CODIGO", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CodigoContrato", codigoContrato));

                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Contrato = GetInternalContrato(reader);
                        ExisteContrato = true;
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
            if (ExisteContrato) return Contrato;
            else return null;
        }

        public void ActualizarSiguienteEstado(int codigoContrato, string estado, string motivo)
        {

            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_CONTRATO_UPD_ESTADO", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@CodigoContrato", codigoContrato));
                    cmd.Parameters.Add(new SqlParameter("@MotivoTermino", motivo));
                    cmd.Parameters.Add(new SqlParameter("@Estado", estado));
                    cmd.ExecuteNonQuery();
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
        
        public void ActualizarAdendasYOtros(int codigoContrato, string estado, string motivo)
        {
            //Invocar aqui el Stored Procedure de SQL Server
        }

        private ContratoE GetInternalContrato(IDataReader reader)
        {
            ContratoE contrato = new ContratoE()
            {
                CODIGO_CONTRATO = Convert.ToInt32(reader["CODIGO_CONTRATO"]),
                NUMERO_CONTRATO = reader["NUMERO_CONTRATO"].ToString(),
                NUMERO_BUENA_PRO = reader["NUMERO_BUENA_PRO"] != null ? reader["NUMERO_BUENA_PRO"].ToString() : string.Empty,
                NUMERO_CARTA_FIANZA = reader["NUMERO_CARTA_FIANZA"] != null ? reader["NUMERO_CARTA_FIANZA"].ToString() : string.Empty,
                FECHA_INICIO = Convert.ToDateTime(reader["FECHA_INICIO"].ToString()),
                FECHA_FIN = Convert.ToDateTime(reader["FECHA_FIN"].ToString()),
                MONTO = Convert.ToDecimal(reader["MONTO"].ToString()),
                DESCRIPCION = reader["DESCRIPCION"].ToString(),
                MOTIVO_TERMINO = reader["MOTIVO_TERMINO"] != null ? reader["MOTIVO_TERMINO"].ToString() : string.Empty,
                ESTADO = reader["ESTADO"].ToString(),
                FECHA_REGISTRO = Convert.ToDateTime(reader["FECHA_REGISTRO"].ToString()),
                ClienteEnt = new ClienteE()
                {
                    CODIGO_CLIENTE = Convert.ToInt32(reader["CODIGO_CLIENTE"]),
                    RAZON_SOCIAL = reader["RAZON_SOCIAL"].ToString(),
                    RUC = reader["RUC"].ToString(),
                    TIPO_CLIENTE = reader["TIPO_CLIENTE"].ToString(),
                    DIRECCION = reader["DIRECCION"].ToString(),
                    TELEFONO = reader["TELEFONO"].ToString(),
                    CORREO = reader["CORREO"] != null ? reader["CORREO"].ToString() : string.Empty,
                    FAX = reader["FAX"] != null ? reader["FAX"].ToString() : string.Empty,
                    CONTACTO = reader["CONTACTO"].ToString(),
                    //ESTADO = bool.Parse(reader["ESTADO"].ToString()),
                    FECHA_INGRESO = Convert.ToDateTime(reader["FECHA_INGRESO"].ToString())
                },
                Servicio = new ServicioE()
                {
                    CODIGO_SERVICIO = Convert.ToInt32(reader["CODIGO_SERVICIO"]),
                    DESCRIPCION = reader["DESCRIPCION_SERVICIO"].ToString()
                },
                Moneda = new MonedaE()
                {
                    CODIGO_MONEDA = reader["CODIGO_MONEDA"].ToString(),
                    NOMBRE = reader["NOMBRE_MONEDA"].ToString()
                }
            };
            if (reader["FECHA_TERMINO"] != DBNull.Value)
            {
                contrato.FECHA_TERMINO = Convert.ToDateTime(reader["FECHA_TERMINO"].ToString());
            }
            return contrato;
        }
    }
}
