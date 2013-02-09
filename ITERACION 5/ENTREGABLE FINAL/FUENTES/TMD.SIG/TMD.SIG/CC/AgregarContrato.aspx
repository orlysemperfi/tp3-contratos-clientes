<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarContrato.aspx.cs" Inherits="TMD.SIG.CC.AgregarContrato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/Validaciones.js" type="text/javascript"></script>
    <link href="../Styles/CC_style.css" rel="stylesheet" type="text/css" />
  
    <style type="text/css">
        .style1
        {
            font-weight: bold;
            text-align: left;
        }
    </style>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlCliente" runat="server">
 <table style="border-bottom-style: ridge">
            <tr>
                <td class="style1" colspan="3" style="font-size: 20px; font-weight: bold">Datos de Cliente</td>
                <td> &nbsp;</td>
            </tr>
            <tr>
                <td>RUC</td>
                <td><asp:TextBox ID="txtRUC" runat="server" MaxLength="11" onKeypress="return acceptNum(event)" Width="98px"></asp:TextBox></td>
                <td><asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" Text="Buscar" /></td>
                <td rowspan="3"><asp:HiddenField ID="hidIdCliente" runat="server" /> </td>
            </tr>
            <tr>
                <td>Razon Social&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td><asp:Label ID="lblRazonSocial" runat="server" CssClass="bold"></asp:Label></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Tipo Cliente</td>
                <td><asp:Label ID="lblTipoCliente" runat="server" CssClass="bold"></asp:Label></td>                
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Contacto</td>
                <td><asp:Label ID="lblContacto" runat="server" CssClass="bold"></asp:Label></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    
        <asp:Panel ID="pnlContrato" runat="server" Visible="False" Height="597px" 
        Width="930px">
      
        <table>
            <tr>
                <td class="bold" colspan="2" style="font-size: 20px; font-weight: bold">Datos del Contrato</td>
            </tr>
            <tr>
                <td>Buena Pro</td>
                <td><asp:TextBox ID="txtBuenaPro" runat="server" MaxLength="15"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Carta Fianza (*)</td>
                <td><asp:TextBox ID="txtCartaFianza" runat="server" MaxLength="15"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <table>
                        <tr>
                            <td>Fecha Inicio (*)</td>
                            <td>
                    <asp:TextBox ID="txtFechaInicio" runat="server" MaxLength="10" ReadOnly="True"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="imgFechaInicio" runat="server" ImageUrl="~/imagenes/Calendario.png" 
                        ToolTip="Click para mostrar u ocultar calendario" onclick="imgFechaInicio_Click" />
                            </td>
                            <td>&nbsp;</td>
                            <td>Fecha Fin (*)</td>
                            <td>
                    <asp:TextBox ID="txtFechaFin" runat="server" MaxLength="10" ReadOnly="True" Height="16px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="imgFechaFin" runat="server" ImageUrl="~/imagenes/Calendario.png" ToolTip="Click para mostrar u ocultar calendario" 
                                    onclick="imgFechaFin_Click" style="width: 18px"/>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Panel ID="pnlFecInicio" runat="server" Visible="False">
                                    <asp:Calendar ID="cldInicio" runat="server" Height="104px" onselectionchanged="cldInicio_SelectionChanged" Width="149px">
                                    </asp:Calendar>
                                </asp:Panel>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Panel ID="pnlFecFin" runat="server" Visible="False">
                                    <asp:Calendar ID="cldFin" runat="server" onselectionchanged="cldFin_SelectionChanged"></asp:Calendar>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>Moneda (*)</td>
                <td><asp:DropDownList ID="ddlMoneda" runat="server" Height="24px" Width="142px"></asp:DropDownList> </td>
            </tr>
            <tr>
                <td>Monto (*)</td>
                <td><asp:TextBox ID="txtMonto" runat="server" onKeypress="return acceptNum(event)"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Servicio (*)</td>
                <td><asp:DropDownList ID="ddlServicio" runat="server" Height="24px" Width="350px"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Descripcion (*)</td>
                <td><asp:TextBox ID="txtDesContrato" runat="server" Height="93px" TextMode="MultiLine" Width="468px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:ImageButton ID="imgBtnClausula" runat="server" ImageUrl="~/imagenes/clausula_d.png" onclick="imgBtnClausula_Click"/>
                    <asp:ImageButton ID="imgBtnRol" runat="server" ImageUrl="~/imagenes/rol_d.png" OnClick="imgBtnRol_Click" />
                    <asp:ImageButton ID="imgBtnEntregable" runat="server" ImageUrl="~/imagenes/entregable_d.png" OnClick="imgBtnEntregable_Click"/>
                    <asp:ImageButton ID="imgBtnIndicador" runat="server" ImageUrl="~/imagenes/indicador_d.png" OnClick="imgBtnIndicador_Click"/>
                </td>
            </tr>
            <tr>
                <td colspan="2"> &nbsp;</td>
            </tr>
                    
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnGuardar" runat="server" onclick="btnGuardar_Click" 
                        Text="Guardar Contrato" Width="130px" Height="25px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="110px" 
                        onclick="btnCancelar_Click" Height="25px" />
                    &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
        </table>

      </asp:Panel>    
        <asp:Panel ID="pnlClausula" runat="server" Height="494px" style="margin-bottom: 0px" 
            Width="782px" Visible="False">
            <table>  
            <tr>
                    <td colspan="2" style="font-size: 20px; font-weight: bold;"> Cláusulas de contrato</td>
                </tr>
                <tr>
                    <td> Tipo Clausula (*)</td>
                    <td>
                        <asp:DropDownList ID="ddlTipoClausula" runat="server" Height="24px" Width="142px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Descripcion(*)</td>
                    <td>
                        <asp:TextBox ID="txtDesClausula" runat="server" Height="59px" TextMode="MultiLine" Width="674px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Penalidad</td>
                    <td><asp:CheckBox ID="chbPenalidad" runat="server" AutoPostBack="True" 
                            oncheckedchanged="chbPenalidad_CheckedChanged" /></td>
                </tr>
                <tr>
                    <td>Tipo Sancion</td>
                    <td>
                        <asp:DropDownList ID="ddlTipoSancion" runat="server" Height="24px" 
                            Width="142px" Enabled="False">
                            <asp:ListItem Value="0">Seleccione</asp:ListItem>
                            <asp:ListItem Value="1">UIT(UND)</asp:ListItem>
                            <asp:ListItem Value="2">Contrato (%)</asp:ListItem>
                            <asp:ListItem Value="3">Monto Fijo</asp:ListItem>
                            <asp:ListItem Value="4">Factura del mes(%)</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Sancion</td>
                    <td>
                        <asp:TextBox ID="txtSancion" runat="server" 
                            onKeypress="return acceptNum(event)" Enabled="False"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnAgregarCl" runat="server" Text="Agregar" onclick="btnAgregarCl_Click" />
                    </td>
                </tr>
                <tr>
                 <td>&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Panel ID="pnlC" runat="server" Height="90px" style="text-align: center" 
                            Width="374px">
                            <br />
                            <br />
                            No existe registro</asp:Panel>
                        <asp:GridView ID="gridClausulasG" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" ForeColor="#333333" GridLines="None" 
                            onrowdeleting="gridClausulasG_RowDeleting">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="delete3" Runat="server" CommandName="Delete" 
                                            ImageUrl="~/imagenes/Eliminar.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                <asp:BoundField DataField="TipoSancion" HeaderText="Tipo Sancion" />
                                <asp:BoundField DataField="Sancion" HeaderText="Sancion" />
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
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnRegContrato_C" runat="server" Height="26px" onclick="btnRegContrato_C_Click" Text="Regresar a Contrato" />
                    </td>
                </tr>
        </table>
        </asp:Panel>
    <asp:Panel ID="pnlRoles" runat="server" Visible="False">
        <table>
            <tr>
                <td colspan="2" style="font-size: 20px; font-weight: bold;">
                    Roles del contrato</td>
            </tr>
            <tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:GridView ID="gridRolesG" runat="server" CellPadding="4" 
                        ForeColor="#333333" GridLines="None" AutoGenerateColumns="False"
                        DataKeyNames="Codigo, Nombre">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                            <HeaderTemplate>
							    <asp:CheckBox id="cbxMarca" runat="server" onclick="javascript:SelectAllCheckboxes(this,'gridRolesG');"></asp:CheckBox>
						    </HeaderTemplate>
                            <ItemTemplate>
                            <asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                            <asp:BoundField DataField="Nombre" HeaderText="Descripcion" />
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
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td>
                    <asp:Button ID="btnRegContrato_R" runat="server" Text="Regresar a Contrato" onclick="btnRegContrato_R_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>

