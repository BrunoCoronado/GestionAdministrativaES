<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="GestionAdministrativaES.Views.OperadorDelSistema.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
    <tr>
        <td style="height: 20px">
            &nbsp;</td>
        <td style="height: 20px"></td>
        <td style="height: 20px"></td>
    </tr>
    <tr>
        <td style="height: 25px">
            <asp:Button ID="btnSalones" runat="server" Text="Salones" OnClick="btnSalones_Click" />
            <asp:Button ID="btnReservaciones" runat="server" OnClick="btnReservaciones_Click" Text="Administracion de Reservaciones" />
            <asp:Button ID="btnIncidentesSalones" runat="server" OnClick="btnIncidentesSalones_Click" Text="Incidentes de Salones" />
            <asp:Button ID="Button1" runat="server" Text="Insumos" />
            <asp:Button ID="Button2" runat="server" Text="Incidentes de Insumos" />
            <asp:Button ID="btnCerrarSesion" runat="server" Text="CerrarSesion" OnClick="btnCerrarSesion_Click" />
        </td>
        <td style="height: 25px"></td>
        <td style="height: 25px"></td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>