<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ActCliente.aspx.cs" Inherits="TMD.SIG.CC.ActCliente" %>

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
        .style57
        {
            width: 33px;
        }
        .style60
        {
            width: 3px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlContrato" runat="server" Height="701px" Width="750px">
        <table class="style1">
            <tr>
                <td class="style55" colspan="2">
                    <asp:Label ID="labTituloEdicion" runat="server" CssClass="page-title" 
                        Text="Actualizacion de Cliente" Font-Bold="True" Font-Size="Large"></asp:Label>
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
                            <asp:BoundField DataField="TIPO_CLIENTE_DESCRIPCION" HeaderText="TIPO" >
                            <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:CommandField SelectText="Actualizar" ShowSelectButton="True">
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
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="page-title" 
                        Text="Actualización de cliente" Font-Bold="True" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                Razón Social:
                            </td>
                            <td class="style53">
                                <asp:TextBox ID="txtRazSocialO" runat="server"  Width="327px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                RUC:
                            </td>
                            <td class="style53">
                                <asp:TextBox ID="txtRuc" runat="server" Enabled="false" ></asp:TextBox>
                            </td>
                            <td class="style54">
                                Tipo:
                            </td>
                            <td class="style60">
                                <asp:DropDownList ID="ddlTipoCliente" runat="server" 
                                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Dirección:
                            </td>
                            <td class="style53">
                                <asp:TextBox ID="txtDireccionAct" runat="server" Width="349px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Teléfono:
                            </td>
                            <td class="style53">
                                <asp:TextBox ID="txtTelefonoAct" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Contacto:
                            </td>
                            <td class="style53">
                                <asp:TextBox ID="txtContactoAct" runat="server" Width="363px"></asp:TextBox>
                            </td>
                            <td>
                                Fax:
                            </td>
                            <td class="style60">
                                <asp:TextBox ID="txtFaxAct" runat="server" Width="143px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td class="style57">
                                Correo:
                            </td>
                            <td class="style53">
                                <asp:TextBox ID="txtCorreoAct" runat="server" Width="363px"></asp:TextBox>
                            </td>
                            <td class="style55">
                                <asp:Panel ID="Panel1" runat="server" GroupingText="Estado">
                                    <asp:RadioButton ID="rbtnEstado" runat="server" Text="Vigente" />
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style20">
                                &nbsp;
                            </td>
                            <td class="style21">
                                <asp:Button ID="btnAceptar" runat="server" Text="Actualizar cliente" OnClick="btnAceptar_Click" />
                                <asp:HiddenField ID="txtCodCliente" runat="server" />
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
