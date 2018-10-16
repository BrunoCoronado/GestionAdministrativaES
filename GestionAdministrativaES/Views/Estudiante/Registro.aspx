<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="GestionAdministrativaES.Views.Estudiante.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        <h1 class="text-center">REGISTRARSE</h1>
        <div class="row">
            <div class="col">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-sm-12 col-md-6">
                            <div class="form-group">
                                <label for="txtNombre">Nombre</label>
                                <input runat="server" type="text" class="form-control" id="txtNombre" placeholder="Nombre">
                            </div>
                            <div class="form-group">
                                <label for="txtCarnet">Carnet</label>
                                <input runat="server" type="number" class="form-control" id="txtCarnet" placeholder="Carnet">
                            </div>
                            <div class="form-group">
                                <label for="txtCorreo">Correo</label>
                                <input runat="server" type="email" class="form-control" id="txtCorreo" placeholder="Correo">
                            </div>
                            <div class="form-group">
                                <label for="txtTelefono">Teléfono</label>
                                <input runat="server" type="number" class="form-control" id="txtTelefono" placeholder="Teléfono">
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                            <div class="form-group">
                                <label for="txtUsuario">Usuario</label>
                                <input runat="server" type="text" class="form-control" id="txtUsuario" placeholder="Usuario">
                            </div>
                            <div class="form-group">
                                <label for="txtPalabraClave">Palabra Clave</label>
                                <input runat="server" type="text" class="form-control" id="txtPalabraClave" placeholder="Palabra Clave">
                            </div>
                            <div class="form-group">
                                <label for="txtContraseña">Contraseña</label>
                                <input runat="server" type="password" class="form-control" id="txtContraseña" placeholder="Contraseña">
                            </div>
                            <div class="form-group">
                                <label for="txtConfirmarContraseña">Confirmar Contraseña</label>
                                <input runat="server" type="password" class="form-control" id="txtConfirmarContraseña" placeholder="Confirmar Contraseña">
                            </div>
                        </div>
                    </div>
                    <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnRegistrarse_Click" Text="Registrarse"></asp:button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
