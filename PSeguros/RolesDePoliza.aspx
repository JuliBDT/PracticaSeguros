<%@ Page Title="Roles de Poliza" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RolesDePoliza.aspx.vb" Inherits="PSeguros.RolesDePoliza" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


   <h2>Roles</h2>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server"/>

   <asp:GridView ID="gvRoles" runat="server" AutoGenerateColumns="False"  CssClass="table table-striped table-bordered">
    <Columns>
        <asp:BoundField DataField="DescripcionDeRamo" HeaderText="Ramo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
        <asp:BoundField DataField="DescripcionDeProducto" HeaderText="Producto" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
        <asp:BoundField DataField="Poliza" HeaderText="Poliza" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
        <asp:BoundField DataField="DescripcionDeRol" HeaderText="Rol" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
        <asp:BoundField DataField="Cliente" HeaderText="Cliente" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
        <asp:BoundField DataField="FecaDeEfecto" HeaderText="Fecha de Efecto" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
    </Columns>
</asp:GridView>
    


</asp:Content>
