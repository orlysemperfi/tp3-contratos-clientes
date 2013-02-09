<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TMD.SIG._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table align="center">
        <tr>
            <td>
                <asp:Image ID="imgContrato" runat="server" Height="290px" 
                    ImageUrl="~/imagenes/contrato.jpg" Width="386px" />
            </td>
        </tr>
    </table>
</asp:Content>
