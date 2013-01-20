using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades.CC;
using Entidades.CR;

namespace Datos.CC {

  public class SqlServerContratoDAO : IContratoDAO {

    private SqlServerHelper sqlHelper = null;

    public SqlServerContratoDAO() {
      //
    }

    public List<ContratoE> GetContratos() {
      sqlHelper = new SqlServerHelper();
      List<ContratoE> listaContratos = new List<ContratoE>();
      try {
        StringBuilder sql = new StringBuilder();
        sql.Append("SELECT C.*, ")
           .Append("       CLI.RAZON_SOCIAL, CLI.RUC, CLI.TIPO_CLIENTE, CLI.DIRECCION, CLI.TELEFONO, CLI.CORREO, CLI.FAX, ")
           .Append("       CLI.CONTACTO, CLI.ESTADO, CLI.FECHA_INGRESO, ")
           .Append("       SERV.DESCRIPCION AS DESCRIPCION_SERVICIO, MON.NOMBRE AS NOMBRE_MONEDA ")
           .Append("  FROM CC.CONTRATO C ")
           .Append("       INNER JOIN CR.CLIENTE CLI ON ( C.CODIGO_CLIENTE = CLI.CODIGO_CLIENTE ) ")
           .Append("       INNER JOIN CC.SERVICIO SERV ON ( C.CODIGO_SERVICIO = SERV.CODIGO_SERVICIO ) ")
           .Append("       INNER JOIN CC.MONEDA MON ON ( C.CODIGO_MONEDA = MON.CODIGO_MONEDA ) ");
        IDataReader reader = sqlHelper.GetSqlCursor(sql.ToString());
        while (reader.Read()) {
          ContratoE bean = new ContratoE() {
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
            Cliente = new ClienteE() {
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
            Servicio = new ServicioE() {
              CODIGO_SERVICIO = Convert.ToInt32(reader["CODIGO_SERVICIO"]),
              DESCRIPCION = reader["DESCRIPCION_SERVICIO"].ToString()
            },
            Moneda = new MonedaE() {
              CODIGO_MONEDA = reader["CODIGO_MONEDA"].ToString(),
              NOMBRE = reader["NOMBRE_MONEDA"].ToString()
            }
          };
          if (reader["FECHA_TERMINO"] != DBNull.Value) {
            bean.FECHA_TERMINO = Convert.ToDateTime(reader["FECHA_TERMINO"].ToString());
          }
          listaContratos.Add(bean);
        }
      } catch (System.Exception ex) {
        Console.WriteLine(ex.Message);
      } finally {
        sqlHelper.EndConnection();
      }
      return listaContratos;
    }

    //public void Insert(OrganizacionE o) {

    //  ConexionDAO cn = new ConexionDAO();

    //  using (SqlConnection con = new SqlConnection(cn.CadenaConexion())) {
    //    try {
    //      con.Open();

    //      SqlCommand cmd = new SqlCommand("GEN.ORGANIZACION_INS", con);

    //      cmd.CommandType = CommandType.StoredProcedure;

    //      cmd.Parameters.Add(new SqlParameter("@Codigo", o.codigoOrganizacion));
    //      cmd.Parameters.Add(new SqlParameter("@Nombre", o.nombre));
    //      cmd.Parameters.Add(new SqlParameter("@Mision", o.mision));
    //      cmd.Parameters.Add(new SqlParameter("@Vision", o.vision));

    //      int response = cmd.ExecuteNonQuery();

    //      cmd.Dispose();
    //    } catch (System.Exception ex) {
    //      Console.WriteLine(ex.Message);
    //    } finally {
    //      con.Close();
    //    }
    //  }
    //}

  }

}
