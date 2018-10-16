<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarReservaciones.aspx.cs" Inherits="GestionAdministrativaES.Views.OperadorDelSistema.Salon.Reservacion.AdministrarReservaciones" %>
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
                            <th class="text-light" scope="col">Catedrático</th>
                            <th class="text-light" scope="col">Salón</th>
                            <th class="text-light" scope="col">Ubicación</th>
                            <th class="text-light" scope="col">Actividad</th>
                            <th class="text-light" scope="col">Período</th>
                            <th class="text-light" scope="col">Hora Inicio</th>
                            <th class="text-light" scope="col">Hora Fin</th>
                            <th class="text-light" scope="col">Fecha Inicio</th>
                            <th class="text-light" scope="col">Fecha Fin</th>
                            <th class="text-light" scope="col">Operador</th>
                            <th class="text-light" scope="col">Estado</th>
                            <th class="text-light" scope="col">Carta</th>
                            <th class="text-light" scope="col">CodigoQR</th>
                            <th class="text-light" scope="col">Modificar</th>
                            <th class="text-light" scope="col">Eliminar</th>
                            <th class="text-light" scope="col">Carta</th>
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
                    <h2 class="text">Verificar Disponibilidad</h2>
                        <small class="form-text text-muted">Llenar los campos para verificar que exista disponibilidad de espacio para la reservación.</small>
                        <div class="row">
                            <div class="col-sm-12 col-md-4">
                                <div class="form-group">
                                    <label for="ddlSalonV">Salón</label>
                                    <select runat="server" class="form-control" id="ddlSalonV">
                                    </select>
                                </div> 
                                <div class="form-group">
                                    <label for="ddlPeriodoV">Período</label>
                                    <select runat="server" class="form-control" id="ddlPeriodoV">
                                    </select>
                                </div> 
                            </div>
                            <div class="col-sm-12 col-md-4">
                                <div class="form-group">
                                    <label for="txtFechaInicioV">Fecha Inicio</label>
                                    <input runat="server" type="date" class="form-control" id="txtFechaInicioV">
                                </div>
                                <div class="form-group">
                                    <label for="txtFechaFinV">Fecha Fin</label>
                                    <input runat="server" type="date" class="form-control" id="txtFechaFinV">
                                </div>
                            </div>
                            <div class="col-sm-12 col-md-4">
                                <div class="form-group">    
                                    <label for="txtHoraInicioV">Hora Inicio</label>
                                    <input runat="server" type="time" class="form-control" id="txtHoraInicioV">
                                </div> 
                                <div class="form-group">
                                    <label for="txtHoraFinV">Hora Fin</label>
                                    <input runat="server" type="time" class="form-control" id="txtHoraFinV">
                                </div> 
                            </div>
                        </div>
                    <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnComprobaraDisponibilidad_Click" Text="Verificar Disponibilidad"></asp:button>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="container-fluid">
                    <h2 class="text">Crear Reservación</h2>
                    <div class="row">
                            <div class="col-sm-12 col-md-4">
                                <div class="form-group">
                                    <label for="ddlSalon">Salón</label>
                                    <select runat="server" class="form-control" id="ddlSalon">
                                    </select>
                                </div> 
                                <div class="form-group">
                                    <label for="ddlPeriodo">Período</label>
                                    <select runat="server" class="form-control" id="ddlPeriodo">
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label for="ddlUsuaio">Usuario</label>
                                    <select runat="server" class="form-control" id="ddlUsuario">
                                    </select>
                                </div>  
                            </div>
                            <div class="col-sm-12 col-md-4">
                                <div class="form-group">
                                    <label for="txtFechaInicio">Fecha Inicio</label>
                                    <input runat="server" type="date" class="form-control" id="txtFechaInicio">
                                </div>
                                <div class="form-group">
                                    <label for="txtFechaFin">Fecha Fin</label>
                                    <input runat="server" type="date" class="form-control" id="txtFechaFin">
                                </div>
                                <div class="form-group">
                                    <label for="ddlActividad">Actividad</label>
                                    <select runat="server" class="form-control" id="ddlActividad">
                                    </select>
                                </div> 
                            </div>
                            <div class="col-sm-12 col-md-4">
                                <div class="form-group">    
                                    <label for="txtHoraInicio">Hora Inicio</label>
                                    <input runat="server" type="time" class="form-control" id="txtHoraInicio">
                                </div> 
                                <div class="form-group">
                                    <label for="txtHoraFin">Hora Fin</label>
                                    <input runat="server" type="time" class="form-control" id="txtHoraFin">
                                </div>
                                <div class="form-group">
                                    <label for="fcCarta">Carta (opcional)</label>
                                    <input runat="server" type="file" class="form-control" id="fcCarta" accept=".pdf"> 
                                </div>
                            </div>
                        </div>
                    <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnCrear_Click" Text="Crear Reservación"></asp:button>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="container-fluid">
                    <h2 class="text">Añadir Carta De Reservación</h2>
                    <small class="form-text text-muted">Seleccionar "Añadir Carta" en la tabla para cargar los datos de la reservación.</small>
                    <div class="row">
                        <div class="col">
                            <div class="form-group">
                                <label>Reservación:</label>
                                <label runat="server" id="lblReservacionC"></label>
                            </div>
                            <div class="form-group">
                                <label for="fcCartaC">Carta</label>
                                <input runat="server" type="file" class="form-control" id="fcCartaC" accept=".pdf">
                            </div>
                        </div>
                    </div>
                    <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnAgregarCarta_Click" Text="Añadir Carta"></asp:button>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="container-fluid">
                    <h2 class="text">Modificar Reservación</h2>
                    <small class="form-text text-muted">Seleccionar modificar en la tabla para cargar los datos de la reservación.</small>
                    <label runat="server" id="lblIdReservacionM" hidden="hidden"></label>
                    <div class="row">
                            <div class="col-sm-12 col-md-4">
                                <div class="form-group">
                                    <label for="ddlSalonM">Salón</label>
                                    <select runat="server" class="form-control" id="ddlSalonM">
                                    </select>
                                </div> 
                                <div class="form-group">
                                    <label for="ddlPeriodoM">Período</label>
                                    <select runat="server" class="form-control" id="ddlPeriodoM">
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label for="ddlUsuarioM">Usuario</label>
                                    <select runat="server" class="form-control" id="ddlUsuarioM">
                                    </select>
                                </div>  
                            </div>
                            <div class="col-sm-12 col-md-4">
                                <div class="form-group">
                                    <label for="txtFechaInicioM">Fecha Inicio</label>
                                    <input runat="server" type="date" class="form-control" id="txtFechaInicioM">
                                </div>
                                <div class="form-group">
                                    <label for="txtFechaFinM">Fecha Fin</label>
                                    <input runat="server" type="date" class="form-control" id="txtFechaFinM">
                                </div>
                                <div class="form-group">
                                    <label for="ddlActividad">Actividad</label>
                                    <select runat="server" class="form-control" id="ddlActividadM">
                                    </select>
                                </div> 
                            </div>
                            <div class="col-sm-12 col-md-4">
                                <div class="form-group">    
                                    <label for="txtHoraInicioM">Hora Inicio</label>
                                    <input runat="server" type="time" class="form-control" id="txtHoraInicioM">
                                </div> 
                                <div class="form-group">
                                    <label for="txtHoraFinM">Hora Fin</label>
                                    <input runat="server" type="time" class="form-control" id="txtHoraFinM">
                                </div>
                            </div>
                        </div>
                    <asp:button runat="server" type="submit" class="btn btn-primary btn-block" OnClick="btnModificar_Click" Text="Modificar Reservación"></asp:button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
