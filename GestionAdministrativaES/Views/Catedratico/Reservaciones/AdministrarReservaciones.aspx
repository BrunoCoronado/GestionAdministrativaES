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
                            <th class="text-light" scope="col">Presentación</th>
                            <th class="text-light" scope="col">Cuestionario</th>
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
                    <h2 class="text">Añadir Presentación</h2>
                    <small class="form-text text-muted">Seleccionar "Presentación" en la tabla para cargar los datos de la reservación.</small>
                    <div class="row">
                        <div class="col">
                            <div class="form-group">
                                <label>Reservación:</label>
                                <label runat="server" id="lblReservacionP"></label>
                            </div>
                            <div class="form-group">
                                <label for="fcCartaC">Presentación</label>
                                <input runat="server" type="file" class="form-control" id="fcPresentacion" name="fcPresentacion" accept=".pptx">
                            </div>
                        </div>
                    </div>
                    <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnInsertarPresentacion_Click" Text="Añadir Presentacion"></asp:button>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="container-fluid">
                    <h2 class="text">Añadir Preguntas</h2>
                    <small class="form-text text-muted">Seleccionar "Cuestionario" en la tabla para cargar los datos de la reservación.</small>
                    <label runat="server" id="lblIdCuestionario" hidden="hidden"></label>
                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <div class="form-group">
                                <label>Reservación:</label>
                                <label runat="server" id="lblReservacionC"></label>
                            </div>
                            <div class="form-group">
                                <label for="txtPregunta">Pregunta</label>
                                <input runat="server" type="text" class="form-control" id="txtPregunta" >
                            </div>
                        </div>
                    </div>
                    <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnAgregarPregunta_Click" Text="Añadir Pregunta"></asp:button>
                </div>
            </div>
        </div>
        <div class="row p-4">
            <h2 class="text">Cuestionario</h2>
            <div class="table-responsive">
                <table runat="server" id="tbCuestionario" class="table">
                    <thead>
                        <tr class="bg-primary">
                            <th class="text-light" scope="col">id Pregunta</th>
                            <th class="text-light" scope="col">Cuestionario</th>
                            <th class="text-light" scope="col">Pregunta</th>
                            <th class="text-light" scope="col">Eliminar</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
