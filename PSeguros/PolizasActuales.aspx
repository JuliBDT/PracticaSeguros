<%@ Page Title="Polizas" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PolizasActuales.aspx.vb" Inherits="PSeguros.PolizasActuales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div>
    <h2>Pólizas</h2>
    <asp:GridView ID="gvPolizas" runat="server" AutoGenerateColumns="False" OnRowCommand="gvPolizas_RowCommand" CssClass="table table-striped table-bordered">
 <Columns>
        <asp:BoundField DataField="DescripcionDeRamo" HeaderText="Ramo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
        <asp:BoundField DataField="DescripcionDeProducto" HeaderText="Producto" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
        <asp:BoundField DataField="Poliza" HeaderText="Número de Póliza" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
        <asp:BoundField DataField="ClienteTitular" HeaderText="Cliente Titular" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-start"/>
        <asp:BoundField DataField="Domicilio" HeaderText="Domicilio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-start"/>
        <asp:BoundField DataField="SumaAsegurada" HeaderText="Suma Asegurada" DataFormatString="{0:$#,##0.00}" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
        <asp:BoundField DataField="FechaDeVigencia" HeaderText="Fecha de Vigencia" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
        <asp:BoundField DataField="EstadoNulldate" HeaderText="Fecha de Baja" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
        <asp:ButtonField ButtonType="Button" Text="Roles de Póliza" CommandName="VerRoles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
    </Columns>
    </asp:GridView>
</div>

</asp:Content>
