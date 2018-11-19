<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cuestionario.aspx.cs" Inherits="GestionAdministrativaES.Views.Estudiante.Actividades.Cuestionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="text-center">CUESTIONARIO</h1>
        <div class="row">
            <div class="col">
                <div class="container-fluid">
                     <%
                         for (int i=0; i<(contenido.Length);i++)
                         {
                             Response.Write("<div class=\"row\">");
                             Response.Write("<div class=\"col\">");
                             Response.Write("<div class=\"form-group\">");
                             Response.Write("<label for="+i+">" + contenido[i] + "</label>");
                             Response.Write("<input runat=\"server\" type=\"text\" class=\"form-control\" id=" + i + ">");
                             Response.Write("</div>");
                             Response.Write("</div>");
                             Response.Write("</div>");
                         }
                    %>
                    <button type="submit" class="btn btn-primary btn-block">Registrarse</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
