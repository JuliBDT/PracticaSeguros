<%@ Page Title="Polizas de Cliente" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PolizasCliente.aspx.vb" Inherits="PSeguros.PolizasCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Pólizas del Cliente</h2>
    <asp:GridView ID="gvPolizas" runat="server" AutoGenerateColumns="False" EmptyDataText="No se encontraron pólizas para este cliente." CssClass="table table-striped table-bordered">
        <Columns>
            <asp:BoundField DataField="DescripcionDeRamo" HeaderText="Ramo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
            <asp:BoundField DataField="DescripcionDeProducto" HeaderText="Producto" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
            <asp:BoundField DataField="Poliza" HeaderText="Número de Póliza" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
            <asp:BoundField DataField="FechaDeVigencia" HeaderText="Fecha de Vigencia" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
            <asp:BoundField DataField="EstadoNulldate" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
        </Columns>
    </asp:GridView>
</asp:Content>
