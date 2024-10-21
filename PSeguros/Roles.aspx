<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Roles.aspx.vb" Inherits="PSeguros.Roles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Ingreso de Roles</h2>
    <div>
        <label for="txtRamo">Ramo:</label>
        <asp:TextBox ID="txtRamo" runat="server" TextMode="Number"></asp:TextBox>
        <br />

        <label for="txtProducto">Producto:</label>
        <asp:TextBox ID="txtProducto" runat="server" TextMode="Number"></asp:TextBox>
        <br />

        <label for="txtPoliza">Póliza:</label>
        <asp:TextBox ID="txtPoliza" runat="server" TextMode="Number"></asp:TextBox>
        <br />

        <label for="txtRol">Rol:</label>
        <asp:TextBox ID="txtRol" runat="server" TextMode="Number"></asp:TextBox>
        <br />

        <label for="txtCliente">Cliente:</label>
        <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox>
        <br />

        <label for="txtFechaEfecto">Fecha de Efecto:</label>
        <asp:TextBox ID="txtFechaEfecto" runat="server" TextMode="Date"></asp:TextBox>
        <br />

    </div>

</asp:Content>
