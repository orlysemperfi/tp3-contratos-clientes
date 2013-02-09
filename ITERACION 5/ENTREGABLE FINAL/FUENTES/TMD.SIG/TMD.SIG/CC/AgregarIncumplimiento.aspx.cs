using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades.CC;
using Negocio.CC;

namespace TMD.SIG.CC
{
    public partial class AgregarIncumplimiento : System.Web.UI.Page
    {
        #region Metodos
        private void LimpiarControles()
        {
            txtContrato.Text = "";
            txtNumeroContrato.Value = "";
            lblRazonSocial.Text = "";
            lblRuc.Text = "";
            lblPenalidad.Text = "";

            txtDescripcion.Text = "";
            txtFecha.Text = "";

            ddlClausula.SelectedIndex = -1;
            txtMonto.Text = "";
            txtMotivo.Text = "";
            lblMonto.Text = "";
            lblEstado.Text = "";

            pnlIncumplimiento.Visible = false;

            Session["IncumplimientoClausulas"] = null;
        }

        private void CargarComboClausula(string numero_contrato)
        {
            ddlClausula.Items.Clear();
            objClausulaBL.LLenarClausulasPenalidad(ref ddlClausula, numero_contrato);

            if (ddlClausula.Items.Count <= 0)
            {
                muestraMensaje("El contrato no tiene cláusulas de penalidad");
            }
        }

        private void muestraMensaje(string mensaje)
        {
            string Clientescript = ("<script>alert(\'" + mensaje + "\')</script>");
            if (!ClientScript.IsClientScriptBlockRegistered("WMensaje"))
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "WMensaje", Clientescript);
            }
        }

        private void cambioCalendario(ref Calendar calendario)
        {
            if (calendario.Visible)
            { calendario.Visible = false; }
            else
            { calendario.Visible = true; }
        }

        #endregion

        #region Interfaces
        private IContratoBL objContratoBL = new ContratoBL();
        private IClausulaBL objClausulaBL = new ClausulaBL();
        private IIncumplimientoBL objIncumplimientoBL = new IncumplimientoBL();
        
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnGrabar.Attributes.Add("onclick", "return confirm('¿Guardar registro?');");
                LimpiarControles();
            }             
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string strContrato = txtContrato.Text.Trim();
            string descripcionEstado;
            
            if (strContrato.Length <= 0)
            {
                this.muestraMensaje("Ingresar el contrato");
            }
            else
            {
                ContratoE objContrato = new ContratoE();
                objContrato = objContratoBL.ObtenerContrato(strContrato);

                if (objContrato != null)
                {
                    txtNumeroContrato.Value = objContrato.CODIGO_CONTRATO.ToString();
                    lblRazonSocial.Text = objContrato.RAZONSOCIAL;
                    lblRuc.Text = objContrato.RUC;
                    Session["MontoContrato"] = objContrato.MONTO;
                    lblMonto.Text = objContrato.MONTO.ToString();

                    if (objContrato.ESTADO == "E") descripcionEstado = "ELABORADO";
                    else if (objContrato.ESTADO == "F") descripcionEstado = "FIRMADO";
                    else if (objContrato.ESTADO == "R") descripcionEstado = "RESCINDIDO";
                    else descripcionEstado = "CONCLUIDO";
                    lblEstado.Text = descripcionEstado;
                    if (objContrato.ESTADO != "F")
                    {
                        muestraMensaje("El contrato ingresado no es válido, esta en Estado:" + descripcionEstado);
                        pnlIncumplimiento.Visible = false;
                    }
                    else
                    {
                        CargarComboClausula(txtNumeroContrato.Value.Trim());
                        pnlIncumplimiento.Visible = true;
                        txtDescripcion.Focus();
                    }
                }
                else
                {
                    muestraMensaje("No existe el contrato");
                }
            }            
        }

        protected void imgFecha_Click(object sender, ImageClickEventArgs e)
        {
            cambioCalendario(ref cldFecha);
        }

        protected void cldFecha_SelectionChanged(object sender, EventArgs e)
        {
            txtFecha.Text = cldFecha.SelectedDate.ToShortDateString();
            cambioCalendario(ref cldFecha);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            string strMensaje = "";

            if (int.Parse(ddlClausula.SelectedItem.Value) <= 0)
                strMensaje = "Seleccionar la cláusula del contrato";
            if (txtMonto.Text.Trim().Length > 0)
            {
                if (decimal.Parse(txtMonto.Text) <= 0)
                    strMensaje = "Ingresar el monto";
            }
            else
            {
                strMensaje = "Ingresar el monto";
            }
            if (txtDescripcion.Text.Trim() == "")
                strMensaje = "Ingresar la descripción del incumplimiento";
            if (txtFecha.Text.Trim() == "")
                strMensaje = "Ingresar la fecha de incumplimiento";

            if (strMensaje.Trim() != "")
                muestraMensaje(strMensaje);
            else
                RegistrarIncumplimiento();
        }

        private void RegistrarIncumplimiento()
        {
            try
            {
                int codigo_incumplimiento = 0;

                IncumplimientoE objIncumplimiento = new IncumplimientoE();

                objIncumplimiento.Codigo_Contrato = int.Parse(txtNumeroContrato.Value.Trim());
                objIncumplimiento.Descripcion = txtDescripcion.Text.Trim();
                objIncumplimiento.Fecha = Convert.ToDateTime(txtFecha.Text);
                objIncumplimiento.Codigo_Clausula = int.Parse(ddlClausula.SelectedValue);
                objIncumplimiento.Monto = decimal.Parse(txtMonto.Text);
                objIncumplimiento.Motivo = txtMotivo.Text.Trim();

                objIncumplimientoBL.insertar(objIncumplimiento);

                codigo_incumplimiento = objIncumplimiento.Codigo_Incumplimiento;

                if (codigo_incumplimiento > 0)
                {
                    muestraMensaje("Registro de incumplimiento satisfactorio");

                    LimpiarControles();
                }
                else
                {
                    muestraMensaje("Error en registro de incumplimiento, favor informar a soporte");
                }

            }
            catch (Exception ex) { muestraMensaje("Error al grabar el incumplimiento: \n" + ex.Message); }    
        }

        protected void ddlClausula_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClausulaBL clausulaBL = new ClausulaBL();
            ClausulaE clausulaE = new ClausulaE();
            //string tipoClausula;

            clausulaE = clausulaBL.ClausulaxCodigo(int.Parse(ddlClausula.SelectedValue));
            txtMonto.Text = string.Empty;
            if (clausulaE.TIPO_SANCION == "1") lblPenalidad.Text = "UIT: " + clausulaE.SANCION.ToString() + " Unidades";
            else if (clausulaE.TIPO_SANCION == "2")
            {
                lblPenalidad.Text = "CONTRATO: " + clausulaE.SANCION.ToString() + "%";
                txtMonto.Text= Math.Round( double.Parse(((decimal)Session["MontoContrato"]).ToString()) * clausulaE.SANCION / 100.0,2).ToString();
            }
            else if (clausulaE.TIPO_SANCION == "3")
            {
                lblPenalidad.Text = "MONTO FIJO:" + clausulaE.SANCION.ToString();
                txtMonto.Text = clausulaE.SANCION.ToString();
            }
            else if (clausulaE.TIPO_SANCION == "4") lblPenalidad.Text = "ULTIMA FACTURA: " + clausulaE.SANCION.ToString() + "%";
        }
    }
}