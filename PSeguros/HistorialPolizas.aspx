<%@ Page Title="Historial de Polizas" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="HistorialPolizas.aspx.vb" Inherits="PSeguros.HistorialPolizas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Historial de Pólizas</h2>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />


    <asp:GridView ID="gvPolizas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
    <Columns>
        <asp:BoundField DataField="Poliza" HeaderText="Número de Póliza" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
        <asp:BoundField DataField="ClienteTitular" HeaderText="Cliente" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-start" />
        <asp:BoundField DataField="FechaDeEfecto" HeaderText="Fecha de Efecto" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
        <asp:BoundField DataField="FechaDeVigencia" HeaderText="Fecha de Vigencia" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
        <asp:BoundField DataField="SumaAsegurada" HeaderText="Suma Asegurada" DataFormatString="{0:$#,##0.00}" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
        <asp:BoundField DataField="Domicilio" HeaderText="Domicilio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-start" />
        <asp:BoundField DataField="Nulldate" HeaderText="Fecha de Modificacion" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" /> 
    </Columns>
</asp:GridView>

    <!--<div>
        <asp:GridView ID="gvPolizasFalso" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" GridLines="None" AllowPaging="True" PageSize="10">
        <Columns>
            <asp:BoundField DataField="RAMO" HeaderText="Ramo" />
            <asp:BoundField DataField="PRODUCTO" HeaderText="Producto" />
            <asp:BoundField DataField="POLIZA" HeaderText="Póliza" />
            <asp:BoundField DataField="CLIENTE_TITULAR" HeaderText="Cliente Titular" />
            <asp:BoundField DataField="FECHA_EFECTO" HeaderText="Fecha de Efecto" />
            <asp:BoundField DataField="FECHA_VIGENCIA" HeaderText="Fecha de Vigencia" />
        </Columns>
    </asp:GridView>
    </div>-->

</asp:Content>
