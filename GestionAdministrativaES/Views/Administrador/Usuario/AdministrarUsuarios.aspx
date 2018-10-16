<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarUsuarios.aspx.cs" Inherits="GestionAdministrativaES.Views.Administrador.Usuario.AdministrarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="text-center">ADMINISTRAR USUARIOS</h1>
        <div class="row p-4">
            <h2 class="text">Usuarios</h2>
            <div class="table-responsive">
                <table runat="server" id="tbUsuarios" class="table">
                    <thead>
                        <tr class="bg-primary">
                            <th class="text-light" scope="col">id Usuario</th>
                            <th class="text-light" scope="col">Carnet</th>
                            <th class="text-light" scope="col">Nombre</th>
                            <th class="text-light" scope="col">Correo</th>
                            <th class="text-light" scope="col">Teléfono</th>
                            <th class="text-light" scope="col">Nick</th>
                            <th class="text-light" scope="col">Rol</th>
                            <th class="text-light" scope="col">Palabra Clave</th>
                            <th class="text-light" scope="col">Modificar</th>
                            <th class="text-light" scope="col">Eliminar</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="container-fluid">
                    <h2 class="text">Nuevo Usuario</h2>
                        <div class="row">
                            <div class="col-sm-12 col-md-4">
                                <div class="form-group">
                                    <label for="txtUsuario">Nombre</label>
                                    <input runat="server" type="text" class="form-control" id="txtNombre" placeholder="Nombre">
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
                            <div class="col-sm-12 col-md-4">
                                <div class="form-group">
                                    <label for="txtCarnet">Carnet</label>
                                    <input runat="server" type="number" class="form-control" id="txtCarnet" placeholder="Carnet">
                                </div>
                                <div class="form-group">
                                    <label for="ddlRol">Rol</label>
                                    <select runat="server" class="form-control" id="ddlRol">
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label for="txtContraseña">Contraseña</label>
                                    <input runat="server" type="password" class="form-control" id="txtContraseña" placeholder="Contraseña">
                                </div>
                            </div>
                            <div class="col-sm-12 col-md-4">
                                <div class="form-group">
                                    <label for="txtUsuario">Usuario</label>
                                    <input runat="server" type="text" class="form-control" id="txtUsuario" placeholder="Usuario">
                                </div> 
                                <div class="form-group">
                                    <label for="txtPalabraClave">Palabra Clave</label>
                                    <input runat="server" type="text" class="form-control" id="txtPalabraClave" placeholder="Palabra Clave">
                                </div> 
                                <div class="form-group">
                                    <label for="txtConfirmarContraseña">Confirmar Contraseña</label>
                                    <input runat="server" type="password" class="form-control" id="txtConfirmarContraseña" placeholder="Confirmar Contraseña">
                                </div> 
                            </div>
                        </div>
                    <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnAgregarUsuario_Click" Text="Crear Usuario"></asp:button>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="container-fluid">
                    <h2 class="text">Modificar Usuario</h2>
                    <small class="form-text text-muted">Seleccionar modificar en la tabla para cargar los datos del usuario.</small>
                    <label runat="server" id="lblIdUsuarioM" hidden="hidden"></label>
                    <div class="row">
                        <div class="col-sm-12 col-md-4">
                            <div class="form-group">
                                <label for="txtNombreM">Nombre</label>
                                <input runat="server" type="text" class="form-control" id="txtNombreM" placeholder="Nombre">
                            </div> 
                            <div class="form-group">
                                <label for="txtCorreoM">Correo</label>
                                <input runat="server" type="email" class="form-control" id="txtCorreoM" placeholder="Correo">
                            </div> 
                            <div class="form-group">
                                <label for="txtTelefonoM">Teléfono</label>
                                <input runat="server" type="number" class="form-control" id="txtTelefonoM" placeholder="Teléfono">
                            </div> 
                        </div>
                        <div class="col-sm-12 col-md-4">
                            <div class="form-group">
                                <label for="txtCarnetM">Carnet</label>
                                <input runat="server" type="number" class="form-control" id="txtCarnetM" placeholder="Carnet">
                            </div>
                            <div class="form-group">
                                <label for="ddlRolM">Rol</label>
                                <select runat="server" class="form-control" id="ddlRolM">
                                </select>
                            </div>
                            <div class="form-group">
                                <label for="txtUsuarioM">Usuario</label>
                                <input runat="server" type="text" class="form-control" id="txtUsuarioM" placeholder="Usuario">
                            </div> 
                        </div>
                        <div class="col-sm-12 col-md-4">
                            <div class="form-group">
                                <label for="txtPalabraClave">Palabra Clave</label>
                                <input runat="server" type="text" class="form-control" id="txtPalabraClaveM" placeholder="Palabra Clave">
                            </div> 
                        </div>
                    </div>
                    <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnModificar_Click" Text="Modificar Usuario"></asp:button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
