using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Negocio.CC;
using Entidades.CC;

namespace TMD.SIG {

  public partial class ListadoContratos : Page {

    private IServicioBL ServicioController = ServicioBL.GetInstance();
    private IContratoBL ContratoController = ContratoBL.GetInstance();

    protected void Page_Load(object sender, EventArgs e) {
      if (!IsPostBack) {
        CargarListaCombos();
        CargarListaContratos();
      }
    }

    private void CargarListaCombos() {
      //** Filtro de Servicios
      List<ServicioE> listaServicios = ServicioController.GetServicios();
      listaServicios.Insert(0, new ServicioE() {
        CODIGO_SERVICIO = 0,
        DESCRIPCION = "Seleccione..."
      });
      ddlFiltroServicio.DataValueField = "CODIGO_SERVICIO";
      ddlFiltroServicio.DataTextField = "DESCRIPCION";
      ddlFiltroServicio.DataSource = listaServicios;
      ddlFiltroServicio.DataBind();
    }

    private void CargarListaContratos() {
      List<ContratoE> listaContratos = ContratoController.GetContratos(txtFiltroNumeroContrato.Text, txtFiltroDescripcion.Text, int.Parse(ddlFiltroServicio.SelectedValue), txtFiltroNombreCliente.Text);
      grdListadoContratos.DataSource = listaContratos;
      grdListadoContratos.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e) {
      CargarListaContratos();
    }

    protected void btnLimpiar_Click(object sender, EventArgs e) {
      txtFiltroDescripcion.Text = string.Empty;
      txtFiltroNombreCliente.Text = string.Empty;
      txtFiltroNumeroContrato.Text = string.Empty;
      ddlFiltroServicio.SelectedIndex = 0;
    }

    protected void btnAprobarContrato_Click(object sender, EventArgs e) {
      //
    }

    protected void grdListadoContratos_RowDataBound(object sender, GridViewRowEventArgs e) {
      if (e.Row.RowType.Equals(DataControlRowType.DataRow)) {
        ContratoE contrato = (ContratoE)e.Row.DataItem;
        ImageButton btnVerContrato = (ImageButton)e.Row.FindControl("btnVerContrato");
        ImageButton btnAprobarContrato = (ImageButton)e.Row.FindControl("btnAprobarContrato");
        if (btnVerContrato != null) {
          btnVerContrato.OnClientClick = string.Format("window.showModalDialog('FormCambioEstadoContrato.aspx?tipo=Ver&idContrato={0}', null, 'dialogWidth:700px; dialogHeight:450px; center:yes');", contrato.CODIGO_CONTRATO);
        }
        if (btnAprobarContrato != null) {
          btnAprobarContrato.Visible = !contrato.ESTADO.Equals("R") && !contrato.ESTADO.Equals("C");
          if (btnAprobarContrato.Visible) {
            btnAprobarContrato.OnClientClick = string.Format("window.showModalDialog('FormCambioEstadoContrato.aspx?tipo=Cambiar&idContrato={0}', null, 'dialogWidth:700px; dialogHeight:450px; center:yes');", contrato.CODIGO_CONTRATO);
          }
        }
      }
    }
    

  }

}
