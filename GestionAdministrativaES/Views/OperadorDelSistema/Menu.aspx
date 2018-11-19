<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="GestionAdministrativaES.Views.OperadorDelSistema.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row pt-4">
            <h1 class="text-center">Operador Del Sistema - Menu</h1>
        </div>
        <div class="row">
            <div class="col-sm-12 col-md-4 pt-4">
                <div class="card border-primary">
                    <img class="card-img-top p-2" src="../assets/images/salon.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">Salones</h5>
                        <p class="card-text">Listado con todos los salones con los que cuenta la escuela de sistemas.</p>
                        <a href="Salon/AdministrarSalones.aspx" class="btn btn-primary">Administrar</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-12 col-md-4 pt-4">
                <div class="card border-primary">
                    <img class="card-img-top p-2" src="../assets/images/incidenteSalon.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">Incidentes de Salones</h5>
                        <p class="card-text">Registro de incidentes relacionados con los salones.</p>
                        <a href="Salon/AdministrarIncidentesSalones.aspx" class="btn btn-primary">Administrar</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-12 col-md-4 pt-4">
                <div class="card border-primary">
                    <img class="card-img-top p-2" src="../assets/images/reservacion.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">Reservaciones</h5>
                        <p class="card-text">Registrar las reservaciones de salones solicitadas por instructores.</p>
                        <a href="Salon/Reservacion/AdministrarReservaciones.aspx" class="btn btn-primary">Administrar</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12 col-md-4 pt-4">
                <div class="card border-primary">
                    <img class="card-img-top p-2" src="../assets/images/insumo.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">Insumos</h5>
                        <p class="card-text">Listado con todos los insumos que la escuela de sistemas posee para prestamos.</p>
                        <a href="Insumos/AdministrarInsumos.aspx" class="btn btn-primary">Administrar</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-12 col-md-4 pt-4">
                <div class="card border-primary">
                    <img class="card-img-top p-2" src="../assets/images/incidenteInsumo.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">Incidentes de Insumos</h5>
                        <p class="card-text">Registro de incidentes relacionados con los insumos.</p>
                        <a href="Insumos/AdministrarIncidentesInsumos.aspx" class="btn btn-primary">Administrar</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-12 col-md-4 pt-4">
                <div class="card border-primary">
                    <img class="card-img-top p-2" src="../assets/images/incidenteInsumo.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">Incidentes de Insumos</h5>
                        <p class="card-text">Registro de incidentes relacionados con los insumos.</p>
                        <a href="Insumos/Prestamo/AdministrarPrestamos.aspx" class="btn btn-primary">Administrar</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>