using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Entidades.CC;
using Negocio.CC;
using System.Data;

namespace TMD.SIG.CC
{
    public partial class MonitoreoContratos : System.Web.UI.Page
    {
        int Index;
        string idCliente;
        string idLineaServicio;

        private IClienteBL clienteBL = new ClienteBL();
        private ILineaServicioBL lineaservicioBL = new LineaServicioBL();

        private void muestraMensaje(string mensaje)
        {
            string Clientescript = ("<script>alert(\'" + mensaje + "\')</script>");
            if (!ClientScript.IsClientScriptBlockRegistered("WMensaje"))
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "WMensaje", Clientescript);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string codigo=Request.QueryString["id"];
            
            if (Request["btnCerrar"]=="Cerrar")
            {
                contenedor.Visible = false;
            }
            if (null != codigo)
            {
                contenedor.Visible = true;
                contenedor.Style.Add("float", "left");
                contenedor.Style.Add("position", "fixed");
                contenedor.Style.Add("display", "block");
                contenedor.Style.Add("left", "470px");
                contenedor.Style.Add("top ", "210px");
                contenedor.Style.Add("width ", "350px");
                contenedor.Style.Add("height ", "250px");
                contenedor.Style.Add("background-color", "#5882FA");
                contenedor.Style.Add("z-index", "1001");
                contenedor.Style.Add("color", "White");
                contenedor.Style.Add("overflow", "auto");
                MostrarInformacionContrato(codigo);
            }
            else 
            {
                contenedor.Visible = false;
            }

            if (!IsPostBack)
            {
                CargarCombos();
                ValidarMonitoreo();
            }
            else
            {
                Session["Index"] = ddlEstadoContrato.SelectedIndex;
                Session["IdCliente"] = ddlCliente.SelectedItem.Value;
                Session["IdLineaServicio"] = ddlLineaServicio.SelectedItem.Value;

                ValidarMonitoreo();
            }
        }

        private void CargarCombos()
        {
            //Se carga Clientes
            ddlCliente.Items.Clear();
            clienteBL.LLenarDrop(ref ddlCliente);
            //Se carga Linea de Servicio
            ddlLineaServicio.Items.Clear();
            lineaservicioBL.LLenarDrop(ref ddlLineaServicio); 
        }

        void MostrarInformacionContrato(string nroContrato)
        {
            ContratoBL oContrato = new ContratoBL();
            DataTable dt = new DataTable();
            dt = oContrato.GetInfoContrato(nroContrato);
            if (dt.Rows.Count == 0)
            {
                dt.Dispose();
                return;
            }
            dt = oContrato.GetInfoContrato(nroContrato);
            lblNroContrato.Text = (dt.Rows[0]["NUMERO_CONTRATO"] is DBNull) ? null : (dt.Rows[0]["NUMERO_CONTRATO"].ToString());
            lblRazSocial.Text = (dt.Rows[0]["RAZON_SOCIAL"] is DBNull) ? null : (dt.Rows[0]["RAZON_SOCIAL"].ToString());
            lblRuc.Text = (dt.Rows[0]["RUC"] is DBNull) ? null : (dt.Rows[0]["RUC"].ToString());
            lblTel.Text = (dt.Rows[0]["TELEFONO"] is DBNull) ? null : (dt.Rows[0]["TELEFONO"].ToString());
            lblContacto.Text = (dt.Rows[0]["CONTACTO"] is DBNull) ? null : (dt.Rows[0]["CONTACTO"].ToString());
            lblFecIni.Text = (dt.Rows[0]["FECHA_INICIO"] is DBNull) ? null : (dt.Rows[0]["FECHA_INICIO"].ToString());
            lblFecFin.Text = (dt.Rows[0]["FECHA_FIN"] is DBNull) ? null : (dt.Rows[0]["FECHA_FIN"].ToString());
            lblNroAddendas.Text = (dt.Rows[0]["NRO_ADDENDAS"] is DBNull) ? null : (dt.Rows[0]["NRO_ADDENDAS"].ToString());
            lblDescripcion.Text = (dt.Rows[0]["DESCRIPCION"] is DBNull) ? null : (dt.Rows[0]["DESCRIPCION"].ToString());
        }
        

