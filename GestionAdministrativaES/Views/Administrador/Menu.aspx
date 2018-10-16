<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="GestionAdministrativaES.Views.Administrador.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row pt-4">
            <h1 class="text-center">Administrador - Menu</h1>
        </div>
        <div class="row">
            <div class="col-sm-12 col-md-4 pt-4">
                <div class="card border-primary">
                    <img class="card-img-top p-2" src="../assets/images/usuarios.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">Usuarios</h5>
                        <p class="card-text">Listado de usuarios registrados.</p>
                        <a href="../Administrador/Usuario/AdministrarUsuarios.aspx" class="btn btn-primary">Administrar</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-12 col-md-4 pt-4">
                <div class="card border-primary">
                    <img class="card-img-top p-2" src="../assets/images/cargaMasiva.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">Carga Masiva</h5>
                        <p class="card-text">Carga de datos mediante archivos .xls.</p>
                        <a href="../Administracion/CargaMasiva.aspx" class="btn btn-primary">Administrar</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
