<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="GestionAdministrativaES.Views.Estudiante.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row pt-4">
            <h1 class="text-center">Estudiante - Menu</h1>
        </div>
        <div class="row">
            <div class="col-sm-12 col-md-4 pt-4">
                <div class="card border-primary">
                    <img class="card-img-top p-2" src="../assets/images/actividades.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">Ver Actividades</h5>
                        <p class="card-text">Listado de actividades a realizarse.</p>
                        <a href="Actividades/VerActividades.aspx" class="btn btn-primary">Administrar</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-12 col-md-4 pt-4">
                <div class="card border-primary">
                    <img class="card-img-top p-2" src="../assets/images/matricularse.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">Insumos</h5>
                        <p class="card-text">Buscar lo relacionado a insumos.</p>
                        <a href="Insumos/AdministrarInsumos.aspx" class="btn btn-primary">Administrar</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-12 col-md-4 pt-4">
                <div class="card border-primary">
                    <img class="card-img-top p-2" src="../assets/images/matricularse.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">Incidentes</h5>
                        <p class="card-text">Buscar lo relacionado a incidentes.</p>
                        <a href="Incidentes/AdministrarIncidentes.aspx" class="btn btn-primary">Administrar</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12 col-md-4 pt-4">
                <div class="card border-primary">
                    <img class="card-img-top p-2" src="../assets/images/matricularse.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">Actividades Matriculadas</h5>
                        <p class="card-text">Ver las actividades matriculadas.</p>
                        <a href="Actividades/VerActividadesMatriculadas.aspx" class="btn btn-primary">Administrar</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
