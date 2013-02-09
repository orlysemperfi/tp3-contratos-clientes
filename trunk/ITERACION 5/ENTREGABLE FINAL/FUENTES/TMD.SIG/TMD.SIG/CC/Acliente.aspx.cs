using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.CC;
using Entidades.CC;

namespace TMD.SIG.CC
{
    public partial class Acliente : System.Web.UI.Page
    {
        List<OventaE> listaOP;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlTipoCliente.Items.Insert(0, new ListItem("Público", "P"));
                ddlTipoCliente.Items.Insert(1, new ListItem("Privado", "R"));
                cargarDatosIniciales();
            }

        }
        protected void cargarDatosIniciales()
        {
            //ddlTipoCliente.Items.Add("Pública");
            //ddlTipoCliente.Items.Add("Privada");


            IOventaBL clsVenta = new OventaBL();

            listaOP = new List<OventaE>();

            listaOP = clsVenta.Oventa_Lista(txtRazonSocial.Text, txtRucConsulta.Text);

            if (listaOP.Count == 0)
            {
                if (Page.IsPostBack)
                showMessage("Cliente no registrado");
                grvOportunidad.DataSource = null;
                grvOportunidad.DataBind();
            }
            else
            {
                grvOportunidad.DataSource = listaOP;
                Session["AgregaCliente"] = listaOP;
                grvOportunidad.DataBind();
            }
        }


        protected void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {      }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            OventaBL oventaBL = new OventaBL();
            ClienteBL clienteBL = new ClienteBL();
            ClienteE clienteE = new ClienteE();
            listaOP = new List<OventaE>();

            listaOP = (List<OventaE>)HttpContext.Current.Session["AgregaCliente"];
            foreach (OventaE oventaE in listaOP)
            {
                if (oventaE.RUC == txtRuc.Text)
                {
                    clienteE.RAZON_SOCIAL = oventaE.RAZON_SOCIAL;
                    clienteE.RUC = oventaE.RUC;
                    clienteE.TIPO_CLIENTE = ddlTipoCliente.SelectedItem.Value;
                    clienteE.DIRECCION = oventaE.DIRECCION;
                    clienteE.TELEFONO = oventaE.TELEFONO;
                    clienteE.CORREO = oventaE.CORREO;
                    clienteE.FAX = txtFax.Text;
                    clienteE.CONTACTO = oventaE.CONTACTO;
                    clienteE.ESTADO = rbtnEstado.Checked;
                    clienteBL.insertar(clienteE);
                }

            }

            LimpiarControles();
            showMessage("Cliente agregado correctamente");
            cargarDatosIniciales();
            pnlContrato.Visible = true;
            pnlOportunidadVenta.Visible = false;
        }

        private void LimpiarControles()
        {
            txtRazSocialO.Text = string.Empty;
            txtRuc.Text = string.Empty;
            txtRubro.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtContaco.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtCargo.Text = string.Empty;
            rbtnEstado.Enabled = true;
           // ddlTipoCliente.SelectedValue = "Privada";

            Session["AgregaCliente"] = null;

            grvOportunidad.DataSource = null;
            grvOportunidad.DataBind();
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlContrato.Visible = true;
            pnlOportunidadVenta.Visible = false;
        }

        protected String getContentCellGridView(GridView grid, int index)
        {
            try
            {
                return grid.DataKeys[grid.SelectedIndex].Values[index].ToString();
            }
            catch
            {
            }
            return string.Empty;
        }
        protected void grvOportunidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nro_ruc = getContentCellGridView(grvOportunidad, 0);
            listaOP = new List<OventaE>();
            pnlOportunidadVenta.Visible = true;
            pnlContrato.Visible = false;

            if (Session["AgregaCliente"] != null)
            {
                listaOP = (List<OventaE>)HttpContext.Current.Session["AgregaCliente"];
                foreach (OventaE oventaE in listaOP)
                {
                    if (oventaE.RUC == nro_ruc)
                    {
                        txtRazSocialO.Text = oventaE.RAZON_SOCIAL;
                        txtRuc.Text = oventaE.RUC;
                        txtRubro.Text = oventaE.RUBRO;
                        txtCargo.Text = oventaE.CARGO;
                        txtContaco.Text = oventaE.CONTACTO;
                        txtTelefono.Text = oventaE.TELEFONO;
                        txtCorreo.Text = oventaE.CORREO;
                        txtDireccion.Text = oventaE.DIRECCION;

                        //showMessage("Datos:" + oventaE.RAZON_SOCIAL);
                        //Session["AgregaCliente"] = listaOP;
                        break;
                    }
                }

            }


        }
        protected void showMessage(string mensaje)
        {
            //string script = @"<script type='text/javascript'> alert('" + mensaje + "');</script>";
            //Page.RegisterClientScriptBlock("alerta", script);

            string Clientescript = ("<script>alert(\'" + mensaje + "\')</script>");
            if (!ClientScript.IsClientScriptBlockRegistered("WMensaje"))
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "WMensaje", Clientescript);
            }
        }
        /*protected void showMessageConf(string mensaje)
        {
            string script = @"<script type='text/javascript'> alert('" + mensaje + "');</script>";
            Page.RegisterClientScriptBlock(   ("alerta", script);
        }*/
        protected void btnBuscarCliente_Click1(object sender, EventArgs e)
        {

            IOventaBL clsVenta = new OventaBL();

            listaOP = new List<OventaE>();

            listaOP = clsVenta.Oventa_Lista(txtRazonSocial.Text, txtRucConsulta.Text);

            if (listaOP.Count == 0)
            {
                showMessage("Cliente no registrado");
                grvOportunidad.DataSource = null;
                grvOportunidad.DataBind();
            }
            else
            {
                grvOportunidad.DataSource = listaOP;
                grvOportunidad.DataBind();
            }

        }

    }
}