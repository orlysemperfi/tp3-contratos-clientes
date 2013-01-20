using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Datos {

  /// <summary>
  /// Clase que contempla las funciones necesarias para la comunicación con la base de datos.
  /// </summary>
  public abstract class DBHelper : IDisposable {

    /// <summary>
    /// Cadena de conexión genérica para el sistema
    /// </summary>
    /// <returns>Cadena de conexión</returns>
    public abstract string DBConnectionString { get; }

    /// <summary>
    /// Instancia de base de datos para el sistema
    /// </summary>
    /// <returns>Cadena de conexión</returns>
    public abstract DbConnection DBConnection { get; }

    private bool IsStartTransaction = false;
    private DbTransaction tx = null;

    #region Constructores

    public DBHelper() {
      try {
        DBConnection.Open();
      } catch (Exception ex) {
        throw ex;
      }
    }

    public DBHelper(bool isTransaccion)
      : this() {
      IsStartTransaction = isTransaccion;
      try {
        if (IsStartTransaction) {
          tx = DBConnection.BeginTransaction();
        }
      } catch (Exception ex) {
        throw ex;
      }
    }

    #endregion

    #region Metodos Publicos

    /// <summary>
    /// Función que ejecuta un Stored Procedure y devuelve una colección de datos.
    /// </summary>
    /// <param name="spName">Nombre del SP a consultar</param>
    /// <param name="listaParametros">Lista de parámetros que necesita el SP</param>
    /// <returns>Valor que indica si la consulta devuelve o no datos</returns>
    public DbDataReader GetStoredProcedureCursor(string spName, List<DbParameter> listaParametros) {
      return GetStoredProcedureCursor(spName, listaParametros, "P_CURSOR");
    }

    /// <summary>
    /// Función que ejecuta un Stored Procedure y devuelve una colección de datos.
    /// </summary>
    /// <param name="spName">Nombre del SP a consultar</param>
    /// <param name="listaParametros">Lista de parámetros que necesita el SP</param>
    /// <param name="cursorName">Nombre de la variable del cursor</param>
    /// <returns>Valor que indica si la consulta devuelve o no datos</returns>
    public DbDataReader GetStoredProcedureCursor(string spName, List<DbParameter> listaParametros, string cursorName) {
      DbDataReader resultado = null;
      DbCommand cm = null;
      try {
        cm = DBConnection.CreateCommand();
        if (IsStartTransaction) {
          cm.Transaction = tx;
        }
        cm.CommandText = spName;
        cm.CommandType = CommandType.StoredProcedure;
        AddCursorParameter(listaParametros, cursorName);
        cm.Parameters.AddRange(listaParametros.ToArray());
        cm.ExecuteNonQuery();
        if (IsStartTransaction) {
          cm.Transaction.Commit();
        }
        resultado = (DbDataReader)cm.Parameters[cursorName].Value;
      } catch (Exception ex) {
        if (IsStartTransaction) {
          cm.Transaction.Rollback();
        }
        throw ex;
      } finally {
        if (cm != null) {
          cm.Dispose();
          cm = null;
        }
      }
      return resultado;
    }

    /// <summary>
    /// Función encargada de recuperar valores de un Stored Procedure
    /// </summary>
    /// <param name="spName">nombre del sp</param>
    /// <param name="listaParametros">lista de parametros que necesita el SP</param>
    /// <param name="paramOutNames">Nombres de los parámetros de salida</param>
    /// <returns>Valor de los elementos recuperados</returns>
    public object[] GetStoredProcedureValues(string spName, List<DbParameter> listaParametros, string[] paramOutNames) {
      return GetStoredProcedureValues(spName, listaParametros, paramOutNames, null);
    }

    /// <summary>
    /// Función encargada de recuperar valores de un Stored Procedure
    /// </summary>
    /// <param name="spName">nombre del sp</param>
    /// <param name="listaParametros">lista de parametros que necesita el sp</param>
    /// <param name="paramOutNames">Nombres de los parámetros de salida</param>
    /// <param name="tamanos">Tamaño del parámetro (en caso sea una cadena)</param>
    /// <returns>Valor de los elementos recuperados</returns>
    public object[] GetStoredProcedureValues(string spName, List<DbParameter> listaParametros, string[] paramOutNames, int[] tamanos) {
      object[] resultado = new object[paramOutNames.Length];
      DbCommand cm = null;
      try {
        cm = DBConnection.CreateCommand();
        if (IsStartTransaction) {
          cm.Transaction = tx;
        }
        cm.CommandText = spName;
        cm.CommandType = CommandType.StoredProcedure;
        cm.Parameters.AddRange(listaParametros.ToArray());
        if (tamanos != null) {
          for (int i = 0; i < paramOutNames.Length; i++) {
            cm.Parameters[paramOutNames[i]].Size = tamanos[i];
          }
        }
        cm.ExecuteNonQuery();
        for (int i = 0; i < paramOutNames.Length; i++) {
          resultado[i] = cm.Parameters[paramOutNames[i]].Value;
        }
        if (IsStartTransaction) {
          cm.Transaction.Commit();
        }
      } catch (Exception ex) {
        if (IsStartTransaction) {
          cm.Transaction.Rollback();
        }
        throw ex;
      } finally {
        if (cm != null) {
          cm.Dispose();
          cm = null;
        }
      }
      return resultado;
    }

    /// <summary>
    /// Función que servirá para modificar y eliminar registros de la base de datos.
    /// </summary>
    /// <param name="spName">nombre del sp que se ejecutara</param>
    /// <param name="listaParametros">lista de parametros que usa el sp</param>
    /// <returns>una var bool que indica si se ejecuto alqun registro o no</returns>
    public void ExecuteVoidStoredProcedure(string spName, List<DbParameter> listaParametros) {
      DbCommand cm = null;
      try {
        cm = DBConnection.CreateCommand();
        if (IsStartTransaction) {
          cm.Transaction = tx;
        }
        cm.CommandText = spName;
        cm.CommandType = CommandType.StoredProcedure;
        cm.Parameters.AddRange(listaParametros.ToArray());
        cm.ExecuteNonQuery();
        if (IsStartTransaction) {
          cm.Transaction.Commit();
        }
      } catch (Exception ex) {
        if (IsStartTransaction) {
          cm.Transaction.Rollback();
        }
        throw ex;
      } finally {
        if (cm != null) {
          cm.Dispose();
          cm = null;
        }
      }
    }

    /// <summary>
    /// Función que ejecuta una sentencia directa de SQL.
    /// </summary>
    /// <param name="SQL">Consulta SQL a ejecutarse.</param>
    /// <returns>Colección de datos resultado de la consulta.</returns>
    public DbDataReader GetSqlCursor(string SQL) {
      return GetSqlCursor(SQL, null);
    }

    /// <summary>
    /// Función que ejecuta una sentencia directa de SQL (con parametros).
    /// </summary>
    /// <param name="SQL">Consulta SQL a ejecutarse.</param>
    /// <returns>Colección de datos resultado de la consulta.</returns>
    public DbDataReader GetSqlCursor(string SQL, List<DbParameter> listaParametros) {
      DbDataReader resultado = null;
      DbCommand cm = null;
      try {
        cm = DBConnection.CreateCommand();
        if (IsStartTransaction) {
          cm.Transaction = tx;
        }
        cm.CommandText = SQL;
        cm.CommandType = CommandType.Text;
        if (listaParametros != null) {
          cm.Parameters.AddRange(listaParametros.ToArray());
        }
        resultado = cm.ExecuteReader();
        if (IsStartTransaction) {
          cm.Transaction.Commit();
        }
      } catch (Exception ex) {
        if (IsStartTransaction) {
          cm.Transaction.Rollback();
        }
        throw ex;
      } finally {
        if (cm != null) {
          cm.Dispose();
          cm = null;
        }
      }
      return resultado;
    }

    public void ExecuteSqlUpdate(string SQL) {
      ExecuteSqlUpdate(SQL, null);
    }

    /// <summary>
    /// Función que ejecuta una sentencia directa de SQL (con parametros).
    /// </summary>
    /// <param name="SQL">Consulta SQL a ejecutarse.</param>
    /// <returns>Colección de datos resultado de la consulta.</returns>
    public void ExecuteSqlUpdate(string SQL, List<DbParameter> listaParametros) {
      DbCommand cm = null;
      try {
        cm = DBConnection.CreateCommand();
        if (IsStartTransaction) {
          cm.Transaction = tx;
        }
        cm.CommandText = SQL;
        cm.CommandType = CommandType.Text;
        if (listaParametros != null) {
          cm.Parameters.AddRange(listaParametros.ToArray());
        }
        cm.ExecuteNonQuery();
        if (IsStartTransaction) {
          cm.Transaction.Commit();
        }
      } catch (Exception ex) {
        if (IsStartTransaction) {
          cm.Transaction.Rollback();
        }
        throw ex;
      } finally {
        if (cm != null) {
          cm.Dispose();
          cm = null;
        }
      }
    }

    /// <summary>
    /// Función encargada de cerrar la conexión
    /// </summary>
    public void EndConnection() {
      EndConnection(false);
    }

    /// <summary>
    /// Función encargada de cerrar la conexión
    /// </summary>
    public void EndConnection(bool isErrores) {
      CloseTransaction(isErrores);
      Dispose();
    }

    /// <summary>
    /// Función encargada de cerrar la transacción
    /// </summary>
    public void CloseTransaction(bool isErrores) {
      if (tx != null) {
        tx.Dispose();
        tx = null;
      }
    }

    public void Dispose() {
      if (DBConnection != null) {
        DBConnection.Close();
        DBConnection.Dispose();
      }
    }

    #endregion

    #region Metodos Abstractos

    protected abstract void AddCursorParameter(List<DbParameter> listaParametros, string cursorName);

    #endregion

  }

}