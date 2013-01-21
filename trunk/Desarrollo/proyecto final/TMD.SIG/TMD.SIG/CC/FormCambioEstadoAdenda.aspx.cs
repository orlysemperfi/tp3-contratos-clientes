using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Negocio.CC;
using Entidades.CC;

namespace TMD.SIG {

  public partial class FormCambioEstadoAdenda : Page {

    private IServicioBL ServicioController = ServicioBL.GetInstance();
    private IAdendaBL AdendaController = AdendaBL.GetInstance();

    protected void Page_Load(object sender, EventArgs e) {
      if (!IsPostBack) {
        CargarDatosFormulario();
      }
    }

    private void CargarDatosFormulario() {
      //Obteniendo la data del Contrato
      string paramTipo = Request.QueryString["tipo"];
      string paramCodigoAdenda = Request.QueryString["idAdenda"];
      if (!string.IsNullOrEmpty(paramCodigoAdenda)) {
        //** Convertir a numero
        int codigoAdenda = int.Parse(paramCodigoAdenda);
        //** Obtener la informacion del contrato
        AdendaE adenda = AdendaController.GetAdenda(codigoAdenda);
        if (adenda != null) {
          //** Llenando los controles del formulario
          txtNumeroContrato.Text = adenda.Contrato.NUMERO_CONTRATO;
          txtNombreEstado.Text = adenda.Contrato.ESTADO_DESCRIPCION;
          txtNombreServicio.Text = adenda.Contrato.Servicio.DESCRIPCION;
          txtNombreCliente.Text = adenda.Contrato.Cliente.RAZON_SOCIAL;
          txtNumeroBuenaPro.Text = adenda.Contrato.NUMERO_BUENA_PRO;
          txtNumeroCartaFianza.Text = adenda.Contrato.NUMERO_CARTA_FIANZA;
          txtFechaInicio.Text = adenda.Contrato.FECHA_INICIO.ToString("dd/MM/yyyy");
          txtFechaFin.Text = adenda.Contrato.FECHA_FIN.ToString("dd/MM/yyyy");
          txtNumeroAdenda.Text = adenda.NUMERO_ADDENDA;
          txtEstadoAdenda.Text = adenda.ESTADO_DESCRIPCION;
          if (paramTipo.Equals("Cambiar")) {
            //** Llenar la informacion del combo de estado
            List<EstadoAdendaE> listaEstadoAdenda = new List<EstadoAdendaE>();
            listaEstadoAdenda.Add(new EstadoAdendaE() {
              CODIGO = "",
              NOMBRE = "Seleccione..."
            });
            if (adenda.ESTADO.Equals("P")) {
              listaEstadoAdenda.Add(new EstadoAdendaE() {
                CODIGO = "F",
                NOMBRE = "FIRMADO"
              });
            }
            ddlProximoEstado.DataValueField = "CODIGO";
            ddlProximoEstado.DataTextField = "NOMBRE";
            ddlProximoEstado.DataSource = listaEstadoAdenda;
            ddlProximoEstado.DataBind();
            //** Campo 'Estado'
            trEstadoCambiar.Visible = (!adenda.ESTADO.Equals("E"));
          } else if (paramTipo.Equals("Ver")) {
            //** Campo 'Motivo'
            trEstadoCambiar.Visible = false;
            //** Aceptar/Cancelar
            btnAceptar.Visible = false;
            btnCancelar.Text = "Cerrar";
          }
        }
      }
    }

    protected void btnAceptar_Click(object sender, EventArgs e) {
      //Obteniendo la data del Contrato
      string paramCodigoAdenda = Request.QueryString["idAdenda"];
      if (!string.IsNullOrEmpty(paramCodigoAdenda)) {
        int codigoAdenda = int.Parse(paramCodigoAdenda);
        //** Actualizar el estado de la adenda
        AdendaController.ActualizarSiguienteEstado(codigoAdenda, ddlProximoEstado.SelectedValue);
      }
      ClientScript.RegisterStartupScript(this.GetType(), "JS-CloseWindow", "window.close();", true);
    }

    protected void btnAprobarContrato_Click(object sender, EventArgs e) {
      //
    }
    

  }

}
