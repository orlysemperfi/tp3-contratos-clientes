﻿<%@ Page Title="Cambio de Estado de Contrato" Language="C#"
         MasterPageFile="~/Popup.master" AutoEventWireup="true"
         CodeBehind="FormCambioEstadoContrato.aspx.cs"
         Inherits="TMD.SIG.FormCambioEstadoContrato" %>

<%@ Import Namespace="Entidades.CC" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>ACTUALIZAR ESTADO DE Contrato</h2>
    <hr />
    <p>Permite cambiar el estado de un Contrato.</p>
    <table width="100%" align="center" border="0" cellpadding="1" cellspacing="1">
      <tr style="height:10px">
        <td colspan="7"></td>
      </tr>
      <tr>
        <td colspan="7">
          <b>Informacion General</b>
        </td>
      </tr>
      <tr>
        <td colspan="7"><hr /></td>
      </tr>
      <tr>
        <td class="labelForms" width="18%">
          N° de Contrato:
        </td>
        <td width="1%">&nbsp;</td>
        <td class="controlForms" width="30%">
          <asp:Label ID="txtNumeroContrato" runat="server" Font-Bold="true" Font-Size="14px" />
        </td>
        <td width="2%">&nbsp;</td>
        <td class="labelForms" width="23%">
          Estado:
        </td>
        <td width="1%">&nbsp;</td>
        <td class="controlForms" width="25%">
          <asp:Label ID="txtNombreEstado" runat="server" Font-Bold="true" Font-Size="14px" />
        </td>
      </tr>
      <tr>
        <td class="labelForms">
          Servicio:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms" colspan="5">
          <asp:Label ID="txtNombreServicio" runat="server" />
        </td>
      </tr>
      <tr>
        <td class="labelForms">
          Cliente:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms" colspan="5">
          <asp:Label ID="txtNombreCliente" runat="server" />
        </td>
      </tr>
      <tr>
        <td class="labelForms">
          N° de Buena Pro:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms">
          <asp:Label ID="txtNumeroBuenaPro" runat="server" />
        </td>
        <td>&nbsp;</td>
        <td class="labelForms">
          N° de Carta Fianza:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms">
          <asp:Label ID="txtNumeroCartaFianza" runat="server" />
        </td>
      </tr>
      <tr>
        <td class="labelForms">
          Fecha de Inicio:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms">
          <asp:Label ID="txtFechaInicio" runat="server" />
        </td>
        <td>&nbsp;</td>
        <td class="labelForms">
          Fecha de Fin:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms">
          <asp:Label ID="txtFechaFin" runat="server" />
        </td>
      </tr>
      <tr style="height:15px">
        <td colspan="7"></td>
      </tr>
      <tr>
        <td colspan="7">
          <b>Estado de Contrato</b>
        </td>
      </tr>
      <tr>
        <td colspan="7"><hr /></td>
      </tr>
      <tr id="trMotivoVer" runat="server">
        <td class="labelForms">
          Motivo:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms" colspan="5">
          <asp:Label ID="txtMotivoVer" runat="server" />
        </td>
      </tr>
      <tr id="trFechaTerminoVer" runat="server">
        <td class="labelForms">
          Fecha de Actualizacion:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms" colspan="5">
          <asp:Label ID="txtFechaTermino" runat="server" />
        </td>
      </tr>
      <tr id="trEstadoCambiar" runat="server">
        <td class="labelForms">
          Estado:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms" colspan="5">
          <asp:DropDownList ID="ddlProximoEstado" runat="server" />
        </td>
      </tr>
      <tr id="trMotivoCambiar" runat="server">
        <td class="labelForms">
          Motivo:
        </td>
        <td>&nbsp;</td>
        <td class="controlForms" colspan="5">
          <asp:TextBox ID="txtMotivoCambiar" runat="server" TextMode="MultiLine" Rows="4" Width="100%" />
        </td>
      </tr>
      <tr style="height:10px">
        <td colspan="7">
          <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="boton_01" 
            OnClick="btnAceptar_Click" 
                
                
                OnClientClick="return confirm('Esta seguro que desea realizar esta accion?\nUna vez ejecutada dicha accion, ya no se puede volver atras.')" 
                Visible="False" />&nbsp;<asp:Button 
                ID="btnCancelar" runat="server" Text="Cancelar" CssClass="boton_01" 
            CausesValidation="false" Visible="False" />
          </td>
      </tr>
      <tr style="height:10px">
        <td colspan="7" align="right">
            &nbsp;
          </td>
      </tr>
    </table>
</asp:Content>
