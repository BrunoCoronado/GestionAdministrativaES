<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarReservaciones.aspx.cs" Inherits="GestionAdministrativaES.Views.OperadorDelSistema.Salon.Reservacion.AdministrarReservaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        RESERVACIONES<asp:Button ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" Text="Regresar" />
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="idReservacion" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="idReservacion" HeaderText="idReservacion" InsertVisible="False" ReadOnly="True" SortExpression="idReservacion" />
                <asp:BoundField DataField="idUsuario" HeaderText="idUsuario" SortExpression="idUsuario" />
                <asp:BoundField DataField="idSalon" HeaderText="idSalon" SortExpression="idSalon" />
                <asp:BoundField DataField="idOperador" HeaderText="idOperador" SortExpression="idOperador" />
                <asp:BoundField DataField="estado" HeaderText="estado" SortExpression="estado" />
                <asp:BoundField DataField="carta" HeaderText="carta" SortExpression="carta" />
                <asp:BoundField DataField="actividad" HeaderText="actividad" SortExpression="actividad" />
                <asp:BoundField DataField="horaInicio" HeaderText="horaInicio" SortExpression="horaInicio" />
                <asp:BoundField DataField="horaFinal" HeaderText="horaFinal" SortExpression="horaFinal" />
                <asp:BoundField DataField="periodo" HeaderText="periodo" SortExpression="periodo" />
                <asp:BoundField DataField="fechaInicial" HeaderText="fechaInicial" SortExpression="fechaInicial" />
                <asp:BoundField DataField="fechaFinal" HeaderText="fechaFinal" SortExpression="fechaFinal" />
                <asp:BoundField DataField="codigoQR" HeaderText="codigoQR" SortExpression="codigoQR" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db_gestion_administrativa_escuela_de_sistemaConnectionString %>" SelectCommand="SELECT * FROM [reservacion]"></asp:SqlDataSource>
    </p>
    <p>
        &nbsp;</p>
    <p>
        VERIFICAR DISPONIBILIDAD</p>
    <p>
        &nbsp;</p>
    <p>
        <table style="width:100%;">
            <tr>
                <td style="height: 20px; width: 143px">Salones</td>
                <td style="height: 20px; width: 214px">
                    <asp:DropDownList ID="ddlSalonesVD" runat="server" DataSourceID="SqlDataSource2" DataTextField="ubicacion" DataValueField="idSalon">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:db_gestion_administrativa_escuela_de_sistemaConnectionString %>" SelectCommand="SELECT * FROM [salon]"></asp:SqlDataSource>
                </td>
                <td style="height: 20px">
                    Fecha</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtFechaInicioVD" runat="server"></asp:TextBox>
                </td>
                <td style="height: 20px">
                    Hora</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtHoraInicioVD" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 143px"></td>
                <td style="width: 214px">
                </td>
                <td>
                    Fecha Fin</td>
                <td>
                    <asp:TextBox ID="txtFechaFinVD" runat="server"></asp:TextBox>
                </td>
                <td>Hora Fin</td>
                <td>
                    <asp:TextBox ID="txtHoraFinVD" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        
    <p>
        <asp:Button ID="btnComprobaraDisponibilidad" runat="server" Text="Comprobar Disponibilidad" OnClick="btnComprobaraDisponibilidad_Click" />
    </p> 
    </p>
    <p>
        &nbsp;</p>
    <p>
        CREAR RESERVACION</p>
    <p>
        <table style="width:100%;">
            <tr>
                <td style="height: 20px; width: 143px">Salones</td>
                <td style="height: 20px; width: 214px">
                    <asp:DropDownList ID="ddlSalon" runat="server" DataSourceID="SqlDataSource2" DataTextField="ubicacion" DataValueField="idSalon">
                    </asp:DropDownList>
                </td>
                <td style="height: 20px">
                    Fecha</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>
                </td>
                <td style="height: 20px">
                    Hora</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtHoraInicio" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 143px">
                    Periodo</td>
                <td style="width: 214px">
                    <asp:DropDownList ID="ddlPeriodo" runat="server">
                        <asp:ListItem>Unico</asp:ListItem>
                        <asp:ListItem>Diario</asp:ListItem>
                        <asp:ListItem>Semanal</asp:ListItem>
                        <asp:ListItem>Quincenal</asp:ListItem>
                        <asp:ListItem>Mensual</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    Fecha Fin</td>
                <td>
                    <asp:TextBox ID="txtFechaFIn" runat="server"></asp:TextBox>
                </td>
                <td>Hora Fin</td>
                <td>
                    <asp:TextBox ID="txtHoraFin" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 143px">
                    Actividad</td>
                <td style="width: 214px">
                    <asp:TextBox ID="txtActividad" runat="server"></asp:TextBox>
                </td>
                <td>
                    Usuario</td>
                <td>
                    <asp:DropDownList ID="ddlUsuario" runat="server" DataSourceID="SqlDataSource3" DataTextField="nick" DataValueField="idUsuario">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:db_gestion_administrativa_escuela_de_sistemaConnectionString %>" SelectCommand="SELECT * FROM [usuario]"></asp:SqlDataSource>
                </td>
                <td>*Carta</td>
                <td>
                    <asp:FileUpload ID="FUInsertarCarta" runat="server" />
                </td>
            </tr>
        </table>   
    <asp:Button ID="btnCrear" runat="server" OnClick="btnCrear_Click" Text="Crear" />
    </p>
    <p>
        ELIMINAR RESERVACION</p>
    <p>
        <asp:DropDownList ID="ddlReservacionEliminar" runat="server" DataSourceID="SqlDataSource1" DataTextField="idReservacion" DataValueField="idReservacion">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
    </p>
    <p>
        EDITAR RESERVACION</p>
    <p>
        <asp:DropDownList ID="ddlReservacionEditar" runat="server" DataSourceID="SqlDataSource1" DataTextField="idReservacion" DataValueField="idReservacion">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
    </p>
    <p>
        <table style="width:100%;">
            <tr>
                <td style="height: 20px; width: 143px">Salones</td>
                <td style="height: 20px; width: 214px">
                    <asp:DropDownList ID="ddlSalonM" runat="server" DataSourceID="SqlDataSource2" DataTextField="ubicacion" DataValueField="idSalon">
                    </asp:DropDownList>
                </td>
                <td style="height: 20px">
                    Fecha</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtFechaInicioM" runat="server"></asp:TextBox>
                </td>
                <td style="height: 20px">
                    Hora</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtHoraInicioM" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 143px">
                    Periodo</td>
                <td style="width: 214px">
                    <asp:DropDownList ID="ddlPeriodoM" runat="server">
                        <asp:ListItem>Unico</asp:ListItem>
                        <asp:ListItem>Diario</asp:ListItem>
                        <asp:ListItem>Semanal</asp:ListItem>
                        <asp:ListItem>Quincenal</asp:ListItem>
                        <asp:ListItem>Mensual</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    Fecha Fin</td>
                <td>
                    <asp:TextBox ID="txtFechaFinM" runat="server"></asp:TextBox>
                </td>
                <td>Hora Fin</td>
                <td>
                    <asp:TextBox ID="txtHoraFinM" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 143px">
                    Actividad</td>
                <td style="width: 214px">
                    <asp:TextBox ID="txtActividadM" runat="server"></asp:TextBox>
                </td>
                <td>
                    Usuario</td>
                <td>
                    <asp:DropDownList ID="ddlUsuarioM" runat="server" DataSourceID="SqlDataSource3" DataTextField="nick" DataValueField="idUsuario">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="txtIdReservacionM" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td></td>
            </tr>
        </table>
    <p>
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
    </p>    
    Agregar Carta</p>
    <p>
        <table style="width:100%;">
            <tr>
                <td class="modal-sm" style="width: 152px">Reservacion</td>
                <td>
                    <asp:DropDownList ID="ddlSalonAC" runat="server" DataSourceID="SqlDataSource1" DataTextField="idReservacion" DataValueField="idReservacion" style="margin-left: 0px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 152px">carta</td>
                <td>
                    <asp:FileUpload ID="FUAgregarCarta" runat="server" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 152px">&nbsp;</td>
                <td>
                    <asp:Button ID="btnAgregarCarta" runat="server" OnClick="btnAgregarCarta_Click" Text="Agregar Carta" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
