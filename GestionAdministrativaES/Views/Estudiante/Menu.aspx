<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="GestionAdministrativaES.Views.Estudiante.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Matricularse a una Actividad" />
        <asp:Button ID="Button2" runat="server" Text="Ver Calendario" />
        <asp:Button ID="Button3" runat="server" Text="Ver Actividades" />
        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="btnCerrarSesion_Click" />
    </p>
</asp:Content>
