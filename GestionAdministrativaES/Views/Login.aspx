<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GestionAdministrativaES.Views.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col"></div>
            <div class="col">
                <h1 class="text-center">INICIAR SESIÓN</h1>
                <div class="form-group">
                    <label for="txtUsuario">Usuario</label>
                    <input runat="server" type="text" class="form-control" ID="txtUsuario" placeholder="Ingresar usuario">
                </div>
                <div class="form-group">
                    <label for="txtContraseña">Contraseña</label>
                    <input runat="server" type="password" class="form-control" id="txtContraseña" placeholder="Contraseña">
                </div>
                <div class="form-group">
                    <asp:Button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnIniciarSesion_Click" Text="Iniciar Sesión"></asp:Button>
                </div>
                <div class="form-group">
                    <asp:Button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnRegistrarEstudiante_Click" Text="Registrarse como estudiante"></asp:Button>
                </div>
                <div class="form-group">
                    <asp:Button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnRecuperarContraseña_Click" Text="Recuperar Contraseña"></asp:Button>
                </div>
            </div>
            <div class="col"></div>
        </div>
    </div>
</asp:Content>
