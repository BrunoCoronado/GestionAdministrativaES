<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarSalones.aspx.cs" Inherits="GestionAdministrativaES.Views.Salon.AdministrarSalones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        LISTADO DE SALONES</p>
    <p>
        &nbsp;</p>
    <p>
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="idSalon" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="idSalon" HeaderText="idSalon" InsertVisible="False" ReadOnly="True" SortExpression="idSalon" />
                <asp:BoundField DataField="ubicacion" HeaderText="ubicacion" SortExpression="ubicacion" />
                <asp:BoundField DataField="capacidad" HeaderText="capacidad" SortExpression="capacidad" />
                <asp:BoundField DataField="estado" HeaderText="estado" SortExpression="estado" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db_gestion_administrativa_escuela_de_sistemaConnectionString %>" SelectCommand="SELECT * FROM [salon]"></asp:SqlDataSource>
        
    </p>
    <p>
        
        &nbsp;</p>
    <p>
        
        AÑADIR SALON</p>
    <p>
        
        <table style="width:100%;">
            <tr>
                <td style="height: 20px; width: 145px">Ubicación</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtUbicacion" runat="server" Width="253px"></asp:TextBox>
                </td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="height: 20px; width: 145px">Capacidad</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtCapacidad" runat="server" Width="247px"></asp:TextBox>
                </td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="width: 145px">
                    <asp:Button ID="btnAgregarSalon" runat="server" OnClick="btnAgregarSalon_Click" Text="Agregar" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        
    </p>
    <br />
    ELIMINAR SALON<br />
    <asp:DropDownList ID="DropDownListEliminar" runat="server" DataSourceID="SqlDataSource1" DataTextField="ubicacion" DataValueField="idSalon">
    </asp:DropDownList>
    <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
    <br />
    <br />
    MODIFICAR SALON<br />
    <table class="nav-justified">
        <tr>
            <td style="width: 153px; height: 22px">
                <asp:DropDownList ID="DropDownListModificar" runat="server" DataSourceID="SqlDataSource1" DataTextField="ubicacion" DataValueField="idSalon">
                </asp:DropDownList>
            </td>
            <td style="height: 22px; width: 128px">Ubicación</td>
            <td style="height: 22px">
                <asp:TextBox ID="txtUbicacionM" runat="server" Width="259px"></asp:TextBox>
                <asp:TextBox ID="txtIdSalonM" runat="server" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 153px; height: 26px;">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            </td>
            <td style="width: 128px; height: 26px;">Capacidad</td>
            <td style="height: 26px">
                <asp:TextBox ID="txtCapacidadM" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 153px">&nbsp;</td>
            <td style="width: 128px">
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
