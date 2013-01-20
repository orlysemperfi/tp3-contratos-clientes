using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Negocio.CC;
using Entidades.CC;

namespace TMD.SIG {

  public partial class FormCambioEstadoContrato : Page {

    private IServicioBL ServicioController = ServicioBL.GetInstance();
    private IContratoBL ContratoController = ContratoBL.GetInstance();

    protected void Page_Load(object sender, EventArgs e) {
      if (!IsPostBack) {
        CargarDatosFormulario();
      }
    }

    private void CargarDatosFormulario() {
      //Obteniendo la data del Contrato
      string paramCodigoContrato = Request.QueryString["idContrato"];
      if (!string.IsNullOrEmpty(paramCodigoContrato)) {
        //** Convertir a numero
        int codigoContrato = int.Parse(paramCodigoContrato);
        //** Obtener la informacion del contrato
        ContratoE contrato = ContratoController.GetContrato(codigoContrato);
        if (contrato != null) {
          //** Llenando los controles del formulario
          txtNumeroContrato.Text = contrato.NUMERO_CONTRATO;
          txtNombreEstado.Text = contrato.ESTADO_DESCRIPCION;
          txtNombreServicio.Text = contrato.Servicio.DESCRIPCION;
          txtNombreCliente.Text = contrato.Cliente.RAZON_SOCIAL;
          txtNumeroBuenaPro.Text = contrato.NUMERO_BUENA_PRO;
          txtNumeroCartaFianza.Text = contrato.NUMERO_CARTA_FIANZA;
          txtFechaInicio.Text = contrato.FECHA_INICIO.ToString("dd/MM/yyyy");
          txtFechaFin.Text = contrato.FECHA_FIN.ToString("dd/MM/yyyy");
          //** Llenar la informacion del combo de estado
          List<EstadoContratoE> listaEstadoContrato = new List<EstadoContratoE>();
          if (contrato.ESTADO.Equals("E")) {
            listaEstadoContrato.Add(new EstadoContratoE() {
              CODIGO = "F",
              NOMBRE = "FIRMADO"
            });
          } else if (contrato.ESTADO.Equals("F")) {
            listaEstadoContrato.Add(new EstadoContratoE() {
              CODIGO = "R",
              NOMBRE = "RESCINDIDO"
            });
            listaEstadoContrato.Add(new EstadoContratoE() {
              CODIGO = "C",
              NOMBRE = "CONCLUIDO"
            });
          }
          ddlProximoEstado.DataValueField = "CODIGO";
          ddlProximoEstado.DataTextField = "NOMBRE";
          ddlProximoEstado.DataSource = listaEstadoContrato;
          ddlProximoEstado.DataBind();
          //** Campo 'Motivo'
          trMotivo.Visible = (!contrato.ESTADO.Equals("E"));
        }
      }
    }

    protected void btnAceptar_Click(object sender, EventArgs e) {
      //Obteniendo la data del Contrato
      string paramCodigoContrato = Request.QueryString["idContrato"];
      if (!string.IsNullOrEmpty(paramCodigoContrato)) {
        int codigoContrato = int.Parse(paramCodigoContrato);
        //** Actualizar el estado del contrato (y sus adendas)
        ContratoController.ActualizarSiguienteEstado(codigoContrato, ddlProximoEstado.SelectedValue, txtMotivo.Text);
        //** Invocar al SP (para actualizar las adendas)
        ContratoController.ActualizarAdendasYOtros(codigoContrato, ddlProximoEstado.SelectedValue, txtMotivo.Text);
      }
      
    }

    protected void btnAprobarContrato_Click(object sender, EventArgs e) {
      //
    }
    

  }

}
