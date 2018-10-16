<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="GestionAdministrativaES.Views.Catedratico.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row pt-4">
            <h1 class="text-center">Catedratico - Menu</h1>
        </div>
        <div class="row">
            <div class="col-sm-12 col-md-4 pt-4">
                <div class="card border-primary">
                    <img class="card-img-top p-2" src="../assets/images/reservacionesCat.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">Reservaciones</h5>
                        <p class="card-text">Listado de reservaciones realizadas.</p>
                        <a href="Reservaciones/AdministrarReservaciones.aspx" class="btn btn-primary">Administrar</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
