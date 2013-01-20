using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades.CC;
using Entidades.CR;

namespace Datos.CC {

  public class SqlServerServicioDAO : IServicioDAO {

    private SqlServerHelper sqlHelper = null;

    public SqlServerServicioDAO() {
      //
    }

    public List<ServicioE> GetServicios() {
      sqlHelper = new SqlServerHelper();
      List<ServicioE> listaServicios = new List<ServicioE>();
      try {
        StringBuilder sql = new StringBuilder();
        sql.Append("SELECT S.*, ")
           .Append("       LS.DESCRIPCION AS DESCRIPCION_LINEA_SERVICIO ")
           .Append("  FROM CC.SERVICIO S ")
           .Append("       INNER JOIN CC.LINEA_SERVICIO LS ON ( S.CODIGO_LINEA_SERVICIO = LS.CODIGO_LINEA_SERVICIO ) ");
        IDataReader reader = sqlHelper.GetSqlCursor(sql.ToString());
        while (reader.Read()) {
          ServicioE bean = new ServicioE() {
            CODIGO_SERVICIO = Convert.ToInt32(reader["CODIGO_SERVICIO"]),
            DESCRIPCION = reader["DESCRIPCION"].ToString(),
            LineaServicio = new LineaServicioE() {
              CODIGO_LINEA_SERVICIO = Convert.ToInt32(reader["CODIGO_LINEA_SERVICIO"]),
              DESCRIPCION = reader["DESCRIPCION_LINEA_SERVICIO"].ToString()
            }
          };
          listaServicios.Add(bean);
        }
      } catch (System.Exception ex) {
        Console.WriteLine(ex.Message);
      } finally {
        sqlHelper.EndConnection();
      }
      return listaServicios;
    }

  }

}
