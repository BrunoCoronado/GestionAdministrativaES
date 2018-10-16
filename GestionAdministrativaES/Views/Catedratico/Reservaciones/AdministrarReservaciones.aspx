<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarReservaciones.aspx.cs" Inherits="GestionAdministrativaES.Views.Catedratico.Reservaciones.AdministrarReservaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="text-center">ADMINISTRAR RESERVACIONES</h1>
        <div class="row p-4">
            <h2 class="text">Reservaciones</h2>
            <div class="table-responsive">
                <table runat="server" id="tbReservaciones" class="table">
                    <thead>
                        <tr class="bg-primary">
                            <th class="text-light" scope="col">id Reservación</th>
                            <th class="text-light" scope="col">Salón</th>
                            <th class="text-light" scope="col">Ubicación</th>
                            <th class="text-light" scope="col">Actividad</th>
                            <th class="text-light" scope="col">Período</th>
                            <th class="text-light" scope="col">Hora Inicio</th>
                            <th class="text-light" scope="col">Hora Fin</th>
                            <th class="text-light" scope="col">Fecha Inicio</th>
                            <th class="text-light" scope="col">Fecha Fin</th>
                            <th class="text-light" scope="col">Estado</th>
                            <th class="text-light" scope="col">CodigoQR</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
