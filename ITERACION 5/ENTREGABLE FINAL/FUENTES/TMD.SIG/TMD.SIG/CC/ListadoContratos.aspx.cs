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
      List<ContratoE> listaContratos = ContratoController.GetContratos(txtFiltroNumeroContrato.Text, txtFiltroDescripcion.Text, int.Parse(ddlFiltroServicio.SelectedValue));
      grdListadoContratos.DataSource = listaContratos;
      grdListadoContratos.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e) {
      CargarListaContratos();
    }

    protected void btnLimpiar_Click(object sender, EventArgs e) {
      txtFiltroDescripcion.Text = string.Empty;
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
          btnVerContrato.OnClientClick = string.Format("window.showModalDialog('FormCambioEstadoContrato.aspx?tipo=Ver&idContrato={0}', null, 'dialogWidth:700px; dialogHeight:500px; center:yes');", contrato.CODIGO_CONTRATO);
        }
        if (btnAprobarContrato != null) {
          btnAprobarContrato.Visible = !contrato.ESTADO.Equals("R") && !contrato.ESTADO.Equals("C");
          btnAprobarContrato.CommandName = "Cambiar";
          btnAprobarContrato.CommandArgument = contrato.CODIGO_CONTRATO.ToString();
          if (btnAprobarContrato.Visible) {
            //btnAprobarContrato.OnClientClick = string.Format("window.showModalDialog('FormCambioEstadoContrato.aspx?tipo=Cambiar&idContrato={0}', null, 'dialogWidth:700px; dialogHeight:500px; center:yes');", contrato.CODIGO_CONTRATO);
          }
        }
      }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        pnlActualizar.Visible = false;
        pnlListado.Visible = true;
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        //Obteniendo la data del Contrato
        string paramCodigoContrato = Session["idContrato"].ToString();
        if (!string.IsNullOrEmpty(paramCodigoContrato))
        {
            int codigoContrato = int.Parse(paramCodigoContrato);
            //** Actualizar el estado del contrato (y sus adendas)
            ContratoController.ActualizarSiguienteEstado(codigoContrato, ddlProximoEstado.SelectedValue, txtMotivoCambiar.Text);
            //** Invocar al SP (para actualizar las adendas)
            ContratoController.ActualizarAdendasYOtros(codigoContrato, ddlProximoEstado.SelectedValue, txtMotivoCambiar.Text);
            CargarListaContratos();
            pnlActualizar.Visible = false;
            pnlListado.Visible = true;
        }
    }


    private void CargarDatosFormulario()
    {
        //Obteniendo la data del Contrato
        string paramTipo = "Cambiar";
        string paramCodigoContrato = Session["idContrato"].ToString();
        if (!string.IsNullOrEmpty(paramCodigoContrato))
        {
            //** Convertir a numero
            int codigoContrato = int.Parse(paramCodigoContrato);
            //** Obtener la informacion del contrato
            ContratoE contrato = ContratoController.GetContrato(codigoContrato);
            if (contrato != null)
            {
                //** Llenando los controles del formulario
                txtNumeroContrato.Text = contrato.NUMERO_CONTRATO;
                txtNombreEstado.Text = contrato.ESTADO_DESCRIPCION;
                txtNombreServicio.Text = contrato.Servicio.DESCRIPCION;
                txtNombreCliente.Text = contrato.ClienteEnt.RAZON_SOCIAL;
                txtNumeroBuenaPro.Text = contrato.NUMERO_BUENA_PRO;
                txtNumeroCartaFianza.Text = contrato.NUMERO_CARTA_FIANZA;
                txtFechaInicio.Text = contrato.FECHA_INICIO.ToString("dd/MM/yyyy");
                txtFechaFin.Text = contrato.FECHA_FIN.ToString("dd/MM/yyyy");
                if (paramTipo.Equals("Cambiar"))
                {
                    //** Llenar la informacion del combo de estado
                    List<EstadoContratoE> listaEstadoContrato = new List<EstadoContratoE>();
                    if (contrato.ESTADO.Equals("E"))
                    {
                        listaEstadoContrato.Add(new EstadoContratoE()
                        {
                            CODIGO = "F",
                            NOMBRE = "FIRMADO"
                        });
                    }
                    else if (contrato.ESTADO.Equals("F"))
                    {
                        listaEstadoContrato.Add(new EstadoContratoE()
                        {
                            CODIGO = "R",
                            NOMBRE = "RESCINDIDO"
                        });
                        listaEstadoContrato.Add(new EstadoContratoE()
                        {
                            CODIGO = "C",
                            NOMBRE = "CONCLUIDO"
                        });
                    }
                    ddlProximoEstado.DataValueField = "CODIGO";
                    ddlProximoEstado.DataTextField = "NOMBRE";
                    ddlProximoEstado.DataSource = listaEstadoContrato;
                    ddlProximoEstado.DataBind();
                    //** Campo 'Estado'
                    trEstadoCambiar.Visible = true;// (!contrato.ESTADO.Equals("E"));
                    //** Campo 'Motivo'
                    trFechaTerminoVer.Visible = false;
                    trMotivoVer.Visible = false;
                    trMotivoCambiar.Visible = (!contrato.ESTADO.Equals("E"));
                }
            }
        }
    }

    protected void grdListadoContratos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Cambiar")
        {
            Session["idContrato"] = e.CommandArgument;
            CargarDatosFormulario();
            pnlListado.Visible = false;
            pnlActualizar.Visible = true;
        }
    }
  }
}
