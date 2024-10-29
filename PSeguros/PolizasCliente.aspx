<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PolizasCliente.aspx.vb" Inherits="PSeguros.PolizasCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Pólizas del Cliente</h2>
    <asp:GridView ID="gvPolizas" runat="server" AutoGenerateColumns="False" EmptyDataText="No se encontraron pólizas para este cliente.">
        <Columns>
            <asp:BoundField DataField="Ramo" HeaderText="Ramo" />
            <asp:BoundField DataField="Producto" HeaderText="Producto" />
            <asp:BoundField DataField="Poliza" HeaderText="Número de Póliza" />
            <asp:BoundField DataField="FechaDeVigencia" HeaderText="Fecha de Vigencia" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="EstadoNulldate" HeaderText="Estado" />
        </Columns>
    </asp:GridView>
</asp:Content>
