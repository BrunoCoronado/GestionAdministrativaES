<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecuperarContraseña.aspx.cs" Inherits="GestionAdministrativaES.Views.Administracion.RecuperarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        RECUPERAR CONTRASEÑA<asp:Button ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" Text="Regresar" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        VALIDAR PALABRA CLAVE</p>
    <p>
        <table style="width:100%;">
            <tr>
                <td class="modal-sm" style="width: 126px">Nick</td>
                <td>
                    <asp:TextBox ID="txtNickVPC" runat="server" style="margin-left: 0px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 126px">Palabra Clave</td>
                <td>
                    <asp:TextBox ID="txtPalabraClaveVPC" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 126px; height: 20px"></td>
                <td style="height: 20px"></td>
                <td style="height: 20px"></td>
            </tr>
        </table>
    </p>
    <p>
        <asp:Button ID="bntValidarPalabraClave" runat="server" OnClick="bntValidarPalabraClave_Click" Text="Validar Palabra Clave" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        CAMBIAR CONTRASEÑA</p>
    <p>
        <table style="width:100%;">
            <tr>
                <td class="modal-sm" style="width: 124px">Usuario</td>
                <td style="width: 216px">
                    <asp:Label ID="lblUsuario" runat="server" Text="Label"></asp:Label>
                </td>
                <td>Nueva Contraseña&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 124px">Nombre</td>
                <td style="width: 216px">
                    <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
                </td>
                <td>Confirmar Contraseña&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtContraseñaR" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 124px">Correo</td>
                <td style="width: 216px">
                    <asp:Label ID="lblCorreo" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
        <asp:Button ID="btnCambiarContraseña" runat="server" OnClick="btnCambiarContraseña_Click" Text="Cambiar Contraseña" />
    </p>
</asp:Content>
