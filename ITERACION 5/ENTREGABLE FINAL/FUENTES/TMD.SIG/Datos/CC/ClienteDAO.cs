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
    public class ClienteDAO : Datos.CC.IClienteDAO
    {
        public ClienteE ObtenerCliente(string strRUC)
        {
            ClienteE bean = new ClienteE();

            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_CLIENTE_SEL_BYRUC", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@RUC", strRUC));

                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        bean = new ClienteE();
                        bean.CODIGO_CLIENTE = reader.GetInt32(0);
                        bean.RUC = reader.GetString(1);
                        bean.RAZON_SOCIAL = reader.GetString(2);
                        bean.TIPO_CLIENTE = getTipoCliente(reader.GetString(3));
                        bean.CONTACTO = reader.GetString(4);
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
            return bean;
        }
        private static String getTipoCliente(string codTipoCliente)
        {
            if (codTipoCliente == "P") return "PÚBLICO";
            else return "PRIVADO";
        }

        public void Insert(ClienteE o)
        {

            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_OVENTA_CLIENTE_INS", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@RazonSocial", o.RAZON_SOCIAL));
                    cmd.Parameters.Add(new SqlParameter("@Ruc", o.RUC));
                    cmd.Parameters.Add(new SqlParameter("@TipoCliente", o.TIPO_CLIENTE));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", o.DIRECCION));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", o.TELEFONO));
                    cmd.Parameters.Add(new SqlParameter("@Correo", o.CORREO));
                    cmd.Parameters.Add(new SqlParameter("@Fax", o.FAX));
                    cmd.Parameters.Add(new SqlParameter("@Contacto", o.CONTACTO));
                    cmd.Parameters.Add(new SqlParameter("@Estado", o.ESTADO));


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
        public List<ClienteE> Cliente_Lista(string razon_social, string ruc)
        {
            ConexionDAO cn = new ConexionDAO();
            List<ClienteE> listCliente = new List<ClienteE>();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_CLIENTE_LISTA", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@RazonSocial", razon_social));
                    cmd.Parameters.Add(new SqlParameter("@Ruc", ruc));

                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ClienteE bean = new ClienteE();
                        bean.CODIGO_CLIENTE = reader.GetInt32(0);
                        bean.TIPO_CLIENTE = reader.GetString(1);
                        if (bean.TIPO_CLIENTE == "P") bean.TIPO_CLIENTE_DESCRIPCION = "PÚBLICO";
                        else bean.TIPO_CLIENTE_DESCRIPCION = "PRIVADO";

                        bean.RAZON_SOCIAL = reader.GetString(2);
                        bean.RUC = reader.GetString(3);
                        bean.DIRECCION = reader.GetString(4);
                        bean.TELEFONO = reader.GetString(5);
                        bean.CORREO = reader.GetString(6);
                        bean.FAX = reader.GetString(7);
                        bean.CONTACTO = reader.GetString(8);
                        bean.ESTADO = reader.GetBoolean(9);
                        listCliente.Add(bean);
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
            return listCliente;
        }
        public void Update(ClienteE o)
        {
            ConexionDAO cn = new ConexionDAO();
            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CC.USP_CLIENTE_UPD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", o.CODIGO_CLIENTE));
                    cmd.Parameters.Add(new SqlParameter("@RazonSocial", o.RAZON_SOCIAL));
                    cmd.Parameters.Add(new SqlParameter("@Ruc", o.RUC));
                    cmd.Parameters.Add(new SqlParameter("@TipoCliente", o.TIPO_CLIENTE));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", o.DIRECCION));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", o.TELEFONO));
                    cmd.Parameters.Add(new SqlParameter("@Correo", o.CORREO));
                    cmd.Parameters.Add(new SqlParameter("@Fax", o.FAX));
                    cmd.Parameters.Add(new SqlParameter("@Contacto", o.CONTACTO));
                    cmd.Parameters.Add(new SqlParameter("@Estado", o.ESTADO));

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

        public List<ClienteE> ListarClientes()
        {
            List<ClienteE> lsrClientes = new List<ClienteE>();

            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_CLIENTE_SEL", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ClienteE bean = new ClienteE();
                        bean.CODIGO_CLIENTE = reader.GetInt32(0);
                        bean.RAZON_SOCIAL = reader.GetString(2);
                        lsrClientes.Add(bean);
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
            return lsrClientes;
        }
    }
}
