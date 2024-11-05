<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RolesDePoliza.aspx.vb" Inherits="PSeguros.RolesDePoliza" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


   <h2>Roles</h2>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="table table-striped" />

   <asp:GridView ID="gvRoles" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="DescripcionDeRamo" HeaderText="Ramo" />
        <asp:BoundField DataField="DescripcionDeProducto" HeaderText="Producto" />
        <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
        <asp:BoundField DataField="DescripcionDeRol" HeaderText="Rol" />
        <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
        <asp:BoundField DataField="FecaDeEfecto" HeaderText="Fecha de Efecto" DataFormatString="{0:dd/MM/yyyy}" />
    </Columns>
</asp:GridView>
    


</asp:Content>
