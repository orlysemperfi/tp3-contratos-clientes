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

    private IContratoBL ContratoController = ContratoBL.GetInstance();

    protected void Page_Load(object sender, EventArgs e) {
      if (!IsPostBack) {
        CargarListaContratos();
      }
    }

    private void CargarListaContratos() {
      List<ContratoE> listaContratos = ContratoController.GetContratos();
      grdListadoContratos.DataSource = listaContratos;
      grdListadoContratos.DataBind();
    }

  }

}
