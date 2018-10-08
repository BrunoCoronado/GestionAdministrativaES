<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="GestionAdministrativaES.Views.Administrador.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
    <tr>
        <td style="height: 20px">
            &nbsp;</td>
        <td style="height: 20px"></td>
        <td style="height: 20px"></td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnUsuarios" runat="server" Text="Usuarios" OnClick="btnUsuarios_Click" />
            <asp:Button ID="btnCargaMasiva" runat="server" OnClick="btnCargaMasiva_Click" Text="Carga Masiva" />
            <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="btnCerrarSesion_Click" />
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
