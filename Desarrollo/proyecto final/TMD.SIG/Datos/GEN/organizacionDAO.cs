using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.GEN;
using System.Data;
using System.Data.SqlClient;


namespace Datos.GEN
{
    public class OrganizacionDAO: IOrganizacionDAO
    {

        public void Insert(OrganizacionE o)
        {

            ConexionDAO cn = new ConexionDAO();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("GEN.ORGANIZACION_INS", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Codigo", o.codigoOrganizacion));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", o.nombre));
                    cmd.Parameters.Add(new SqlParameter("@Mision", o.mision));
                    cmd.Parameters.Add(new SqlParameter("@Vision", o.vision));

                    int response = cmd.ExecuteNonQuery();

                    cmd.Dispose();
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally {
                    con.Close();
                }
            }
        }



        public List<OrganizacionE> listAll()
        {
            ConexionDAO cn = new ConexionDAO();
            List<OrganizacionE> listOrg = new List<OrganizacionE>();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("GEN.LISTARORGANIZACION", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    IDataReader reader = cmd.ExecuteReader();

                    while(reader.Read()){
                        OrganizacionE bean = new OrganizacionE();
                        bean.codigoOrganizacion = reader.GetString(0);
                        bean.nombre = reader.GetString(1);
                        bean.vision = reader.GetString(2);
                        bean.mision = reader.GetString(3);
                        listOrg.Add(bean);
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
            return listOrg;
        }
    }
}
