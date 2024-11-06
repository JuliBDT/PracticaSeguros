<%@ Page Title="Clientes" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Clientes.aspx.vb" Inherits="PSeguros.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Clientes</h2>
    <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" OnRowCommand="gvClientes_RowCommand"  CssClass="table table-striped table-bordered">
        <Columns>
            <asp:BoundField DataField="Cliente" HeaderText="Cliente ID" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre"  HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-start"/>
            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
            <asp:BoundField DataField="EstadoCivil" HeaderText="Estado Civil" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
            <asp:ButtonField ButtonType="Button" Text="Ver Pólizas" CommandName="VerPolizas" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
        </Columns>
    </asp:GridView>
</asp:Content>