<asp:Panel ID="pnlEntregables" runat="server" Visible="False" Width="679px">
    <table>
        <tr>
            <td colspan="2" style="font-size: 20px; font-weight: bold">
                Entregables del contrato</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Entregable (*)</td>
            <td>
                <asp:DropDownList ID="ddlEntregable" runat="server" Width="300px"></asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Rol (*)</td>
            <td><asp:DropDownList ID="ddlRol" runat="server" Width="150px"> </asp:DropDownList></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Fecha Pactada (*)</td>
            <td>
                <asp:TextBox ID="txtFechaPactada" runat="server" MaxLength="10" ReadOnly="True" Width="86px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImgFechaPactada" runat="server" ImageUrl="~/imagenes/Calendario.png" onclick="ImgFechaPactada_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnAgregarEnt" runat="server" onclick="btnAgregarEnt_Click" Text="Agregar" />
                <asp:Panel ID="pnlFecPactada" runat="server" Visible="False" Width="238px">
                    <asp:Calendar ID="cldFechaPactada" runat="server" onselectionchanged="cldFechaPactada_SelectionChanged"></asp:Calendar>
                </asp:Panel>
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Panel ID="pnlE" runat="server" Height="90px" style="text-align: center" Width="374px">
                    <br /><br />No existe registro</asp:Panel>
                <asp:GridView ID="gridEntregablesG" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" 
                    onrowdeleting="gridEntregablesG_RowDeleting">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="delete" Runat="server" CommandName="Delete" ImageUrl="~/imagenes/Eliminar.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nombre" HeaderText="Entregable" />
                        <asp:BoundField DataField="NombreRol" HeaderText="Rol" />
                        <asp:BoundField DataField="FechaPactada" HeaderText="Fecha Pactada" />
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
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td><asp:Button ID="btnRegContrato_E" runat="server" onclick="btnRegContrato_E_Click" Text="Regresar a Contrato" /></td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlIndicadores" runat="server" Visible="False">
    <table>
        <tr>
            <td colspan="2" style="font-size: 20px; font-weight: bold">Indicadores del contrato</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td> Indicador (*)</td>
            <td colspan="2"><asp:DropDownList ID="ddlIndicadorG" runat="server" Width="300px"> </asp:DropDownList> </td>
        </tr>
        <tr>
            <td>Valor Objetivo (*)</td>
            <td><asp:TextBox ID="txtValorObjetivo" runat="server" MaxLength="20" Width="115px"  onKeypress="return acceptNum(event)"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Frecuencia (*)</td>
            <td>
                <asp:DropDownList ID="ddlFrecuencia" runat="server">
                    <asp:ListItem>Seleccione</asp:ListItem>
                    <asp:ListItem>Diario</asp:ListItem>
                    <asp:ListItem>Semanal</asp:ListItem>
                    <asp:ListItem>Mensual</asp:ListItem>
                    <asp:ListItem>Anual</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td><asp:Button ID="btnAgregarInd" runat="server" onclick="btnAgregarInd_Click" Text="Agregar" /> </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">
                <asp:Panel ID="pnlI" runat="server" Height="90px" style="text-align: center" Width="374px">
                    <br /><br />No existe registro</asp:Panel>
                <asp:GridView ID="gridIndicadorG" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" 
                    onrowdeleting="gridIndicadorG_RowDeleting">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="delete1" Runat="server" CommandName="Delete" 
                                    ImageUrl="~/imagenes/Eliminar.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nombre" HeaderText="Indicador" />
                        <asp:BoundField DataField="ValorObjetivo" HeaderText="Valor Objetivo" />
                        <asp:BoundField DataField="Frecuencia" HeaderText="Frecuencia" />
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
        <tr>
            <td>&nbsp;</td>
            <td colspan="2"><asp:Button ID="btnRegContrato_I" runat="server" onclick="btnRegContrato_I_Click" Text="Regresar a Contrato" /></td>
        </tr>
    </table>
</asp:Panel>

</asp:Content>
