<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="organizacion.aspx.cs" Inherits="TMD.SIG.GEN.organizacion" MasterPageFile="~/Site.master"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <table>
        <tr>
            <td>
                <asp:Label ID="lblCodigo" Text="Codigo" runat="server" />
            </td>
            <td>
                <asp:TextBox ID="txtCodigo" Text="Nombre" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblNombre" Text="Nombre" runat="server" />
            </td>
            <td>
                <asp:TextBox ID="txtNombre" Text="Nombre" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMision" Text="Mision" runat="server" />
            </td>
            <td>
                <asp:TextBox ID="txtMision" Text="Nombre" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblVision" Text="Vision" runat="server" />
            </td>
            <td>
                <asp:TextBox ID="txtVision" Text="Nombre" runat="server" />
            </td>
        </tr>
        <tr>
        <td colspan="2">
            <asp:Button id="btnRegistrar" Text="Registrar" runat="server" 
                onclick="btnRegistrar_Click"/>    
        </td>
        </tr>
    </table>
    <div>
    </div>
    <br/>
    <br/>
    <asp:Button id="btnListar" Text="Listar" runat="server" 
        onclick="btnListar_Click" />    
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
      
    </asp:GridView>
</asp:Content>
