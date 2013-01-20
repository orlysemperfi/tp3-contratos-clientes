<%@ Page Title="Listado de Contratos y Adendas" Language="C#"
         MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeBehind="ListadoContratos.aspx.cs"
         Inherits="TMD.SIG.ListadoContratos" %>

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
          Tipo de Documento:
        </td>
        <td width="1%">&nbsp;</td>
        <td class="labelForms" width="30%">
          <asp:DropDownList ID="ddlFiltroTipoDocumento" runat="server" Width="90%">
            <asp:ListItem Value="1" Text="Tipo 1" />
            <asp:ListItem Value="2" Text="Tipo 2" />
          </asp:DropDownList>
        </td>
        <td width="2%">&nbsp;</td>
        <td class="labelForms" width="18%">
          N° de Documento:
        </td>
        <td width="1%">&nbsp;</td>
        <td class="labelForms" width="30%">
          <asp:TextBox ID="txtFiltroNumeroDocumento" runat="server" Width="90%" MaxLength="50" />
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
          <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="boton_01" />&nbsp;
          <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="boton_01" CausesValidation="false" />
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
              <asp:BoundField HeaderText="ID" DataField="CodigoContrato">
                <HeaderStyle Width="3%" Font-Size="12px" BackColor="#3A4F63" ForeColor="#FFFFFF" />
                <ItemStyle Font-Size="11px" />
              </asp:BoundField>
            </Columns>
          </asp:GridView>
        </td>
      </tr>
    </table>
</asp:Content>
