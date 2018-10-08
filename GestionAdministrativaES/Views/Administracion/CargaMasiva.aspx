<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargaMasiva.aspx.cs" Inherits="GestionAdministrativaES.Views.Administracion.CargaMasiva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        Carga Masiva</p>
    <p>
        <asp:FileUpload id="FileUploadControl" runat="server" />
        <asp:Button runat="server" id="UploadButton" text="Upload" onclick="UploadButton_Click" />
        <asp:Button ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" Text="Regresar" />
        <br /><br />
        <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
