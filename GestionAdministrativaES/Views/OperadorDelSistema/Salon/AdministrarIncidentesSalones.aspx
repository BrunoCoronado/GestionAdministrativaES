<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarIncidentesSalones.aspx.cs" Inherits="GestionAdministrativaES.Views.OperadorDelSistema.Salon.AdministrarIncidentesSalones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="text-center">ADMINISTRAR INCIDENTES DE SALONES</h1>
        <div class="row p-4">
            <h2 class="text">Incidentes</h2>
            <div class="table-responsive">
                <table runat="server" class="table" id="tbIncidentes">
                    <thead>
                        <tr class="bg-primary">
                            <th class="text-light" scope="col">No. Incidente</th>
                            <th class="text-light" scope="col">Salon</th>
                            <th class="text-light" scope="col">Usuario</th>
                            <th class="text-light" scope="col">Descripcion</th>
                            <th class="text-light" scope="col">Fecha</th>
                            <th class="text-light" scope="col">Operador</th>
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
                                <label for="listaSalones">Salón</label>
                                <select runat="server" class="form-control" id="listaSalones">
                                </select>
                            </div>
                            <div class="form-group">
                                <label for="listaUsuarios">Usuario</label>
                                <select runat="server" class="form-control" id="listaUsuarios">
                                </select>
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-group">
                                <label for="textDescripcion">Descripción</label>
                                <input runat="server" type="text" class="form-control" id="textDescripcion" placeholder="Descripción">
                            </div>
                            <div class="form-group">
                                <label for="textFecha">Fecha</label>
                                <input runat="server" type="date" class="form-control" id="textFecha" min="2018-10-09">
                            </div>
                        </div>
                    </div>
                    <asp:button runat="server" id="btReportar" OnClick="btnReportar_Click" type="submit" class="btn btn-primary btn-block" Text="Reportar Incidente"></asp:button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
