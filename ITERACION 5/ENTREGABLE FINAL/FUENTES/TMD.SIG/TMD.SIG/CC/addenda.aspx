<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addenda.aspx.cs" Inherits="TMD.SIG.CC.addenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/Validaciones.js" type="text/javascript"></script>
    <link href="../Styles/CC_style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
        }
        .style4
        {
        }
        .style13
        {
            width: 160px;
            height: 43px;
        }
        .style16
        {
        }
        .style17
        {            text-align: left;
        }
        .style20
        {
            width: 69px;
        }
        .style21
        {
            width: 492px;
            text-align: center;
        }
        .style40
        {
            width: 111px;
        }
        .style41
        {
            width: 34px;
        }
        .style43
        {
        }
        .style46
        {
            width: 150px;
        }
        .style48
        {
            width: 140px;
        }
        .style49
        {
            width: 16px;
        }
        .style53
        {
            width: 117px;
        }
        .style54
        {
            width: 171px;
        }
        .style55
        {
            width: 160px;
        }
        .style56
        {
            width: 123px;
        }
        .style57
        {
            width: 73px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlContrato" runat="server" Height="701px" Width="750px">
    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="labTituloEdicion" runat="server" 
                CssClass="page-title" Text="Nueva Addenda" Font-Bold="True" Font-Size="Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" GroupingText="Datos del Contrato" 
                    Height="176px">
                    <table class="style1">
                        <tr>
                            <td class="style55">
                                Nro. Contrato:</td>
                            <td class="style53">
                                <asp:TextBox ID="txtNroContrato" runat="server"></asp:TextBox>
                            </td>
                            <td class="style57">
                                <asp:Button ID="btnBuscarContrato" runat="server" Text="Buscar" 
                                    onclick="btnBuscarContrato_Click" CausesValidation="False" />
                            </td>
                            <td class="style55">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                    ControlToValidate="txtNroContrato" 
                                    ErrorMessage="Debe ingresar el Nro. de Contrato">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="style46">
                                Nro. Contrato:</td>
                            <td class="style54">
                                <asp:Label ID="lblNroContrato" runat="server" BorderStyle="Solid" 
                                    BorderWidth="1px" ForeColor="#0000CC" Width="95px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style55">
                                Cliente:</td>
                            <td class="style3" colspan="3">
                                <asp:Label ID="lblRazonSocial" runat="server" BorderStyle="Solid" 
                                    BorderWidth="1px" ForeColor="#0000CC" Width="357px"></asp:Label>
                            </td>
                            <td class="style46">
                                Estado:</td>
                            <td class="style54">
                                <asp:Label ID="lblEstado" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                                    ForeColor="#0000CC" Width="94px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style55">
                                Descripción:</td>
                            <td class="style4" colspan="5" rowspan="2">
                                <asp:Label ID="lblDescripcionContrato" runat="server" BorderStyle="Solid" 
                                    BorderWidth="1px" ForeColor="#0000CC" Height="48px" Width="583px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel2" runat="server" GroupingText="Datos de la Addenda">
                    <table class="style1">
                        <tr>
                            <td class="style20">
                                Descripción:</td>
                            <td class="style16" colspan="2" rowspan="3">
                                <asp:TextBox ID="txtDescripcionAddenda" runat="server" MaxLength="500" 
                                    TextMode="MultiLine" Width="595px" Height="55px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtDescripcionAddenda" 
                                    ErrorMessage="Debe ingresar una Descripción">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style20">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style20">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style20">
                                Cláusulas:</td>
                            <td class="style17">
                                <asp:Button ID="btnAgregarClausula" runat="server" Font-Bold="True" 
                                    Height="26px" Text="Agregar Cláusulas" Width="139px" 
                                    onclick="btnAgregarClausula_Click" CausesValidation="False" Enabled="False" />
                            </td>
                            <td class="style21">
                                &nbsp;</td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                    ControlToValidate="txtNroClausulas" 
                                    ErrorMessage="Debe ingresar al menos una Cláusula">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style20">
                                &nbsp;</td>
                            <td class="style17" colspan="2">
                                <asp:GridView ID="grvClausulas" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="4" DataKeyNames="NUMERO_CLAUSULA" ForeColor="#333333" 
                                    GridLines="None" Width="595px" onrowcommand="grvClausulas_RowCommand">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:ButtonField CommandName="Editar" Text="Editar">
                                        <ItemStyle Width="40px" />
                                        </asp:ButtonField>
                                        <asp:ButtonField CommandName="Eliminar" Text="Eliminar">
                                        <ItemStyle Width="50px" />
                                        </asp:ButtonField>
                                        <asp:BoundField DataField="NUMERO_CLAUSULA" HeaderText="Nro.">
                                        <ItemStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripción"/>
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
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style20">
                                &nbsp;</td>
                            <td class="style17">
                                &nbsp;</td>
                            <td class="style21">
                                <asp:HiddenField ID="hfldFilaEditar" runat="server" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style20">
                                &nbsp;</td>
                            <td align="right" class="style17">
                                &nbsp;</td>
                            <td class="style21">
                                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" 
                                    onclick="btnAceptar_Click" Enabled="False" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                                    onclick="btnCancelar_Click" CausesValidation="False" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="txtNroClausulas" runat="server" ForeColor="White" Height="0px" 
                                    Width="0px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>

</asp:Panel>
 <asp:Panel ID="pnlClausula" runat="server" Visible="False" Width="750px" 
        GroupingText="Datos de la Cláusula">
     <table class="style1">
         <tr>
             <td class="style46">
                 Estado:</td>
             <td>
                 <asp:DropDownList ID="ddlEstado" runat="server" Width="150px" 
                     onselectedindexchanged="ddlEstado_SelectedIndexChanged" 
                     AutoPostBack="True">
                     <asp:ListItem Selected="True" Value="P">Nuevo</asp:ListItem>
                     <asp:ListItem Value="R">Modificado</asp:ListItem>
                     <asp:ListItem Value="E">Eliminado</asp:ListItem>
                 </asp:DropDownList>
             </td>
             <td class="style49">
                 &nbsp;</td>
             <td class="style48">
                 Número Cláusula:</td>
             <td class="style40">
                 <asp:DropDownList ID="ddlNroClausula" runat="server" Width="120px" 
                     AutoPostBack="True" 
                     onselectedindexchanged="ddlNroClausula_SelectedIndexChanged" Visible="False">
                 </asp:DropDownList>
                 <asp:TextBox ID="txtNroClausula" runat="server" Width="68px" onKeypress="return acceptNum(event)"></asp:TextBox>
             </td>
             <td class="style41">
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                     ControlToValidate="txtNroClausula" 
                     ErrorMessage="Debe ingresar un Número de Cláusula">*</asp:RequiredFieldValidator>
             </td>
         </tr>
         <tr>
             <td class="style46">
                 Tipo de Cláusula:</td>
             <td class="style43" colspan="3">
                 <asp:DropDownList ID="ddlTipoClausula" runat="server" Width="300px">
                 </asp:DropDownList>
             </td>
             <td class="style40">
                 &nbsp;</td>
             <td class="style41">
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style46">
                 Descripción:</td>
             <td class="style43" colspan="4" rowspan="3">
                 <asp:TextBox ID="txtDescripcionClausula" runat="server" Height="58px" TextMode="MultiLine" 
                     Width="563px" MaxLength="500"></asp:TextBox>
             </td>
             <td class="style41">
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                     ControlToValidate="txtDescripcionClausula" 
                     ErrorMessage="Debe ingresar una descripción">*</asp:RequiredFieldValidator>
             </td>
         </tr>
         <tr>
             <td class="style46">
                 &nbsp;</td>
             <td class="style41">
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style46">
                 &nbsp;</td>
             <td class="style41">
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style46">
                 &nbsp;</td>
             <td>
                 <asp:CheckBox ID="chkSujetoPenalidad" runat="server" 
                     Text="Sujeto a penalidad" 
                     oncheckedchanged="chkSujetoPenalidad_CheckedChanged" AutoPostBack="True" />
             </td>
             <td class="style49">
                 &nbsp;</td>
             <td class="style48">
                 &nbsp;</td>
             <td class="style40">
                 &nbsp;</td>
             <td class="style41">
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style46">
                 Tipo de Sanción:</td>
             <td>
                 <asp:DropDownList ID="ddlTipoSancion" runat="server" Width="250px" 
                     Enabled="False">
                     <asp:ListItem Value="1">UIT(UND)</asp:ListItem>
                     <asp:ListItem Value="2">CONTRATO(%)</asp:ListItem>
                     <asp:ListItem Value="3">MONTO FIJO</asp:ListItem>
                     <asp:ListItem Value="4">ULTIMA FACTURA(%)</asp:ListItem>
                 </asp:DropDownList>
             </td>
             <td class="style49">
                 &nbsp;</td>
             <td class="style48" align="right">
                 Sanción:</td>
             <td class="style40">
                 <asp:TextBox ID="txtSancion" runat="server" Width="119px" Enabled="False" onKeypress="return acceptNum(event)"></asp:TextBox>
             </td>
             <td class="style41">
                 <asp:RequiredFieldValidator ID="rfldSancion" runat="server" 
                     ControlToValidate="txtSancion" ErrorMessage="Debe ingresar una sanción" 
                     Visible="False">*</asp:RequiredFieldValidator>
             </td>
         </tr>
         <tr>
             <td class="style46">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td class="style49">
                 &nbsp;</td>
             <td class="style48">
                 &nbsp;</td>
             <td class="style40">
                 &nbsp;</td>
             <td class="style41">
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style46">
                 &nbsp;</td>
             <td align="center">
                 <asp:Button ID="btnAceptarClausula" runat="server" onclick="btnAceptarClausula_Click" 
                     Text="Aceptar" />
             </td>
             <td class="style49">
                 &nbsp;</td>
             <td class="style48">
                 <asp:Button ID="btnCancelarClausula" runat="server" Text="Cancelar" 
                     onclick="btnCancelarClausula_Click" CausesValidation="False" />
             </td>
             <td class="style40">
                 &nbsp;</td>
             <td class="style41">
                 &nbsp;</td>
         </tr>
     </table>
    
   </asp:Panel>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ShowMessageBox="True" ShowSummary="False" />
    <br />
</asp:Content>
