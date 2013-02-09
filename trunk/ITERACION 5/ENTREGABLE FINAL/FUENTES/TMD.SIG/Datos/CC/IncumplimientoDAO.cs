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
    public class IncumplimientoDAO : Datos.CC.IIncumplimientoDAO
    {
        public void Insertar(IncumplimientoE incumplimiento)
        {
            ConexionDAO cnx = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cnx.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CC.USP_INCUMPLIMIENTO_INSERTAR", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@CODIGO_CONTRATO", incumplimiento.Codigo_Contrato));
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", incumplimiento.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@FECHA", incumplimiento.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_CLAUSULA", incumplimiento.Codigo_Clausula));
                    cmd.Parameters.Add(new SqlParameter("@MONTO", incumplimiento.Monto));
                    cmd.Parameters.Add(new SqlParameter("@MOTIVO_CONCILIACION", incumplimiento.Motivo));

                    SqlParameter parCodigoIncumplimiento = new SqlParameter("@CODIGO_INCUMPLIMIENTO", SqlDbType.Int, incumplimiento.Codigo_Incumplimiento);
                    parCodigoIncumplimiento.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parCodigoIncumplimiento);

                    int response = cmd.ExecuteNonQuery();

                    incumplimiento.Codigo_Incumplimiento = Convert.ToInt32(cmd.Parameters["@CODIGO_INCUMPLIMIENTO"].Value);

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
    }
}