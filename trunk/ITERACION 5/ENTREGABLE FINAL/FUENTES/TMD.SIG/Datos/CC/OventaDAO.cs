using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Entidades.CC;
using System.Data.SqlClient;
using Datos.GEN;
using System.Data;

namespace Datos.CC
{
    public class OventaDAO:IOventaDAO
    {
        public void Insert(OventaE o)
        {

            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_OVENTA_CLIENTE_INS", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@RazonSocial",o.RAZON_SOCIAL));
                    cmd.Parameters.Add(new SqlParameter("@Ruc",o.RUC));
                    cmd.Parameters.Add(new SqlParameter("@TipoCliente",o.TIPO));
                    cmd.Parameters.Add(new SqlParameter("@Direccion",o.DIRECCION));
                    cmd.Parameters.Add(new SqlParameter("@Telefono",o.TELEFONO));
                    cmd.Parameters.Add(new SqlParameter("@Correo",o.CORREO));
                    //cmd.Parameters.Add(new SqlParameter("@Fax",o.FAX));
                    cmd.Parameters.Add(new SqlParameter("@Contacto", o.CONTACTO));
                    //cmd.Parameters.Add(new SqlParameter("@Estado",o.ESTADO));

                    /*cmd.Parameters.Add(new SqlParameter("@CodigoContrato", o.CODIGO_CONTRATO));
                    cmd.Parameters.Add(new SqlParameter("@CodigoAddenda", o.CODIGO_ADDENDA));
                    cmd.Parameters.Add(new SqlParameter("@CodigoTipoClausula", o.CODIGO_TIPO_CLAUSULA));
                    cmd.Parameters.Add(new SqlParameter("@NumeroClausula", o.NUMERO_CLAUSULA));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", o.DESCRIPCION));
                    cmd.Parameters.Add(new SqlParameter("@SujetoPenalidad", o.SUJETO_PENALIDAD));
                    cmd.Parameters.Add(new SqlParameter("@TipoSancion", (o.SUJETO_PENALIDAD == true ? o.TIPO_SANCION : string.Empty)));
                    cmd.Parameters.Add(new SqlParameter("@Sancion", o.SANCION));
                    cmd.Parameters.Add(new SqlParameter("@Estado", o.ESTADO));*/

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

        public List<OventaE> Oventa_Lista(string razon_social, string ruc)
        {
            ConexionDAO cn = new ConexionDAO();
            List<OventaE> listOventa = new List<OventaE>();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_OVENTA_LISTA", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@RazonSocial", razon_social));
                    cmd.Parameters.Add(new SqlParameter("@Ruc", ruc));

                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        OventaE bean = new OventaE();
                        bean.RUC = reader.GetString(0);
                        bean.RAZON_SOCIAL = reader.GetString(1);
                        bean.RUBRO = reader.GetString(2);
                        bean.TIPO = reader.GetString(3);
                        bean.CONTACTO = reader.GetString(4);
                        bean.TELEFONO = reader.GetString(5);
                        bean.CORREO = reader.GetString(6);
                        bean.CARGO = reader.GetString(7);
                        bean.DIRECCION = reader.GetString(8);
                        listOventa.Add(bean);
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
            return listOventa;
        }

    }
}
