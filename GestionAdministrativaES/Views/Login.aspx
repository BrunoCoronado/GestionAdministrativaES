<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GestionAdministrativaES.Views.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="width: 118px">Usuario</td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server" Width="301px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 118px">Contraseña</td>
            <td>
                <asp:TextBox ID="txtContraseña" runat="server" Width="301px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 118px">
                <asp:Button ID="btnIniciarSesion" runat="server" OnClick="btnIniciarSesion_Click" style="height: 26px" Text="Iniciar Sesión" />
            </td>
            <td>
                <asp:Button ID="btnRegistrarEstudiante" runat="server" OnClick="btnRegistrarEstudiante_Click" Text="Registrarse como estudiante" />
                <asp:Button ID="btnRecuperarContraseña" runat="server" OnClick="btnRecuperarContraseña_Click" Text="Recuperar Contraseña" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
