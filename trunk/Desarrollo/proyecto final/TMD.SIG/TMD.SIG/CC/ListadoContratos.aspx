<%@ Page Title="Listado de Contratos" Language="C#"
         MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeBehind="ListadoContratos.aspx.cs"
         Inherits="TMD.SIG.ListadoContratos" %>

<%@ Import Namespace="Entidades.CC" %>
<%@ Import Namespace="Entidades.CR" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
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
          Cliente:
        </td>
        <td>&nbsp;</td>
        <td class="labelForms">
          <asp:TextBox ID="txtFiltroNombreCliente" runat="server" Width="90%" MaxLength="60" />
        </td>
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
                        CellSpacing="1" GridLines="None" PageSize="25">
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
                  <b><%# ((ClienteE)DataBinder.Eval(Container.DataItem, "Cliente")).RAZON_SOCIAL %></b>
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
              <asp:BoundField HeaderText="Monto" DataField="MONTO" DataFormatString="{0:#,##0.00}">
                <HeaderStyle Width="7%" HorizontalAlign="Right" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Right" />
              </asp:BoundField>
              <asp:TemplateField HeaderText="Moneda">
                <HeaderStyle Width="4%" HorizontalAlign="Right" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Right" />
                <ItemTemplate>
                  <%# ((MonedaE)DataBinder.Eval(Container.DataItem, "Moneda")).CODIGO_MONEDA %>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField HeaderText="Estado" DataField="ESTADO_DESCRIPCION">
                <HeaderStyle Width="9%" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="12px" HorizontalAlign="Center" Font-Bold="true" />
              </asp:BoundField>
            </Columns>
          </asp:GridView>
        </td>
      </tr>
    </table>
</asp:Content>
