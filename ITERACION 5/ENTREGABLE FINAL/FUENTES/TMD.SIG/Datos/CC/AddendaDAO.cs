using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Datos.GEN;
using Entidades.CC;
using System.Data.Common;

namespace Datos.CC
{
    public class AddendaDAO : Datos.CC.IAddendaDAO
    {
        public void Insert(AddendaE o)
        {

            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_ADDENDA_INS", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@CodigoContrato", o.CODIGO_CONTRATO));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", o.DESCRIPCION));
                    cmd.Parameters.Add(new SqlParameter("@CodigoAddenda",0));
                    cmd.Parameters.Add(new SqlParameter("@NumeroAddenda", string.Empty));
                    cmd.Parameters["@CodigoAddenda"].Direction = ParameterDirection.Output;
                    cmd.Parameters["@NumeroAddenda"].Direction = ParameterDirection.Output;

                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        o.CODIGO_ADDENDA = Convert.ToInt32(cmd.Parameters["@CodigoAddenda"].Value);
                        o.NUMERO_ADDENDA = Convert.ToString(cmd.Parameters["@NumeroAddenda"].Value);
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
        }

        private IContratoDAO contratoDao = new ContratoDAO();

         public AddendaDAO() {
      //
    }

         public List<AddendaE> GetAdendas()
         {
             ConexionDAO cn = new ConexionDAO();
             List<AddendaE> listaAdendas = new List<AddendaE>();

             using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
             {
                 try
                 {
                     con.Open();

                     SqlCommand cmd = new SqlCommand("CC.USP_ADDENDA_ALL", con);

                     cmd.CommandType = CommandType.StoredProcedure;
                     IDataReader reader = cmd.ExecuteReader();

                     while (reader.Read())
                     {
                         AddendaE adenda = GetInternalAdenda(reader);
                         listaAdendas.Add(adenda);
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
             return listaAdendas;
         }

         public List<AddendaE> GetAdendas(string numeroContrato, string numeroAdenda, int codigoServicio)
         {
             ConexionDAO cn = new ConexionDAO();
             List<AddendaE> listAddendas = new List<AddendaE>();

             using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
             {
                 try
                 {
                     con.Open();

                     SqlCommand cmd = new SqlCommand("CC.USP_ADDENDA_X_CONTRATO_ADDENDA_SERVICIO", con);

                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.Add(new SqlParameter("@NumeroContrato", numeroContrato));
                     cmd.Parameters.Add(new SqlParameter("@NumeroAddenda", numeroAdenda));
                     cmd.Parameters.Add(new SqlParameter("@CodigoServicio", codigoServicio));

                     IDataReader reader = cmd.ExecuteReader();

                     while (reader.Read())
                     {
                         AddendaE adenda = GetInternalAdenda(reader);
                        listAddendas.Add(adenda);
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
             return listAddendas;
         }

         public AddendaE GetAdenda(int codigoAdenda) 
         {
             ConexionDAO cn = new ConexionDAO();
             AddendaE Addenda=new AddendaE();
             bool ExisteAddenda=false;

             using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
             {
                 try
                 {
                     con.Open();

                     SqlCommand cmd = new SqlCommand("CC.USP_ADDENDA_X_CODIGO", con);

                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.Add(new SqlParameter("@CodigoAddenda", codigoAdenda));

                     IDataReader reader = cmd.ExecuteReader();

                     while (reader.Read())
                     {
                         Addenda = GetInternalAdenda(reader);
                         ExisteAddenda = true;
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
             if (ExisteAddenda) return Addenda;
             else return null;
         }

         public void ActualizarSiguienteEstado(int codigoAdenda, string estado) 
         {

             ConexionDAO cn = new ConexionDAO();

             using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
             {
                 try
                 {
                     con.Open();

                     SqlCommand cmd = new SqlCommand("CC.USP_ADDENDA_UPD_ESTADO", con);

                     cmd.CommandType = CommandType.StoredProcedure;

                     cmd.Parameters.Add(new SqlParameter("@CodigoAddenda", codigoAdenda));
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

    private AddendaE GetInternalAdenda(IDataReader reader) {
      AddendaE adenda = new AddendaE() {
        CODIGO_ADDENDA = Convert.ToInt32(reader["CODIGO_ADDENDA"]),
        NUMERO_ADDENDA = reader["NUMERO_ADDENDA"].ToString(),
        DESCRIPCION = reader["DESCRIPCION"].ToString(),
        FECHA_REGISTRO = Convert.ToDateTime(reader["FECHA_REGISTRO"].ToString()),
        ESTADO = reader["ESTADO"].ToString()
      };
      adenda.Contrato = contratoDao.GetContrato(int.Parse(reader["CODIGO_CONTRATO"].ToString()));
      return adenda;
    }
    }
}
