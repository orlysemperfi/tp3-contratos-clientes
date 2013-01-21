using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades.CC;
using Entidades.CR;
using System.Data.Common;

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
          ContratoE contrato = GetInternalContrato(reader);
          listaContratos.Add(contrato);
        }
      } catch (System.Exception ex) {
        Console.WriteLine(ex.Message);
      } finally {
        sqlHelper.EndConnection();
      }
      return listaContratos;
    }

    public List<ContratoE> GetContratos(string numeroContrato, string descripcion, int codigoServicio, string cliente) {
      sqlHelper = new SqlServerHelper();
      List<ContratoE> listaContratos = new List<ContratoE>();
      List<DbParameter> listaParams = new List<DbParameter>();
      try {
        StringBuilder sql = new StringBuilder();
        sql.Append("SELECT C.*, ")
           .Append("       CLI.RAZON_SOCIAL, CLI.RUC, CLI.TIPO_CLIENTE, CLI.DIRECCION, CLI.TELEFONO, CLI.CORREO, CLI.FAX, ")
           .Append("       CLI.CONTACTO, CLI.ESTADO, CLI.FECHA_INGRESO, ")
           .Append("       SERV.DESCRIPCION AS DESCRIPCION_SERVICIO, MON.NOMBRE AS NOMBRE_MONEDA ")
           .Append("  FROM CC.CONTRATO C ")
           .Append("       INNER JOIN CR.CLIENTE CLI ON ( C.CODIGO_CLIENTE = CLI.CODIGO_CLIENTE ) ")
           .Append("       INNER JOIN CC.SERVICIO SERV ON ( C.CODIGO_SERVICIO = SERV.CODIGO_SERVICIO ) ")
           .Append("       INNER JOIN CC.MONEDA MON ON ( C.CODIGO_MONEDA = MON.CODIGO_MONEDA ) ")
           .Append(" WHERE 1 = 1 ");
        if (!string.IsNullOrEmpty(numeroContrato)) {
          sql.Append(" AND C.NUMERO_CONTRATO = @NumeroContrato ");
          listaParams.Add(new SqlParameter() {
            ParameterName = "NumeroContrato",
            DbType = System.Data.DbType.String,
            Value = numeroContrato
          });
        }
        if (!string.IsNullOrEmpty(descripcion)) {
          sql.Append(" AND C.DESCRIPCION LIKE @Descripcion ");
          listaParams.Add(new SqlParameter() {
            ParameterName = "Descripcion",
            DbType = System.Data.DbType.String,
            Value = "%" + descripcion + "%"
          });
        }
        if (codigoServicio > 0) {
          sql.Append(" AND C.CODIGO_SERVICIO = @CodigoServicio ");
          listaParams.Add(new SqlParameter() {
            ParameterName = "CodigoServicio",
            DbType = System.Data.DbType.Int32,
            Value = codigoServicio
          });
        }
        if (!string.IsNullOrEmpty(cliente)) {
          sql.Append(" AND CLI.RAZON_SOCIAL LIKE @NombreCliente ");
          listaParams.Add(new SqlParameter() {
            ParameterName = "NombreCliente",
            DbType = System.Data.DbType.String,
            Value = "%" + cliente + "%"
          });
        }
        IDataReader reader = sqlHelper.GetSqlCursor(sql.ToString(), listaParams);
        while (reader.Read()) {
          ContratoE contrato = GetInternalContrato(reader);
          listaContratos.Add(contrato);
        }
      } catch (System.Exception ex) {
        Console.WriteLine(ex.Message);
      } finally {
        sqlHelper.EndConnection();
      }
      return listaContratos;
    }

    public ContratoE GetContrato(int codigoContrato) {
      sqlHelper = new SqlServerHelper();
      try {
        StringBuilder sql = new StringBuilder();
        sql.Append("SELECT C.*, ")
           .Append("       CLI.RAZON_SOCIAL, CLI.RUC, CLI.TIPO_CLIENTE, CLI.DIRECCION, CLI.TELEFONO, CLI.CORREO, CLI.FAX, ")
           .Append("       CLI.CONTACTO, CLI.ESTADO, CLI.FECHA_INGRESO, ")
           .Append("       SERV.DESCRIPCION AS DESCRIPCION_SERVICIO, MON.NOMBRE AS NOMBRE_MONEDA ")
           .Append("  FROM CC.CONTRATO C ")
           .Append("       INNER JOIN CR.CLIENTE CLI ON ( C.CODIGO_CLIENTE = CLI.CODIGO_CLIENTE ) ")
           .Append("       INNER JOIN CC.SERVICIO SERV ON ( C.CODIGO_SERVICIO = SERV.CODIGO_SERVICIO ) ")
           .Append("       INNER JOIN CC.MONEDA MON ON ( C.CODIGO_MONEDA = MON.CODIGO_MONEDA ) ")
           .Append(" WHERE C.CODIGO_CONTRATO = @CodigoContrato ");
        List<DbParameter> listaParams = new List<DbParameter>() {
          new SqlParameter() {
            ParameterName = "CodigoContrato",
            DbType = System.Data.DbType.Int32,
            Value = codigoContrato
          }
        };
        IDataReader reader = sqlHelper.GetSqlCursor(sql.ToString(), listaParams);
        if (reader.Read()) {
          ContratoE contrato = GetInternalContrato(reader);
          return contrato;
        }
      } catch (System.Exception ex) {
        Console.WriteLine(ex.Message);
      } finally {
        sqlHelper.EndConnection();
      }
      return null;
    }

    public void ActualizarSiguienteEstado(int codigoContrato, string estado, string motivo) {
      sqlHelper = new SqlServerHelper();
      try {
        StringBuilder sql = new StringBuilder();
        List<DbParameter> listaParams = new List<DbParameter>();
        sql.Append("UPDATE CC.CONTRATO ")
           .Append("   SET ESTADO = @Estado ");
        listaParams.Add(new SqlParameter() {
          ParameterName = "Estado",
          DbType = System.Data.DbType.String,
          Value = estado
        });
        if (!string.IsNullOrEmpty(motivo)) {
          sql.Append(" , FECHA_TERMINO = @FechaTermino ")
             .Append(" , MOTIVO_TERMINO = @MotivoTermino ");
          listaParams.Add(new SqlParameter() {
            ParameterName = "FechaTermino",
            DbType = System.Data.DbType.DateTime,
            Value = DateTime.Now
          });
          listaParams.Add(new SqlParameter() {
            ParameterName = "MotivoTermino",
            DbType = System.Data.DbType.String,
            Value = motivo
          });
        }
        sql.Append(" WHERE CODIGO_CONTRATO = @CodigoContrato ");
        listaParams.Add(new SqlParameter() {
          ParameterName = "CodigoContrato",
          DbType = System.Data.DbType.Int32,
          Value = codigoContrato
        });
        sqlHelper.ExecuteSqlUpdate(sql.ToString(), listaParams);
      } catch (System.Exception ex) {
        Console.WriteLine(ex.Message);
      } finally {
        sqlHelper.EndConnection();
      }
    }

    public void ActualizarAdendasYOtros(int codigoContrato, string estado, string motivo) {
      //Invocar aqui el Stored Procedure de SQL Server
    }

    private ContratoE GetInternalContrato(IDataReader reader) {
      ContratoE contrato = new ContratoE() {
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
        contrato.FECHA_TERMINO = Convert.ToDateTime(reader["FECHA_TERMINO"].ToString());
      }
      return contrato;
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
