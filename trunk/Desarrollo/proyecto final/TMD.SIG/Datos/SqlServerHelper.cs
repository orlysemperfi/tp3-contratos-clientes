using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Datos {

  /// <summary>
  /// Clase que contempla las funciones necesarias para la comunicación con la base de datos (SQL Server).
  /// </summary>
  public class SqlServerHelper : DBHelper {

    private SqlConnection cn = null;

    public override string DBConnectionString {
      get {
        return ConfigurationManager.ConnectionStrings["TMD_DB_Connection_1"].ConnectionString;
      }
    }

    /// <summary>
    /// Instancia de base de datos para el sistema (SQL Server)
    /// </summary>
    /// <returns>Cadena de conexión</returns>
    public override DbConnection DBConnection {
      get {
        if (cn == null) {
          cn = new SqlConnection(DBConnectionString);
        }
        return cn;
      }
    }

    /// <summary>
    /// Función encargada de recuperar valores de un Stored Procedure
    /// </summary>
    /// <param name="spName">nombre del Stored Procedure</param>
    /// <param name="listaParametros">lista de parametros que necesita el Stored Procedure</param>
    /// <param name="paramOutNames">Nombres de los parámetros de salida</param>
    /// <param name="paramOutTypes">Tipos de los parámetros de salida</param>
    /// <returns>Valor de los elementos recuperados</returns>
    public object[] GetStoredProcedureValues(string spName, string[] paramOutNames, SqlDbType[] paramOutTypes, List<DbParameter> listaParametros) {
      try {
        for (int i = 0; i < paramOutNames.Length; i++) {
          string paramOutName = paramOutNames[i];
          if (paramOutName != null && !paramOutName.Equals("")) {
            listaParametros.Add(new SqlParameter() {
              Direction = System.Data.ParameterDirection.Output,
              SqlDbType = paramOutTypes[i],
              ParameterName = paramOutName
            });
          }
        }
        return base.GetStoredProcedureValues(spName, listaParametros, paramOutNames);
      } catch (Exception ex) {
        throw ex;
      }
    }

    /// <summary>
    /// Función encargada de agregar el parámetro cursor en el Stored Procedure
    /// </summary>
    /// <param name="listaParametros">lista de parametros que necesita el Stored Procedure</param>
    /// <param name="cursorName">Nombre del cursor a ser adicionado</param>
    protected override void AddCursorParameter(List<DbParameter> listaParametros, string cursorName) {
      bool isCursorNameFound = false;
      foreach (DbParameter parametro in listaParametros) {
        if (parametro.ParameterName.Equals(cursorName)) {
          isCursorNameFound = true;
          break;
        }
      }
      if (!isCursorNameFound) {
        listaParametros.Add(new SqlParameter() {
          Direction = System.Data.ParameterDirection.Output,
          SqlDbType = SqlDbType.Variant,
          ParameterName = cursorName
        });
      }
    }

  }

}