        void CrearTabla(string Param, int Cliente, int LineaServicio, DateTime FechaInicio, DateTime FechaFin)
        {
            
            int TotalContratos=0;
            int TotalEstado0 = 0;
            int TotalEstado1 = 0;
            int TotalEstado2 = 0;
            int TotalEstado3 = 0;
            ContratoBL oContrato = new ContratoBL();
           
            DataTable dt=new DataTable();
            dt = oContrato.GetMonitoreoContratos(Param, Cliente, LineaServicio, FechaInicio, FechaFin);
            
            int r=0;
            int c=0;
            int totalReg = 0;
            int totaCol = 0;

            if (dt.Rows.Count == 0) 
            {
                if (IsPostBack)
                muestraMensaje("No hay registros para el filtro seleccionado");
                return;
            }

            if (dt.Rows.Count < 5) 
            {
                totalReg = 1;
                totaCol = dt.Rows.Count;
            }

            if (dt.Rows.Count >= 5)
            {
                
                int nroReg = (int)Math.Ceiling((decimal)dt.Rows.Count / 5m);
                totalReg = nroReg;
                totaCol = 5;
            }
            int rr=0;

            tblContratos.Controls.Clear();
            for (r = 0; r < totalReg; r++)
            {
                HtmlTableRow fila = new HtmlTableRow();
                for (c = 0; c < 5; c++)
                {
                    string NroContrato="";
                    string RazonSocial = "";
                    DateTime fechaIni ;
                    DateTime fechaFin ;
                    DateTime fechaActual;
                    int dias;
                    HtmlTableCell celda = new HtmlTableCell();
                    
                    string cadena = "";

                    if (rr >= dt.Rows.Count)
                    {
                        break;
                    }
                                                     
                        NroContrato = dt.Rows[rr][0].ToString();
                        RazonSocial = dt.Rows[rr][1].ToString();
                        fechaIni = (DateTime)dt.Rows[rr][2];
                        fechaFin = (DateTime)dt.Rows[rr][3];

                        rr += 1;
                        
                        fechaActual = DateTime.Today;
                        TimeSpan cantDias;
                        cantDias = fechaFin.Subtract(fechaActual);
                        dias = cantDias.Days;

                        cadena = NroContrato;                        
                        cadena += "<BR>" + RazonSocial;

                        celda.Width = "90px";
                        if (dias < 0)
                        {
                            celda.BgColor = "Red";
                            TotalEstado0 += 1;
                        }
                        else if (dias >= 0 && dias < 15)
                        {
                            celda.BgColor = "Orange";
                            TotalEstado1 += 1;
                        }
                        else
                        {
                            if (dias >= 15 && dias <= 30)
                            {
                                celda.BgColor = "#0099FF";
                                TotalEstado2 += 1;
                            }
                            else
                            {
                                celda.BgColor = "Green";
                                TotalEstado3 += 1;
                            }
                        }
                        celda.Style.Add("color", "White");


                    celda.InnerHtml = "<a href=MonitoreoContratos.aspx?id=" + NroContrato + "'>" + cadena + "<a/>";
                    fila.Cells.Add(celda);
                    TotalContratos = rr;
                }
                tblContratos.Rows.Add(fila);
                lblEstado0.Text = TotalEstado0.ToString();
                lblEstado1.Text = TotalEstado1.ToString();
                lblEstado2.Text = TotalEstado2.ToString();
                lblEstado3.Text = TotalEstado3.ToString();
                lblTotal.Text =TotalContratos.ToString();
                
            }            
        }
        private void ValidarMonitoreo()
        {            
            Index = Session["Index"] == null ? 0 : (int)Session["Index"];
            idCliente = Session["IdCliente"] == null ? "0" : Session["IdCliente"].ToString();
            idLineaServicio = Session["IdLineaServicio"] == null ? "0" : Session["IdLineaServicio"].ToString();

            ddlEstadoContrato.SelectedIndex = Index;
            ddlCliente.SelectedItem.Value = idCliente;
            ddlLineaServicio.SelectedItem.Value = idLineaServicio;

            int codigoCliente = int.Parse(ddlCliente.SelectedItem.Value);
            int codigoLineaServicio = int.Parse(ddlLineaServicio.SelectedItem.Value);           

            if (ddlEstadoContrato.SelectedIndex == 0)
            {
                CrearTabla("1", codigoCliente, codigoLineaServicio, DateTime.Today, DateTime.Today);
            }
            else if (ddlEstadoContrato.SelectedIndex == 1)
            {
                DateTime fechaActual;                
                fechaActual = DateTime.Today;
                CrearTabla("2", codigoCliente, codigoLineaServicio, fechaActual, fechaActual);
            }
            else if (ddlEstadoContrato.SelectedIndex == 2)
            {
                DateTime fechaActual;
                DateTime fechaAdelante;
                fechaActual = DateTime.Today;
                fechaAdelante = fechaActual.AddDays(14);
                CrearTabla("3", codigoCliente, codigoLineaServicio, fechaActual, fechaAdelante);
            }
            else if (ddlEstadoContrato.SelectedIndex == 3)
            {
                DateTime fechaAntes;
                DateTime fechaPosterior;
                fechaAntes = DateTime.Today.AddDays(15);
                fechaPosterior = fechaAntes.AddDays(30);
                CrearTabla("4", codigoCliente, codigoLineaServicio, fechaAntes, fechaPosterior);
            }
            else if (ddlEstadoContrato.SelectedIndex == 4)
            {
                DateTime fechaAntes;
                fechaAntes = DateTime.Today.AddDays(31);
                CrearTabla("5", codigoCliente, codigoLineaServicio, fechaAntes, DateTime.Today);
            }
        }
        protected void ddlEstadoContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Index"] = ddlEstadoContrato.SelectedIndex;           
        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["IdCliente"] = ddlCliente.SelectedItem.Value;           
        }

        protected void ddlLineaServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["IdLineaServicio"] = ddlLineaServicio.SelectedItem.Value;       
        } 
    }
}