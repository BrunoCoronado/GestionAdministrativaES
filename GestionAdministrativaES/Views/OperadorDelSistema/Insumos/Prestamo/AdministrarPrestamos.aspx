<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarPrestamos.aspx.cs" Inherits="GestionAdministrativaES.Views.OperadorDelSistema.Insumos.Prestamo.AdministrarPrestamos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="text-center">ADMINISTRAR PRESTAMOS DE INSUMOS</h1>
        <div class="row p-4">
            <h2 class="text">Prestamos</h2>
            <div class="table-responsive">
                <table runat="server" id="tbPrestamos" class="table">
                    <thead>
                        <tr class="bg-primary">
                            <th class="text-light" scope="col">id Prestamo</th>
                            <th class="text-light" scope="col">Usuario</th>
                            <th class="text-light" scope="col">Id Insumo</th>
                            <th class="text-light" scope="col">Insumo</th>
                            <th class="text-light" scope="col">Operador</th>
                            <th class="text-light" scope="col">Fecha</th>
                            <th class="text-light" scope="col">Estado</th>
                            <th class="text-light" scope="col">Modificar</th>
                            <th class="text-light" scope="col">Eliminar</th>
                            <th class="text-light" scope="col">Finalizar</th>
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
                    <h2 class="text">Crear Prestamo</h2>
                    <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label for="ddlInsumo">Insumo</label>
                                    <select runat="server" class="form-control" id="ddlInsumo">
                                    </select>
                                </div> 
                                <div class="form-group">
                                    <label for="ddlUsuario">Usuario</label>
                                    <select runat="server" class="form-control" id="ddlUsuario">
                                    </select>
                                </div>  
                                <div class="form-group">
                                    <label for="txtFecha">Fecha</label>
                                    <input runat="server" type="date" class="form-control" id="txtFecha">
                                </div>
                            </div>
                        </div>
                    <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="CrearPrestamo_Click" Text="Crear Prestamo"></asp:button>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="container-fluid">
                    <h2 class="text">Modificar Prestamo</h2>
                    <small class="form-text text-muted">Seleccionar modificar en la tabla para cargar los datos del prestamo.</small>
                    <label runat="server" id="lblIdPrestamoM" hidden="hidden"></label>
                    <div class="row">
                            <div class="col-sm-12 col-md-6">
                                <div class="form-group">
                                    <label for="ddlInsumoM">Insumo</label>
                                    <select runat="server" class="form-control" id="ddlInsumoM">
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label for="ddlUsuarioM">Usuario</label>
                                    <select runat="server" class="form-control" id="ddlUsuarioM">
                                    </select>
                                </div>  
                                
                            </div>
                            <div class="col-sm-12 col-md-6">
                                <div class="form-group">
                                    <label for="txtFechaM">Fecha</label>
                                    <input runat="server" type="date" class="form-control" id="txtFechaM">
                                </div>
                                <div class="form-group">
                                    <label>Estado:</label>
                                    <label runat="server" id="lblEstadoM"></label>
                                </div>
                            </div>
                        </div>
                    <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="ModificarPrestamo_Click" Text="Modificar Prestamo"></asp:button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
