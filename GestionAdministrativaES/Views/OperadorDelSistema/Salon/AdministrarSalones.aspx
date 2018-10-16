<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarSalones.aspx.cs" Inherits="GestionAdministrativaES.Views.Salon.AdministrarSalones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="text-center">ADMINISTRAR SALONES</h1>
        <div class="row p-4">
            <h2 class="text">Salones</h2>
            <div class="table-responsive">
                <table runat="server" id="tbSalones" class="table">
                    <thead>
                        <tr class="bg-primary">
                            <th class="text-light" scope="col">id Salon</th>
                            <th class="text-light" scope="col">Ubicación</th>
                            <th class="text-light" scope="col">Capacidad</th>
                            <th class="text-light" scope="col">Estado</th>
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
                    <h2 class="text">Nuevo Salón</h2>
                    <div class="row">
                        <div class="col-sm-12 col-md-6">
                            <div class="form-group">
                                <label for="txtUbicacion">Ubicación</label>
                                <input runat="server" type="text" class="form-control" id="txtUbicacion" placeholder="Ubicación">
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                            <div class="form-group">
                                <label for="txtCapacidad">Capacidad</label>
                                <input runat="server" type="number" class="form-control" id="txtCapacidad" placeholder="Capacidad">
                            </div>
                        </div>
                    </div>
                    <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnAgregarSalon_Click" Text="Crear Salon"></asp:button>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="container-fluid">
                    <h2 class="text">Modificar Salón</h2>
                    <small class="form-text text-muted">Seleccionar modificar en la tabla para cargar los datos del salón.</small>
                    <div class="row">
                        <div class="col-sm-12 col-md-6">
                            <div class="form-group">
                                <label>Id Salón:</label>
                                <label runat="server" id="lblIdSalonM"></label>
                            </div>
                            <div class="form-group">
                                <label for="txtUbicacionM">Ubicación</label>
                                <input runat="server" type="text" class="form-control" id="txtUbicacionM" placeholder="Ubicación">
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                            <div class="form-group">
                                <label>Estado:</label>
                                <label runat="server" id="lblEstadoM"></label>
                            </div>
                            <div class="form-group">
                                <label for="txtCapacidadM">Capacidad</label>
                                <input runat="server" type="number" class="form-control" id="txtCapacidadM" placeholder="Capacidad">
                            </div>
                        </div>
                    </div>
                    <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnModificar_Click" Text="Modificar Salón"></asp:button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
