﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="GestionAdministrativaES.Views.Administrador.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
    <tr>
        <td style="height: 20px">
            <asp:Button ID="btnUsuarios" runat="server" Text="Usuarios" />
        </td>
        <td style="height: 20px"></td>
        <td style="height: 20px"></td>
    </tr>
    <tr>
        <td style="height: 25px">
            <asp:Button ID="btnSalones" runat="server" Text="Salones" OnClick="btnSalones_Click" />
        </td>
        <td style="height: 25px"></td>
        <td style="height: 25px"></td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnInsumos" runat="server" Text="Insumos" />
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>