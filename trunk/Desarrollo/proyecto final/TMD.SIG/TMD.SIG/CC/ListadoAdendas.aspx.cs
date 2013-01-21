using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Negocio.CC;
using Entidades.CC;

namespace TMD.SIG {

  public partial class ListadoAdendas : Page {

    private IServicioBL ServicioController = ServicioBL.GetInstance();
    private IAdendaBL AdendaController = AdendaBL.GetInstance();

    protected void Page_Load(object sender, EventArgs e) {
      if (!IsPostBack) {
        CargarListaCombos();
        CargarListaAdendas();
      } else {
        if (Request["ctl00$hdnPostBackAction"].Equals("btnBuscar")) {
          CargarListaAdendas();
        }
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

    private void CargarListaAdendas() {
      List<AdendaE> listaAdendas = AdendaController.GetAdendas(txtFiltroNumeroContrato.Text,
                                                               txtFiltroNumeroAdenda.Text,
                                                               int.Parse(ddlFiltroServicio.SelectedValue),
                                                               null);
      grdListadoAdendas.DataSource = listaAdendas;
      grdListadoAdendas.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e) {
      CargarListaAdendas();
    }

    protected void btnLimpiar_Click(object sender, EventArgs e) {
      txtFiltroNumeroContrato.Text = string.Empty;
      txtFiltroNumeroAdenda.Text = string.Empty;
      ddlFiltroServicio.SelectedIndex = 0;
    }

    protected void btnAprobarContrato_Click(object sender, EventArgs e) {
      //
    }

    protected void grdListadoAdendas_RowDataBound(object sender, GridViewRowEventArgs e) {
      if (e.Row.RowType.Equals(DataControlRowType.DataRow)) {
        AdendaE adenda = (AdendaE)e.Row.DataItem;
        ImageButton btnVerAdenda = (ImageButton)e.Row.FindControl("btnVerAdenda");
        ImageButton btnAprobarAdenda = (ImageButton)e.Row.FindControl("btnAprobarAdenda");
        if (btnVerAdenda != null) {
          btnVerAdenda.OnClientClick = string.Format("window.showModalDialog('FormCambioEstadoAdenda.aspx?tipo=Ver&idAdenda={0}', null, 'dialogWidth:700px; dialogHeight:450px; center:yes');", adenda.CODIGO_ADDENDA);
        }
        if (btnAprobarAdenda != null) {
          btnAprobarAdenda.Visible = !adenda.ESTADO.Equals("F");
          if (btnAprobarAdenda.Visible) {
            btnAprobarAdenda.OnClientClick = string.Format("openModal('FormCambioEstadoAdenda.aspx?tipo=Cambiar&idAdenda={0}');", adenda.CODIGO_ADDENDA);
          }
        }
      }
    }
    

  }

}
