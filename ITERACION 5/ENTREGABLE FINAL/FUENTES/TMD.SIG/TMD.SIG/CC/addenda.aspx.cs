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
    public partial class addenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarDatosIniciales();
            }
        }

        protected void btnBuscarContrato_Click(object sender, EventArgs e)
        {
            string numeroContrato = txtNroContrato.Text.Trim();
            ContratoBL contratoBL = new ContratoBL();
            ContratoE contratoE = new ContratoE();

            if (numeroContrato.Length!=0) 
            {

                contratoE = contratoBL.GetContratoXNro(numeroContrato);
                limpiarControles();
                txtNroContrato.Text = numeroContrato;
                if (contratoE.CODIGO_CONTRATO==0)
                {
                    //Mensaje de contrato inexistente
                    showMessage("El Nro. de Contrato ingresado no existe");
                }
                else
                {
                    lblNroContrato.Text = txtNroContrato.Text;
                    HttpContext.Current.Session.Add("codigoContrato", contratoE.CODIGO_CONTRATO);
                    lblRazonSocial.Text = contratoE.CLIENTE;
                    lblDescripcionContrato.Text = contratoE.DESCRIPCION;

                    if (contratoE.ESTADO == "E") lblEstado.Text = "Elaborado";
                    else if (contratoE.ESTADO == "F") lblEstado.Text = "Firmado";
                    else if (contratoE.ESTADO == "C") lblEstado.Text = "Concluido";
                    else lblEstado.Text = "Rescindido";

                    if (contratoE.ESTADO == "F")
                    {
                        if (contratoE.NRO_ADDENDAS_PROCESO != 0)
                        {
                            habilitarControles(false);
                            //Mensaje: Tiene una Addenda en proceso.
                            showMessage("El contrato ingresado ya tiene una addenda en Proceso");
                        }
                        else
                        {
                            cargarClasulasxContrato();
                            habilitarControles(true);
                        }
                    }
                    else
                    {
                        //Mensaje que no puede registrar una addenda si el contrato no esta en estado firmado.
                        habilitarControles(false);
                        showMessage("El contrato ingresado debe estar en estado <FIRMADO> para poder agregarle una addenda");
                    }
                }
            }
        }

        private void habilitarControles(bool estado)
        {
            txtDescripcionAddenda.Enabled = estado;
            btnAgregarClausula.Enabled = estado;
            btnAceptar.Enabled = estado;
        }

        private void limpiarControles()
        {
            txtNroContrato.Text = string.Empty;
            lblNroContrato.Text = string.Empty;
            lblDescripcionContrato.Text = string.Empty;
            lblEstado.Text = string.Empty;
            lblRazonSocial.Text = string.Empty;
            txtDescripcionAddenda.Text = string.Empty;
            Session["CodigoContrato"] = null;
            Session["ClausulasAddenda"] = null;
            grvClausulas.DataSource = null;
            grvClausulas.DataBind();
         
        }

        private void cargarClasulasxContrato()
        {
            ClausulaBL clausulaBL = new ClausulaBL();

            ddlNroClausula.DataSource = clausulaBL.ClausulasxContrato((int)Session["CodigoContrato"]);
            ddlNroClausula.DataTextField = "NUMERO_CLAUSULA";
            ddlNroClausula.DataValueField = "CODIGO_CLAUSULA";
            ddlNroClausula.DataBind();
        }

        private void cargarDatosClausulaxCodigo()
        {
            ClausulaBL clausulaBL = new ClausulaBL();
            ClausulaE clausulaE = new ClausulaE();

            if (ddlNroClausula.SelectedValue.Length != 0)
            {
                clausulaE = clausulaBL.ClausulaxCodigo(int.Parse(ddlNroClausula.SelectedValue));
                ddlTipoClausula.SelectedValue = clausulaE.CODIGO_TIPO_CLAUSULA.ToString();
                txtDescripcionClausula.Text = clausulaE.DESCRIPCION;
                if (clausulaE.SUJETO_PENALIDAD == true)
                {
                    chkSujetoPenalidad.Checked = true;
                    ddlTipoSancion.SelectedIndex = int.Parse(clausulaE.TIPO_SANCION) - 1;
                    txtSancion.Text = clausulaE.SANCION.ToString();
                    ddlTipoSancion.Enabled = (ddlEstado.SelectedIndex != 2);
                    txtSancion.Enabled = (ddlEstado.SelectedIndex != 2);
                    rfldSancion.Visible = (ddlEstado.SelectedIndex != 2);
                }
                else
                {
                    chkSujetoPenalidad.Checked = false;
                    txtSancion.Text = string.Empty;
                    ddlTipoSancion.Enabled = false;
                    txtSancion.Enabled = false;
                    rfldSancion.Visible = false;
                }
            }
        }
        private void cargarDatosIniciales()
        { 
            TipoClausulaBL tipoClausulaBL= new TipoClausulaBL();

            //ddlEstado.Items.Add("Nuevo");
            //ddlEstado.Items.Add("Modificar");
            //ddlEstado.Items.Add("Eliminar");
                        
            //ddlTipoSancion.Items.Add("UIT(UND)");
            //ddlTipoSancion.Items.Add("CONTRATO(%)");
            //ddlTipoSancion.Items.Add("MONTO FIJO");
            //ddlTipoSancion.Items.Add("ULTIMA FACTURA(%)");

            ddlTipoClausula.DataSource = tipoClausulaBL.ObteneTipoClausulas();
            ddlTipoClausula.DataTextField = "Nombre";
            ddlTipoClausula.DataValueField = "Codigo";
            ddlTipoClausula.DataBind();
        }

        private void cargarListadoClausulas()
        {
            List<ClausulaE> listaCA = new List<ClausulaE>();
            if (Session["ClausulasAddenda"] != null)
            {
                listaCA = (List<ClausulaE>)HttpContext.Current.Session["ClausulasAddenda"];
                Session["ClausulasAddenda"] = listaCA;
            }
            grvClausulas.DataSource = listaCA;
            grvClausulas.DataBind();
        }
        protected void btnAgregarClausula_Click(object sender, EventArgs e)
        {
            pnlContrato.Visible = false;
            pnlClausula.Visible = true;
            rfldSancion.Visible = false;
        }

        private void limpiarClausula()
        {
            chkSujetoPenalidad.Checked = false;
            txtSancion.Text = string.Empty;
            txtSancion.Enabled = false;
            rfldSancion.Visible = false;
            txtDescripcionClausula.Text = string.Empty;
            txtNroClausula.Text = string.Empty;
            txtNroClausula.Visible = true;
            ddlNroClausula.Visible = false;
            ddlEstado.SelectedIndex = 0;
            ddlTipoClausula.SelectedIndex = 0;
            ddlTipoSancion.SelectedIndex = 0;
            ddlTipoSancion.Enabled = false;
            ddlTipoClausula.Enabled = true;
            chkSujetoPenalidad.Enabled = true;
            hfldFilaEditar.Value = string.Empty;
        }
        protected void btnCancelarClausula_Click(object sender, EventArgs e)
        {
            pnlContrato.Visible = true;
            pnlClausula.Visible = false;
            limpiarClausula();
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivarCamposXEstado();
            if (ddlEstado.SelectedIndex == 0) limpiarClausula();
            else cargarDatosClausulaxCodigo();
        }
        private void ActivarCamposXEstado()
        {
            bool estado = (ddlEstado.SelectedIndex != 2);//Eliminar
            ddlNroClausula.Visible = (ddlEstado.SelectedIndex != 0);
            txtNroClausula.Visible = (ddlEstado.SelectedIndex == 0);

            ddlTipoClausula.Enabled = estado;
            chkSujetoPenalidad.Enabled = estado;
            ddlTipoSancion.Enabled = (estado && chkSujetoPenalidad.Checked == true);
            txtSancion.Enabled = (estado && chkSujetoPenalidad.Checked == true);
            rfldSancion.Visible = (estado && chkSujetoPenalidad.Checked == true);        
        }

        protected void ddlNroClausula_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDatosClausulaxCodigo();
        }

        protected void chkSujetoPenalidad_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSujetoPenalidad.Checked == true)
            {
                ddlTipoSancion.Enabled = true;
                txtSancion.Enabled = true;
                rfldSancion.Visible = true;
            }
            else 
            {
                ddlTipoSancion.Enabled = false;
                txtSancion.Enabled = false;
                txtSancion.Text = string.Empty;
                rfldSancion.Visible = false;
            }
        }

        protected void btnAceptarClausula_Click(object sender, EventArgs e)
        {
            ClausulaE clausulaE = new ClausulaE();
            List<ClausulaE> listaCA = new List<ClausulaE>();
            string mensaje;

            if ((mensaje = NumeroClausulaRepetida(hfldFilaEditar.Value)).Length > 0)
            {
                //mostrar mensaje de Cláusula repetida
                showMessage(mensaje);
            }
            else
            {
                clausulaE.ESTADO = ddlEstado.SelectedValue;
                if (ddlEstado.SelectedIndex == 0)
                {
                    //clausulaE.ESTADO = "P";//PROCESO
                    clausulaE.NUMERO_CLAUSULA = int.Parse(txtNroClausula.Text);
                }
                else
                {
                    clausulaE.NUMERO_CLAUSULA = int.Parse(ddlNroClausula.SelectedItem.Text);
                    //if (ddlEstado.SelectedIndex == 1) clausulaE.ESTADO = "R";//MODIFICADO
                    //else clausulaE.ESTADO = "E";//ELIMINADO
                }

                clausulaE.CODIGO_TIPO_CLAUSULA = int.Parse(ddlTipoClausula.SelectedValue);
                clausulaE.DESCRIPCION = txtDescripcionClausula.Text;
                clausulaE.SUJETO_PENALIDAD = (chkSujetoPenalidad.Checked == true);
                if (clausulaE.SUJETO_PENALIDAD)
                {
                    clausulaE.TIPO_SANCION = ddlTipoSancion.SelectedValue;// (ddlTipoSancion.SelectedIndex + 1).ToString();
                    clausulaE.SANCION = double.Parse(txtSancion.Text);
                }
                if (Session["ClausulasAddenda"] == null)
                {
                    listaCA.Add(clausulaE);
                    HttpContext.Current.Session.Add("ClausulasAddenda", listaCA);
                }
                else
                {
                    listaCA = (List<ClausulaE>)HttpContext.Current.Session["ClausulasAddenda"];
                    if (hfldFilaEditar.Value.Length == 0)
                        listaCA.Add(clausulaE);
                    else
                        listaCA[int.Parse(hfldFilaEditar.Value)] = clausulaE;
                    Session["ClausulasAddenda"] = listaCA;
                }
                cargarListadoClausulas();
                if (grvClausulas.Rows.Count == 0) txtNroClausulas.Text = "";
                else txtNroClausulas.Text = grvClausulas.Rows.Count.ToString();
                if (hfldFilaEditar.Value.Length == 0)
                    showMessage("La Cláusula fue agregada correctamente");
                else
                {
                    pnlClausula.Visible = false;
                    pnlContrato.Visible = true;
                    showMessage("La Cláusula fue modificada correctamente");
                }
                limpiarClausula();

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            AddendaBL addendaBL = new AddendaBL();
            AddendaE addendaE = new AddendaE();

            ClausulaBL clausulaBL = new ClausulaBL();

            addendaE.CODIGO_CONTRATO = (int)Session["CodigoContrato"];
            addendaE.DESCRIPCION = txtDescripcionAddenda.Text;

            addendaBL.insertar(addendaE);
            if (addendaE.CODIGO_ADDENDA != 0)
            {

                List<ClausulaE> listaCA = new List<ClausulaE>();
                listaCA = (List<ClausulaE>)HttpContext.Current.Session["ClausulasAddenda"];

                foreach(ClausulaE clausulaE in listaCA)
                {
                    clausulaE.CODIGO_CONTRATO = (int)Session["CodigoContrato"];
                    clausulaE.CODIGO_ADDENDA = addendaE.CODIGO_ADDENDA;
                    clausulaBL.Insert(clausulaE);
                }
            }
            //Datos grabados correctamente
            limpiarControles();
            showMessage("La Addenda fue registrata correctamente");
        }

        private String getContentCellGridView(GridView grid, int index)
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


        private string NumeroClausulaRepetida(string filaParam)
        {
            string mensaje = string.Empty;
            int nroClausula, posItem, filaMod;

            if (filaParam.Length == 0) filaMod = -1;
            else filaMod = int.Parse(filaParam);

            if (ddlEstado.SelectedIndex == 0) nroClausula = int.Parse(txtNroClausula.Text);
            else nroClausula = int.Parse(ddlNroClausula.SelectedItem.Text);

            if (Session["ClausulasAddenda"] != null)
            {
                List<ClausulaE> listaCA = new List<ClausulaE>();
                listaCA = (List<ClausulaE>)HttpContext.Current.Session["ClausulasAddenda"];
                posItem = -1;
                foreach (ClausulaE clausulaE in listaCA)
                {
                    posItem++;
                    if (posItem != filaMod)
                    {
                        if (clausulaE.NUMERO_CLAUSULA == nroClausula)
                        {
                            mensaje = "La addenda ya tiene agregada este Número<" + nroClausula.ToString() + "> de Cláusula";
                            break;
                        }
                    }
                }
            }
            if (mensaje.Length == 0 && ddlEstado.SelectedIndex==0)// sin agregar y si es nuevo que no exista.
            {
                for (int fila = 0; fila < ddlNroClausula.Items.Count; fila++)
                {
                    if (int.Parse(ddlNroClausula.Items[fila].Text) == nroClausula)
                    {
                        mensaje = "En el contrato ya existe una cláusula con el Número<" + nroClausula.ToString() + "> debe asignar otro ";
                        break;
                    }
                }
            }
            return mensaje;
        }


        private void showMessage(string mensaje)
        {
            //string script = @"<script type='text/javascript'> alert('" + mensaje + "');</script>";
            //Page.RegisterClientScriptBlock("alerta", script);
            string Clientescript = ("<script>alert(\'" + mensaje + "\')</script>");
            if (!ClientScript.IsClientScriptBlockRegistered("WMensaje"))
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "WMensaje", Clientescript);
            }
        }

        protected void grvClausulas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            List<ClausulaE> listaCA;
            ClausulaE clausulaE;
            int fila;

            if (Session["ClausulasAddenda"] != null)
            {
                listaCA = (List<ClausulaE>)HttpContext.Current.Session["ClausulasAddenda"];
                clausulaE = listaCA[int.Parse(e.CommandArgument.ToString())];

                if (e.CommandName.ToString() == "Editar")
                {
                    hfldFilaEditar.Value = e.CommandArgument.ToString();
                    ddlEstado.SelectedValue = clausulaE.ESTADO;
                    ActivarCamposXEstado();
                    if (ddlEstado.SelectedIndex == 0)
                        txtNroClausula.Text = clausulaE.NUMERO_CLAUSULA.ToString();
                    else
                    { 
                        for(fila=0;fila<ddlNroClausula.Items.Count;fila++)
                            if (ddlNroClausula.Items[fila].Text == clausulaE.NUMERO_CLAUSULA.ToString())
                            {
                                ddlNroClausula.SelectedIndex = fila;
                                break;
                            }
                    }
                    ddlTipoClausula.SelectedValue = clausulaE.CODIGO_TIPO_CLAUSULA.ToString();
                    txtDescripcionClausula.Text = clausulaE.DESCRIPCION;
                    chkSujetoPenalidad.Checked = clausulaE.SUJETO_PENALIDAD;
                    ddlTipoSancion.Enabled = clausulaE.SUJETO_PENALIDAD;
                    txtSancion.Enabled = clausulaE.SUJETO_PENALIDAD;
                    if (clausulaE.SUJETO_PENALIDAD)
                    {
                        ddlTipoSancion.Enabled = (ddlEstado.SelectedIndex!=2);
                        txtSancion.Enabled = (ddlEstado.SelectedIndex != 2);
                        ddlTipoSancion.SelectedValue = clausulaE.TIPO_SANCION;// (ddlTipoSancion.SelectedIndex + 1).ToString();
                        txtSancion.Text = clausulaE.SANCION.ToString();
                    }
                    pnlContrato.Visible = false;
                    pnlClausula.Visible = true;
                }
                else if (e.CommandName.ToString() == "Eliminar")
                {
                    listaCA.Remove(clausulaE);
                    Session["ClausulasAddenda"] = listaCA;
                    cargarListadoClausulas();

                    if (grvClausulas.Rows.Count == 0) txtNroClausulas.Text = "";
                    else txtNroClausulas.Text = grvClausulas.Rows.Count.ToString();
                    showMessage("Se ha eliminado la Cláusula Nro.: " + clausulaE.NUMERO_CLAUSULA.ToString());
                }
            }
        }

        protected void grvClausulas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}