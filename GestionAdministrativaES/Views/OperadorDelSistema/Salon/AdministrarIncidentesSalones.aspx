<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarIncidentesSalones.aspx.cs" Inherits="GestionAdministrativaES.Views.OperadorDelSistema.Salon.AdministrarIncidentesSalones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        INCIDENTES<asp:Button ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" Text="Regresar" />
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="idIncidenteSalon" DataSourceID="incidentes">
            <Columns>
                <asp:BoundField DataField="idIncidenteSalon" HeaderText="idIncidenteSalon" InsertVisible="False" ReadOnly="True" SortExpression="idIncidenteSalon" />
                <asp:BoundField DataField="idOperador" HeaderText="idOperador" SortExpression="idOperador" />
                <asp:BoundField DataField="idSalon" HeaderText="idSalon" SortExpression="idSalon" />
                <asp:BoundField DataField="idUsuario" HeaderText="idUsuario" SortExpression="idUsuario" />
                <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                <asp:BoundField DataField="fecha" HeaderText="fecha" SortExpression="fecha" />
                <asp:BoundField DataField="estado" HeaderText="estado" SortExpression="estado" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="incidentes" runat="server" ConnectionString="<%$ ConnectionStrings:db_gestion_administrativa_escuela_de_sistemaConnectionString %>" SelectCommand="SELECT * FROM [incidenteSalon]"></asp:SqlDataSource>
    </p>
    <p>
        &nbsp;</p>
    <p>
        REPORTAR INCIDENTE</p>
    <p>
        <table style="width:100%;">
            <tr>
                <td style="width: 132px">Salon</td>
                <td style="width: 344px">
                    <asp:DropDownList ID="ddlSalon" runat="server" DataSourceID="SqlDataSource1" DataTextField="ubicacion" DataValueField="idSalon" Height="16px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db_gestion_administrativa_escuela_de_sistemaConnectionString %>" SelectCommand="SELECT * FROM [salon]"></asp:SqlDataSource>
                </td>
                <td>Fecha</td>
            </tr>
            <tr>
                <td style="width: 132px">Usuario</td>
                <td style="width: 344px">
                    <asp:DropDownList ID="ddlUsuario" runat="server" DataSourceID="usuarios" DataTextField="nick" DataValueField="idUsuario">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="usuarios" runat="server" ConnectionString="<%$ ConnectionStrings:db_gestion_administrativa_escuela_de_sistemaConnectionString %>" SelectCommand="SELECT * FROM [usuario]"></asp:SqlDataSource>
                </td>
                <td>
                    <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 132px">Descripcion</td>
                <td style="width: 344px">
                    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
        <asp:Button ID="btnReportar" runat="server" Text="Reportar" OnClick="btnReportar_Click" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        FINALIZAR INCIDENTES</p>
    <p>
        <asp:DropDownList ID="ddlInicidentes" runat="server" DataSourceID="incidentes" DataTextField="idIncidenteSalon" DataValueField="idIncidenteSalon">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar" OnClick="btnFinalizar_Click" />
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
