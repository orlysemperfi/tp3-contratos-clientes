<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MonitoreoContratos.aspx.cs" Inherits="TMD.SIG.CC.MonitoreoContratos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/Validaciones.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
 
        function Cerrar() {
            var div;
            div = document.getElementById("MainContent_contenedor");
            div.style.visibility = "hidden";
            window.location = "MonitoreoContratos.aspx";
        }
     
    </script>
    <style type="text/css">   
        a:link {
            color: white;
        }
        a:hover {
            color: white;
        }
        a:visited {
            color: white;
        }
        a:active {
            color: white;
        }     
        .style1
        {
            height: 69px;
        }        
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlMonitoreo" runat="server">
    <div id="divMonitoreo" style="height: 122px; width: 901px; margin-right: 233px;">
        <table>
            <tr>
                <td class="bold" colspan="3" 
                    style="font-size: 20px; font-weight: bold">
                    Monitoreo de Contratos</td>                
            </tr>
            <tr><td colspan="3">
                <br />
                </td></tr>
            <tr>
            <td>
            <label>Próximos a vencer:</label>                     
                <asp:DropDownList ID="ddlEstadoContrato" runat="server" AutoPostBack="True" 
                    EnableViewState="False" 
                    onselectedindexchanged="ddlEstadoContrato_SelectedIndexChanged">
                    <asp:ListItem Text="Todos" Value="Todos"></asp:ListItem>
                    <asp:ListItem Text="Vencidos" Value="Vencidos"></asp:ListItem>
                    <asp:ListItem Text="Menores a 15 días" Value="Menores a 15 días"></asp:ListItem>
                    <asp:ListItem Text="Entre 15 a 30 días" Value="Entre 15 a 30 días"></asp:ListItem>
                    <asp:ListItem Text="Mayores a 30 días" Value="Mayores a 30 días"></asp:ListItem>
                </asp:DropDownList>            
            </td>   
            <td>
            <label>Cliente:</label>
                <asp:DropDownList ID="ddlCliente" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlCliente_SelectedIndexChanged">
                    </asp:DropDownList>   
            </td> 
            <td>
            <label>L&iacute;nea de Servicio:</label>                     
                <asp:DropDownList ID="ddlLineaServicio" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlLineaServicio_SelectedIndexChanged">
                    </asp:DropDownList>         
            </td>            
            </tr>
            <tr><td colspan="3">
                <br />
                </td></tr>
            <tr valign="top">
                <td colspan="2" class="style1">
                    <div id="Contenido" name="Contenido" runat="server" style="overflow:scroll;height:280px;width:650px;">
                        <table id="tblContratos" width="700px" runat="server" cellpadding="8" cellspacing="1">
                        </table>
                    </div>            
                </td>
                <td class="style1" >
                    <table>
                        <tr><td style="width:20px;background-color:Red;"></td><td>Vencidos (<b><asp:Label 
                                ID="lblEstado0" runat="server"></asp:Label></b>)</td></tr>
                        <tr><td style="width:20px;background-color:Orange;"></td><td>Menores a 15 días (<b><asp:Label 
                                ID="lblEstado1" runat="server"></asp:Label></b>)</td></tr>
                        <tr><td style="width:20px;background-color:#0099FF;"></td><td>Entre 15 a 30 días (<b><asp:Label 
                                ID="lblEstado2" runat="server"></asp:Label>)</b></td></tr>
                        <tr><td style="width:20px;background-color:Green;"></td><td>Mayores a 30 días (<b><asp:Label 
                                ID="lblEstado3" runat="server"></asp:Label>)</b></td></tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div runat="server" id="contenedor" name="contenedor">
            
                        <table>
                            <tr><td>Nro. Contrato:</td><td>
                                <asp:Label ID="lblNroContrato" runat="server" Text=""></asp:Label></td></tr>
                            <tr><td>Descripci&oacute;n:</td><td>
                                <asp:Label ID="lblDescripcion" runat="server" Text=""></asp:Label></td></tr>
                            <tr><td>Fecha Inicio:</td><td>
                                <asp:Label ID="lblFecIni" runat="server" Text=""></asp:Label></td></tr>
                            <tr><td>Fecha Fin:</td><td>
                                <asp:Label ID="lblFecFin" runat="server" Text=""></asp:Label></td></tr>
                            <tr><td># Addendas:</td><td>
                                <asp:Label ID="lblNroAddendas" runat="server" Text=""></asp:Label></td></tr>
                            <tr><td colspan="2"><hr /></td></tr>
                            <tr><td>Raz&oacute;n Social:</td><td>
                                <asp:Label ID="lblRazSocial" runat="server" Text=""></asp:Label></td></tr>
                            <tr><td>RUC:</td><td><asp:Label ID="lblRuc" runat="server" Text=""></asp:Label></td></tr>
                            <tr><td>Persona Contacto:</td><td><asp:Label ID="lblContacto" runat="server" Text=""></asp:Label></td></tr>
                            <tr><td>Tel&eacute;fono:</td><td><asp:Label ID="lblTel" runat="server" Text=""></asp:Label></td></tr>
                            <tr><td colspan="2">                
                                <input id="btnSalir" type="button" value="Cerrar" onclick="Cerrar()" />
                            </td></tr>
                        </table>
            
                    </div>
                </td>
            </tr>
            <tr>
            <td colspan="3">Total de Registros:
                <b><asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></b>
                </td>
            </tr>
         </table>
    </div>
    </asp:Panel>
    
 

</asp:Content>