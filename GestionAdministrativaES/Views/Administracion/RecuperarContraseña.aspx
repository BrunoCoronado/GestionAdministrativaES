<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecuperarContraseña.aspx.cs" Inherits="GestionAdministrativaES.Views.Administracion.RecuperarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   y <div class="container">
        <h1 class="text-center">CAMBIAR CONTRASEÑA</h1>
        <div class="row">
            <div class="col">
                <h2 class="text-center">Validar Palabra Clave</h2>
                <div class="form-group">
                    <label for="txtUsuario">Usuario</label>
                    <input runat="server" type="text" class="form-control" id="txtUsuario" placeholder="Usuario">
                </div>
                <div class="form-group">
                    <label for="txtPalabraClave">Palabra Clave</label>
                    <input runat="server" type="text" class="form-control" id="txtPalabraClave" placeholder="Palabra Clave">
                </div>
                <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="bntValidarPalabraClave_Click" Text="Validar Palabra Clave"></asp:button>
            </div>
            <div class="col">
                <div class="container-fluid">
                    <h2 class="text-center">Cambiar Contraseña</h2>
                    <div class="row">
                        <div class="col">
                            <div class="form-group">
                                <label>Nombre:</label>
                                <label runat="server" id="lblNombre"></label>
                            </div>
                            <div class="form-group">
                                <label>Carnet:</label>
                                <label runat="server" id="lblCarnet"></label>
                            </div>
                            <div class="form-group">
                                <label>Usuario:</label>
                                <label runat="server" id="lblUsuario"></label>
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-group">
                                <label for="txtContraseña">Nueva Contraseña</label>
                                <input runat="server" type="password" class="form-control" id="txtContraseña" placeholder="Contraseña">
                            </div>
                            <div class="form-group">
                                <label for="txtConfirmarContraseña">Confirmar Contraseña</label>
                                <input runat="server" type="password" class="form-control" id="txtConfirmarContraseña" placeholder="Confirmar Contraseña">
                            </div>
                        </div>
                        <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnCambiarContraseña_Click" Text="Cambiar Contraseña"></asp:button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
