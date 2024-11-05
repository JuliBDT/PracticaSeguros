<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PolizasActuales.aspx.vb" Inherits="PSeguros.PolizasActuales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div>
    <h2>Pólizas</h2>
    <asp:GridView ID="gvPolizas" runat="server" AutoGenerateColumns="False" OnRowCommand="gvPolizas_RowCommand">
 <Columns>
        <asp:BoundField DataField="DescripcionDeRamo" HeaderText="Ramo" />
        <asp:BoundField DataField="DescripcionDeProducto" HeaderText="Producto" />
        <asp:BoundField DataField="Poliza" HeaderText="Número de Póliza" />
        <asp:BoundField DataField="ClienteTitular" HeaderText="Cliente Titular" />
        <asp:BoundField DataField="Domicilio" HeaderText="Domicilio" />
        <asp:BoundField DataField="SumaAsegurada" HeaderText="Suma Asegurada" />
        <asp:BoundField DataField="FechaDeVigencia" HeaderText="Fecha de Vigencia" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="EstadoNulldate" HeaderText="Fecha de Baja" />
        <asp:ButtonField ButtonType="Button" Text="Roles de Póliza" CommandName="VerRoles" />
    </Columns>
    </asp:GridView>
</div>
</asp:Content>
