<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarIncidentesInsumos.aspx.cs" Inherits="GestionAdministrativaES.Views.OperadorDelSistema.Insumos.AdministrarIncidentesInsumos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="text-center">ADMINISTRAR INCIDENTES DE INSUMOS</h1>
        <div class="row p-4">
            <h2 class="text">Incidentes</h2>
            <div class="table-responsive">
                <table runat="server" id="tbIncidentes" class="table">
                    <thead>
                        <tr class="bg-primary">
                            <th class="text-light" scope="col">No. Incidente</th>
                            <th class="text-light" scope="col">Id. Insumo</th>
                            <th class="text-light" scope="col">Insumo</th>
                            <th class="text-light" scope="col">Usuario</th>
                            <th class="text-light" scope="col">Fecha</th>
                            <th class="text-light" scope="col">Estado</th>
                            <th class="text-light" scope="col">Accion</th>
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
                    <h2 class="text">Reportar Incidente</h2>
                    <div class="row">
                        <div class="col">
                            <div class="form-group">
                                <label for="ddlInsumos">Insumo</label>
                                <select runat="server" class="form-control" id="ddlInsumos">
                                </select>
                            </div>
                            <div class="form-group">
                                <label for="ddlUsuarios">Usuario</label>
                                <select runat="server" class="form-control" id="ddlUsuarios">
                                </select>
                            </div>
                            <div class="form-group">
                                <label for="txtFecha">Fecha</label>
                                <input runat="server" type="date" class="form-control" id="txtFecha" min="2018-10-09">
                            </div>
                        </div>
                    </div>
                    <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="ReportarIncidente_Click" Text="Reportar Incidente"></asp:button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
