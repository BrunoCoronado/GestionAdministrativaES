<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarUsuarios.aspx.cs" Inherits="GestionAdministrativaES.Views.Administrador.Usuario.AdministrarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        LISTADO DE USUARIOS</p>
    <p>
        &nbsp;</p>
    <p>
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="idUsuario" DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="idUsuario" HeaderText="idUsuario" InsertVisible="False" ReadOnly="True" SortExpression="idUsuario" />
                <asp:BoundField DataField="idRol" HeaderText="idRol" SortExpression="idRol" />
                <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                <asp:BoundField DataField="correo" HeaderText="correo" SortExpression="correo" />
                <asp:BoundField DataField="nick" HeaderText="nick" SortExpression="nick" />
                <asp:BoundField DataField="contraseña" HeaderText="contraseña" SortExpression="contraseña" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:db_gestion_administrativa_escuela_de_sistemaConnectionString %>" SelectCommand="SELECT * FROM [usuario]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db_gestion_administrativa_escuela_de_sistemaConnectionString %>" SelectCommand="SELECT * FROM [salon]"></asp:SqlDataSource>
        
    </p>
    <p>
        
        &nbsp;</p>
    <p>
        
        AÑADIR SALON</p>
    <p>
        
        <table class="nav-justified">
            <tr>
                <td style="height: 20px; width: 145px">Nombre</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtNombre" runat="server" Width="253px"></asp:TextBox>
                </td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="height: 20px; width: 145px">Correo</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtCorreo" runat="server" Width="247px"></asp:TextBox>
                </td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="height: 20px; width: 145px">Nick</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtNick" runat="server" Width="247px"></asp:TextBox>
                </td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="height: 20px; width: 145px">Contraseña</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtContraseña" runat="server" Width="247px"></asp:TextBox>
                </td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="height: 20px; width: 145px">Rol</td>
                <td style="height: 20px">
                    <asp:DropDownList ID="ddlRol" runat="server">
                        <asp:ListItem Value="1">Administrador</asp:ListItem>
                        <asp:ListItem Value="2">Operador Del Sistema</asp:ListItem>
                        <asp:ListItem Value="3">Catedratico</asp:ListItem>
                        <asp:ListItem Value="4">Estudiante</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="width: 145px">
                    <asp:Button ID="btnAgregarUsuario" runat="server"  Text="Agregar" OnClick="btnAgregarUsuario_Click" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        
    </p>
    <br />
    ELIMINAR SALON<br />
    <asp:DropDownList ID="DropDownListEliminar" runat="server" DataSourceID="SqlDataSource2" DataTextField="nick" DataValueField="idUsuario">
    </asp:DropDownList>
    <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
    <br />
    <br />
    MODIFICAR SALON<br />
    <table class="nav-justified">
        <tr>
            <td style="width: 153px; height: 22px">
                <asp:DropDownList ID="DropDownListModificar" runat="server" DataSourceID="SqlDataSource2" DataTextField="nick" DataValueField="idUsuario">
                </asp:DropDownList>
            </td>
            <td style="height: 22px; width: 128px">Nombre</td>
            <td style="height: 22px">
                <asp:TextBox ID="txtNombreM" runat="server" Width="259px"></asp:TextBox>
                <asp:TextBox ID="txtIdUsuarioM" runat="server" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 153px; height: 26px;">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            </td>
            <td style="width: 128px; height: 26px;">Correo</td>
            <td style="height: 26px">
                <asp:TextBox ID="txtCorreoM" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
            <tr>
                <td style="height: 20px">
                    &nbsp;</td>
                <td style="height: 20px; width: 145px">Nick</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtNickM" runat="server" Width="247px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 20px">
                    &nbsp;</td>
                <td style="height: 20px; width: 145px">Contraseña</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtContraseñaM" runat="server" Width="247px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 20px; width: 145px">Rol</td>
                <td style="height: 20px">
                    &nbsp;</td>
                <td style="height: 20px">
                    <asp:DropDownList ID="ddlRolM" runat="server">
                        <asp:ListItem Value="1">Administrador</asp:ListItem>
                        <asp:ListItem Value="2">Operador Del Sistema</asp:ListItem>
                        <asp:ListItem Value="3">Catedratico</asp:ListItem>
                        <asp:ListItem Value="4">Estudiante</asp:ListItem>
                    </asp:DropDownList>
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
