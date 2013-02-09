<%@ Page Title="TMR : Listado de Contratos" Language="C#"
         MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeBehind="ListadoContratos.aspx.cs"
         Inherits="TMD.SIG.ListadoContratos" %>

<%@ Import Namespace="Entidades.CC" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Panel ID="pnlListado" runat="server">
    
    <h2>Listado de Contratos</h2>
    <hr />
    <p>Utilice los filtros de búsqueda para poder ubicar el contrato deseado.</p>
    <table width="100%" align="center" border="0" cellpadding="1" cellspacing="1">
      <tr style="height:10px">
        <td colspan="7"></td>
      </tr>
      <tr>
        <td class="labelForms" width="18%">
          N° de Contrato:
        </td>
        <td width="1%">&nbsp;</td>
        <td class="labelForms" width="30%">
          <asp:TextBox ID="txtFiltroNumeroContrato" runat="server" Width="90%" MaxLength="50" />
        </td>
        <td width="2%">&nbsp;</td>
        <td class="labelForms" width="18%">
          Descripcion:
        </td>
        <td width="1%">&nbsp;</td>
        <td class="labelForms" width="30%">
          <asp:TextBox ID="txtFiltroDescripcion" runat="server" Width="90%" MaxLength="50" />
        </td>
      </tr>
      <tr>
        <td class="labelForms">
          Servicio:
        </td>
        <td>&nbsp;</td>
        <td class="labelForms">
          <asp:DropDownList ID="ddlFiltroServicio" runat="server" Width="90%">
            <asp:ListItem Value="1" Text="Servicio 1" />
            <asp:ListItem Value="2" Text="Servicio 2" />
          </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
        <td class="labelForms">
            &nbsp;</td>
        <td>&nbsp;</td>
        <td class="labelForms">
            &nbsp;</td>
      </tr>
      <tr style="height:10px">
        <td colspan="7"></td>
      </tr>
      <tr style="height:10px">
        <td colspan="7" align="right">
          <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="boton_01" 
            onclick="btnBuscar_Click" />&nbsp;
          <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="boton_01" 
            CausesValidation="false" onclick="btnLimpiar_Click" />
        </td>
      </tr>
      <tr style="height:10px">
        <td colspan="7"><hr /></td>
      </tr>
      <tr style="height:10px">
        <td colspan="7"></td>
      </tr>
      <tr>
        <td colspan="7">
          <asp:GridView ID="grdListadoContratos" runat="server"  Width="100%" 
                        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                        CellSpacing="1" GridLines="None" PageSize="25" 
            onrowdatabound="grdListadoContratos_RowDataBound" 
                DataKeyNames="CODIGO_CONTRATO" onrowcommand="grdListadoContratos_RowCommand">
            <Columns>
              <asp:BoundField HeaderText="ID" DataField="CODIGO_CONTRATO">
                <HeaderStyle Width="2%" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" />
              </asp:BoundField>
              <asp:TemplateField HeaderText="Servicio">
                <HeaderStyle Width="18%" HorizontalAlign="Left" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                <ItemTemplate>
                  <b><%# ((ServicioE)DataBinder.Eval(Container.DataItem, "Servicio")).DESCRIPCION %></b>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Cliente">
                <HeaderStyle Width="18%" HorizontalAlign="Left" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                <ItemTemplate>
                  <b><%# ((ClienteE)DataBinder.Eval(Container.DataItem, "ClienteEnt")).RAZON_SOCIAL%></b>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField HeaderText="No. Contrato" DataField="NUMERO_CONTRATO">
                <HeaderStyle Width="9%" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
              </asp:BoundField>
              <asp:BoundField HeaderText="No. Buena Pro" DataField="NUMERO_BUENA_PRO">
                <HeaderStyle Width="11%" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
              </asp:BoundField>
              <asp:BoundField HeaderText="Fecha Inicio" DataField="FECHA_INICIO" DataFormatString="{0:dd/MM/yyyy}">
                <HeaderStyle Width="10%" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
              </asp:BoundField>
              <asp:BoundField HeaderText="Fecha Fin" DataField="FECHA_FIN" DataFormatString="{0:dd/MM/yyyy}">
                <HeaderStyle Width="10%" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
              </asp:BoundField>
              <asp:TemplateField HeaderText="Moneda">
                <HeaderStyle Width="4%" HorizontalAlign="Right" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Right" />
                <ItemTemplate>
                  <%# double.Parse(DataBinder.Eval(Container.DataItem, "Monto").ToString()).ToString("#,##0.00") + " " + ((MonedaE)DataBinder.Eval(Container.DataItem, "Moneda")).CODIGO_MONEDA%>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField HeaderText="Estado" DataField="ESTADO_DESCRIPCION">
                <HeaderStyle Width="9%" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Center" Font-Bold="true" />
              </asp:BoundField>
              <asp:TemplateField HeaderText="Acciones">
                <HeaderStyle Width="7%" HorizontalAlign="Center" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                <ItemTemplate>
                  <asp:ImageButton ID="btnVerContrato" runat="server" Text="Ver Detalles" ImageUrl="~/Imagenes/view.png"
                                   ToolTip="Ver" Height="24px" Width="24px" />&nbsp;
                  <asp:ImageButton ID="btnAprobarContrato" runat="server" Text="Cambiar Estado" ImageUrl="~/Imagenes/change_status.png"
                                   ToolTip="Cambiar Estado" Height="24px" Width="24px"  />
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </td>
      </tr>
      <tr style="height:10px">
        <td colspan="7" align="right">
            
        </td>
      </tr>
    </table>
            </asp:Panel>
            <asp:Panel ID="pnlActualizar" runat="server" Visible="False">
                <h2>ACTUALIZAR ESTADO DE Contrato</h2>
    <hr />
    <p>Permite cambiar el estado de un Contrato.</p>
    <table width="100%" align="center" border="0" cellpadding="1" cellspacing="1">
      <tr style="height:10px">
        <td colspan="7"></td>
      </tr>
      <tr>
        <td colspan="7">
          <b>Informacion General</b>
        </td>
      </tr>
      <tr>
        <td colspan="7"><hr /></td>
      </tr>
      <tr>
        <td class="labelForms" width="18%">
          N° de Contrato:
        </td>
        <td width="1%">&nbsp;</td>
        <td class="controlForms" width="30%">
          <asp:Label ID="txtNumeroContrato" runat="server" Font-Bold="true" Font-Size="14px" />
        </td>
        <td width="2%">&nbsp;</td>
        <td class="labelForms" width="23%">
          Estado:
        </td>
        <td width="1%">&nbsp;</td>
        <td class="controlForms" width="25%">
          <asp:Label ID="txtNombreEstado" runat="server" Font-Bold="true" Font-Size="14px" />
        </td>
      </tr>
      <tr>
        <td class="labelForms">
          Servicio:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms" colspan="5">
          <asp:Label ID="txtNombreServicio" runat="server" />
        </td>
      </tr>
      <tr>
        <td class="labelForms">
          Cliente:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms" colspan="5">
          <asp:Label ID="txtNombreCliente" runat="server" />
        </td>
      </tr>
      <tr>
        <td class="labelForms">
          N° de Buena Pro:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms">
          <asp:Label ID="txtNumeroBuenaPro" runat="server" />
        </td>
        <td>&nbsp;</td>
        <td class="labelForms">
          N° de Carta Fianza:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms">
          <asp:Label ID="txtNumeroCartaFianza" runat="server" />
        </td>
      </tr>
      <tr>
        <td class="labelForms">
          Fecha de Inicio:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms">
          <asp:Label ID="txtFechaInicio" runat="server" />
        </td>
        <td>&nbsp;</td>
        <td class="labelForms">
          Fecha de Fin:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms">
          <asp:Label ID="txtFechaFin" runat="server" />
        </td>
      </tr>
      <tr style="height:15px">
        <td colspan="7"></td>
      </tr>
      <tr>
        <td colspan="7">
          <b>Estado de Contrato</b>
        </td>
      </tr>
      <tr>
        <td colspan="7"><hr /></td>
      </tr>
      <tr id="trMotivoVer" runat="server">
        <td class="labelForms">
          Motivo:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms" colspan="5">
          <asp:Label ID="txtMotivoVer" runat="server" />
        </td>
      </tr>
      <tr id="trFechaTerminoVer" runat="server">
        <td class="labelForms">
          Fecha de Actualizacion:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms" colspan="5">
          <asp:Label ID="txtFechaTermino" runat="server" />
        </td>
      </tr>
      <tr id="trEstadoCambiar" runat="server">
        <td class="labelForms">
          Estado:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms" colspan="5">
          <asp:DropDownList ID="ddlProximoEstado" runat="server" />
        </td>
      </tr>
      <tr id="trMotivoCambiar" runat="server">
        <td class="labelForms">
          Motivo:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms" colspan="5">
          <asp:TextBox ID="txtMotivoCambiar" runat="server" TextMode="MultiLine" Rows="4" Width="100%" />
        </td>
      </tr>
      <tr style="height:10px">
        <td colspan="7"></td>
      </tr>
      <tr style="height:10px">
        <td colspan="7" align="right">
          <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="boton_01" 
            OnClick="btnAceptar_Click" OnClientClick="return confirm('Esta seguro que desea realizar esta accion?\nUna vez ejecutada dicha accion, ya no se puede volver atras.')" />&nbsp;
          <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="boton_01" 
            CausesValidation="false" 
                onclick="btnCancelar_Click" />
        </td>
      </tr>
    </table>
            </asp:Panel>
</asp:Content>
