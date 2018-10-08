<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarReservaciones.aspx.cs" Inherits="GestionAdministrativaES.Views.Catedratico.Reservaciones.AdministrarReservaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        Reservaciones Realizadas<asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
    </p>
    <p>
       
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="idReservacion" DataSourceID="SqlDataSource3">
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
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:db_gestion_administrativa_escuela_de_sistemaConnectionString %>" SelectCommand="SELECT * FROM [reservacion]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:db_gestion_administrativa_escuela_de_sistemaConnectionString %>" SelectCommand="SELECT * FROM reservacion WHERE idUsuario = Login.usuario.idUsuario"></asp:SqlDataSource>
       
    </p>
    <p>
        &nbsp;</p>
    <p>
        DESCARGAR CODIGOQR</p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Reservacion:"></asp:Label>
        <asp:DropDownList ID="ddlReservacion" runat="server" DataSourceID="SqlDataSource1" DataTextField="idReservacion" DataValueField="idReservacion">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db_gestion_administrativa_escuela_de_sistemaConnectionString %>" SelectCommand="SELECT * FROM [reservacion]"></asp:SqlDataSource>
        <asp:Button ID="btnDescargar" runat="server" Text="Descargar" OnClick="btnDescargar_Click" />
    </p>
</asp:Content>
