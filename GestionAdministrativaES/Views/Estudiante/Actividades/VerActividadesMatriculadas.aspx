<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerActividadesMatriculadas.aspx.cs" Inherits="GestionAdministrativaES.Views.Estudiante.Actividades.VerActividadesMatriculadas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <%
     for (int i=0; i<(actividadesNuevas.Length/5);i++)
     {
         if (i % 3 == 0)
         {
             if (i>1)
             {
                 Response.Write("</div");
             }
             Response.Write("<div class=\"row\">");
         }
         Response.Write("<div class=\"col-sm-12 col-md-4 pt-4\">");
         Response.Write("<div class=\"card border-primary\">");
         Response.Write("<img class=\"card-img-top p-2\" src=\"../../assets/images/actividades.png\" alt=\"Card image cap\">");
         Response.Write("<div class=\"card-body\">");
         Response.Write("<h5 class=\"card-title\">"+actividadesNuevas[i,0]+"</h5>");
         Response.Write("<p class=\"card-text\">Catedratico: "+actividadesNuevas[i,1]+"<br>Lugar: "+actividadesNuevas[i,2]+"<br>Fecha: "+actividadesNuevas[i,3]+"<br>Hora: "+actividadesNuevas[i,4]+"</p>");
         Response.Write("<button id=\" "+actividadesNuevas[i,5]+" \" class=\"btn btn-primary\" onclick=\"myFunction("+actividadesNuevas[i,5]+")\">Ver</button>");
         Response.Write("</div>");
         Response.Write("</div>");
         Response.Write("</div>");
     }
%>
    <asp:label runat="server" id="lblIdActividad"></asp:label>
     <asp:HiddenField ID = "hfName" runat = "server" />
    <script>
        function myFunction(id) {
            var label = document.getElementById("<% =lblIdActividad.ClientID %>")
 
            //Set the value of Label.
            label.innerHTML = id;
 
            //Set the value of Label in Hidden Field.
            document.getElementById("<%=hfName.ClientID %>").value = label.innerHTML;
            
        }
</script>
</asp:Content>
