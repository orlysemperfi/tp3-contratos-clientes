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

  public class SqlServerAdendaDAO : IAdendaDAO {

    private IContratoDAO contratoDao = new SqlServerContratoDAO();
    private SqlServerHelper sqlHelper = null;

    public SqlServerAdendaDAO() {
      //
    }

    public List<AdendaE> GetAdendas() {
      sqlHelper = new SqlServerHelper();
      List<AdendaE> listaAdendas = new List<AdendaE>();
      try {
        StringBuilder sql = new StringBuilder();
        sql.Append("SELECT A.* ")
           .Append("  FROM CC.ADDENDA A ");
        IDataReader reader = sqlHelper.GetSqlCursor(sql.ToString());
        while (reader.Read()) {
          AdendaE adenda = GetInternalAdenda(reader);
          listaAdendas.Add(adenda);
        }
      } catch (System.Exception ex) {
        Console.WriteLine(ex.Message);
      } finally {
        sqlHelper.EndConnection();
      }
      return listaAdendas;
    }

    public List<AdendaE> GetAdendas(string numeroContrato, string numeroAdenda, int codigoServicio, string cliente) {
      sqlHelper = new SqlServerHelper();
      List<AdendaE> listaAdendas = new List<AdendaE>();
      List<DbParameter> listaParams = new List<DbParameter>();
      try {
        StringBuilder sql = new StringBuilder();
        sql.Append("SELECT A.* ")
           .Append("  FROM CC.ADDENDA A ")
           .Append("       INNER JOIN CC.CONTRATO C ON ( A.CODIGO_CONTRATO = C.CODIGO_CONTRATO ) ")
           .Append("       INNER JOIN CR.CLIENTE CLI ON ( C.CODIGO_CLIENTE = CLI.CODIGO_CLIENTE ) ")
           .Append("       INNER JOIN CC.SERVICIO SERV ON ( C.CODIGO_SERVICIO = SERV.CODIGO_SERVICIO ) ")
           .Append(" WHERE 1 = 1 ");
        if (!string.IsNullOrEmpty(numeroContrato)) {
          sql.Append(" AND C.NUMERO_CONTRATO = @NumeroContrato ");
          listaParams.Add(new SqlParameter() {
            ParameterName = "NumeroContrato",
            DbType = System.Data.DbType.String,
            Value = numeroContrato
          });
        }
        if (!string.IsNullOrEmpty(numeroAdenda)) {
          sql.Append(" AND A.NUMERO_ADDENDA = @NumeroAdenda ");
          listaParams.Add(new SqlParameter() {
            ParameterName = "NumeroAdenda",
            DbType = System.Data.DbType.String,
            Value = numeroAdenda
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
          AdendaE adenda = GetInternalAdenda(reader);
          listaAdendas.Add(adenda);
        }
      } catch (System.Exception ex) {
        Console.WriteLine(ex.Message);
      } finally {
        sqlHelper.EndConnection();
      }
      return listaAdendas;
    }

    public AdendaE GetAdenda(int codigoAdenda) {
      sqlHelper = new SqlServerHelper();
      try {
        StringBuilder sql = new StringBuilder();
        sql.Append("SELECT A.* ")
           .Append("  FROM CC.ADDENDA A ")
           .Append(" WHERE A.CODIGO_ADDENDA = @CodigoAdenda ");
        List<DbParameter> listaParams = new List<DbParameter>() {
          new SqlParameter() {
            ParameterName = "CodigoAdenda",
            DbType = System.Data.DbType.Int32,
            Value = codigoAdenda
          }
        };
        IDataReader reader = sqlHelper.GetSqlCursor(sql.ToString(), listaParams);
        if (reader.Read()) {
          AdendaE adenda = GetInternalAdenda(reader);
          return adenda;
        }
      } catch (System.Exception ex) {
        Console.WriteLine(ex.Message);
      } finally {
        sqlHelper.EndConnection();
      }
      return null;
    }

    public void ActualizarSiguienteEstado(int codigoAdenda, string estado) {
      sqlHelper = new SqlServerHelper();
      try {
        StringBuilder sql = new StringBuilder();
        List<DbParameter> listaParams = new List<DbParameter>();
        sql.Append("UPDATE CC.ADDENDA ")
           .Append("   SET ESTADO = @Estado ");
        listaParams.Add(new SqlParameter() {
          ParameterName = "Estado",
          DbType = System.Data.DbType.String,
          Value = estado
        });
        sql.Append(" WHERE CODIGO_ADDENDA = @CodigoAdenda ");
        listaParams.Add(new SqlParameter() {
          ParameterName = "CodigoAdenda",
          DbType = System.Data.DbType.Int32,
          Value = codigoAdenda
        });
        sqlHelper.ExecuteSqlUpdate(sql.ToString(), listaParams);
      } catch (System.Exception ex) {
        Console.WriteLine(ex.Message);
      } finally {
        sqlHelper.EndConnection();
      }
    }

    private AdendaE GetInternalAdenda(IDataReader reader) {
      AdendaE adenda = new AdendaE() {
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
