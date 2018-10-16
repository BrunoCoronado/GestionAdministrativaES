<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="GestionAdministrativaES.Views.Estudiante.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row pt-4">
            <h1 class="text-center">Estudiante - Menu</h1>
        </div>
        <div class="row">
            <div class="col-sm-12 col-md-4 pt-4">
                <div class="card border-primary">
                    <img class="card-img-top p-2" src="../assets/images/matricularse.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">Matricularse a una Actividad</h5>
                        <p class="card-text">Buscar actividades para matricularse.</p>
                        <a class="btn btn-primary">Administrar</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-12 col-md-4 pt-4">
                <div class="card border-primary">
                    <img class="card-img-top p-2" src="../assets/images/calendario.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">Ver Calendario</h5>
                        <p class="card-text">Calendario de actividades en la escuela.</p>
                        <a class="btn btn-primary">Administrar</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-12 col-md-4 pt-4">
                <div class="card border-primary">
                    <img class="card-img-top p-2" src="../assets/images/actividades.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">Ver Actividades</h5>
                        <p class="card-text">Listado de actividades a realizarse.</p>
                        <a class="btn btn-primary">Administrar</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
