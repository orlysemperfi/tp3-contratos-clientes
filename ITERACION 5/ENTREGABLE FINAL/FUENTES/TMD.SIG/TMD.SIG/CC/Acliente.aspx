<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Acliente.aspx.cs" Inherits="TMD.SIG.CC.Acliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style20
        {
            width: 69px;
        }
        .style53
        {
            width: 180px;
        }
        .style54
        {
            width: 81px;
        }
        .style55
        {
            width: 121px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlContrato" runat="server" Height="701px" Width="750px">
        <table class="style1">
            <tr>
                <td class="style55" colspan="2">
                    <asp:Label ID="labTituloEdicion" runat="server" 
                        Text="Creacion de Cliente" Font-Bold="True" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style55">
                    Razon Social:
                </td>
                <td class="style53">
                    <asp:TextBox ID="txtRazonSocial" runat="server" Width="327px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style55">
                    RUC:
                </td>
                <td class="style53">
                    <asp:TextBox ID="txtRucConsulta" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style55">
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnBuscarCliente" runat="server" Font-Bold="True" Height="26px" Text="Buscar Cliente"
                        Width="139px" CausesValidation="False" OnClick="btnBuscarCliente_Click1" />
                    <asp:Button ID="btnCancelar" runat="server" Font-Bold="True" Height="26px" Text="Cancelar"
                        Width="139px" OnClick="btnCancelarBusqueda_Click" CausesValidation="False" />
                </td>
            </tr>
            <tr>
                <td class="style55">
                    &nbsp;
                </td>
                <td class="style17" colspan="2">
                    <asp:GridView ID="grvOportunidad" runat="server" CellPadding="4" DataKeyNames="RUC"
                        ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grvOportunidad_SelectedIndexChanged"
                        Width="595px" AutoGenerateColumns="False" PageSize="3">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="RUC" HeaderText="RUC">
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RAZON_SOCIAL" HeaderText="RAZON SOCIAL" />
                            <asp:BoundField DataField="RUBRO" HeaderText="RUBRO" >
                            <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TIPO" HeaderText="TIPO" Visible="False" />
                            <asp:CommandField SelectText="Crear" ShowSelectButton="True">
                                <ItemStyle Width="40px" />
                            </asp:CommandField>
                        </Columns>
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
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlOportunidadVenta" runat="server" Visible="false" Height="701px"
        Width="750px">
        <table class="style1">
            <tr>
                <td class="style56">
                    <asp:Label ID="Label1" runat="server" CssClass="page-title" 
                        Text="Agregar al Cliente" Font-Bold="True" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style56">
                    <asp:Panel ID="pnlOportunidad" runat="server" GroupingText="Oportunidad venta">
                        <table class="style1">
                            <tr>
                                <td class="style54">
                                    Razon Social:
                                </td>
                                <td class="style53">
                                    <asp:TextBox ID="txtRazSocialO" Enabled="false" runat="server" Width="327px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style54">
                                    RUC:
                                </td>
                                <td class="style53">
                                    <asp:TextBox ID="txtRuc" Enabled="false" runat="server"></asp:TextBox>
                                </td>
                                <td class="style54">
                                    Telefono:
                                </td>
                                <td class="style53">
                                    <asp:TextBox ID="txtTelefono" Enabled="false" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style54">
                                    Rubro:
                                </td>
                                <td class="style53">
                                    <asp:TextBox ID="txtRubro" Enabled="false" runat="server"></asp:TextBox>
                                </td>
                                <td class="style54">
                                    Correo:
                                </td>
                                <td class="style53">
                                    <asp:TextBox ID="txtCorreo" Enabled="false" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style54">
                                    Contacto:
                                </td>
                                <td class="style53">
                                    <asp:TextBox ID="txtContaco" Enabled="false" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style54">
                                    Cargo:
                                </td>
                                <td class="style53">
                                    <asp:TextBox ID="txtCargo" Enabled="false" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style57">
                                    Direccion:
                                </td>
                                <td class="style53">
                                    <asp:TextBox ID="txtDireccion" Enabled="false" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td class="style56">
                                <asp:Label ID="Label2" runat="server" CssClass="page-title" 
                                    Text="Datos del Cliente" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style57">
                                Tipo Cliente:
                            </td>
                            <td class="style53">
                                <asp:DropDownList ID="ddlTipoCliente" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style55">
                                &nbsp;</td>
                            <td class="style57">
                                Fax:
                            </td>
                            <td class="style53">
                                <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                            </td>
                            <td class="style55">
                                <asp:Panel ID="pnlEstado" runat="server" GroupingText="Estado" Height="91px">
                                    <asp:RadioButton ID="rbtnEstado" Text="Vigente" runat="server" 
                                        Checked="True" Enabled="false" />
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style20">
                                &nbsp;
                            </td>
                            <td class="style21">
                                <asp:Button ID="btnAceptar" runat="server" Text="Agregar cliente" OnClick="btnAceptar_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnCancelarC" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"
                                    CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" />
    <br />
</asp:Content>