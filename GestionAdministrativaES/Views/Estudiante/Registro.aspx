<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="GestionAdministrativaES.Views.Estudiante.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        REGISTRARSE COMO ESTUDIANTE</p>
    <p>
        &nbsp;</p>
    <p>
        <table style="width:100%;">
            <tr>
                <td class="modal-sm" style="width: 144px">
                    Nombre</td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    Carnet</td>
                <td>
                    <asp:TextBox ID="txtCarnet" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 144px; height: 25px;">
                    Correo</td>
                <td style="height: 25px">
                    <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
                    Telefono</td>
                <td style="height: 25px">
                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 144px">
                    Nick</td>
                <td>
                    <asp:TextBox ID="txtNick" runat="server"></asp:TextBox>
                    Palabra Clave</td>
                <td>
                    <asp:TextBox ID="txtPalabraClave" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 144px">
                    Contraseña</td>
                <td>
                    <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox>
                    Confirmar Contraseña</td>
                <td>
                    <asp:TextBox ID="txtConfirmarContraseña" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <p>
            <asp:Button ID="btnRegistrarse" runat="server" OnClick="btnRegistrarse_Click" Text="Registrarse" />
            <asp:Button ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" Text="Regresar" />
    </p>
    </p>
</asp:Content>
