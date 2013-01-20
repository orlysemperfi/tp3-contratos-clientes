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
      List<ContratoE> listaContratos = ContratoController.GetContratos();
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

  }

}
