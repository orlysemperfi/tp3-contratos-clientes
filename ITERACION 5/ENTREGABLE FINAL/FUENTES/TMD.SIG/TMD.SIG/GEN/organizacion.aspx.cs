using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Generico;
using Entidades.GEN;

namespace TMD.SIG.GEN
{
    public partial class organizacion : System.Web.UI.Page
    {
        private IOrganizacionBL orgBL = new OrganizacionBL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            OrganizacionE o = new OrganizacionE();
            o.codigoOrganizacion = txtCodigo.Text;
            o.nombre = txtNombre.Text;
            o.mision = txtMision.Text;
            o.vision = txtVision.Text;

            orgBL.insertar(o);

        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            this.GridView1.DataSource = orgBL.listAll();
            this.GridView1.DataBind();
        }
    }
}