<%@ Page Title="TMR : Listado de Adendas" Language="C#"
         MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeBehind="ListadoAdendas.aspx.cs"
         Inherits="TMD.SIG.ListadoAdendas" %>

<%@ Import Namespace="Entidades.CC" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <asp:Panel ID="pnlListado" runat="server">
    <h2>Listado de Adendas</h2>
    <hr />
    <p>Utilice los filtros de búsqueda para poder ubicar la adenda deseada.</p>
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
          <asp:TextBox ID="txtFiltroNumeroContrato" runat="server" Width="90%" MaxLength="15" />
        </td>
        <td width="2%">&nbsp;</td>
        <td class="labelForms" width="18%">
          N° de Adenda:
        </td>
        <td width="1%">&nbsp;</td>
        <td class="labelForms" width="30%">
          <asp:TextBox ID="txtFiltroNumeroAdenda" runat="server" Width="90%" MaxLength="15" />
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
          <asp:GridView ID="grdListadoAdendas" runat="server"  Width="100%" 
                        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                        CellSpacing="1" GridLines="None" PageSize="25" 
                        OnRowDataBound="grdListadoAdendas_RowDataBound" 
                onrowcommand="grdListadoAdendas_RowCommand">
            <Columns>
              <asp:BoundField HeaderText="ID" DataField="CODIGO_ADDENDA">
                <HeaderStyle Width="2%" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" />
              </asp:BoundField>
              <asp:TemplateField HeaderText="No. Contrato">
                <HeaderStyle Width="9%" HorizontalAlign="Center" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                <ItemTemplate>
                  <b><%# ((ContratoE)DataBinder.Eval(Container.DataItem, "Contrato")).NUMERO_CONTRATO %></b>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField HeaderText="No. Adenda" DataField="NUMERO_ADDENDA">
                <HeaderStyle Width="9%" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Center" Font-Bold="true" />
              </asp:BoundField>
              <asp:TemplateField HeaderText="Cliente">
                <HeaderStyle Width="20%" HorizontalAlign="Left" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                <ItemTemplate>
                  <b><%# ((ContratoE)DataBinder.Eval(Container.DataItem, "Contrato")).ClienteEnt.RAZON_SOCIAL%></b>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Servicio">
                <HeaderStyle Width="20%" HorizontalAlign="Left" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                <ItemTemplate>
                  <%# ((ContratoE)DataBinder.Eval(Container.DataItem, "Contrato")).Servicio.DESCRIPCION %>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField HeaderText="Descripcion" DataField="DESCRIPCION">
                <HeaderStyle Width="20%" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
              </asp:BoundField>
               <asp:BoundField HeaderText="Estado" DataField="ESTADO_DESCRIPCION">
                <HeaderStyle Width="9%" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Center" Font-Bold="true" />
              </asp:BoundField>
              <asp:TemplateField HeaderText="Acciones">
                <HeaderStyle Width="7%" HorizontalAlign="Center" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                <ItemTemplate>
                  <asp:ImageButton ID="btnVerAdenda" runat="server" Text="Ver Detalles" ImageUrl="~/Imagenes/view.png"
                                   ToolTip="Ver" Height="24px" Width="24px" />&nbsp;
                  <asp:ImageButton ID="btnAprobarAdenda" runat="server" Text="Cambiar Estado" ImageUrl="~/Imagenes/change_status.png"
                                   ToolTip="Cambiar Estado" Height="24px" Width="24px" />
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
    <asp:Panel ID="pnlActualizar" runat="server" Visible="false">
    <h2>ACTUALIZAR ESTADO DE Adenda</h2>
    <hr />
    <p>Permite cambiar el estado de una Adenda.</p>
    <table width="100%" align="center" border="0" cellpadding="1" cellspacing="1">
      <tr style="height:10px">
        <td colspan="7"></td>
      </tr>
      <tr>
        <td colspan="7">
          <b>Informacion del Contrato</b>
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
          Estado del Contrato:
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
          <b>Informacion y Estado de Adenda</b>
        </td>
      </tr>
      <tr>
        <td colspan="7"><hr /></td>
      </tr>
      <tr>
        <td class="labelForms">
          N° de Adenda:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms">
          <asp:Label ID="txtNumeroAdenda" runat="server" />
        </td>
        <td>&nbsp;</td>
        <td class="labelForms">
          Estado de la Adenda:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms">
          <asp:Label ID="txtEstadoAdenda" runat="server" Font-Bold="true" Font-Size="14px" />
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
      <tr style="height:10px">
        <td colspan="7"></td>
      </tr>
      <tr style="height:10px">
        <td colspan="7" align="right">
          <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="boton_01" 
            OnClick="btnAceptar_Click" OnClientClick="return confirm('Esta seguro que desea realizar esta accion?\nUna vez ejecutada dicha accion, ya no se puede volver atras.')" />&nbsp;
          <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="boton_01" 
            CausesValidation="false" onclick="btnCancelar_Click" />
        </td>
      </tr>
    </table>
    </asp:Panel>
</asp:Content>
