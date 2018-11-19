<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarIncidentes.aspx.cs" Inherits="GestionAdministrativaES.Views.Estudiante.Incidentes.AdministrarIncidentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="text-center">ADMINISTRAR INCIDENTES</h1>
        <div class="row p-4">
            <h2 class="text">Incidentes En Proceso</h2>
            <div class="table-responsive">
                <table runat="server" id="tbEnProceso" class="table">
                    <thead>
                        <tr class="bg-primary">
                            <th class="text-light" scope="col">id Incidente</th>
                            <th class="text-light" scope="col">Id Insumo</th>
                            <th class="text-light" scope="col">Insumo</th>
                            <th class="text-light" scope="col">Fecha</th>
                            <th class="text-light" scope="col">Estado</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="row p-4">
            <h2 class="text">Incidentes Finalizados</h2>
            <div class="table-responsive">
                <table runat="server" id="tbFinalizados" class="table">
                    <thead>
                        <tr class="bg-primary">
                            <th class="text-light" scope="col">id Incidente</th>
                            <th class="text-light" scope="col">Id Insumo</th>
                            <th class="text-light" scope="col">Insumo</th>
                            <th class="text-light" scope="col">Fecha</th>
                            <th class="text-light" scope="col">Estado</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
