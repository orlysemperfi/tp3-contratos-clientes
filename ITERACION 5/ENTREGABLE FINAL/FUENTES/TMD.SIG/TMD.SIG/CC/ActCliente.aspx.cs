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
    public partial class ActCliente : System.Web.UI.Page
    {
        List<ClienteE> listaOP;

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

            IClienteBL clsVenta = new ClienteBL();

            listaOP = new List<ClienteE>();

            listaOP = clsVenta.Cliente_Lista(txtRazonSocial.Text, txtRucConsulta.Text);

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
                Session["ActualizaCliente"] = listaOP;
                grvOportunidad.DataBind();
            }
        }


        protected void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            OventaBL oventaBL = new OventaBL();
            //ClienteE oventaE = new ClienteE();
            ClienteBL clienteBL = new ClienteBL();
            ClienteE clienteE = new ClienteE();
            listaOP = new List<ClienteE>();

            listaOP = (List<ClienteE>)HttpContext.Current.Session["ActualizaCliente"];
            foreach (ClienteE oventaE in listaOP)
            {
                if (oventaE.RUC == txtRuc.Text)
                {
                    clienteE.RUC = txtRuc.Text;
                    clienteE.RAZON_SOCIAL = txtRazSocialO.Text;
                    clienteE.CONTACTO = txtContactoAct.Text;
                    clienteE.CORREO = txtCorreoAct.Text;
                    clienteE.TELEFONO = txtTelefonoAct.Text;
                    clienteE.FAX = txtFaxAct.Text;
                    clienteE.DIRECCION = txtDireccionAct.Text;

                    clienteE.CODIGO_CLIENTE =Int32.Parse(txtCodCliente.Value);
                    clienteE.TIPO_CLIENTE = ddlTipoCliente.SelectedItem.Value;
                    //if(ddlTipoCliente.Text=="Privada"){
                    //    clienteE.TipoCliente = "P";
                    //}else{
                    //    clienteE.TipoCliente = "E";
                    //}
                    clienteE.ESTADO = rbtnEstado.Checked;

                    clienteBL.actualizar(clienteE);
                }

            }

            LimpiarControles();
            showMessage("Datos del cliente actualizado correctamente");
            cargarDatosIniciales();
            pnlContrato.Visible = true;
            pnlOportunidadVenta.Visible = false;
        }

        private void LimpiarControles()
        {
            txtRazSocialO.Text = string.Empty;
            txtRuc.Text = string.Empty;
            txtTelefonoAct.Text = string.Empty;
            txtDireccionAct.Text = string.Empty;
            txtCorreoAct.Text = string.Empty;
            txtContactoAct.Text = string.Empty;
            txtFaxAct.Text = string.Empty;
            
            //rbtnEstado.Enabled = true;
            Session["ActualizaCliente"] = null;
            grvOportunidad.DataSource = null;
            grvOportunidad.DataBind();
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlContrato.Visible = true;
            pnlOportunidadVenta.Visible = false;
        }

        //protected void rbtnEstado_CheckedChanged(object sender, EventArgs e)
        //{
        //    if(rbtnEstado.Checked==true){
        //        rbtnEstado.Checked = false;
        //    }
        //    else{
        //        rbtnEstado.Checked = true;
        //    }            
        //}
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
            listaOP = new List<ClienteE>();
            pnlOportunidadVenta.Visible = true;
            pnlContrato.Visible = false;

            if (Session["ActualizaCliente"] != null)
            {
                listaOP = (List<ClienteE>)HttpContext.Current.Session["ActualizaCliente"];
                foreach (ClienteE clienteE in listaOP)
                {
                    if (clienteE.RUC == nro_ruc)
                    {
                        txtCodCliente.Value = clienteE.CODIGO_CLIENTE.ToString();
                        txtRazSocialO.Text = clienteE.RAZON_SOCIAL;
                        txtRuc.Text = clienteE.RUC;
                        ddlTipoCliente.SelectedValue = clienteE.TIPO_CLIENTE;
                        //if (clienteE.TipoCliente == "P")
                        //{
                        //    ddlTipoCliente.SelectedValue="Privada";
                        //}
                        //else { 
                        //    ddlTipoCliente.SelectedValue="Pública";
                        //}

                        txtDireccionAct.Text = clienteE.DIRECCION;  
                        txtTelefonoAct.Text = clienteE.TELEFONO;
                        txtContactoAct.Text = clienteE.CONTACTO;
                        txtFaxAct.Text = clienteE.FAX;
                        txtCorreoAct.Text = clienteE.CORREO;
                        rbtnEstado.Checked = clienteE.ESTADO;
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

            IClienteBL clsVenta = new ClienteBL();

            listaOP = new List<ClienteE>();

            listaOP = clsVenta.Cliente_Lista(txtRazonSocial.Text, txtRucConsulta.Text);

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