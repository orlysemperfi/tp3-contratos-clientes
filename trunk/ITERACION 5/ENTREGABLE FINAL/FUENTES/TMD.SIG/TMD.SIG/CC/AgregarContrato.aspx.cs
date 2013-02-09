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
    public partial class AgregarContrato : System.Web.UI.Page
    {
        #region Interfaces
        private IClienteBL clienteBL = new ClienteBL();
        private IMonedaBL monedaBL = new MonedaBL();
        private IServicioBL servicioBL = new ServicioBL();
        private ITipoClausulaBL tipoClausulaBL = new TipoClausulaBL();
        private IRolBL rolBL = new RolBL();
        private IEntregableBL entregableBL = new EntregableBL();
        private IIndicadorBL indicadorBL = new IndicadorBL();
        private IContratoBL contratoBL = new ContratoBL();
        private IClausulaBL clausulaBL = new ClausulaBL();
        #endregion

       protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnGuardar.Attributes.Add("onclick", "return confirm('¿Está Seguro(a) de guardar registro?”');");
                CargarCombos();
                CargarGrillas();
            } 
        }
       protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string strRUC = txtRUC.Text;
            LimpiarContrato();

            ClienteE beanCliente = new ClienteE();
            hidIdCliente.Value = "";
            beanCliente = clienteBL.ObtenerCliente(strRUC);
            if (strRUC.Length < 11)
            {
                muestraMensaje("Ingrese RUC completo");
                lblRazonSocial.Text = "";
                lblTipoCliente.Text = "";
                lblContacto.Text = "";
                pnlContrato.Visible = false;
            }
            else
            {
                if (beanCliente.RUC != null)
                {
                    lblRazonSocial.Text = beanCliente.RAZON_SOCIAL;
                    lblTipoCliente.Text = beanCliente.TIPO_CLIENTE;
                    lblContacto.Text = beanCliente.CONTACTO;

                    hidIdCliente.Value = Convert.ToString(beanCliente.CODIGO_CLIENTE);

                    CargarDivContrato();
                
                }else
                {
                    muestraMensaje("No existe Cliente registrado");
                }
            }
        }
       
        protected void cldInicio_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaInicio.Text = cldInicio.SelectedDate.ToShortDateString();
            pnlFecInicio.Visible = false;
        }
        protected void cldFin_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaFin.Text = cldFin.SelectedDate.ToShortDateString();
            pnlFecFin.Visible = false;
        }
        protected void cldFechaPactada_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaPactada.Text = cldFechaPactada.SelectedDate.ToShortDateString();
            pnlFecPactada.Visible = false;
        }

        //private void cambioCalendario(ref Calendar calendario)
        //{
        //    if (calendario.Visible)
        //    { calendario.Visible = false; }
        //    else
        //    { calendario.Visible = true; }
        //}



        //protected void btnAgregarC_Click(object sender, EventArgs e)
        //{
        //    pnlClausula.Visible = true;
        //    pnlContrato.Visible=false;
        //}

        //protected void btnCancelar_Click(object sender, EventArgs e)
        //{
        //    pnlClausula.Visible = false;
        //}

        //protected void btnAgregar_Click(object sender, EventArgs e)
        //{
        //    if (Session["Clausulas"] != null)
        //    {
        //        List<ClausulaE> lista = new List<ClausulaE>();
        //        lista = (List<ClausulaE>)HttpContext.Current.Session["Clausulas"];

        //        gridClausulas.DataSource = lista;
        //        gridClausulas.DataBind();
        //    }

        //    pnlContrato.Visible = true;
        //    pnlClausula.Visible = false;

        //  }

        //protected void gridClausulas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    List<ClausulaE> lstClasulas = new List<ClausulaE>();
        //    lstClasulas = (List<ClausulaE>)HttpContext.Current.Session["Clausulas"];
        //    lstClasulas.RemoveAt(e.RowIndex);
        //    Session["Clausulas"] = lstClasulas;
        //    gridClausulas.DataSource = lstClasulas;
        //    gridClausulas.DataBind();

        //}
        
        protected void gridClausulasG_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<ClausulaE> lstClasulas = new List<ClausulaE>();
            lstClasulas = (List<ClausulaE>)HttpContext.Current.Session["Clausulas"];
            lstClasulas.RemoveAt(e.RowIndex);
            if (lstClasulas.Count == 0)
            {
                Session["Clausulas"] = null;
                LimpiarGrilla(ref gridClausulasG);
                OcultarMostrarPanel(ref pnlC, gridClausulasG);
            }
            else
            {
            Session["Clausulas"] = lstClasulas;
            gridClausulasG.DataSource = lstClasulas;
            gridClausulasG.DataBind();
            }          
        }
        protected void gridEntregablesG_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<EntregableE> lista = new List<EntregableE>();
            lista = (List<EntregableE>)HttpContext.Current.Session["Entregables"];
            lista.RemoveAt(e.RowIndex);
            if (lista.Count == 0)
            {
                Session["Entregables"] = null;
                LimpiarGrilla(ref gridEntregablesG);
                OcultarMostrarPanel(ref pnlE, gridEntregablesG);
            }
            else { 
                Session["Entregables"] = lista;
                gridEntregablesG.DataSource = lista;
                gridEntregablesG.DataBind();
            }
        

        }
        protected void gridIndicadorG_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<EntregableE> lista = new List<EntregableE>();
            lista = (List<EntregableE>)HttpContext.Current.Session["Indicadores"];
            lista.RemoveAt(e.RowIndex);
            if (lista.Count == 0)
            {
                Session["Indicadores"] = null;
                LimpiarGrilla(ref gridIndicadorG);
                OcultarMostrarPanel(ref pnlI, gridIndicadorG);
            }
            else
            {
                Session["Indicadores"] = lista;
                gridIndicadorG.DataSource = lista;
                gridIndicadorG.DataBind();
            }
        }

        //protected void gridRolesC_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    List<RolE> lista = new List<RolE>();
        //    lista = (List<RolE>)HttpContext.Current.Session["RolesC"];
        //    lista.RemoveAt(e.RowIndex);
        //    Session["RolesC"] = lista; 
        //    gridRolesC.DataSource = lista;
        //    gridRolesC.DataBind();
        //}
       
        //protected void gridEntregablesC_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    List<EntregableE> lista = new List<EntregableE>();
        //    lista = (List<EntregableE>)HttpContext.Current.Session["EntregablesC"];
        //    lista.RemoveAt(e.RowIndex);
        //    Session["EntregablesC"] = lista;
        //    gridEntregablesC.DataSource = lista;
        //    gridEntregablesC.DataBind();

        //}

        
        //protected void gridIndicadorC_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    List<EntregableE> lista = new List<EntregableE>();
        //    lista = (List<EntregableE>)HttpContext.Current.Session["IndicadoresC"];
        //    lista.RemoveAt(e.RowIndex);
        //    Session["IndicadoresC"] = lista;
        //    gridIndicadorC.DataSource = lista;
        //    gridIndicadorC.DataBind();

        //}

        //protected void btnAgregarR_Click(object sender, EventArgs e)
        //{
        //    pnlRoles.Visible = true;
        //    pnlContrato.Visible = false;
        //}

        //protected void btnCancelarRol_Click(object sender, EventArgs e)
        //{
        //    pnlRoles.Visible = false;
        //    pnlContrato.Visible = true;
        //}

        //protected void btnAgregarRol_Click(object sender, EventArgs e)
        //{
        //    List<RolE> lista = new List<RolE>();

        //    foreach (GridViewRow linea in gridRolesG.Rows)
        //    {
        //        CheckBox marca = linea.Cells[0].FindControl("CheckBox1") as CheckBox;
        //        if (marca.Checked)
        //        {
        //            RolE bean = new RolE();
        //            bean.Codigo = int.Parse(gridRolesG.DataKeys[linea.RowIndex]["Codigo"].ToString());
        //            bean.Nombre = gridRolesG.DataKeys[linea.RowIndex]["Nombre"].ToString();
        //            lista.Add(bean);
        //        }
               
        //    }
            
        //    if (Session["RolesC"] == null)
        //    {
        //        HttpContext.Current.Session.Add("RolesC", lista);
        //    }
        //    else
        //    {
        //        Session["RolesC"] = lista; 
        //    }
        //    gridRolesG.DataSource = lista;
        //    gridRolesG.DataBind();

        //    pnlRoles.Visible = false;
        //    pnlContrato.Visible = true;
        //}

        //protected void btnAgregarE_Click(object sender, EventArgs e)
        //{
        //    pnlEntregables.Visible = true;
        //    pnlContrato.Visible = false;

        //    if (Session["EntregablesC"] != null)
        //    {
        //        List<EntregableE> lista = new List<EntregableE>();
        //        lista = (List<EntregableE>)HttpContext.Current.Session["EntregablesC"];
        //        gridEntregablesG.DataSource = lista;
        //        gridEntregablesG.DataBind();
        //    }
        //    if (Session["RolesC"] != null)
        //    {
        //        List<RolE> lista = new List<RolE>();
        //        lista = (List<RolE>)HttpContext.Current.Session["RolesC"];
        //        ddlRol.Items.Add(new ListItem(@"Seleccione", @"Seleccione"));

        //        foreach (RolE bean in lista)
        //        {
        //            ListItem a = new ListItem();
        //            a.Text = bean.Nombre;
        //            a.Value = bean.Codigo + "";
        //            ddlRol.Items.Add(a);
        //        }
        //    }  
        //}

        protected void btnAgregarCl_Click(object sender, EventArgs e)
        {
            if (ddlTipoClausula.SelectedIndex > 0 & txtDesClausula.Text.Length > 0)
            {
                if (chbPenalidad.Checked & (ddlTipoSancion.SelectedIndex < 1 || txtSancion.Text.Length < 1))
                    muestraMensaje("Ingrese datos de penalidad");
                else
                {
                    ClausulaE beanClausula = new ClausulaE();
                    List<ClausulaE> lstClasulas = new List<ClausulaE>();

                    beanClausula.IdTipo = int.Parse(ddlTipoClausula.SelectedItem.Value);
                    beanClausula.Tipo = ddlTipoClausula.SelectedItem.Text;
                    beanClausula.DESCRIPCION = txtDesClausula.Text;
                    beanClausula.Penalidad = 0;
                    beanClausula.TipoSancion = "-";

                    if (chbPenalidad.Checked)
                    {
                        beanClausula.Penalidad = 1;
                        beanClausula.IdTipoSancion = int.Parse(ddlTipoSancion.SelectedItem.Value);
                        beanClausula.TipoSancion = ddlTipoSancion.SelectedItem.Text;
                        beanClausula.SANCION = double.Parse(txtSancion.Text);
                    }
                    if (Session["Clausulas"] == null)
                    {
                        lstClasulas.Add(beanClausula);
                        HttpContext.Current.Session.Add("Clausulas", lstClasulas);
                    }
                    else
                    {
                        lstClasulas = (List<ClausulaE>)HttpContext.Current.Session["Clausulas"];
                        lstClasulas.Add(beanClausula);
                        Session["Clausulas"] = lstClasulas;
                    }

                    gridClausulasG.DataSource = lstClasulas;
                    gridClausulasG.DataBind();

                    OcultarMostrarPanel(ref pnlC, gridClausulasG);
                    txtDesClausula.Text = "";
                    txtSancion.Text = "";
                    ddlTipoSancion.SelectedIndex = 0;
                    chbPenalidad.Checked = false;
                    ddlTipoClausula.SelectedIndex = 0;

                    ddlTipoSancion.Enabled = false;
                    txtSancion.Enabled = false;
                }
            }
            else
            {
                muestraMensaje("Ingrese datos obligatorios");
            }
        }
        protected void btnAgregarEnt_Click(object sender, EventArgs e)
        {
            if (ddlRol.SelectedIndex != 0 & ddlEntregable.SelectedIndex != 0 & txtFechaPactada.Text.Length > 0)
            {

                if (ExisteEntregable())
                    muestraMensaje("El Entregable elegido ya fue asignado");
                else
                {
                    List<EntregableE> lista = new List<EntregableE>();
                    EntregableE bean = new EntregableE();
                    bean.Codigo = int.Parse(ddlEntregable.SelectedItem.Value);
                    bean.Nombre = ddlEntregable.SelectedItem.Text;
                    bean.CodigoRol = int.Parse(ddlRol.SelectedItem.Value);
                    bean.NombreRol = ddlRol.SelectedItem.Text;
                    bean.FechaPactada = Convert.ToDateTime(txtFechaPactada.Text);

                    if (Session["Entregables"] == null)
                    {
                        lista.Add(bean);
                        HttpContext.Current.Session.Add("Entregables", lista);
                    }
                    else
                    {
                        lista = (List<EntregableE>)HttpContext.Current.Session["Entregables"];
                        lista.Add(bean);
                        Session["Entregables"] = lista;
                    }
                    pnlE.Visible = false;
                    txtFechaPactada.Text = "";
                    ddlEntregable.SelectedIndex = 0;
                    ddlRol.SelectedIndex = 0;
                    gridEntregablesG.DataSource = lista;
                    gridEntregablesG.DataBind();
                }
            }
            else
                muestraMensaje("Ingrese datos obligatorios");

        }
        protected void btnAgregarInd_Click(object sender, EventArgs e)
        {
            if (ddlIndicadorG.SelectedIndex != 0 & ddlFrecuencia.SelectedIndex != 0 & txtValorObjetivo.Text.Length > 0)
            {
                if(ExisteIndicador())
                    muestraMensaje("El Indicador elegido ya fue asignado");
                else
                {
                    List<IndicadorE> lista = new List<IndicadorE>();
                    IndicadorE bean = new IndicadorE();
                    bean.Codigo = int.Parse(ddlIndicadorG.SelectedItem.Value);
                    bean.Nombre = ddlIndicadorG.SelectedItem.Text;
                    bean.ValorObjetivo = txtValorObjetivo.Text;
                    bean.Frecuencia = ddlFrecuencia.SelectedItem.Text;              

                    if (Session["Indicadores"] == null)
                    {
                        lista.Add(bean);
                        HttpContext.Current.Session.Add("Indicadores", lista);
                    }
                    else
                    {
                        lista = (List<IndicadorE>)HttpContext.Current.Session["Indicadores"];
                        lista.Add(bean);
                        Session["Indicadores"] = lista;
                    }
                    pnlI.Visible = false;
                    gridIndicadorG.DataSource = lista;
                    gridIndicadorG.DataBind();
                    ddlIndicadorG.SelectedIndex=0;
                    txtValorObjetivo.Text="";
                    ddlFrecuencia.SelectedIndex = 0;
                }
            }
            else
                muestraMensaje("Ingrese datos obligatorios");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string strMensaje = ValidaCampos();
            if (strMensaje != "")
                muestraMensaje(strMensaje);
            else
                RegistrarContrato();
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarContrato();
        }

        //protected void cldFechaPactada_SelectionChanged(object sender, EventArgs e)
        //{
        //    txtFechaPactada.Text = cldFechaPactada.SelectedDate.ToShortDateString();
        //    cambioCalendario(ref cldFechaPactada);
        //}

        //protected void btnCancelarEnt_Click(object sender, EventArgs e)
        //{
        //    pnlEntregables.Visible = false;
        //    pnlContrato.Visible = true;
        //}

        //protected void btnAceptarEnt_Click(object sender, EventArgs e)
        //{
        //    if (Session["EntregablesC"] != null)
        //    {
        //        List<EntregableE> lista = new List<EntregableE>();
        //        lista = (List<EntregableE>)HttpContext.Current.Session["EntregablesC"];
        //        gridEntregablesC.DataSource = lista;
        //        gridEntregablesC.DataBind();
        //    }

        //    pnlEntregables.Visible = false;
        //    pnlContrato.Visible = true;
        //}

        //protected void btnAgregarIndC_Click(object sender, EventArgs e)
        //{
        //    if (Session["IndicadoresC"] != null)
        //    {
        //        List<IndicadorE> lista = new List<IndicadorE>();
        //        lista = (List<IndicadorE>)HttpContext.Current.Session["IndicadoresC"];
        //        gridIndicadorG.DataSource = lista;
        //        gridIndicadorG.DataBind();
        //    }
        //    pnlIndicadores.Visible = true;
        //    pnlContrato.Visible = false;


        //}

        

        //protected void CancelarInd_Click(object sender, EventArgs e)
        //{
        //    pnlIndicadores.Visible = false;
        //    pnlContrato.Visible = true;
        //}

        //protected void btnAceptarInd_Click(object sender, EventArgs e)
        //{
        //    if (Session["IndicadoresC"] != null)
        //    {
        //        List<IndicadorE> lista = new List<IndicadorE>();
        //        lista = (List<IndicadorE>)HttpContext.Current.Session["IndicadoresC"];
        //        gridIndicadorC.DataSource = lista;
        //        gridIndicadorC.DataBind();
        //    }

        //    pnlIndicadores.Visible = false;
        //    pnlContrato.Visible = true;
        //}



        //protected void Menu1_MenuItemClick(object sender,EventArgs e)
        //{        
        //    for (int i = 0; i <= Menu1.Items.Count - 1; i++)
        //    {
        //        if (Menu1.Items[i].Selected)
        //        {
        //            Menu1.Items[i].ImageUrl = "~/imagenes/" + Menu1.Items[i].Value + "_a.png";
        //            MultiView1.ActiveViewIndex = i;
        //        }
        //        else
        //            Menu1.Items[i].ImageUrl = "~/imagenes/" + Menu1.Items[i].Value + "_d.png"; 

        //    }
        //}

        #region imageneBoton
        protected void imgFechaInicio_Click(object sender, ImageClickEventArgs e)
        {
            pnlFecInicio.Visible = true;
        }
        protected void imgFechaFin_Click(object sender, ImageClickEventArgs e)
        {
            pnlFecFin.Visible = true;
        }
        protected void ImgFechaPactada_Click(object sender, ImageClickEventArgs e)
        {
            pnlFecPactada.Visible = true;
        }
        protected void imgBtnClausula_Click(object sender, ImageClickEventArgs e)
        {
            MostrarOcultarPanel(ref pnlClausula, ref pnlContrato);
        }
        protected void imgBtnRol_Click(object sender, ImageClickEventArgs e)
        {
            MostrarOcultarPanel(ref pnlRoles, ref pnlContrato);
        }
        protected void imgBtnEntregable_Click(object sender, ImageClickEventArgs e)
        {
            MostrarOcultarPanel(ref pnlEntregables, ref pnlContrato);

        }
        protected void imgBtnIndicador_Click(object sender, ImageClickEventArgs e)
        {
            MostrarOcultarPanel(ref pnlIndicadores, ref pnlContrato);
        }
        #endregion

        protected void btnRegContrato_C_Click(object sender, EventArgs e)
        {
            MostrarOcultarPanel(ref pnlContrato, ref pnlClausula);
          
        }
        protected void btnRegContrato_R_Click(object sender, EventArgs e)
        {
            MostrarOcultarPanel(ref pnlContrato, ref pnlRoles);
            List<RolE> listRol = new List<RolE>();
            listRol = listaRol();
            if (listRol.Count != 0)
            {
                ddlRol.DataSource = listRol;
                ddlRol.DataValueField = "Codigo";
                ddlRol.DataTextField = "Nombre";
                ddlRol.DataBind();
                ddlRol.Items.Insert(0, new ListItem("Seleccione", "Seleccione"));
                if (Session["Roles"] == null)
                    HttpContext.Current.Session.Add("Roles", listRol);
                else
                    Session["Roles"] = listRol;
            }
            else
                Session["Roles"] = null;
        }
        protected void btnRegContrato_E_Click(object sender, EventArgs e)
        {
            MostrarOcultarPanel(ref pnlContrato, ref pnlEntregables);
        }
        protected void btnRegContrato_I_Click(object sender, EventArgs e)
        {
            MostrarOcultarPanel(ref pnlContrato, ref pnlIndicadores);
        }

        #region Funciones de ayuda
        private void muestraMensaje(string mensaje)
        {
            string Clientescript = ("<script>alert(\'" + mensaje + "\')</script>");
            if (!ClientScript.IsClientScriptBlockRegistered("WMensaje"))
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "WMensaje", Clientescript);
            }
        }
        void OcultarMostrarPanel(ref Panel pnlPanel, GridView gridGrilla)
        {
            if (gridGrilla.Rows.Count == 0)
                pnlPanel.Visible = true;
            else
                pnlPanel.Visible = false;
        }
        void LimpiarGrilla(ref GridView gridgrilla)
        {
            gridgrilla.DataSource = null;
            gridgrilla.DataBind();
        }
        void MostrarOcultarPanel(ref Panel pnlMostrar, ref Panel pnlOcultar) {
            pnlMostrar.Visible = true;
            pnlOcultar.Visible = false;
        }
        private void CargarDivContrato()
        {
            pnlContrato.Visible = true;
            LimpiarContrato();

        }
        private string ValidaCampos()
        {
            if (lblTipoCliente.Text == "PÚBLICO" & txtBuenaPro.Text == "")
                return "Ingresar Buena Pro para cliente público";
            if (txtCartaFianza.Text == "")
                return "Ingresar Carta Fianza";
            if (txtFechaInicio.Text == "" || txtFechaFin.Text == "")
                return "Ingresar las fechas completas";
            if (ddlMoneda.SelectedIndex < 1)
                return "Seleccionar moneda";
            if (txtMonto.Text == "")
                return "Ingresar monto";
            if (ddlServicio.SelectedIndex < 1)
                return "Seleccionar servicio";
            if (txtDesContrato.Text == "")
                return "Ingresar descripcion del contrato";
            if (gridClausulasG.Rows.Count == 0)
                return "Ingresar Claúsulas";
            if (Session["Roles"] == null)
                return "Ingresar Roles";
            if (gridEntregablesG.Rows.Count == 0)
                return "Ingresar Entregables";
            if (gridIndicadorG.Rows.Count == 0)
                return "Ingresar Indicadores";

            return "";
        }
        private void LimpiarContrato()
        {
            txtBuenaPro.Text = "";
            txtCartaFianza.Text = "";
            txtFechaInicio.Text = "";
            txtFechaFin.Text = "";
            ddlMoneda.SelectedIndex = 0;
            txtMonto.Text = "";
            txtDesContrato.Text = "";
            ddlServicio.SelectedIndex = 0;

            Session["Clausulas"] = null;
            Session["Roles"] = null;
            Session["Entregables"] = null;
            Session["Indicadores"] = null;

            LimpiarGrilla(ref gridClausulasG);
            LimpiarGrilla(ref gridEntregablesG);
            LimpiarGrilla(ref gridIndicadorG);
            ReiniciargridRol();

        }
        private void CargarCombos()
        {
            //Se carga Monedas
            ddlMoneda.Items.Clear();
            monedaBL.LLenarDrop(ref ddlMoneda);
            //Se carga Servicios
            ddlServicio.Items.Clear();
            servicioBL.LLenarDrop(ref ddlServicio);
            //Se carga Tipo se clausula
            ddlTipoClausula.Items.Clear();
            tipoClausulaBL.LLenarDrop(ref ddlTipoClausula);
            //Se carga combo de Entregables
            ddlEntregable.Items.Clear();
            entregableBL.LLenarDrop(ref ddlEntregable);
            //Se carga combo de indicadores
            ddlIndicadorG.Items.Clear();
            indicadorBL.LLenarDrop(ref ddlIndicadorG);
        }
        private void CargarGrillas()
        {
            gridRolesG.DataSource = rolBL.ObteneRoles();
            gridRolesG.DataBind();
        }
        private List<RolE> listaRol() {
            List<RolE> lista = new List<RolE>();
            foreach (GridViewRow linea in gridRolesG.Rows)
            {
                CheckBox marca = linea.Cells[0].FindControl("CheckBox1") as CheckBox;
                if (marca.Checked)
                {
                    RolE bean = new RolE();        
                    bean.Codigo = int.Parse(gridRolesG.DataKeys[linea.RowIndex]["Codigo"].ToString());
                    bean.Nombre = gridRolesG.DataKeys[linea.RowIndex]["Nombre"].ToString();
                    lista.Add(bean);
                }
            }
            return lista;
        }       
        private void ReiniciargridRol()
        {
            foreach (GridViewRow linea in gridRolesG.Rows)
            {
                CheckBox marca = linea.Cells[0].FindControl("CheckBox1") as CheckBox;
                if (marca.Checked)
                    marca.Checked=false;   
           }
        }
        #endregion

        #region Funciones para BD
         void RegistrarContrato()
        {

            try
            {
                int idContrato = 0;
                ContratoE beanContrato = new ContratoE();
                beanContrato.CODIGO_CLIENTE = int.Parse(hidIdCliente.Value);
                beanContrato.NUMERO_BUENA_PRO = txtBuenaPro.Text;
                beanContrato.NUMERO_CARTA_FIANZA = txtCartaFianza.Text;
                beanContrato.FECHA_INICIO = Convert.ToDateTime(txtFechaInicio.Text);
                beanContrato.FECHA_FIN = Convert.ToDateTime(txtFechaFin.Text);
                beanContrato.CODIGO_MONEDA = ddlMoneda.SelectedItem.Value;
                beanContrato.MONTO = decimal.Parse(txtMonto.Text);
                beanContrato.DESCRIPCION = txtDesContrato.Text;
                beanContrato.CODIGO_SERVICIO = int.Parse(ddlServicio.SelectedItem.Value);
                contratoBL.insertar(beanContrato);

                idContrato = beanContrato.CODIGO_CONTRATO;

                if (idContrato > 0)
                {
                    RegistrarClausulas(idContrato);
                    RegistrarRoles(idContrato);
                    RegistrarEntregables(idContrato);
                    RegistrarIndicadores(idContrato);

                    muestraMensaje("Registro de contrato satisfactorio");
                    LimpiarContrato();
                }
                else
                {
                    muestraMensaje("Error en registro de contrato, favor informar a soporte");
                }

            }
            catch (Exception ex) { muestraMensaje("Error al grabar Contrato: \n" + ex.Message); }
        }
         private void RegistrarClausulas(int idContrato)
         {
             if (Session["Clausulas"] != null)
             {
                 List<ClausulaE> lista = new List<ClausulaE>();
                 lista = (List<ClausulaE>)HttpContext.Current.Session["Clausulas"];
                 foreach (ClausulaE bean in lista)
                 {
                     clausulaBL.insertar(bean, idContrato);
                 }
             }
         }
         private void RegistrarRoles(int idContrato)
         {
             if (Session["Roles"] != null)
             {
                 List<RolE> lista = new List<RolE>();
                 lista = (List<RolE>)HttpContext.Current.Session["Roles"];
                 foreach (RolE bean in lista)
                 {
                     rolBL.insertar(bean, idContrato);
                 }
             }
         }
         private void RegistrarEntregables(int idContrato)
         {
             if (Session["Entregables"] != null)
             {
                 List<EntregableE> lista = new List<EntregableE>();
                 lista = (List<EntregableE>)HttpContext.Current.Session["Entregables"];
                 foreach (EntregableE bean in lista)
                 {
                     entregableBL.insertar(bean, idContrato);
                 }
             }
         }
         private void RegistrarIndicadores(int idContrato)
         {
             if (Session["Indicadores"] != null)
             {
                 List<IndicadorE> lista = new List<IndicadorE>();
                 lista = (List<IndicadorE>)HttpContext.Current.Session["Indicadores"];
                 foreach (IndicadorE bean in lista)
                 {
                     indicadorBL.insertar(bean, idContrato);
                 }
             }
         }
        #endregion

         protected void chbPenalidad_CheckedChanged(object sender, EventArgs e)
         {
             ddlTipoSancion.Enabled = chbPenalidad.Checked;
             txtSancion.Enabled = chbPenalidad.Checked;
         }

         private bool ExisteEntregable()
         {
             int CodigoEntregable= int.Parse(ddlEntregable.SelectedValue);

             if (Session["Entregables"] != null)
             {
                 List<EntregableE> listaE = new List<EntregableE>();
                 listaE = (List<EntregableE>)HttpContext.Current.Session["Entregables"];
                 foreach (EntregableE entregableE in listaE)
                     if (entregableE.Codigo == CodigoEntregable) return true;
             }
             return false;
         }

         private bool ExisteIndicador()
         {
             int CodigoIndicador= int.Parse(ddlIndicadorG.SelectedValue);

             if (Session["Indicadores"] != null)
             {
                 List<IndicadorE> listaI = new List<IndicadorE>();
                 listaI = (List<IndicadorE>)HttpContext.Current.Session["Indicadores"];
                 foreach (IndicadorE indicadorE in listaI)
                     if (indicadorE.Codigo == CodigoIndicador) return true;
             }
             return false;
         }
    }
}