using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Entidades.CC;
using System.Data.SqlClient;
using System.Data;
using Datos.GEN;


namespace Datos.CC
{
    public class ClausulaDAO : Datos.CC.IClausulaDAO
    {
       public void Agregar(ClausulaE clausula, int idContrato)
        {
            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_CLAUSULA_INS", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@CODIGO_CONTRATO", idContrato));
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCIÓN", clausula.DESCRIPCION));
                    cmd.Parameters.Add(new SqlParameter("@SUJETO_PENALIDAD", clausula.Penalidad));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_TIPO_CLAUSULA", clausula.IdTipo));

                    if (clausula.Penalidad == 1)
                    {
                        cmd.Parameters.Add(new SqlParameter("@TIPO_SANCION", clausula.IdTipoSancion));
                        cmd.Parameters.Add(new SqlParameter("@SANCION", clausula.SANCION));
                    }
                    
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

       public void Insert(ClausulaE o)
       {

           ConexionDAO cn = new ConexionDAO();

           using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
           {
               try
               {
                   con.Open();

                   SqlCommand cmd = new SqlCommand("CC.USP__CLAUSULA_INS", con);

                   cmd.CommandType = CommandType.StoredProcedure;

                   cmd.Parameters.Add(new SqlParameter("@CodigoContrato", o.CODIGO_CONTRATO));
                   cmd.Parameters.Add(new SqlParameter("@CodigoAddenda", o.CODIGO_ADDENDA));
                   cmd.Parameters.Add(new SqlParameter("@CodigoTipoClausula", o.CODIGO_TIPO_CLAUSULA));
                   cmd.Parameters.Add(new SqlParameter("@NumeroClausula", o.NUMERO_CLAUSULA));
                   cmd.Parameters.Add(new SqlParameter("@Descripcion", o.DESCRIPCION));
                   cmd.Parameters.Add(new SqlParameter("@SujetoPenalidad", o.SUJETO_PENALIDAD));
                   cmd.Parameters.Add(new SqlParameter("@TipoSancion", (o.SUJETO_PENALIDAD == true ? o.TIPO_SANCION : string.Empty)));
                   cmd.Parameters.Add(new SqlParameter("@Sancion", o.SANCION));
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

       public List<ClausulaE> ClausulasxContrato(int codigoContrato)
       {
           ConexionDAO cn = new ConexionDAO();
           List<ClausulaE> listClausula = new List<ClausulaE>();

           using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
           {
               try
               {
                   con.Open();

                   SqlCommand cmd = new SqlCommand("CC.USP_NROCLAUSULAS_X_CODIGO_CONTRATO", con);

                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@CodigoContrato", codigoContrato));

                   IDataReader reader = cmd.ExecuteReader();

                   while (reader.Read())
                   {
                       ClausulaE bean = new ClausulaE();
                       bean.CODIGO_CLAUSULA = reader.GetInt32(0);
                       bean.NUMERO_CLAUSULA = reader.GetInt16(1);
                       listClausula.Add(bean);
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
           return listClausula;
       }

       public ClausulaE ClausulaxCodigo(int codigoClausula)
       {

           ConexionDAO cn = new ConexionDAO();
           ClausulaE clausula = new ClausulaE();

           using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
           {
               try
               {
                   con.Open();

                   SqlCommand cmd = new SqlCommand("CC.USP_DATOS_X_CODIGO_CLAUSULA", con);

                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@CodigoClausula", codigoClausula));
                   IDataReader reader = cmd.ExecuteReader();

                   if (reader.Read())
                   {
                       clausula.CODIGO_TIPO_CLAUSULA = reader.GetInt32(0);
                       clausula.DESCRIPCION = reader.GetString(1);
                       clausula.SUJETO_PENALIDAD = reader.GetBoolean(2);
                       clausula.TIPO_SANCION = reader.GetString(3);
                       clausula.SANCION = (double)reader.GetDecimal(4);
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
           return clausula;
       }

       public List<ClausulaE> ObtenerClausulasPenalidad(string numero_contrato)
       {
           List<ClausulaE> lstClausula = new List<ClausulaE>();

           ConexionDAO cnx = new ConexionDAO();

           using (SqlConnection con = new SqlConnection(cnx.CadenaConexion()))
           {
               try
               {
                   con.Open();

                   SqlCommand cmd = new SqlCommand("CC.USP_CLAUSULA_POR_PENALIDAD_CONSULTA", con);

                   cmd.CommandType = CommandType.StoredProcedure;

                   cmd.Parameters.Add(new SqlParameter("@CODIGO_CONTRATO", numero_contrato));

                   IDataReader reader = cmd.ExecuteReader();

                   while (reader.Read())
                   {
                       ClausulaE obj = new ClausulaE();
                       obj.IdClausula = reader.GetInt32(0);
                       obj.DESCRIPCION = reader.GetString(1);
                       lstClausula.Add(obj);
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
           return lstClausula;
       }
       
    }
}
