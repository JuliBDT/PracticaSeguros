<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Clientes.aspx.vb" Inherits="PSeguros.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


        <h2>Clientes</h2>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="table table-striped" />

    <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="Cliente" HeaderText="Numero de CLiente" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:dd/MM/yyyy}" />
    </Columns>
</asp:GridView>
    


</asp:Content>
