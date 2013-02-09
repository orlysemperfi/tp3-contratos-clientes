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
    private IAddendaBL AdendaController = AddendaBL.GetInstance();

    protected void Page_Load(object sender, EventArgs e) {
      if (!IsPostBack) {
        CargarListaCombos();
        CargarListaAdendas();
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
      List<AddendaE> listaAdendas = AdendaController.GetAdendas(txtFiltroNumeroContrato.Text, txtFiltroNumeroAdenda.Text, int.Parse(ddlFiltroServicio.SelectedValue));
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
        AddendaE adenda = (AddendaE)e.Row.DataItem;
        ImageButton btnVerAdenda = (ImageButton)e.Row.FindControl("btnVerAdenda");
        ImageButton btnAprobarAdenda = (ImageButton)e.Row.FindControl("btnAprobarAdenda");
        if (btnVerAdenda != null) {
          btnVerAdenda.OnClientClick = string.Format("window.showModalDialog('FormCambioEstadoAdenda.aspx?tipo=Ver&idAdenda={0}', null, 'dialogWidth:700px; dialogHeight:450px; center:yes');", adenda.CODIGO_ADDENDA);
        }
        if (btnAprobarAdenda != null) {
          btnAprobarAdenda.Visible = !adenda.ESTADO.Equals("F");
          btnAprobarAdenda.CommandName = "Cambiar";
          btnAprobarAdenda.CommandArgument = adenda.CODIGO_ADDENDA.ToString();
          if (btnAprobarAdenda.Visible) {
            //btnAprobarAdenda.OnClientClick = string.Format("window.showModalDialog('FormCambioEstadoAdenda.aspx?tipo=Cambiar&idAdenda={0}', null, 'dialogWidth:700px; dialogHeight:450px; center:yes');", adenda.CODIGO_ADDENDA);
          }
        }
      }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        //Obteniendo la data del Contrato
        string paramCodigoAdenda = Session["idAdenda"].ToString();
        if (!string.IsNullOrEmpty(paramCodigoAdenda))
        {
            int codigoAdenda = int.Parse(paramCodigoAdenda);
            //** Actualizar el estado de la adenda
            AdendaController.ActualizarSiguienteEstado(codigoAdenda, ddlProximoEstado.SelectedValue);
        }
        CargarListaAdendas();
        pnlActualizar.Visible = false;
        pnlListado.Visible = true;
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        pnlActualizar.Visible = false;
        pnlListado.Visible = true;
    }


    private void CargarDatosFormulario()
    {
        //Obteniendo la data del Contrato
        string paramTipo = "Cambiar";
        string paramCodigoAdenda = Session["idAdenda"].ToString();
        if (!string.IsNullOrEmpty(paramCodigoAdenda))
        {
            //** Convertir a numero
            int codigoAdenda = int.Parse(paramCodigoAdenda);
            //** Obtener la informacion del contrato
            AddendaE adenda = AdendaController.GetAdenda(codigoAdenda);
            if (adenda != null)
            {
                //** Llenando los controles del formulario
                txtNumeroContrato.Text = adenda.Contrato.NUMERO_CONTRATO;
                txtNombreEstado.Text = adenda.Contrato.ESTADO_DESCRIPCION;
                txtNombreServicio.Text = adenda.Contrato.Servicio.DESCRIPCION;
                txtNombreCliente.Text = adenda.Contrato.ClienteEnt.RAZON_SOCIAL;
                txtNumeroBuenaPro.Text = adenda.Contrato.NUMERO_BUENA_PRO;
                txtNumeroCartaFianza.Text = adenda.Contrato.NUMERO_CARTA_FIANZA;
                txtFechaInicio.Text = adenda.Contrato.FECHA_INICIO.ToString("dd/MM/yyyy");
                txtFechaFin.Text = adenda.Contrato.FECHA_FIN.ToString("dd/MM/yyyy");
                txtNumeroAdenda.Text = adenda.NUMERO_ADDENDA;
                txtEstadoAdenda.Text = adenda.ESTADO_DESCRIPCION;
                if (paramTipo.Equals("Cambiar"))
                {
                    //** Llenar la informacion del combo de estado
                    List<EstadoAdendaE> listaEstadoAdenda = new List<EstadoAdendaE>();
                    if (adenda.ESTADO.Equals("P"))
                    {
                        listaEstadoAdenda.Add(new EstadoAdendaE()
                        {
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
                }
                else if (paramTipo.Equals("Ver"))
                {
                    //** Campo 'Motivo'
                    trEstadoCambiar.Visible = false;
                    //** Aceptar/Cancelar
                    btnAceptar.Visible = false;
                    btnCancelar.Text = "Cerrar";
                }
            }
        }
    }

    protected void grdListadoAdendas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Cambiar")
        {
            Session["idAdenda"] = e.CommandArgument;
            CargarDatosFormulario();
            pnlListado.Visible = false;
            pnlActualizar.Visible = true;
        }
    }
  }

}
