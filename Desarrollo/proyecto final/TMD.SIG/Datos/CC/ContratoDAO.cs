using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Entidades.CC;
using System.Data.SqlClient;


namespace Datos.CC
{
    public class ContratoDAO: IContratoDAO
    {
        public List<ContratoE> GetContratos()
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerSQL"].ConnectionString);

        return new List<ContratoE>();
        }
    }
}
