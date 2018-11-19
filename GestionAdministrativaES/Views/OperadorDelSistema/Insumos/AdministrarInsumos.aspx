<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarInsumos.aspx.cs" Inherits="GestionAdministrativaES.Views.OperadorDelSistema.Insumos.AdministrarInsumos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
    <h1 class="text-center">ADMINISTRAR INSUMOS</h1>
    <div class="row p-4">
        <h2 class="text">Insumos</h2>
        <div class="table-responsive">
            <table runat="server" id="tbInsumos" class="table">
                <thead>
                    <tr class="bg-primary">
                        <th class="text-light" scope="col">id Insumo</th>
                        <th class="text-light" scope="col">Nombre</th>
                        <th class="text-light" scope="col">Tipo</th>
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
                <h2 class="text">Nuevo Insumo</h2>
                <div class="row">
                    <div class="col-sm-12 col-md-6">
                        <div class="form-group">
                            <label for="txtNombre">Nombre</label>
                            <input runat="server" type="text" class="form-control" id="txtNombre" placeholder="Nombre">
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-6">
                        <div class="form-group">
                            <label for="ddlTipo">Tipo</label>
                            <select runat="server" class="form-control" id="ddlTipo">
                            </select>
                        </div>
                    </div>
                </div>
                <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnAgregarInsumo_Click" Text="Crear Insumo"></asp:button>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <div class="container-fluid">
                <h2 class="text">Modificar Insumo</h2>
                <small class="form-text text-muted">Seleccionar modificar en la tabla para cargar los datos del insumo.</small>
                <div class="row">
                    <div class="col-sm-12 col-md-6">
                        <div class="form-group">
                            <label>id Insumo:</label>
                            <label runat="server" id="lblIdInsumoM" ></label>
                        </div>
                        <div class="form-group">
                            <label for="txtNombreM">Nombre</label>
                            <input runat="server" type="text" class="form-control" id="txtNombreM" placeholder="Nombre">
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-6">
                        <div class="form-group">
                            <label>Estado:</label>
                            <label runat="server" id="lblEstadoInsumoM"></label>
                        </div>
                        <div class="form-group">
                            <label for="ddlTipoM">Tipo</label>
                            <select runat="server" class="form-control" id="ddlTipoM">
                            </select>
                        </div>
                    </div>
                </div>
                <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnModificarInsumo_Click" Text="Modificar Salón"></asp:button>
            </div>
        </div>
    </div>
    <div class="row p-4">
        <h2 class="text">Tipos de Insumos</h2>
        <div class="table-responsive">
            <table runat="server" id="tbTipoInsumos" class="table">
                <thead>
                    <tr class="bg-primary">
                        <th class="text-light" scope="col">id Insumo</th>
                        <th class="text-light" scope="col">Nombre</th>
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
                <h2 class="text">Nuevo Tipo de Insumo</h2>
                <div class="row">
                    <div class="col-sm-12 col-md-12">
                        <div class="form-group">
                            <label for="txtNombreTipoInsumo">Nombre</label>
                            <input runat="server" type="text" class="form-control" id="txtNombreTipoInsumo" placeholder="Nombre">
                        </div>
                    </div>
                </div>
                <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnAgregarTipoInsumo_Click" Text="Crear Tipo Insumo"></asp:button>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <div class="container-fluid">
                <h2 class="text">Modificar Tipo Insumo</h2>
                <small class="form-text text-muted">Seleccionar modificar en la tabla para cargar los datos del tipo de insumo.</small>
                <div class="row">
                    <div class="col-sm-12 col-md-12">
                        <div class="form-group">
                            <label>id Tipo Insumo:</label>
                            <label runat="server" id="lblIdTipoInsumo"></label>
                        </div>
                        <div class="form-group">
                            <label for="txtNombreTipoInsumoM">Nombre</label>
                            <input runat="server" type="text" class="form-control" id="txtNombreTipoInsumoM" placeholder="Nombre">
                        </div>
                    </div>
                </div>
                <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnModificarTipoInsumo_Click" Text="Modificar Salón"></asp:button>
            </div>
        </div>
    </div>
</div>

</asp:Content>
