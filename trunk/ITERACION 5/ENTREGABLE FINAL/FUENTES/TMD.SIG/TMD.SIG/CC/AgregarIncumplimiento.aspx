<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarIncumplimiento.aspx.cs" Inherits="TMD.SIG.CC.AgregarIncumplimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/Validaciones.js" type="text/javascript"></script>
    <link href="../Styles/CC_style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            font-size: 20px;
            font-weight: 700;
            height: 35px;
            color: #003366;
        }
        .style8
        {
            color: #003366;
            height: 41px;
        }
        .style9
        {
        }
        .style14
        {
            color: #003366;
            height: 45px;
        }
        .style25
        {
            width: 228px;
        }
        .style27
        {
            width: 298px;
        }
        .style43
        {
            width: 195px;
            height: 28px;
        }
        .style44
        {
            width: 327px;
            height: 28px;
        }
        .style45
        {
            width: 325px;
            height: 28px;
        }
        .style52
        {
            height: 28px;
        }
        .style75
        {
            height: 28px;
            width: 170px;
        }
        .style76
        {
            width: 170px;
        }
        .style78
        {
            font-size: small;
            width: 671px;
            height: 26px;
        }
        .style79
        {
            width: 195px;
            height: 26px;
        }
        .style80
        {
            height: 26px;
        }
        .style81
        {
            font-size: small;
            width: 671px;
            height: 28px;
        }
        .style83
        {
            width: 176px;
        }
        .style84
        {
            width: 176px;
            height: 28px;
        }
        .style85
        {
            width: 157px;
        }
        .style86
        {
            width: 171px;
            height: 28px;
        }
        .style87
        {
            width: 171px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlContrato" runat="server" Height="180px" Width="899px">
    <div id="divContrato" style="height: 180px; width: 848px;">
        <table style="width:86%; height: 128px;">
            <tr>
                <td class="style1" colspan="4">
                    Datos del contrato</td>
            </tr>
            <tr>
                <td class="style81">
                    Número Contrato:</td>
                <td class="style43">
                    <asp:TextBox ID="txtContrato" runat="server" Width="193px" MaxLength="10"></asp:TextBox>
                </td>
                <td class="style52" colspan="2">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar Contrato" 
                        Width="127px" onclick="btnBuscar_Click" style="font-weight: 700" />
                </td>
            </tr>
            <tr>
                <td class="style81">
                    Monto:</td>
                <td class="style43">
                    <asp:Label ID="lblMonto" runat="server" ForeColor="Black"></asp:Label>
                </td>
                <td class="style44">
                    Estado del Contrato:</td>
                <td class="style45">
                    <asp:Label ID="lblEstado" runat="server" BorderWidth="0px" Width="137px" 
                        ForeColor="Black"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style81">
                    Razón Social:</td>
                <td class="style43">
                    <asp:Label ID="lblRazonSocial" runat="server" Text="lblRazonSocial" 
                        ForeColor="Black"></asp:Label>
                </td>
                <td class="style44">
                    </td>
                <td class="style45">
                    </td>
            </tr>
            <tr>
                <td class="style78">
                    Ruc:</td>
                <td class="style79">
                    <asp:Label ID="lblRuc" runat="server" Text="lblRuc" ForeColor="Black"></asp:Label>
                </td>
                <td class="style80" colspan="2">
                    <asp:HiddenField ID="txtNumeroContrato" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </asp:Panel>
    
    <asp:Panel ID="pnlIncumplimiento" runat="server" Visible="False" Height="1886px" 
        Width="899px" style="margin-right: 45px">
            <div id="div2" style="width: 851px;">
            <table style="width:86%;">
                <tr>
                    <td class="style8" colspan="2" style="font-size: 20px; font-weight: bold;">
                        Cláusula del contrato</td>
                </tr>
                <tr>
                    <td class="style86">
                        Cláusula(*):</td>
                    <td class="style75">
                        <asp:DropDownList ID="ddlClausula" runat="server" Height="19px" 
                            Width="418px" AutoPostBack="True" 
                            onselectedindexchanged="ddlClausula_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style86">
                        Penalidad:</td>
                    <td class="style75">
                        <asp:Label ID="lblPenalidad" runat="server" ForeColor="Black"></asp:Label>
                    </td>
                </tr>
                    <tr>
                        <td class="style86">
                            Monto(*):</td>
                        <td class="style75">
                            <asp:TextBox ID="txtMonto" runat="server" MaxLength="10"  onKeypress="return acceptNum(event)"></asp:TextBox>
                        </td>
                    </tr>
                <tr>
                    <td class="style86" style="font-size: small">
                        Motivo de Conciliación:</td>
                    <td class="style75">
                        <asp:TextBox ID="txtMotivo" runat="server" Height="58px" 
                            TextMode="MultiLine" Width="417px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 20px; font-weight: bold;" class="style14">
                        Datos del incumplimiento</td>
                </tr>
                <tr>
                    <td class="style86">
                        Descripción: (*)</td>
                    <td class="style75">
                        <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="200" 
                            Width="415px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style86">
                        Fecha (*)
                    </td>
                    <td class="style76">
                        <asp:TextBox ID="txtFecha" runat="server" MaxLength="10" ReadOnly="True"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="imgFecha" runat="server" 
                            ImageUrl="~/imagenes/Calendario.png" 
                            ToolTip="Click para mostrar u ocultar calendario" 
                            onclick="imgFecha_Click"/>
                    </td>
                </tr>
                <tr>
                    <td class="style87">
                        &nbsp;</td>
                    <td class="style76">
                        <asp:Calendar ID="cldFecha" runat="server" Visible="False" 
                            onselectionchanged="cldFecha_SelectionChanged">
                        </asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td class="style87" style="font-size: small">
                        &nbsp;</td>
                    <td class="style76">
                        &nbsp;</td>
                </tr>
                <tr>
                <td class="style9" colspan="2">
                    <table style="width:100%;">
                        <tr>
                            <td class="style85">
                                &nbsp;</td>
                            <td class="style25">
                                <asp:Button ID="btnGrabar" runat="server" onclick="btnGrabar_Click" 
                                    style="text-align: center; font-weight: 700" Text="Grabar" Width="167px" />
                            </td>
                            <td class="style27">
                                <asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
                                    style="font-weight: 700" Text="Cancelar" Width="178px" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
