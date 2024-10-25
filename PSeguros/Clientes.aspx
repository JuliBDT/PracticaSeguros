﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Clientes.aspx.vb" Inherits="PSeguros.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


        <h2>Roles</h2>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="table table-striped" />

    <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="Ramo" HeaderText="Ramo" />
        <asp:BoundField DataField="Producto" HeaderText="Producto" />
        <asp:BoundField DataField="Rol" HeaderText="Rol" />
        <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
        <asp:BoundField DataField="FecaDeEfecto" HeaderText="Fecha de Efecto" DataFormatString="{0:dd/MM/yyyy}" />
    </Columns>
</asp:GridView>
    


</asp:Content>
