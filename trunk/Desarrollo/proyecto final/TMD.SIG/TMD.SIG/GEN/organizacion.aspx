<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="organizacion.aspx.cs" Inherits="TMD.SIG.GEN.organizacion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
    <asp:GridView ID="GridView1" runat="server">
      
    </asp:GridView>
    </form>
</body>
</html>
