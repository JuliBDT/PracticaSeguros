<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PolizasActuales.aspx.vb" Inherits="PSeguros.PolizasActuales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div>
    <h2>Pólizas Activas</h2>
    <asp:GridView ID="gvPolizas" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Ramo" HeaderText="Ramo" />
            <asp:BoundField DataField="Producto" HeaderText="Producto" />
            <asp:BoundField DataField="Poliza" HeaderText="Número de Póliza" />
            <asp:BoundField DataField="ClienteTitular" HeaderText="Cliente Titular" />
            <asp:BoundField DataField="Domicilio" HeaderText="Domicilio" />
            <asp:BoundField DataField="SumaAsegurada" HeaderText="Suma Asegurada" />
            <asp:BoundField DataField="FechaDeVigencia" HeaderText="Fecha de Vigencia" DataFormatString="{0:dd/MM/yyyy}" />
        </Columns>
    </asp:GridView>
</div>

</asp:Content>
