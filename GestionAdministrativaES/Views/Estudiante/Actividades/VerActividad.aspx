<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerActividad.aspx.cs" Inherits="GestionAdministrativaES.Views.Estudiante.Actividades.VerActividad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="text-center">PANEL ACTIVIDAD</h1>
        <label runat="server" id="lblIdReservacion" hidden="hidden"></label>
        Actividad:<h2 runat="server" id="txtActividad" class="text">#nombre</h2>
        <h5 runat="server" id="txtInstructor" class="text">#instructo</h5>
        <h5 runat="server" id="txtSalon" class="text">#salon</h5>
        <h5 runat="server" id="txtFechaInicio" class="text">#fecha inicio</h5>
        <h5 runat="server" id="txtFechaFin" class="text">#fecha fin</h5>
        <h5 runat="server" id="txtHoraInicio" class="text">#hora inicio</h5>
        <h5 runat="server" id="txtHoraFin" class="text">#hora fin</h5>
        <asp:button runat="server" type="button" class="btn btn-info" OnClick="descargarQR_Click" Text="Ver QR"></asp:button>
        <asp:button runat="server" type="button" class="btn btn-info" OnClick="descargarPresentacion_Click" Text="Descargar Presentacion"></asp:button>
        <asp:button runat="server" type="button" class="btn btn-info" OnClick="responderCuestionario_Click" Text="Responder Cuestionario"></asp:button>
        <h5 class="text">#Descripcion:</h5>
        <h6>Lorem ipsum dolor sit amet consectetur adipisicing elit. Tempore accusantium quo perferendis architecto incidunt. Nam itaque, illo assumenda debitis ipsa nemo cum nisi amet blanditiis. Nemo saepe aliquid aspernatur nesciunt.
            Lorem ipsum dolor sit amet consectetur adipisicing elit. Aut, voluptatem. Doloremque, impedit eos eum aliquam rerum tenetur id nesciunt in laborum corporis, eius expedita, iste ad debitis delectus. Accusantium, veritatis.
            Lorem ipsum dolor sit amet consectetur adipisicing elit. Vel impedit sapiente consequuntur accusamus iure possimus ipsam officia assumenda exercitationem eligendi dolorem delectus, quo ex facilis eum in ratione ullam? Alias.
            Lorem ipsum dolor sit amet consectetur adipisicing elit. Consequatur dolorum soluta dignissimos fugiat iste! Blanditiis temporibus est iure, eius sed dolores fugiat. Sequi illum, perferendis asperiores cumque laborum in nisi.
        </h6>
    </div>
</asp:Content>
